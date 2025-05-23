using System;
using System.Windows;

namespace DatePickerExample
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            datePicker.IsDropDownOpen = false;
        }

        
        private void datePicker_SelectedDateChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (datePicker.SelectedDate.HasValue)
            {
                labelSelectedDate.Content = "Выбранная дата: " + datePicker.SelectedDate.Value.ToString("dd.MM.yyyy");
            }
            else
            {
                labelSelectedDate.Content = "Дата не выбрана";
            }
        }

        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            datePicker.IsDropDownOpen = true; 
        }
    }
}