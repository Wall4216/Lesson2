using System.Windows;
using System.Windows.Controls;
using System.Linq;
using Lesson2.DataModels;

namespace Lesson2.Pages
{
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            using (var context = new UserEntities())
            {
               

                string passwordHash = SomeHashFunction(password);

                var user = context.Users.FirstOrDefault(u => u.Username == username && u.PasswordHash == passwordHash);

                if (user != null)
                {
                    MessageBox.Show("Вы прошли", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    NavigationService.Navigate(new AddDataPage());
                }
                else
                {
                    MessageBox.Show("Пароль не подходит", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private string SomeHashFunction(string input)
        {
            return "hashed_" + input;
        }
    }
}
