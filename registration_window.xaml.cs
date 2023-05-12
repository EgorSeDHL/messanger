using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
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
    /// Логика взаимодействия для registration_window.xaml
    /// </summary>
    public partial class registration_window : Window
    {
        public registration_window()
        {
            InitializeComponent();
            
        }


        public string ip;
        public string name;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ip = ipBox.Text;
            name = loginBX.Text;
                IPAddress address;
                bool isIPAddres = false;
            try
            {
                // Определяем является ли строка ip-адресом
                isIPAddres = IPAddress.TryParse(ip, out address);
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Неверный формат Ip-адреса");

            }
            if (!loginBX.Text.Contains(" ") && loginBX.Text != "")
            {
                

                if (isIPAddres)
                {
                    chat_window chat_Window = new chat_window();
                    chat_Window.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверный IP - адрес");
                }

            }
            else
            {
                MessageBox.Show("Неверный логин!");
            }
        }
    }
}
