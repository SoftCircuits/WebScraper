using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace WebScraper
{
    public partial class frmEditField : Form
    {
        public Field Field { get; set; }

        public frmEditField(Field field = null)
        {
            InitializeComponent();
            Field = field;
        }

        private void frmEditField_Load(object sender, EventArgs e)
        {
            // Populate mode combo box
            foreach (FieldSourceMode mode in Enum.GetValues(typeof(FieldSourceMode)).Cast<FieldSourceMode>())
                cboExtractMode.Items.Add(new FieldSourceModeListItem(mode));

            if (Field != null)
            {
                Text = "Edit Field";
                SetExtractMode(Field.Mode);
                txtAttributeName.Text = Field.AttributeName;
                txtName.Text = Field.Name;
                txtSelector.Text = Field.SelectorText;
            }
            else
            {
                Text = "Add Field";
                cboExtractMode.SelectedIndex = 0;
            }
            EnableButtons();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            FieldSourceMode mode = GetSelectedMode();
            string attributeName = txtAttributeName.Text.Trim();
            if (mode == FieldSourceMode.AttributeValue && string.IsNullOrEmpty(attributeName))
            {
                MessageBox.Show("The Attribute Name is required when extracting an attribute value.");
                return;
            }
            Field = new Field(txtName.Text.Trim(), txtSelector.Text.Trim(), mode, txtAttributeName.Text);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OnTextChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }

        private void cboExtractMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }

        private void EnableButtons()
        {
            FieldSourceMode mode = GetSelectedMode();
            txtAttributeName.Enabled = (mode == FieldSourceMode.AttributeValue);
            bool disabled = string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtSelector.Text) ||
                (mode == FieldSourceMode.AttributeValue && string.IsNullOrWhiteSpace(txtAttributeName.Text));
            btnOk.Enabled = !disabled;
        }

        #region Mode helpers

        private FieldSourceMode GetSelectedMode()
        {
            return (cboExtractMode.SelectedItem as FieldSourceModeListItem)?.Mode ?? FieldSourceMode.Text;
        }

        private void SetExtractMode(FieldSourceMode mode)
        {
            foreach (var item in cboExtractMode.Items.Cast<FieldSourceModeListItem>())
            {
                if (mode == item.Mode)
                    cboExtractMode.SelectedItem = item;
            }
        }

        #endregion
    }
}
