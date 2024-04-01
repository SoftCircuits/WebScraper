using SoftCircuits.SimpleLogFile;
using SoftCircuits.WebScraper;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace WebScraper
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Settings.Load();
            dataFileManager1.New();
            if (Settings.AutoLoad && !string.IsNullOrWhiteSpace(Settings.LastFile))
                dataFileManager1.Open(Settings.LastFile);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.LastFile = dataFileManager1.FileName;
            Settings.Save();
            e.Cancel = !dataFileManager1.PromptSaveIfModified();
        }

        #region File menu handlers

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataFileManager1.New();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataFileManager1.Open();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataFileManager1.Save();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataFileManager1.SaveAs();
        }

        private void openDataFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(DataFiles.GetDataFolder());
            }
            catch (Exception ex)
            {
                ex.ShowError("Unable to open data folder.");
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region Scraper menu handlers

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataFileManager1.PromptSaveIfModified())
            {
                // Get data
                SessionData data = new();
                GetControlValues(data);

                try
                {
                    runToolStripMenuItem1.Enabled = false;
                    tsbRun.Enabled = false;

                    // Get output file
                    string csvFile = DataFiles.GetDataFile(dataFileManager1.FileName, "csv");
                    File.Delete(csvFile);

                    // Create log file
                    LogFile logFile = new(DataFiles.GetApplicationDataFile("log"))
                    {
                        LogLevel = Settings.LogResults ? LogLevel.All : LogLevel.None
                    };
                    if (Settings.DeleteLogBeforeRun)
                        logFile.Delete();

                    // Open run window
                    frmRun frm = new(data, csvFile, logFile);
                    frm.ShowDialog();

                    if (Settings.LoadResultsAfterRun)
                        Process.Start(csvFile);
                }
                catch (Exception ex)
                {
                    ex.ShowError("Fatal error running scan");
                }
                finally
                {
                    runToolStripMenuItem1.Enabled = true;
                    tsbRun.Enabled = true;
                }
            }
        }

        private void viewResultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(DataFiles.GetDataFile(dataFileManager1.FileName, "csv"));
            }
            catch (Exception ex)
            {
                ex.ShowError();
            }
        }

        private void viewLogFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(DataFiles.GetApplicationDataFile("log"));
            }
            catch (Exception ex)
            {
                ex.ShowError();
            }
        }

        private void deleteLogFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                File.Delete(DataFiles.GetApplicationDataFile("log"));
            }
            catch (Exception ex)
            {
                ex.ShowError();
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSettings frm = new();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Settings.LastFile = dataFileManager1.FileName;
                Settings.Save();
            }
        }

        #endregion

        #region Placeholder button handlers

        private void btnPlaceholderAdd_Click(object sender, EventArgs e)
        {
            frmEditPlaceholder frm = new();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                lstPlaceholders.AppendItem(frm.Placeholder);
                dataFileManager1.IsModified = true;
            }
        }

        private void btnPlaceholderEdit_Click(object sender, EventArgs e)
        {
            int index = lstPlaceholders.SelectedIndex;
            if (index >= 0)
            {
                frmEditPlaceholder frm = new(lstPlaceholders.Items[index] as Placeholder);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    lstPlaceholders.ReplaceItem(frm.Placeholder);
                    dataFileManager1.IsModified = true;
                }
            }
        }

        private void btnPlaceholderDelete_Click(object sender, EventArgs e)
        {
            int index = lstPlaceholders.SelectedIndex;
            if (index >= 0)
            {
                Placeholder placeholder = lstPlaceholders.Items[index] as Placeholder;
                string msg = string.Format("Delete the URL placeholder for '{0}'. Are you sure?", placeholder.Name);
                if (MessageBox.Show(this, msg, "Delete URL Placeholder", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    lstPlaceholders.DeleteItem();
                    dataFileManager1.IsModified = true;
                }
            }
        }

        private void btnPlaceholdersMoveUp_Click(object sender, EventArgs e)
        {
            if (lstPlaceholders.MoveUp())
                dataFileManager1.IsModified = true;
        }

        private void btnPlaceholdersMoveDown_Click(object sender, EventArgs e)
        {
            if (lstPlaceholders.MoveDown())
                dataFileManager1.IsModified = true;
        }

        private void lstPlaceholders_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnablePlaceholderButtons();
        }

        private void EnablePlaceholderButtons()
        {
            btnPlaceholderEdit.Enabled = btnPlaceholderDelete.Enabled = lstPlaceholders.SelectedIndex >= 0;
            btnPlaceholdersMoveUp.Enabled = lstPlaceholders.CanMoveUp;
            btnPlaceholdersMoveDown.Enabled = lstPlaceholders.CanMoveDown;
        }

        #endregion

        #region Field button handlers

        private void btnFieldAdd_Click(object sender, EventArgs e)
        {
            frmEditField frm = new();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                lstFields.AppendItem(frm.Field);
                dataFileManager1.IsModified = true;
            }
        }

        private void btnFieldEdit_Click(object sender, EventArgs e)
        {
            int index = lstFields.SelectedIndex;
            if (index >= 0)
            {
                frmEditField frm = new(lstFields.Items[index] as Field);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    lstFields.ReplaceItem(frm.Field);
                    dataFileManager1.IsModified = true;
                }
            }
        }

        private void btnFieldDelete_Click(object sender, EventArgs e)
        {
            int index = lstFields.SelectedIndex;
            if (index >= 0)
            {
                Field field = lstFields.Items[index] as Field;
                string msg = string.Format("Delete the field information for '{0}'. Are you sure?", field.Name);
                if (MessageBox.Show(this, msg, "Delete Field", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    lstFields.DeleteItem();
                    dataFileManager1.IsModified = true;
                }
            }
        }

        private void btnFieldMoveUp_Click(object sender, EventArgs e)
        {
            if (lstFields.MoveUp())
                dataFileManager1.IsModified = true;
        }

        private void btnFieldMoveDown_Click(object sender, EventArgs e)
        {
            if (lstFields.MoveDown())
                dataFileManager1.IsModified = true;
        }

        private void lstFields_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableFieldButtons();
        }

        private void EnableFieldButtons()
        {
            btnFieldEdit.Enabled = btnFieldDelete.Enabled = lstFields.SelectedIndex >= 0;
            btnFieldMoveUp.Enabled = lstFields.CanMoveUp;
            btnFieldMoveDown.Enabled = lstFields.CanMoveDown;
        }

        #endregion

        #region File handlers

        private void dataFileManager1_NewFile(object sender, MapToGrid.Utility.DataFileEventArgs e)
        {
            ClearControlValues();
        }

        private void dataFileManager1_OpenFile(object sender, MapToGrid.Utility.DataFileEventArgs e)
        {
            SessionData data = new();
            data.Read(e.FileName);
            SetControlValues(data);
        }

        private void dataFileManager1_SaveFile(object sender, MapToGrid.Utility.DataFileEventArgs e)
        {
            SessionData data = new();
            GetControlValues(data);
            data.Write(e.FileName);
        }

        private void dataFileManager1_FileChanged(object sender, MapToGrid.Utility.DataFileEventArgs e)
        {
            Text = $"{e.FileTitle} - Web Scraper";
        }

        private void ClearControlValues()
        {
            txtUrl.Text = string.Empty;
            lstPlaceholders.Items.Clear();
            txtContainerSelector.Text = string.Empty;
            txtItemSelector.Text = string.Empty;
            txtNextPageSelector.Text = string.Empty;
            txtTextSeparator.Text = SessionData.DefaultDataSeparator;
            lstFields.Items.Clear();

            EnablePlaceholderButtons();
            EnableFieldButtons();
        }

        private void SetControlValues(SessionData data)
        {
            txtUrl.Text = data.Url;
            lstPlaceholders.Items.Clear();
            foreach (Placeholder placeholder in data.Placeholders)
                lstPlaceholders.Items.Add(placeholder);
            lstPlaceholders.InitSelection();
            txtContainerSelector.Text = data.Container;
            txtItemSelector.Text = data.Item;
            txtNextPageSelector.Text = data.NextPage;
            txtTextSeparator.Text = data.DataSeparator;
            lstFields.Items.Clear();
            foreach (Field field in data.Fields)
                lstFields.Items.Add(field);
            lstFields.InitSelection();

            EnablePlaceholderButtons();
            EnableFieldButtons();
        }

        private void GetControlValues(SessionData data)
        {
            data.Url = txtUrl.Text;
            data.Placeholders.Clear();
            foreach (Placeholder placeholder in lstPlaceholders.Items)
                data.Placeholders.Add(placeholder);
            data.Container = txtContainerSelector.Text;
            data.Item = txtItemSelector.Text;
            data.NextPage = txtNextPageSelector.Text;
            data.DataSeparator = txtTextSeparator.Text;
            data.Fields.Clear();
            foreach (Field field in lstFields.Items)
                data.Fields.Add(field);
        }

        #endregion

        private void OnTextChanged(object sender, EventArgs e)
        {
            dataFileManager1.IsModified = true;
        }

        private void lstPlaceholders_Format(object sender, ListControlConvertEventArgs e)
        {
            if (e.ListItem is Placeholder placeholder)
            {
                e.Value = string.Format("{0}={1}",
                    placeholder.Name ?? "(null)",
                    string.Join(", ", placeholder.Values));
            }
        }

        private void lstFields_Format(object sender, ListControlConvertEventArgs e)
        {
            if (e.ListItem is Field field)
            {
                string mode = FieldHelper.GetDescription(field.GetType());
                if (field is AttributeField attributeField)
                    mode += $":{attributeField.AttributeName ?? "(null)"}";
                e.Value = $"{field.Name ?? "(null)"}={field.Selector ?? "(null)"} ({mode})";
            }
        }
    }
}
