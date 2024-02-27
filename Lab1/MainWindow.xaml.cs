using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace ArrayOperations
{
    public partial class MainWindow : Window
    {
        private List<double> customNumbers = new List<double>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddNumber_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txtCustomNumber.Text, out double number))
            {
                customNumbers.Add(number);
                listBoxInRange.Items.Add(number);
                txtCustomNumber.Clear();
            }
            else
            {
                MessageBox.Show("Please enter a valid number.");
            }
        }

        private void DeleteSelected_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxInRange.SelectedIndex != -1)
            {
                customNumbers.RemoveAt(listBoxInRange.SelectedIndex);
                listBoxInRange.Items.RemoveAt(listBoxInRange.SelectedIndex);
            }
            else if (listBoxOutOfRange.SelectedIndex != -1)
            {
                customNumbers.RemoveAt(listBoxOutOfRange.SelectedIndex);
                listBoxOutOfRange.Items.RemoveAt(listBoxOutOfRange.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Please select a number to delete.");
            }
        }

        private void Fill_Click(object sender, RoutedEventArgs e)
        {
            int n = customNumbers.Count;
            if (n >= 2)
            {
                for (int i = 2; i < n; i++)
                {
                    customNumbers[i] = Math.Pow(customNumbers[i - 1], 2) + 2 * customNumbers[i - 2];
                    listBoxInRange.Items[i] = customNumbers[i];
                }
            }
            else
            {
                MessageBox.Show("Please add at least two numbers before using Fill.");
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            customNumbers.Clear();
            listBoxInRange.Items.Clear();
            listBoxOutOfRange.Items.Clear();
        }

        private void Run_Click(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(txtB.Text, out double b) || !double.TryParse(txtC.Text, out double c))
            {
                MessageBox.Show("Please enter valid numbers for b and c.");
                return;
            }

            List<double> inRange = new List<double>();
            List<double> outOfRange = new List<double>();

            double sum = 0;
            int count = 0;

            foreach (double num in customNumbers)
            {
                if (num > b && num <= c)
                {
                    inRange.Add(num);
                    sum += num;
                    count++;
                }
                else
                {
                    outOfRange.Add(num);
                }
            }

            double average = count == 0 ? 0 : sum / count;

            string message = $"Average of all elements in the range ({b},{c}] = {average}\n\n";

            outOfRange.Sort((a, b) => b.CompareTo(a)); // Сортуємо у порядку спадання

            message += "Elements not in range (descending order):\n";
            foreach (double num in outOfRange)
            {
                message += num + "\n";
            }

            // Виводимо середнє значення та елементи, які не потрапили в проміжок, у модальному вікні
            MessageBox.Show(message, "Results");
        }
    }
}
