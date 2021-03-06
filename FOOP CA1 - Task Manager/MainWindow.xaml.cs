﻿using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Win32;
using Newtonsoft.Json;

namespace FOOP_CA1___Task_Manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Task> Tasks = new List<Task>();
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

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            string json = JsonConvert.SerializeObject(Tasks, Formatting.Indented);

            SaveFileDialog saveHere = new SaveFileDialog
            {
                DefaultExt = ".json"
            };
            bool? result = saveHere.ShowDialog();

            if(result == true)
            {
                string fileName = saveHere.FileName;
                using (StreamWriter sw = new StreamWriter(fileName))
                {
                    sw.Write(json);
                }
            }
        }

        private void BtnLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openThis = new OpenFileDialog();
            if(openThis.ShowDialog() == true)
            {
                string fileName = openThis.FileName;
                using (StreamReader sr = new StreamReader(fileName))
                {
                    string json = sr.ReadToEnd();
                    Tasks = JsonConvert.DeserializeObject<List<Task>>(json);
                }
            }
            ResetListBox();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddTaskWindow addTask = new AddTaskWindow();
            addTask.Owner = this;
            addTask.ShowDialog();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            EditTaskWindow editTask = new EditTaskWindow();
            editTask.Owner = this;

            string errorMessage = "Please Select a Task from the list";
            string caption = "No Selection";
            MessageBoxButton boxButton = MessageBoxButton.OK;
            MessageBoxImage boxImage = MessageBoxImage.Information;

            if (lbxCurrentTasks.SelectedItem == null)
            {
                MessageBox.Show(errorMessage, caption, boxButton, boxImage);
            }
            else
            {
                editTask.ShowDialog();
            }
        }

        private void CbxCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        public void ResetListBox()
        {
            lbxCurrentTasks.ItemsSource = null;
            lbxCurrentTasks.ItemsSource = Tasks;
        }
    }
}
