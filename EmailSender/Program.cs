using StudentInformationSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmailSender
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm mainForm = new MainForm();
            LoginForm loginForm = new LoginForm(mainForm);
            mainForm.LoginForm = loginForm; // Добавьте эту строку
            Application.Run(loginForm);

        }
    }
}
