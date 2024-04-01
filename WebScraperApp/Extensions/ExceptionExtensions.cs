using System;
using System.Windows.Forms;

namespace WebScraper
{
    public static class ExceptionExtensions
    {
        public static void ShowError(this Exception ex, string message = null)
        {
            // Get innermost exception
            while (ex.InnerException != null)
                ex = ex.InnerException;

            if (string.IsNullOrWhiteSpace(message))
                message = ex.Message;
            else
                message = $"{message} : {ex.Message}";

            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
