using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebScraper
{
    public partial class frmOptions : Form
    {
        private Settings Settings;

        public frmOptions(Settings settings)
        {
            Debug.Assert(settings != null);
            Settings = settings;
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
