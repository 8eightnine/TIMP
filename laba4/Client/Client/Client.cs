using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.IO;

namespace Client
{
    internal class Client
    {
        //адрес и порт сервера, к которому будем подключаться
        static int port = 8005; // порт сервера
        //static string address = "127.0.0.1"; // адрес сервера

        static void MakeConnection(int port, string address)
        {
            try
            {
                IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(address), port);

                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                // подключаемся к удаленному хосту
                socket.Connect(ipPoint);

                DriveInfo[] drives = DriveInfo.GetDrives();


            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
