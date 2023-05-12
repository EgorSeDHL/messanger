using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _6_практос
{
    /// <summary>
    /// Логика взаимодействия для chat_window.xaml
    /// </summary>
    public partial class chat_window : Window
    {
        private Socket server;
        public registration_window reg = new registration_window();
        public chat_window()
        {
            InitializeComponent();
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.Connect(reg.ip, 8888);
            SendMessage("/u" + reg.name);
            ReceiveMessage();
        }

        private async Task ReceiveMessage()
        {
            while (true)
            {
                byte[] bytes = new byte[1024];
                await server.ReceiveAsync(bytes, SocketFlags.None);
                string message = Encoding.UTF8.GetString(bytes);

                ListBox.Items.Add(message);
            }
        }
        private async Task SendMessage(string message)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(" USERNAME: " + reg.name + message);
            await server.SendAsync(bytes, SocketFlags.None);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Message.Text == "/disconnect")
            {
                SendMessage(reg.name + "/d");

                this.Close();
                server.Close();
                Message.Text = null;
                reg.name = "";
                reg.Show();

            }
            else
            {
                SendMessage(Message.Text);
                Message.Text = "";

            }
        }

        private void exit_btn_Click(object sender, RoutedEventArgs e)
        {
            SendMessage(reg.name + "/d");
            this.Close();
            server.Close();
            Message.Text = null;
            reg.name = "";
            reg.Show();

        }
    }
}
