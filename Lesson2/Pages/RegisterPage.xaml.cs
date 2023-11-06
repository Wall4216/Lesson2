using Lesson2.DataModels;
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

namespace Lesson2.Pages
{
    /// <summary>
    /// Логика взаимодействия для RagisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            var password = PasswordBox.Password;

            if (password.Length < 8)
            {
                MessageBox.Show("Пароль должен содержать не менее 8 символов.", "Ошибка регистрации", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!password.Any(char.IsDigit) || !password.Any(char.IsUpper))
            {
                MessageBox.Show("Пароль должен содержать цифры и заглавные буквы.", "Ошибка регистрации", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            using (var context = new UserEntities())
            {
                var passwordHash = SomeHashFunction(password);
                var user = new Users
                {
                    Username = UsernameBox.Text,
                    PasswordHash = passwordHash,
                    Role = "User"
                };

                context.Users.Add(user);
                try
                {
                    context.SaveChanges();
                    MessageBox.Show("Регистрация прошла успешно!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.NavigationService.Navigate(new LoginPage());
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка при регистрации: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private string SomeHashFunction(string input)
        {
            return "hashed_" + input;
        }

        private void LoginPage_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new LoginPage());
        }
    }
}
