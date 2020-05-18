using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace WebScraper
{
    public partial class frmMain : Form
    {
        private string FilePath = null;
        private bool Modified = false;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Program.Settings.Load();
            ClearFile();
            if (Program.Settings.AutoLoad && !string.IsNullOrWhiteSpace(Program.Settings.LastFile))
                ReadFile(Program.Settings.LastFile);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.Settings.LastFile = FilePath;
            Program.Settings.Save();
            e.Cancel = !PromptSaveChanges();
        }

        private void txtTextSeparator_TextChanged(object sender, EventArgs e)
        {
            Modified = true;
        }

        #region Menu handlers

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileNew();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileOpen();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileSave();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileSaveAs();
        }

        private void openDataFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(WebScraperFile.GetMyDocumentsPath());
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Run();
        }

        private void viewResultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(WebScraperFile.GetCsvPath(FilePath));
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
                Process.Start(WebScraperFile.LogPath);
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
                File.Delete(WebScraperFile.LogPath);
            }
            catch (Exception ex)
            {
                ex.ShowError();
            }
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOptions frm = new frmOptions(Program.Settings);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Program.Settings.LastFile = FilePath;
                Program.Settings.Save();
            }
        }

        #endregion

        #region Placeholder button handlers

        private void btnPlaceholderAdd_Click(object sender, EventArgs e)
        {
            frmEditPlaceholder frm = new frmEditPlaceholder();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                lstPlaceholders.AppendItem(frm.Placeholder);
                Modified = true;
            }
        }

        private void btnPlaceholderEdit_Click(object sender, EventArgs e)
        {
            int index = lstPlaceholders.SelectedIndex;
            if (index >= 0)
            {
                frmEditPlaceholder frm = new frmEditPlaceholder(lstPlaceholders.Items[index] as UrlPlaceholder);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    lstPlaceholders.ReplaceItem(frm.Placeholder);
                    Modified = true;
                }
            }
        }

        private void btnPlaceholderDelete_Click(object sender, EventArgs e)
        {
            int index = lstPlaceholders.SelectedIndex;
            if (index >= 0)
            {
                UrlPlaceholder placeholder = lstPlaceholders.Items[index] as UrlPlaceholder;
                string msg = string.Format("Delete the URL placeholder for '{0}'. Are you sure?", placeholder.Placeholder);
                if (MessageBox.Show(this, msg, "Delete URL Placeholder", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    lstPlaceholders.DeleteItem();
                    Modified = true;
                }
            }
        }

        private void btnPlaceholdersMoveUp_Click(object sender, EventArgs e)
        {
            if (lstPlaceholders.MoveUp())
                Modified = true;
        }

        private void btnPlaceholdersMoveDown_Click(object sender, EventArgs e)
        {
            if (lstPlaceholders.MoveDown())
                Modified = true;
        }

        private void lstPlaceholders_DoubleClick(object sender, EventArgs e)
        {
            btnPlaceholderEdit_Click(sender, e);
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
            frmEditField frm = new frmEditField();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                lstFields.AppendItem(frm.Field);
                Modified = true;
            }
        }

        private void btnFieldEdit_Click(object sender, EventArgs e)
        {
            int index = lstFields.SelectedIndex;
            if (index >= 0)
            {
                frmEditField frm = new frmEditField(lstFields.Items[index] as Field);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    lstFields.ReplaceItem(frm.Field);
                    Modified = true;
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
                    Modified = true;
                }
            }
        }

        private void btnFieldMoveUp_Click(object sender, EventArgs e)
        {
            if (lstFields.MoveUp())
                Modified = true;
        }

        private void btnFieldMoveDown_Click(object sender, EventArgs e)
        {
            if (lstFields.MoveDown())
                Modified = true;
        }

        private void lstFields_DoubleClick(object sender, EventArgs e)
        {
            btnFieldEdit_Click(sender, e);
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

        private void Run()
        {
            if (PromptSaveChanges())
            {
                // Get data
                FileData data = new FileData();
                GetControlValues(data);

                // Validate data
                FileDataValidation validation = data.Validate(out string message);
                if (validation != FileDataValidation.Valid)
                {
                    string caption;
                    MessageBoxButtons buttons;

                    if (validation == FileDataValidation.Error)
                    {
                        caption = "Data Error";
                        buttons = MessageBoxButtons.OK;
                    }
                    else
                    {
                        caption = "Data Warning";
                        buttons = MessageBoxButtons.YesNo;
                        message += "\r\nRun anyway?";
                    }
                    if (MessageBox.Show(message, caption, buttons) != DialogResult.Yes)
                        return;
                }

                try
                {
                    using (CsvFileWriter writer = new CsvFileWriter(WebScraperFile.GetCsvPath(FilePath)))
                    {
                        Logger logger = new Logger(WebScraperFile.LogPath);
                        logger.SuppressLogging = !Program.Settings.LogResults;
                        if (Program.Settings.DeleteLogBeforeRun)
                            File.Delete(WebScraperFile.LogPath);

                        // Show run window
                        frmRun frm = new frmRun(data, writer, logger);
                        frm.ShowDialog();

                        if (Program.Settings.LoadResultsAfterRun)
                            Process.Start(WebScraperFile.GetCsvPath(FilePath));
                    }
                }
                catch (Exception ex)
                {
                    ex.ShowError("Fatal error running scan");
                }
            }
        }

        #region File operations

        private void DataChanged(object sender, EventArgs e)
        {
            Modified = true;
        }

        private void FileNew()
        {
            if (PromptSaveChanges())
                ClearFile();
        }

        private void FileOpen()
        {
            if (PromptSaveChanges())
            {
                openFileDialog1.CheckPathExists = true;
                openFileDialog1.Filter = "Web Scraper Files (*.wscr)|*.wscr";
                openFileDialog1.FilterIndex = 0;
                openFileDialog1.FileName = string.Empty;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    ReadFile(openFileDialog1.FileName);
            }
        }

        private bool FileSave()
        {
            if (FilePath == null)
                return FileSaveAs();
            else
                return WriteFile(FilePath);
        }

        private bool FileSaveAs()
        {
            saveFileDialog1.OverwritePrompt = true;
            saveFileDialog1.Filter = "Web Scraper Files (*.wscr)|*.wscr";
            saveFileDialog1.FilterIndex = 0;

            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return false;

            return WriteFile(saveFileDialog1.FileName);
        }

        private bool PromptSaveChanges()
        {
            if (Modified)
            {
                var result = MessageBox.Show(this, "Data has changed. Save changes?", "Save Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                    return FileSave();
                else if (result == DialogResult.Cancel)
                    return false;
            }
            return true;
        }

        // Core file routines

        private void ClearFile()
        {
            ClearControlValues();
            FilePath = null;
            Modified = false;
            UpdateTitle();
        }

        private bool ReadFile(string path)
        {
            try
            {
                FileData data = new FileData();
                data.Read(path);
                SetControlValues(data);
                FilePath = path;
                Modified = false;
                UpdateTitle();
            }
            catch (Exception ex)
            {
                ex.ShowError("Error loading file");
                return false;
            }
            return true;
        }

        private bool WriteFile(string path)
        {
            try
            {
                FileData data = new FileData();
                GetControlValues(data);
                data.Write(path);
                FilePath = path;
                Modified = false;
                UpdateTitle();
            }
            catch (Exception ex)
            {
                ex.ShowError("Error saving file.");
                return false;
            }
            return true;
        }

        private void UpdateTitle()
        {
            Text = string.Format("{0} - Web Scraper", string.IsNullOrWhiteSpace(FilePath) ? "Untitled" : Path.GetFileName(FilePath));
        }

        #endregion

        #region Updating and retrieving control values

        private void ClearControlValues()
        {
            txtUrl.Text = string.Empty;
            lstPlaceholders.Items.Clear();
            txtContainerSelector.Text = string.Empty;
            txtItemSelector.Text = string.Empty;
            txtNextPageSelector.Text = string.Empty;
            txtTextSeparator.Text = FileData.DefaultTextSeparator;
            lstFields.Items.Clear();

            EnablePlaceholderButtons();
            EnableFieldButtons();
        }

        private void SetControlValues(FileData data)
        {
            txtUrl.Text = data.Url;
            lstPlaceholders.Items.Clear();
            foreach (UrlPlaceholder placeholder in data.UrlPlaceholders)
                lstPlaceholders.Items.Add(placeholder);
            lstPlaceholders.InitSelection();
            txtContainerSelector.Text = data.Container;
            txtItemSelector.Text = data.Item;
            txtNextPageSelector.Text = data.NextPage;
            txtTextSeparator.Text = data.TextSeparator;
            lstFields.Items.Clear();
            foreach (Field field in data.Fields)
                lstFields.Items.Add(field);
            lstFields.InitSelection();

            EnablePlaceholderButtons();
            EnableFieldButtons();
        }

        private void GetControlValues(FileData data)
        {
            data.Url = txtUrl.Text;
            data.UrlPlaceholders.Clear();
            foreach (UrlPlaceholder placeholder in lstPlaceholders.Items)
                data.UrlPlaceholders.Add(placeholder);
            data.Container = txtContainerSelector.Text;
            data.Item = txtItemSelector.Text;
            data.NextPage = txtNextPageSelector.Text;
            data.TextSeparator = txtTextSeparator.Text;
            data.Fields.Clear();
            foreach (Field field in lstFields.Items)
                data.Fields.Add(field);
        }

        #endregion

    }
}
