using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _6_практос
{
    /// <summary>
    /// Логика взаимодействия для server_window.xaml
    /// </summary>
    public partial class server_window : Window
    {
        chat_window chat = new chat_window();

        public List<string> log = new List<string>();
        public List<string> users = new List<string>();
        
        private Socket socket;
        private List<Socket> clients = new List<Socket>();
        public server_window()
        {
            InitializeComponent();
            IPEndPoint iPEnd = new IPEndPoint(IPAddress.Any, 8888);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            log_list.ItemsSource = log;
            users_list.ItemsSource = users;
            socket.Bind(iPEnd);
            socket.Listen(1000);
            listen_to_client();
        }

        public async Task listen_to_client()
        {
            while (true)
            {
                var client = await socket.AcceptAsync();
                clients.Add(client);
                recive_message(client);
            }

        }
        private async Task recive_message(Socket client)
        {

            while (true)
            {
                byte[] bytes = new byte[1024];
                await client.ReceiveAsync(bytes, SocketFlags.None);
                string message = Encoding.UTF8.GetString(bytes);
                list_box.Items.Add($"{client.RemoteEndPoint}: {message}");
                if (message.Contains("/u"))
                {

                    char[] chars = { '/', 'u' };
                    string user = message.TrimStart(chars);
                    log.Add(user + "Подключился!");
                    users.Add(user);
                }
                else if (message.Contains("/d"))
                {
                    char[] charss = { '/', 'd' };
                    string user = message.TrimStart(charss);
                    log.Add(user + "Отключился!");
                    users.Remove(user);
                }
                else
                {
                    foreach (var item in clients)
                    {
                        SendMessage(item, message);
                    }
                }
            }
        }

        private async Task SendMessage(Socket client, string msg)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(msg);
            await client.SendAsync(bytes, SocketFlags.None);
        }
        private void list_box_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        private void send_nudes_Click(object sender, RoutedEventArgs e)
        {

            foreach (var item in clients)
            {
                SendMessage(item, text_box.Text);

            }
            list_box.Items.Add(text_box.Text);
            text_box.Text = "";
        }
    }
}
 