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
    /// Логика взаимодействия для CreateTaskPage.xaml
    /// </summary>
    public partial class CreateTaskPage : Page
    {
        public CreateTaskPage() {
            InitializeComponent();
        }

        private void ResetDefaiultValue(object sender, RoutedEventArgs e) {
            TextBox field = (TextBox)sender;
            if (field.Text == "0" || field.Text == DateTime.MinValue.ToShortDateString()) {
                field.Text = "";
            }
        }
    }
}
