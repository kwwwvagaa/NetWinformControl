using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Test
{
    static class Program
    {
        static int hookID;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;           
            Application.Run(new FrmMain());
            Application.ApplicationExit += Application_ApplicationExit;
        }

        static void Application_ApplicationExit(object sender, EventArgs e)
        {
            Console.WriteLine("程序退出成功");
        }

       

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show(((Exception)e.ExceptionObject).Message);
        }

    }
}
