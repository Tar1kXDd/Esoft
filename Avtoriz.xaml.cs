using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Esoft
{
    /// <summary>
    /// Логика взаимодействия для Avtoriz.xaml
    /// </summary>
    public partial class Avtoriz : Page
    {
        public Avtoriz()
        {
            InitializeComponent();
        }

        private void Bat1_Click(object sender, RoutedEventArgs e)
        {
            string login = L1.Text;
            string pasword = P1.Password;
            var Users = Manager2Entities.GetContext().User.Where(x => x.IsDeleted == false).ToList();
            bool isOK = false;
            foreach (var item in Users)
            {
                if (login==item.Login&&pasword==item.Password)
                {
                    MainWindow.MainWinFrame.Content = new Pages.TaskPage(item);
                    isOK = true;
                    break;
                }
            }
            if (isOK==false)
            {
                MessageBox.Show("Неверный логин или пароль");
            }
            
        }
    }
}

