using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace WebScraper
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }

        private void frmOptions_Load(object sender, EventArgs e)
        {
            chkAutoLoad.Checked = Settings.AutoLoad;
            chkLogResults.Checked = Settings.LogResults;
            chkDeleteLogBeforeRun.Checked = Settings.DeleteLogBeforeRun;
            chkLoadResultsAfterRun.Checked = Settings.LoadResultsAfterRun;
            chkWriteColumnHeaders.Checked = Settings.WriteColumnHeaders;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Settings.AutoLoad = chkAutoLoad.Checked;
            Settings.LogResults = chkLogResults.Checked;
            Settings.DeleteLogBeforeRun = chkDeleteLogBeforeRun.Checked;
            Settings.LoadResultsAfterRun = chkLoadResultsAfterRun.Checked;
            Settings.WriteColumnHeaders = chkWriteColumnHeaders.Checked;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
