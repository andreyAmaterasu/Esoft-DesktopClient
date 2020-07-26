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
    /// Логика взаимодействия для EditTaskPage.xaml
    /// </summary>
    public partial class EditTaskPage : Page
    {
        public EditTaskPage(string login) {
            InitializeComponent();
            DataContext = new EditTaskPageViewModel(login);
        }
    }
}
