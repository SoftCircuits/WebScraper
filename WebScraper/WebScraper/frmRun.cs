using SoftCircuits.WebScraper;
using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebScraper
{
    public partial class frmRun : Form
    {
        private FileData FileData;
        private CsvFileWriter CsvWriter;
        private Logger Logger;

        public frmRun(FileData data, CsvFileWriter csvWriter, Logger logger)
        {
            FileData = data;
            CsvWriter = csvWriter;
            Logger = logger;
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

        private async void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Scraper scraper = new Scraper();
            scraper.Url = FileData.Url;
            scraper.ContainerSelector = FileData.Container;
            scraper.ItemSelector = FileData.Item;
            scraper.NextPageSelector = FileData.NextPage;
            foreach (UrlPlaceholder placeholder in FileData.UrlPlaceholders)
            {
                var values = placeholder.ReplacementItems.Split(',').Select(s => s.Trim());
                scraper.Placeholders.Add(new Placeholder(placeholder.Placeholder, values));
            }
            foreach (Field field in FileData.Fields)
            {
                switch (field.Mode)
                {
                    case FieldSourceMode.Text:
                        scraper.Fields.Add(new TextField(field.Name, field.SelectorText));
                        break;
                    case FieldSourceMode.AttributeValue:
                        scraper.Fields.Add(new AttributeField(field.Name, field.SelectorText, field.AttributeName));
                        break;
                    case FieldSourceMode.InnerHtml:
                        scraper.Fields.Add(new InnerHtmlField(field.Name, field.SelectorText));
                        break;
                    case FieldSourceMode.OuterHtml:
                    default:
                        scraper.Fields.Add(new OuterHtmlField(field.Name, field.SelectorText));
                        break;
                }
            }
            scraper.DataSeparator = FileData.TextSeparator;
            scraper.WriteColumnHeaders = Program.Settings.WriteColumnHeaders;
            scraper.UpdateProgress += Scraper_UpdateProgress;

            Task task = scraper.RunAsync(WebScraperFile.LogPath);
            task.Wait();

            e.Result = new ScanResult
            {
                UrlsScanned = scraper.UrlsScanned,
                UrlErrors = scraper.UrlErrors,
            };

            //Scraper scraper = new Scraper();
            //scraper.WriteColumnHeaders = Program.Settings.WriteColumnHeaders;
            //scraper.OnUpdateProgress += OnUpdateProgressHandler;
            //scraper.Run(FileData, CsvWriter, Logger);
            //e.Result = new ScanResult
            //{
            //    UrlsScanned = scraper.UrlsScanned,
            //    UrlErrors = scraper.UrlErrors
            //};
        }

        private void Scraper_UpdateProgress(object sender, UpdateProgressEventArgs e)
        {
            backgroundWorker1.ReportProgress(0, e);
            if (backgroundWorker1.CancellationPending)
                e.Cancel = true;
        }

        //private void OnUpdateProgressHandler(object sender, ProgressEventArgs a)
        //{
        //    backgroundWorker1.ReportProgress(0, a);
        //    if (backgroundWorker1.CancellationPending)
        //        a.Cancel = true;
        //}

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            UpdateProgressEventArgs args = e.UserState as UpdateProgressEventArgs;
            progressBar1.Maximum = args.Maximum;
            progressBar1.Value = args.Current;
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
