using System;
using System.Windows.Forms;

namespace WebScraper
{
    public static class ExceptionExtensions
    {
        public static void ShowError(this Exception ex, string message = null)
        {
            if (string.IsNullOrWhiteSpace(message))
                message = ex.Message;
            else
                message = string.Format("{0} : {1}", message, ex.Message);

            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
