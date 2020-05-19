namespace WebScraper
{
    partial class frmSettings
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
            this.chkAutoLoad = new System.Windows.Forms.CheckBox();
            this.chkLogResults = new System.Windows.Forms.CheckBox();
            this.chkDeleteLogBeforeRun = new System.Windows.Forms.CheckBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkLoadResultsAfterRun = new System.Windows.Forms.CheckBox();
            this.chkWriteColumnHeaders = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chkAutoLoad
            // 
            this.chkAutoLoad.AutoSize = true;
            this.chkAutoLoad.Location = new System.Drawing.Point(34, 31);
            this.chkAutoLoad.Name = "chkAutoLoad";
            this.chkAutoLoad.Size = new System.Drawing.Size(199, 17);
            this.chkAutoLoad.TabIndex = 0;
            this.chkAutoLoad.Text = "&Automatically load last file on start up";
            this.chkAutoLoad.UseVisualStyleBackColor = true;
            // 
            // chkLogResults
            // 
            this.chkLogResults.AutoSize = true;
            this.chkLogResults.Location = new System.Drawing.Point(34, 54);
            this.chkLogResults.Name = "chkLogResults";
            this.chkLogResults.Size = new System.Drawing.Size(123, 17);
            this.chkLogResults.TabIndex = 1;
            this.chkLogResults.Text = "&Log scraping activity";
            this.chkLogResults.UseVisualStyleBackColor = true;
            // 
            // chkDeleteLogBeforeRun
            // 
            this.chkDeleteLogBeforeRun.AutoSize = true;
            this.chkDeleteLogBeforeRun.Location = new System.Drawing.Point(34, 77);
            this.chkDeleteLogBeforeRun.Name = "chkDeleteLogBeforeRun";
            this.chkDeleteLogBeforeRun.Size = new System.Drawing.Size(168, 17);
            this.chkDeleteLogBeforeRun.TabIndex = 2;
            this.chkDeleteLogBeforeRun.Text = "&Delete log file before each run";
            this.chkDeleteLogBeforeRun.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(89, 171);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(182, 171);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chkLoadResultsAfterRun
            // 
            this.chkLoadResultsAfterRun.AutoSize = true;
            this.chkLoadResultsAfterRun.Location = new System.Drawing.Point(34, 100);
            this.chkLoadResultsAfterRun.Name = "chkLoadResultsAfterRun";
            this.chkLoadResultsAfterRun.Size = new System.Drawing.Size(125, 17);
            this.chkLoadResultsAfterRun.TabIndex = 3;
            this.chkLoadResultsAfterRun.Text = "Load &results after run";
            this.chkLoadResultsAfterRun.UseVisualStyleBackColor = true;
            // 
            // chkWriteColumnHeaders
            // 
            this.chkWriteColumnHeaders.AutoSize = true;
            this.chkWriteColumnHeaders.Location = new System.Drawing.Point(34, 123);
            this.chkWriteColumnHeaders.Name = "chkWriteColumnHeaders";
            this.chkWriteColumnHeaders.Size = new System.Drawing.Size(129, 17);
            this.chkWriteColumnHeaders.TabIndex = 4;
            this.chkWriteColumnHeaders.Text = "&Write column headers";
            this.chkWriteColumnHeaders.UseVisualStyleBackColor = true;
            // 
            // frmSettings
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(346, 228);
            this.Controls.Add(this.chkWriteColumnHeaders);
            this.Controls.Add(this.chkLoadResultsAfterRun);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.chkDeleteLogBeforeRun);
            this.Controls.Add(this.chkLogResults);
            this.Controls.Add(this.chkAutoLoad);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.frmOptions_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkAutoLoad;
        private System.Windows.Forms.CheckBox chkLogResults;
        private System.Windows.Forms.CheckBox chkDeleteLogBeforeRun;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkLoadResultsAfterRun;
        private System.Windows.Forms.CheckBox chkWriteColumnHeaders;
    }
}