using EmailSender;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace StudentInformationSystem
{
    public partial class MainForm : Form
    {
        private LoginForm loginForm;

        public LoginForm LoginForm
        {
            set { loginForm = value; }
        }

        private Dictionary<string, List<Student>> studentsDictionary;

        public MainForm()
        {
            InitializeComponent();
            InitializeStudents();
            listBoxStudents.SelectedIndexChanged += CheckedListBox_SelectedIndexChanged;
            
        }


        private void InitializeStudents()
        {
            studentsDictionary = new Dictionary<string, List<Student>>();

            List<Student> studentsFor525 = new List<Student>
            {
                new Student { Name = "Vlad", Email = "vlad.pp04@gmail.com.com" },
                
            };

            List<Student> studentsFor525a = new List<Student>
            {
                new Student { Name = "Vlad2", Email = "v.v.pashchenko@student.csn.khai.edu" },
               
            };
            List<Student> studentsFor525b = new List<Student>
            {
                new Student { Name = "David", Email = "david@example.com" },
                new Student { Name = "Sarah", Email = "sarah@example.com" }
            };
            List<Student> studentsFor525v = new List<Student>
            {
                new Student { Name = "David", Email = "david@example.com" },
                new Student { Name = "Sarah", Email = "sarah@example.com" }
            };

            studentsDictionary.Add("525", studentsFor525);
            studentsDictionary.Add("525а", studentsFor525a);
            studentsDictionary.Add("525б", studentsFor525b);
            studentsDictionary.Add("525в", studentsFor525v);
          
           

            listBoxStudents.DataSource = new BindingSource(studentsDictionary, null);
            listBoxStudents.DisplayMember = "Key";
        }

        private void CheckedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxSelectedStudents.Items.Clear();

            foreach (KeyValuePair<string, List<Student>> pair in listBoxStudents.CheckedItems)
            {
                List<Student> students = pair.Value;
                foreach (Student student in students)
                {
                    listBoxSelectedStudents.Items.Add(student);
                }
            }
        }



        private void btnSend_Click(object sender, EventArgs e)
        {
            string subject = txtSubject.Text;
            string message = txtMessage.Text;

            if (string.IsNullOrEmpty(subject))
            {
                MessageBox.Show("Будь ласка, введіть тему повідомлення.");
                return;
            }

            if (string.IsNullOrEmpty(message))
            {
                MessageBox.Show("Будь ласка, введіть текст повідомлення.");
                return;
            }

            List<Student> selectedStudents = GetSelectedStudents();

            if (selectedStudents.Count == 0)
            {
                MessageBox.Show("Будь ласка, оберіть отримувачів.");
                return;
            }

            foreach (Student student in selectedStudents)
            {
                SendEmail(student.Email, subject, message);
            }

            MessageBox.Show("Повідомлення були надіслані.");
            txtSubject.Text = string.Empty;
            txtMessage.Text = string.Empty;
        }

        private List<Student> GetSelectedStudents()
        {
            List<Student> selectedStudents = new List<Student>();

            foreach (var selectedItem in listBoxStudents.CheckedItems)
            {
                var selectedKey = ((KeyValuePair<string, List<Student>>)selectedItem).Key;
                var students = studentsDictionary[selectedKey];
                selectedStudents.AddRange(students);
            }

            return selectedStudents;
        }



        private void SendEmail(string toEmail, string subject, string body)
        {
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential("vlad.pp04@gmail.com", "lqftsehddxwntgmb");

            MailMessage mailMessage = new MailMessage("vlad.pp04@gmail.com", toEmail, subject, body);
            smtpClient.Send(mailMessage);
        }

        private void btnSupport_Click(object sender, EventArgs e)
        {
            Support support = new Support();
            support.ShowDialog();
        }
    }

    class Student
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
