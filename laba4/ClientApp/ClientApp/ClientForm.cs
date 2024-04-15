using System;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace ClientApp
{
    public partial class ClientForm : Form
    {
        private const int port = 8888;
        private TcpClient client;
        private NetworkStream stream;
        private byte[] data;

        public ClientForm()
        {
            InitializeComponent();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (addressBox.Text == "" || dirBox.Text == "")
                {
                    MessageBox.Show("Все поля должны быть заполнены!");
                }
                else
                {
                    client = new TcpClient();
                    client.Connect(addressBox.Text, port);
                    stream = client.GetStream();

                    string directoryName = dirBox.Text;
                    data = Encoding.UTF8.GetBytes(directoryName);
                    stream.Write(data, 0, data.Length);

                    data = new byte[256];
                    int bytes = stream.Read(data, 0, data.Length);
                    string response = Encoding.UTF8.GetString(data, 0, bytes);
                    MessageBox.Show(response);

                    stream.Close();
                    client.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
