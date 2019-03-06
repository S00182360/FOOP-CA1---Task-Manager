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

namespace FOOP_CA1___Task_Manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Task> Tasks = new List<Task>();
        //enum Categories { Work, Home, Personal };
        //Categories ThisCat;
        string[] Categories = { "All", "Home", "Work", "Personal" };
        string[] SortBy = { "Default", "Due Date", "Priority" };
        public MainWindow()
        {
            InitializeComponent();
            Tasks = TaskInit.GetTasks();
            cbxCategories.ItemsSource = Categories;
            cbxCategories.SelectedIndex = 0;
            cbxLabels.ItemsSource = SortBy;
            cbxLabels.SelectedIndex = 0;
            lbxCurrentTasks.ItemsSource = Tasks;
        }


    }
}
