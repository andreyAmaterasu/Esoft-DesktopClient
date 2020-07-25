using esoft.Models;
using esoft.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace esoft.View
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page {
        public MainPage() {
            InitializeComponent();

            //TasksPage tasksPage = new TasksPage();
            //TasksPageViewModel tasksPageViewModel = new TasksPageViewModel("user3");
            //tasksPage.DataContext = tasksPageViewModel;
            //this.ContainerForPages.Content = tasksPage;

            //TasksPage.CurrentPage = this.ContainerForPages;
            //PerformersPage.CurrentPage = this.ContainerForPages;

            MainPage.CurrentPage = this.ContainerForPages;
        }

        public static Frame CurrentPage { get; set; }
    }
}
