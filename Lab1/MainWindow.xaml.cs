using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace ArrayOperations
{
    public partial class MainWindow : Window
    {
        private List<long> customNumbers = new List<long>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddNumber_Click(object sender, RoutedEventArgs e)
        {
            if (long.TryParse(txtCustomNumber.Text, out long number))
            {
                customNumbers.Add(number);
                listBoxNumbers.Items.Add(number);
                txtCustomNumber.Clear();
            }
            else
            {
                MessageBox.Show("Please enter a valid number.");
            }
        }

        private void DeleteSelected_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxNumbers.SelectedIndex != -1)
            {
                customNumbers.RemoveAt(listBoxNumbers.SelectedIndex);
                listBoxNumbers.Items.RemoveAt(listBoxNumbers.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Please select a number to delete.");
            }
        }

        private void Fill_Click(object sender, RoutedEventArgs e)
        {
            FillArray();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            customNumbers.Clear();
            listBoxNumbers.Items.Clear();
        }

        private void Run_Click(object sender, RoutedEventArgs e)
        {
            if (!long.TryParse(txtB.Text, out long b) || !long.TryParse(txtC.Text, out long c))
            {
                MessageBox.Show("Please enter valid numbers for b and c.");
                return;
            }

            List<long> inRange = new List<long>();
            List<long> outOfRange = new List<long>();

            foreach (long num in customNumbers)
            {
                if (num > b && num <= c)
                {
                    inRange.Add(num);
                }
                else
                {
                    outOfRange.Add(num);
                }
            }

            long sum = inRange.Sum();
            int count = inRange.Count;
            double average = count == 0 ? 0 : (double)sum / count;

            outOfRange.Sort((a, b) => b.CompareTo(a)); // Сортуємо у порядку спадання

            string message = $"Average of all elements in the range ({b},{c}] = {average:F5}\n\n";

            message += "Elements not in range:\n";
            foreach (long num in outOfRange)
            {
                message += num + "\n";
            }

            MessageBox.Show(message, "Results");
        }

        private void FillArray()
        {
            customNumbers.Clear(); // Очищаємо масив перед заповненням
            customNumbers.Add(-4); // Перше число
            customNumbers.Add(3); // Друге число

            int n = customNumbers.Count;
            while (n < 20) // Заповнюємо масив до досягнення максимального розміру 
            {
                long nextNumber = customNumbers[n - 1] * customNumbers[n - 1] + 2 * customNumbers[n - 2];
                customNumbers.Add(nextNumber);
                n++;
            }

            // Відображення чисел у ListBox
            listBoxNumbers.Items.Clear();
            foreach (long num in customNumbers)
            {
                listBoxNumbers.Items.Add(num);
            }
        }
    }
}
