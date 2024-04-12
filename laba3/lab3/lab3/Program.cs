using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace lab3
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Позднее связывание
            //Assembly asm = Assembly.LoadFrom("laba2.dll");
            //dynamic t = asm.GetType("laba2.AuthForm");
            //dynamic AuthForm = Activator.CreateInstance(t);
            //Application.Run(AuthForm);


            // Раннее связывание
            Form AuthForm = new laba2.AuthForm();
            Application.Run(AuthForm);
        }
    }
}
