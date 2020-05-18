namespace WebScraper
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnPlaceholdersMoveDown = new System.Windows.Forms.Button();
            this.btnPlaceholdersMoveUp = new System.Windows.Forms.Button();
            this.btnPlaceholderDelete = new System.Windows.Forms.Button();
            this.btnPlaceholderEdit = new System.Windows.Forms.Button();
            this.btnPlaceholderAdd = new System.Windows.Forms.Button();
            this.lstPlaceholders = new WebScraper.ListBoxEx();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtNextPageSelector = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtItemSelector = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtContainerSelector = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtTextSeparator = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnFieldMoveDown = new System.Windows.Forms.Button();
            this.btnFieldMoveUp = new System.Windows.Forms.Button();
            this.btnFieldDelete = new System.Windows.Forms.Button();
            this.btnFieldEdit = new System.Windows.Forms.Button();
            this.btnFieldAdd = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lstFields = new WebScraper.ListBoxEx();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.openDataFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scraperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.viewResultsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.viewLogFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteLogFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.optionsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton9 = new System.Windows.Forms.ToolStripButton();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.tabControl1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(853, 387);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(853, 436);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.menuStrip1);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 14);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(829, 361);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnPlaceholdersMoveDown);
            this.tabPage1.Controls.Add(this.btnPlaceholdersMoveUp);
            this.tabPage1.Controls.Add(this.btnPlaceholderDelete);
            this.tabPage1.Controls.Add(this.btnPlaceholderEdit);
            this.tabPage1.Controls.Add(this.btnPlaceholderAdd);
            this.tabPage1.Controls.Add(this.lstPlaceholders);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtUrl);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(821, 335);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "URL";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnPlaceholdersMoveDown
            // 
            this.btnPlaceholdersMoveDown.Location = new System.Drawing.Point(734, 222);
            this.btnPlaceholdersMoveDown.Name = "btnPlaceholdersMoveDown";
            this.btnPlaceholdersMoveDown.Size = new System.Drawing.Size(75, 23);
            this.btnPlaceholdersMoveDown.TabIndex = 15;
            this.btnPlaceholdersMoveDown.Text = "&Move Down";
            this.btnPlaceholdersMoveDown.UseVisualStyleBackColor = true;
            this.btnPlaceholdersMoveDown.Click += new System.EventHandler(this.btnPlaceholdersMoveDown_Click);
            // 
            // btnPlaceholdersMoveUp
            // 
            this.btnPlaceholdersMoveUp.Location = new System.Drawing.Point(734, 193);
            this.btnPlaceholdersMoveUp.Name = "btnPlaceholdersMoveUp";
            this.btnPlaceholdersMoveUp.Size = new System.Drawing.Size(75, 23);
            this.btnPlaceholdersMoveUp.TabIndex = 14;
            this.btnPlaceholdersMoveUp.Text = "Move &Up";
            this.btnPlaceholdersMoveUp.UseVisualStyleBackColor = true;
            this.btnPlaceholdersMoveUp.Click += new System.EventHandler(this.btnPlaceholdersMoveUp_Click);
            // 
            // btnPlaceholderDelete
            // 
            this.btnPlaceholderDelete.Location = new System.Drawing.Point(734, 132);
            this.btnPlaceholderDelete.Name = "btnPlaceholderDelete";
            this.btnPlaceholderDelete.Size = new System.Drawing.Size(75, 23);
            this.btnPlaceholderDelete.TabIndex = 13;
            this.btnPlaceholderDelete.Text = "&Delete...";
            this.btnPlaceholderDelete.UseVisualStyleBackColor = true;
            this.btnPlaceholderDelete.Click += new System.EventHandler(this.btnPlaceholderDelete_Click);
            // 
            // btnPlaceholderEdit
            // 
            this.btnPlaceholderEdit.Location = new System.Drawing.Point(734, 103);
            this.btnPlaceholderEdit.Name = "btnPlaceholderEdit";
            this.btnPlaceholderEdit.Size = new System.Drawing.Size(75, 23);
            this.btnPlaceholderEdit.TabIndex = 12;
            this.btnPlaceholderEdit.Text = "&Edit...";
            this.btnPlaceholderEdit.UseVisualStyleBackColor = true;
            this.btnPlaceholderEdit.Click += new System.EventHandler(this.btnPlaceholderEdit_Click);
            // 
            // btnPlaceholderAdd
            // 
            this.btnPlaceholderAdd.Location = new System.Drawing.Point(734, 74);
            this.btnPlaceholderAdd.Name = "btnPlaceholderAdd";
            this.btnPlaceholderAdd.Size = new System.Drawing.Size(75, 23);
            this.btnPlaceholderAdd.TabIndex = 11;
            this.btnPlaceholderAdd.Text = "&Add...";
            this.btnPlaceholderAdd.UseVisualStyleBackColor = true;
            this.btnPlaceholderAdd.Click += new System.EventHandler(this.btnPlaceholderAdd_Click);
            // 
            // lstPlaceholders
            // 
            this.lstPlaceholders.FormattingEnabled = true;
            this.lstPlaceholders.IntegralHeight = false;
            this.lstPlaceholders.Location = new System.Drawing.Point(8, 74);
            this.lstPlaceholders.Name = "lstPlaceholders";
            this.lstPlaceholders.Size = new System.Drawing.Size(720, 251);
            this.lstPlaceholders.TabIndex = 10;
            this.lstPlaceholders.SelectedIndexChanged += new System.EventHandler(this.lstPlaceholders_SelectedIndexChanged);
            this.lstPlaceholders.DoubleClick += new System.EventHandler(this.lstPlaceholders_DoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "URL &placeholders:";
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(8, 30);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(801, 20);
            this.txtUrl.TabIndex = 8;
            this.txtUrl.TextChanged += new System.EventHandler(this.DataChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "&URL (include {page} placeholder to enable paging):";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtNextPageSelector);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.txtItemSelector);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.txtContainerSelector);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(821, 335);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Selectors";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtNextPageSelector
            // 
            this.txtNextPageSelector.Location = new System.Drawing.Point(8, 136);
            this.txtNextPageSelector.Name = "txtNextPageSelector";
            this.txtNextPageSelector.Size = new System.Drawing.Size(801, 20);
            this.txtNextPageSelector.TabIndex = 5;
            this.txtNextPageSelector.TextChanged += new System.EventHandler(this.DataChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "&Next page selector:";
            // 
            // txtItemSelector
            // 
            this.txtItemSelector.Location = new System.Drawing.Point(8, 86);
            this.txtItemSelector.Name = "txtItemSelector";
            this.txtItemSelector.Size = new System.Drawing.Size(801, 20);
            this.txtItemSelector.TabIndex = 3;
            this.txtItemSelector.TextChanged += new System.EventHandler(this.DataChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "&Item selector:";
            // 
            // txtContainerSelector
            // 
            this.txtContainerSelector.Location = new System.Drawing.Point(8, 37);
            this.txtContainerSelector.Name = "txtContainerSelector";
            this.txtContainerSelector.Size = new System.Drawing.Size(801, 20);
            this.txtContainerSelector.TabIndex = 1;
            this.txtContainerSelector.TextChanged += new System.EventHandler(this.DataChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "&Container selector:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txtTextSeparator);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.btnFieldMoveDown);
            this.tabPage3.Controls.Add(this.btnFieldMoveUp);
            this.tabPage3.Controls.Add(this.btnFieldDelete);
            this.tabPage3.Controls.Add(this.btnFieldEdit);
            this.tabPage3.Controls.Add(this.btnFieldAdd);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.lstFields);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(821, 335);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Fields";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txtTextSeparator
            // 
            this.txtTextSeparator.Location = new System.Drawing.Point(261, 306);
            this.txtTextSeparator.Name = "txtTextSeparator";
            this.txtTextSeparator.Size = new System.Drawing.Size(33, 20);
            this.txtTextSeparator.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 309);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(245, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "&Separator inserted between multiple field elements:";
            // 
            // btnFieldMoveDown
            // 
            this.btnFieldMoveDown.Location = new System.Drawing.Point(734, 174);
            this.btnFieldMoveDown.Name = "btnFieldMoveDown";
            this.btnFieldMoveDown.Size = new System.Drawing.Size(75, 23);
            this.btnFieldMoveDown.TabIndex = 6;
            this.btnFieldMoveDown.Text = "&Move Down";
            this.btnFieldMoveDown.UseVisualStyleBackColor = true;
            this.btnFieldMoveDown.Click += new System.EventHandler(this.btnFieldMoveDown_Click);
            // 
            // btnFieldMoveUp
            // 
            this.btnFieldMoveUp.Location = new System.Drawing.Point(734, 145);
            this.btnFieldMoveUp.Name = "btnFieldMoveUp";
            this.btnFieldMoveUp.Size = new System.Drawing.Size(75, 23);
            this.btnFieldMoveUp.TabIndex = 5;
            this.btnFieldMoveUp.Text = "Move &Up";
            this.btnFieldMoveUp.UseVisualStyleBackColor = true;
            this.btnFieldMoveUp.Click += new System.EventHandler(this.btnFieldMoveUp_Click);
            // 
            // btnFieldDelete
            // 
            this.btnFieldDelete.Location = new System.Drawing.Point(734, 87);
            this.btnFieldDelete.Name = "btnFieldDelete";
            this.btnFieldDelete.Size = new System.Drawing.Size(75, 23);
            this.btnFieldDelete.TabIndex = 4;
            this.btnFieldDelete.Text = "&Delete...";
            this.btnFieldDelete.UseVisualStyleBackColor = true;
            this.btnFieldDelete.Click += new System.EventHandler(this.btnFieldDelete_Click);
            // 
            // btnFieldEdit
            // 
            this.btnFieldEdit.Location = new System.Drawing.Point(734, 58);
            this.btnFieldEdit.Name = "btnFieldEdit";
            this.btnFieldEdit.Size = new System.Drawing.Size(75, 23);
            this.btnFieldEdit.TabIndex = 3;
            this.btnFieldEdit.Text = "&Edit...";
            this.btnFieldEdit.UseVisualStyleBackColor = true;
            this.btnFieldEdit.Click += new System.EventHandler(this.btnFieldEdit_Click);
            // 
            // btnFieldAdd
            // 
            this.btnFieldAdd.Location = new System.Drawing.Point(734, 29);
            this.btnFieldAdd.Name = "btnFieldAdd";
            this.btnFieldAdd.Size = new System.Drawing.Size(75, 23);
            this.btnFieldAdd.TabIndex = 2;
            this.btnFieldAdd.Text = "&Add...";
            this.btnFieldAdd.UseVisualStyleBackColor = true;
            this.btnFieldAdd.Click += new System.EventHandler(this.btnFieldAdd_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "&Fields:";
            // 
            // lstFields
            // 
            this.lstFields.FormattingEnabled = true;
            this.lstFields.IntegralHeight = false;
            this.lstFields.Location = new System.Drawing.Point(8, 29);
            this.lstFields.Name = "lstFields";
            this.lstFields.Size = new System.Drawing.Size(720, 271);
            this.lstFields.TabIndex = 1;
            this.lstFields.SelectedIndexChanged += new System.EventHandler(this.lstFields_SelectedIndexChanged);
            this.lstFields.DoubleClick += new System.EventHandler(this.lstFields_DoubleClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.scraperToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(853, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.openDataFolderToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = global::WebScraper.Properties.Resources.document_new;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = global::WebScraper.Properties.Resources.document_open;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.openToolStripMenuItem.Text = "&Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = global::WebScraper.Properties.Resources.save;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.saveAsToolStripMenuItem.Text = "Save &As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(205, 6);
            // 
            // openDataFolderToolStripMenuItem
            // 
            this.openDataFolderToolStripMenuItem.Image = global::WebScraper.Properties.Resources.folder_open;
            this.openDataFolderToolStripMenuItem.Name = "openDataFolderToolStripMenuItem";
            this.openDataFolderToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.openDataFolderToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.openDataFolderToolStripMenuItem.Text = "Open &Data Folder";
            this.openDataFolderToolStripMenuItem.Click += new System.EventHandler(this.openDataFolderToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(205, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // scraperToolStripMenuItem
            // 
            this.scraperToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runToolStripMenuItem1,
            this.viewResultsToolStripMenuItem1,
            this.toolStripMenuItem3,
            this.viewLogFileToolStripMenuItem,
            this.deleteLogFileToolStripMenuItem,
            this.toolStripMenuItem5,
            this.optionsToolStripMenuItem1});
            this.scraperToolStripMenuItem.Name = "scraperToolStripMenuItem";
            this.scraperToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.scraperToolStripMenuItem.Text = "&Scraper";
            // 
            // runToolStripMenuItem1
            // 
            this.runToolStripMenuItem1.Image = global::WebScraper.Properties.Resources.StatusAnnotations_Play_16xLG_color;
            this.runToolStripMenuItem1.Name = "runToolStripMenuItem1";
            this.runToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.runToolStripMenuItem1.Size = new System.Drawing.Size(158, 22);
            this.runToolStripMenuItem1.Text = "&Run";
            this.runToolStripMenuItem1.Click += new System.EventHandler(this.runToolStripMenuItem_Click);
            // 
            // viewResultsToolStripMenuItem1
            // 
            this.viewResultsToolStripMenuItem1.Image = global::WebScraper.Properties.Resources.table;
            this.viewResultsToolStripMenuItem1.Name = "viewResultsToolStripMenuItem1";
            this.viewResultsToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.viewResultsToolStripMenuItem1.Size = new System.Drawing.Size(158, 22);
            this.viewResultsToolStripMenuItem1.Text = "&View Results";
            this.viewResultsToolStripMenuItem1.Click += new System.EventHandler(this.viewResultsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(155, 6);
            // 
            // viewLogFileToolStripMenuItem
            // 
            this.viewLogFileToolStripMenuItem.Image = global::WebScraper.Properties.Resources.document_text;
            this.viewLogFileToolStripMenuItem.Name = "viewLogFileToolStripMenuItem";
            this.viewLogFileToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.viewLogFileToolStripMenuItem.Text = "View &Log File";
            this.viewLogFileToolStripMenuItem.Click += new System.EventHandler(this.viewLogFileToolStripMenuItem_Click);
            // 
            // deleteLogFileToolStripMenuItem
            // 
            this.deleteLogFileToolStripMenuItem.Image = global::WebScraper.Properties.Resources.document_text_delete;
            this.deleteLogFileToolStripMenuItem.Name = "deleteLogFileToolStripMenuItem";
            this.deleteLogFileToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.deleteLogFileToolStripMenuItem.Text = "&Delete Log File";
            this.deleteLogFileToolStripMenuItem.Click += new System.EventHandler(this.deleteLogFileToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(155, 6);
            // 
            // optionsToolStripMenuItem1
            // 
            this.optionsToolStripMenuItem1.Image = global::WebScraper.Properties.Resources.settings_options;
            this.optionsToolStripMenuItem1.Name = "optionsToolStripMenuItem1";
            this.optionsToolStripMenuItem1.Size = new System.Drawing.Size(158, 22);
            this.optionsToolStripMenuItem1.Text = "&Options...";
            this.optionsToolStripMenuItem1.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton3,
            this.toolStripButton2,
            this.toolStripButton4,
            this.toolStripSeparator2,
            this.toolStripButton5,
            this.toolStripSeparator1,
            this.toolStripButton1,
            this.toolStripButton6,
            this.toolStripSeparator3,
            this.toolStripButton7,
            this.toolStripButton8,
            this.toolStripSeparator4,
            this.toolStripButton9});
            this.toolStrip1.Location = new System.Drawing.Point(3, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(243, 25);
            this.toolStrip1.TabIndex = 1;
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::WebScraper.Properties.Resources.document_new;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.ToolTipText = "New File (Ctrl+N)";
            this.toolStripButton3.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::WebScraper.Properties.Resources.document_open;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.ToolTipText = "Open File (Ctrl+O)";
            this.toolStripButton2.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = global::WebScraper.Properties.Resources.save;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "toolStripButton4";
            this.toolStripButton4.ToolTipText = "Save  File (Ctrl+S)";
            this.toolStripButton4.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = global::WebScraper.Properties.Resources.folder_open;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton5.ToolTipText = "Open Data Folder (Ctrl+D)";
            this.toolStripButton5.Click += new System.EventHandler(this.openDataFolderToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::WebScraper.Properties.Resources.StatusAnnotations_Play_16xLG_color;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.ToolTipText = "Run (F5)";
            this.toolStripButton1.Click += new System.EventHandler(this.runToolStripMenuItem_Click);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = global::WebScraper.Properties.Resources.table;
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton6.ToolTipText = "View Results (F6)";
            this.toolStripButton6.Click += new System.EventHandler(this.viewResultsToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton7.Image = global::WebScraper.Properties.Resources.document_text;
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton7.ToolTipText = "View Log File";
            this.toolStripButton7.Click += new System.EventHandler(this.viewLogFileToolStripMenuItem_Click);
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton8.Image = global::WebScraper.Properties.Resources.document_text_delete;
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton8.ToolTipText = "Delete Log File";
            this.toolStripButton8.Click += new System.EventHandler(this.deleteLogFileToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton9
            // 
            this.toolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton9.Image = global::WebScraper.Properties.Resources.settings_options;
            this.toolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton9.Name = "toolStripButton9";
            this.toolStripButton9.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton9.ToolTipText = "Options";
            this.toolStripButton9.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 436);
            this.Controls.Add(this.toolStripContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Web Scraper";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnPlaceholderDelete;
        private System.Windows.Forms.Button btnPlaceholderEdit;
        private System.Windows.Forms.Button btnPlaceholderAdd;
        private ListBoxEx lstPlaceholders;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TextBox txtNextPageSelector;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtItemSelector;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtContainerSelector;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnFieldMoveDown;
        private System.Windows.Forms.Button btnFieldMoveUp;
        private System.Windows.Forms.Button btnFieldDelete;
        private System.Windows.Forms.Button btnFieldEdit;
        private System.Windows.Forms.Button btnFieldAdd;
        private ListBoxEx lstFields;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnPlaceholdersMoveDown;
        private System.Windows.Forms.Button btnPlaceholdersMoveUp;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem scraperToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem viewResultsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem viewLogFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteLogFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openDataFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripButton toolStripButton8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButton9;
        private System.Windows.Forms.TextBox txtTextSeparator;
        private System.Windows.Forms.Label label7;
    }
}

