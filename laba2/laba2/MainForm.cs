using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace laba2
{
    public partial class MainForm : Form
    {
        private string _username;

        public MainForm(string username)
        {
            this._username = username;
            InitializeComponent();
            LoadUserRoles(_username);
        }

        // Метод для загрузки ролей пользователя из файла
        private void LoadUserRoles(string username)
        {
            // Словарь для хранения ролей пользователя
            Dictionary<string, string> userRoles = new Dictionary<string, string>();

            // Чтение строк из файла пользователей
            string[] lines = File.ReadAllLines("users.txt");

            // Перебор строк файла
            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(' ');
                if ("#" + username == parts[0])
                {
                    for (int j = i + 1; j < lines.Length; j++)
                    {
                        if (!lines[j].StartsWith("#"))
                        {
                            string[] roleParts = lines[j].Split(' ');

                            string name = "";
                            string status = "";
                            for (int k = 0; k < roleParts.Length; k++)
                            {
                                bool isNumeric = int.TryParse(roleParts[k], out _);
                                if (!isNumeric)
                                {
                                    name += roleParts[k] + " ";
                                }
                                else
                                {
                                    status = roleParts[k];
                                }


                            }
                            name = name.Trim();
                            status = status.Trim();
                            userRoles[name] = status;
                        }
                        else
                        {
                            break;
                        }
                    }
                    break;
                }
            }

            LoadMenu("menu.txt", menuStrip1, userRoles);
        }

        // Метод для загрузки меню из файла
        private void LoadMenu(string fileName, MenuStrip menuStrip, Dictionary<string, string> userRoles)
        {
            if (File.Exists(fileName))
            {
                string[] lines = File.ReadAllLines(fileName);
                ToolStripMenuItem parentMenuItem = null;
                foreach (string line in lines)
                {
                    string[] parts = line.Split(' ');
                    if (parts.Length >= 4)
                    {
                        int level = int.Parse(parts[0]);
                        string title = "";
                        int status = 0;
                        string methodName = "";
                        for (int i = 1; i < parts.Length; i++)
                        {
                            bool isNumeric = int.TryParse(parts[i], out _);
                            if (!isNumeric)
                            {
                                title += parts[i] + " ";
                            }
                            else
                            {
                                status = int.Parse(parts[i]);
                                methodName = parts[i + 1];
                                break;
                            }
                        }
                        title = title.Trim();
                        if (userRoles.ContainsKey(title))
                        {
                            status = Int32.Parse(userRoles[title]);
                        }

                        if (level == 0)
                        {
                            parentMenuItem = new ToolStripMenuItem(title);
                            menuStrip.Items.Add(parentMenuItem);
                            if (status == 2)
                            {
                                parentMenuItem.Visible = false;
                            }
                            if (status == 1)
                            {
                                parentMenuItem.Enabled = true;
                            }
                        }
                        else
                        {
                            ToolStripMenuItem menuItem = new ToolStripMenuItem(title, null, MenuItem_Click);
                            menuItem.Tag = methodName;

                            if (status == 2)
                            {
                                menuItem.Visible = false;
                            }
                            else if (status == 1)
                                menuItem.Enabled = false;

                            if (parentMenuItem != null)
                                parentMenuItem.DropDownItems.Add(menuItem);
                        }
                    }
                }
            }
        }

        // Метод для поиска родительского пункта меню по уровню
        private ToolStripMenuItem FindParentMenuItem(ToolStripItemCollection items, int level)
        {
            foreach (ToolStripMenuItem item in items)
            {
                if (item.Tag != null && (int)item.Tag == level)
                {
                    return item;
                }
                if (item.DropDownItems.Count > 0)
                {
                    ToolStripMenuItem foundItem = FindParentMenuItem(item.DropDownItems, level);
                    if (foundItem != null)
                        return foundItem;
                }
            }
            return null;
        }

        // Обработчик события нажатия на элемент меню
        private void MenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            string methodName = menuItem.Tag as string;
            if (!string.IsNullOrEmpty(methodName))
            {
                InvokeMethodByName(methodName);
            }
            else
            {
                MessageBox.Show("Подпункты.");
            }
        }

        // Метод для вызова метода по имени
        private void InvokeMethodByName(string methodName)
        {
            MessageBox.Show($"{methodName}");
        }
    }
}