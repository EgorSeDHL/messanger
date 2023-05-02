
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _6_практос
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

        }
        private void createBtn_Click(object sender, RoutedEventArgs e)
        {
            server_window server = new server_window();
            server.Show();
            this.Close();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            registration_window registration_Window = new registration_window();
            registration_Window.Show();
            this.Close();
        }
    }
}
