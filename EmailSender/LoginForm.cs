using StudentInformationSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmailSender
{
    public partial class LoginForm : Form
    {
        private MainForm mainForm;
       

        public LoginForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
           
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtLogin.Text;
            string password = txtPassword.Text;

            // Проверка введенных учетных данных
            if (IsUserValid(username, password))
            {
                MainForm mainForm = new MainForm();
                this.Hide(); // Скрыть форму LoginForm
                mainForm.FormClosed += (s, args) => this.Close(); // Закрыть форму LoginForm при закрытии MainForm
                mainForm.Show(); // Открыть форму MainForm в новом потоке


            }
            else
            {
                // Неверные учетные данные
                MessageBox.Show("Неправильні облікові дані. Будь ласка, спробуйте ще раз.", "Помилка авторизації", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            // При изменении состояния флажка показа пароля
            txtPassword.UseSystemPasswordChar = chkShowPassword.Checked;
        }

        private bool IsUserValid(string username, string password)
        {
            // Проверка введенных учетных данных (здесь может быть логика проверки в базе данных, файле конфигурации и т.д.)
            // В данном примере предполагается, что валидными являются только "admin" / "password"
            return username == "admin" && password == "password";
        }
    }
}

