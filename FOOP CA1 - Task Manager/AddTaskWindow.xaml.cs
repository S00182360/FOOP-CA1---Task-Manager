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
using System.Windows.Shapes;

namespace FOOP_CA1___Task_Manager
{
    public partial class AddTaskWindow : Window
    {
        
        public AddTaskWindow()
        {
            InitializeComponent();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            MainWindow Main = Owner as MainWindow;
            //Dialogbox config
            string errorMessage = "Please enter detials again";
            string caption = "Missing data";
            MessageBoxButton boxButton = MessageBoxButton.OK;
            MessageBoxImage boxImage = MessageBoxImage.Exclamation;

            //New object
            Task taskToAdd;
            string title = tbxTitle.Text;
            string descrip = tbxDescription.Text;
            DateTime date = dpkrDate.DisplayDate;
            string labels = tbxLables.Text;

            if (title == "" || descrip == "" || date == null || labels == "")
                MessageBox.Show(errorMessage, caption, boxButton, boxImage);
            else
            {
                taskToAdd = new Task(title, descrip, date, labels);
                Main.Tasks.Add(taskToAdd);
            }
            Main.ResetListBox();
            this.Close();
        }
    }
}
