using Lesson2.DataModels;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Lesson2.Pages
{
    public partial class AddDataPage : Page
    {
        public AddDataPage()
        {
            InitializeComponent();
        }

        private void AddDataButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            if (!decimal.TryParse(PriceTextBox.Text, out decimal price))
            {
                MessageBox.Show("Введите валидную цену");
                return;
            }
            if (!decimal.TryParse(CostTextBox.Text, out decimal cost))
            {
                MessageBox.Show("Введите валидную стоимость");
                return;
            }

            using (var context = new UserEntities())
            {
                var dish = new Dishes
                {
                    Name = name,
                    Price = price,
                    Cost = cost,
                };

                context.Dishes.Add(dish);
                try
                {
                    context.SaveChanges();
                    MessageBox.Show("Блюдо успешно сохранено");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Оишбка: {ex.Message}");
                }
            }
        }

        private void ViewDataButton_Click( object sender, RoutedEventArgs e )
        {
            NavigationService.Navigate(new ViewDataPage());
        }
    }
}
