using SoftCircuits.WebScraper;
using System;
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
            foreach (string description in FieldHelper.GetDescriptions())
                cboExtractMode.Items.Add(description);

            if (Field != null)
            {
                Text = "Edit Field";
                SetExtractMode(Field.GetType());
                if (Field is AttributeField attributeField)
                    txtAttributeName.Text = attributeField.AttributeName;
                txtName.Text = Field.Name;
                txtSelector.Text = Field.Selector;
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
            string name = txtName.Text.Trim();
            string selector = txtSelector.Text.Trim();
            string attributeName = txtAttributeName.Text;
            Type type = GetSelectedMode();
            Field = FieldHelper.FieldFactory(type, name, selector, attributeName);
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
            Type type = GetSelectedMode();
            txtAttributeName.Enabled = type == typeof(AttributeField);
            bool disabled = string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtSelector.Text) ||
                (type == typeof(AttributeField) && string.IsNullOrWhiteSpace(txtAttributeName.Text));
            btnOk.Enabled = !disabled;
        }

        #region Mode helpers

        private Type GetSelectedMode()
        {
            return FieldHelper.GetDescriptionType(cboExtractMode.SelectedItem as string);
        }

        private void SetExtractMode(Type type)
        {
            string description = FieldHelper.GetDescription(type);
            foreach (string item in cboExtractMode.Items)
            {
                if (item == description)
                {
                    cboExtractMode.SelectedItem = item;
                    break;
                }
            }
        }

        #endregion

    }
}
