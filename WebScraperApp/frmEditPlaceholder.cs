using SoftCircuits.WebScraper;
using System;
using System.Windows.Forms;

namespace WebScraper
{
    public partial class frmEditPlaceholder : Form
    {
        public Placeholder Placeholder { get; set; }

        public frmEditPlaceholder(Placeholder placeholder = null)
        {
            InitializeComponent();
            Placeholder = placeholder;
        }

        private void frmEditPlaceholder_Load(object sender, EventArgs e)
        {
            if (Placeholder != null)
            {
                Text = "Edit URL Placeholder";
                txtPlaceholder.Text = Placeholder.Name;
                txtReplacementItems.Text = string.Join(",", Placeholder.Values);
            }
            else
            {
                Text = "Add URL Placeholder";
            }
            OnTextChanged(sender, e);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string name = txtPlaceholder.Text.Trim();
            var values = txtReplacementItems.Text.Trim().Split(',');
            Placeholder = new Placeholder(name, values);
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
