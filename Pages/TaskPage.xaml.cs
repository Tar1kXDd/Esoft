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


namespace Esoft.Pages
{
    /// <summary>
    /// Логика взаимодействия для TaskPage.xaml
    /// </summary>
    public partial class TaskPage : Page
    {
        User MyUser = new User();
        public TaskPage(User MyUser)
        {
            InitializeComponent();
            this.MyUser = MyUser;
            var data = Manager2Entities.GetContext().Task.Where(x=>x.ExecutorID == MyUser.ID).ToList();
            DataGridTask.ItemsSource = data;
        }

        private void ClickTask(object sender, MouseButtonEventArgs e)
        {
            Task task = (e.OriginalSource as FrameworkElement).DataContext as Task;
            MainWindow.MainWinFrame.Content = new Pages.AddEditTaskPage(task, MyUser);
        }

        private void AddTask(object sender, RoutedEventArgs e)
        {
            MainWindow.MainWinFrame.Content = new Pages.AddEditTaskPage(null, MyUser);
        }
    }
}
