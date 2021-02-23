using SoftCircuits.SimpleLogFile;
using SoftCircuits.WebScraper;
using System;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebScraper
{
    public partial class frmRun : Form
    {
        private readonly SessionData SessionData;
        private readonly string CsvFile;
        private readonly LogFile LogFile;

        public frmRun(SessionData data, string csvFile, LogFile logFile)
        {
            SessionData = data;
            CsvFile = csvFile;
            LogFile = logFile;
            InitializeComponent();
        }

        private void frmRun_Load(object sender, EventArgs e)
        {
            // Start background worker
            btnCancel.Tag = null;
            backgroundWorker1.RunWorkerAsync();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (btnCancel.Tag == null)
            {
                if (backgroundWorker1.IsBusy)
                    backgroundWorker1.CancelAsync();
                SetCloseMode(false);
            }
            else
            {
                Close();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            // Configure web scraper object
            Scraper scraper = new Scraper(SessionData.Url, SessionData.Container, SessionData.Item)
            {
                NextPageSelector = SessionData.NextPage,
                DataSeparator = SessionData.DataSeparator,
                WriteColumnHeaders = Settings.WriteColumnHeaders
            };
            scraper.Placeholders.AddRange(SessionData.Placeholders);
            scraper.Fields.AddRange(SessionData.Fields);
            scraper.UpdateProgress += Scraper_UpdateProgress;

            Task task = scraper.RunAsync(CsvFile);
            task.Wait();

            e.Result = new ScanResult
            {
                UrlsScanned = scraper.UrlsScanned,
                UrlErrors = scraper.UrlErrors,
            };
        }

        private void Scraper_UpdateProgress(object sender, UpdateProgressEventArgs e)
        {
            LogFile.LogInfo(e.Status);
            backgroundWorker1.ReportProgress(0, e);
            if (backgroundWorker1.CancellationPending)
                e.Cancel = true;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            UpdateProgressEventArgs args = e.UserState as UpdateProgressEventArgs;
            progressBar1.Value = args.Percent;
            lblStatus.Text = args.Status;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string status = (btnCancel.Tag == null) ? "Scan Completed" : "Scan Aborted";
            if (e.Result is ScanResult result)
                status = string.Format("{0} : {1} page(s) processed : {2} error(s)", status, result.UrlsScanned, result.UrlErrors);
            lblStatus.Text = status;
            progressBar1.Value = progressBar1.Maximum;
            progressBar1.Style = ProgressBarStyle.Continuous;
            SetCloseMode();
        }

        private void SetCloseMode(bool enabled = true)
        {
            btnCancel.Text = "Close";
            btnCancel.Enabled = enabled;
            btnCancel.Tag = 1;
        }
    }

    public class ScanResult
    {
        public int UrlsScanned { get; set; }
        public int UrlErrors { get; set; }
    }
}
