using System;
using System.Windows.Forms;

namespace WebScraper
{
    public partial class frmEditPlaceholder : Form
    {
        public UrlPlaceholder Placeholder { get; set; }

        public frmEditPlaceholder(UrlPlaceholder placeholder = null)
        {
            InitializeComponent();
            Placeholder = placeholder;
        }

        private void frmEditPlaceholder_Load(object sender, EventArgs e)
        {
            if (Placeholder != null)
            {
                Text = "Edit URL Placeholder";
                txtPlaceholder.Text = Placeholder.Placeholder;
                txtReplacementItems.Text = Placeholder.ReplacementItems;
            }
            else
            {
                Text = "Add URL Placeholder";
            }
            OnTextChanged(sender, e);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Placeholder = new UrlPlaceholder
            {
                Placeholder = txtPlaceholder.Text.Trim(),
                ReplacementItems = txtReplacementItems.Text.Trim()
            };
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OnTextChanged(object sender, EventArgs e)
        {
            btnOk.Enabled = !string.IsNullOrWhiteSpace(txtPlaceholder.Text) && !string.IsNullOrWhiteSpace(txtReplacementItems.Text);
        }
    }
}
