using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoadKeyApp
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            //用來除錯

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)//用來除錯
        {
            Console.WriteLine(e.ExceptionObject.ToString());
            MessageBox.Show(e.ExceptionObject.ToString());
        }
    }
}
