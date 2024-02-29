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
using System.Collections.ObjectModel;

namespace TaskManagerApp
{
    public class Task
    {
        public string Title { get; set; }
    }

    public partial class MainWindow : Window
    {
        private ObservableCollection<Task> activeTasks = new ObservableCollection<Task>();
        private ObservableCollection<Task> finishedTasks = new ObservableCollection<Task>();

        public MainWindow()
        {
            InitializeComponent();
            activeTasksListBox.ItemsSource = activeTasks;
            finishedTasksListBox.ItemsSource = finishedTasks;
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(newTaskTextBox.Text))
            {
                activeTasks.Add(new Task { Title = newTaskTextBox.Text });
                newTaskTextBox.Clear();
            }
        }

        private void MarkAsFinished_Click(object sender, RoutedEventArgs e)
        {
            var selectedTask = activeTasksListBox.SelectedItem as Task;
            if (selectedTask != null)
            {
                activeTasks.Remove(selectedTask);
                finishedTasks.Add(selectedTask);
            }
        }

        private void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            var selectedTask = activeTasksListBox.SelectedItem as Task;
            if (selectedTask != null)
            {
                activeTasks.Remove(selectedTask);
            }
            else
            {
                selectedTask = finishedTasksListBox.SelectedItem as Task;
                if (selectedTask != null)
                {
                    finishedTasks.Remove(selectedTask);
                }
            }
        }

        private void ActiveTasksListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (activeTasksListBox.SelectedItem != null)
            {
                finishedTasksListBox.UnselectAll();
            }
        }


    }

}
