using System.Windows.Forms;
using BakeryManagementSystem.Properties;
using Shared.Logger;

namespace BakeryManagementSystem.Loggers
{
    public class WarningMessageBox : ILogger
    {
        public void NewLogHandled(Log log)
        {
            MessageBox.Show(
                log.Message,
                Resources.WarningMessageBox_NewLogHandled_Warning,
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1
            );
        }
    }
}
