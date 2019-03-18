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
    /// <summary>
    /// Interaction logic for EditTaskWindow.xaml
    /// </summary>
    public partial class EditTaskWindow : Window
    {
        public EditTaskWindow()
        {
            InitializeComponent();
            MainWindow Main = Owner as MainWindow;
            Task editThis = new Task();
            editThis = (Task)Main.lbxCurrentTasks.SelectedItem;
            tbxEditTitle.Text = editThis.Title;
            tbxEditDescription.Text = editThis.Description;
            dpkrEditDate.DisplayDate = editThis.DueDate;
            tbxLables.Text = string.Join("," , editThis.Labels);
        }

        private void BtnEditCancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
