using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ServerApp
{
    public partial class ServerForm : Form
    {
        private TcpListener server;
        private const int port = 8888;
        private bool isRunning = true;

        public ServerForm()
        {
            InitializeComponent();
        }

        private void LogMessage(string message)
        {
            if (logBox.InvokeRequired)
            {
                logBox.Invoke(new MethodInvoker(delegate { LogMessage(message); }));
            }
            else
            {
                logBox.AppendText(message + "\n");
            }
        }

        private void StartServer()
        {
            try
            {
                server = new TcpListener(IPAddress.Any, port);
                server.Start();
                LogMessage("Сервер запущен.");

                while (isRunning)
                {
                    TcpClient client = server.AcceptTcpClient();
                    Thread clientThread = new Thread(HandleClient);
                    clientThread.Start(client);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void HandleClient(object obj)
        {
            TcpClient client = (TcpClient)obj;
            NetworkStream stream = client.GetStream();

            byte[] data = new byte[256];
            int bytes = stream.Read(data, 0, data.Length);
            string request = Encoding.UTF8.GetString(data, 0, bytes);

            // Лог подключения клиента
            LogMessage($"Клиент подключен: {((IPEndPoint)client.Client.RemoteEndPoint).Address}");

            if (File.Exists(request) && Path.GetExtension(request).ToLower() == ".txt")
            {
                // Обработка запроса на случай, если был передан текстовый файл
                string fileContent = File.ReadAllText(request);
                byte[] fileData = Encoding.UTF8.GetBytes(fileContent);
                stream.Write(fileData, 0, fileData.Length);

                // Сообщение о том, что запрос с текстовым файлом выполнен
                LogMessage($"Содержимое текстового файла отправлено клиенту. Запрос: {request}");
            }
            else if (File.Exists(request) && Path.GetExtension(request).ToLower() != ".txt")
            {
                // На случай, если переданный файл не является текстовым
                LogMessage($"Переданный файл не является текстовым. Запрос: {request}");
            }
            else if (Directory.Exists(request))
            {
                // Обработка запроса клиента
                string[] files = Directory.GetFiles(request);
                string[] directories = Directory.GetDirectories(request);

                StringBuilder responseBuilder = new StringBuilder();
                responseBuilder.AppendLine($"Файлы в каталоге '{request}':");
                foreach (string file in files)
                {
                    responseBuilder.AppendLine(Path.GetFileName(file));
                }
                responseBuilder.AppendLine($"Директории в каталоге '{request}':");
                foreach (string directory in directories)
                {
                    responseBuilder.AppendLine(Path.GetFileName(directory));
                }

                byte[] responseData = Encoding.UTF8.GetBytes(responseBuilder.ToString());
                stream.Write(responseData, 0, responseData.Length);

                // Сообщение о том, что запрос каталогом выполнен
                LogMessage($"Содержимое каталога передано клиенту. Запрос: {request}");
            }
            else
            {
                // Некорректный запрос
                LogMessage("Некорректный запрос: " + request);
            }

            stream.Close();
            client.Close();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            Thread serverThread = new Thread(StartServer);
            serverThread.Start();
        }
    }
}
