using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace laba2
{
    public partial class AuthForm : Form
    {
        public AuthForm()
        {
            InitializeComponent();
        }

        // Обработчик нажатия кнопки "Отмена"
        private void cancelButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Обработчик нажатия кнопки "Вход"
        private void enterButton_Click(object sender, EventArgs e)
        {
            // Чтение всех строк из файла пользователей
            string[] lines = File.ReadAllLines("users.txt");
            // Создание словаря для хранения пар логин-пароль
            Dictionary<string, string> users = new Dictionary<string, string>();

            // Перебор каждой строки файла
            foreach (string line in lines)
            {
                string[] parts = line.Split(' ');
                // Проверка, является ли строка логином и паролем
                if (line.StartsWith("#"))
                {
                    // Добавление пары логин-пароль в словарь
                    users[parts[0]] = parts[1].Trim();
                }
            }

            // Проверка наличия введенного логина в словаре
            if (users.ContainsKey("#" + loginBox.Text))
            {
                // Проверка правильности введенного пароля
                if (passBox.Text == users["#" + loginBox.Text])
                {
                    MessageBox.Show("Успешно!"); // Оповещение об успешном входе
                    MainForm mainForm = new MainForm(loginBox.Text); // Создание главной формы с передачей логина
                    mainForm.Show(); // Отображение главной формы
                }
                else
                {
                    MessageBox.Show("Неправильный пароль!"); // Оповещение о неправильном пароле
                }
            }
            else
            {
                MessageBox.Show("Неправильный логин!"); // Оповещение о неправильном логине
            }
        }
    }
}