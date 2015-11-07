using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BakeryManagementSystem.Loggers;
using Controller.Tools;
using Shared.Logger;
using LogLevel = Shared.Logger.LogLevel;

namespace BakeryManagementSystem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            #region Logger
            var loggerController = new LoggerController();
            var logManager = loggerController.Manager;
            logManager.AddNewLogger(new WarningMessageBox(), LogLevel.Warning, LogLevel.Warning);
            #endregion
            
            Application.Run(new MainWindow());
        }
    }
}
