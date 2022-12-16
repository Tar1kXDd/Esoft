using Esoft.APdata;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private object text;
        public static Frame MainWinFrame;

        public MainWindow()
        {
            InitializeComponent();
            MainWinFrame = MainFrame;
            MainWinFrame.Content =new Avtoriz();
            Connekt.ConOJB = new Manager();
        }

        public MainWindow(object text)
        {
            this.text = text;
        }
    }
}
