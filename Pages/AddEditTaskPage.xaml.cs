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
    /// Логика взаимодействия для AddEditTaskPage.xaml
    /// </summary>
    public partial class AddEditTaskPage : Page
    {
        Task SelectTask = new Task();
        User MyUser = new User();
        private bool isAdd = false;
        public AddEditTaskPage(Task task,User MyUser)
        {
            InitializeComponent();
            this.MyUser = MyUser;
            if (task==null)
            {
                isAdd = true;
            }
            else
            {
                SelectTask = task;
            }
            ExecutorComboBox.ItemsSource = Manager2Entities.GetContext().User.ToList();
            ExecutorComboBox.SelectedIndex = 0;
            if (task!=null)
            {
                ExecutorComboBox.SelectedItem = MyUser;
            }
            DataContext = task;
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            SelectTask.Title = TitlTB.Text;
            SelectTask.Description = DescripTB.Text;
            SelectTask.Status =StatusTB.Text;
            SelectTask.WorkType = WorkTyTB.Text;
            if (Create1.SelectedDate==null)
            {
                MessageBox.Show("Укажите данные в поле начала работы");
                return;
            }
            else
            {
                SelectTask.CreateDateTime = Create1.SelectedDate.Value;
            }
            if (DeadlineDP.SelectedDate == null)
            {
                MessageBox.Show("Укажите завершения работы");
                return;
            }
            else
            {
                SelectTask.Deadline = DeadlineDP.SelectedDate.Value;
            }
            if (ComplitedDP.SelectedDate == null)
            {
                SelectTask.CompletedDateTime = null;
            }
            else
            {
                SelectTask.CompletedDateTime = DeadlineDP.SelectedDate.Value;
            }
            
            SelectTask.Time = int.Parse(TimeTB.Text);
            SelectTask.ExecutorID = (ExecutorComboBox.SelectedItem as User).ID;
            Saving();
        }

        private void Saving()
        {
            if (isAdd)
            {
                Manager2Entities.GetContext().Task.Add(SelectTask);
            }
            Manager2Entities.GetContext().SaveChanges();
            MainWindow.MainWinFrame.Content = new Pages.TaskPage(MyUser);
        }

        private void Bake(object sender, RoutedEventArgs e)
        {
            MainWindow.MainWinFrame.Content = new Pages.TaskPage(MyUser);
        }
    }
}
