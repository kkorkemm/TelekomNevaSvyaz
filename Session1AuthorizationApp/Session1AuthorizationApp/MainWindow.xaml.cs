using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Session1AuthorizationApp
{
    using Base;
    using System.Threading;

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Employees Employee = new Employees();
        private string CurrentCode = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Нажатие на кнопку Новый код
        /// </summary>
        private void BtnCode_Click(object sender, RoutedEventArgs e)
        {
            GetCode();
        }

        /// <summary>
        /// Нажатие на кнопку Отмена
        /// </summary>
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            TextLogin.Text = "";
            TextPass.Password = "";
            TextCode.Text = "";

            TextPass.IsEnabled = false;
            TextCode.IsEnabled = false;
            BtnLogin.IsEnabled = false;
        }

        /// <summary>
        /// Нажатие на кнопку Вход
        /// </summary>
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentCode != TextCode.Text)
            {
                MessageBox.Show("Неверный код", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            AppData.CurrentEmployee = Employee;

            MessageBox.Show($"{Employee.FullName}, Ваша роль: {Employee.EmployeeRoles.RoleName}", "Добро пожаловать!", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// Нажатие Enter при вводе номер телефона
        /// </summary>
        private void TextLogin_KeyUp(object sender, KeyEventArgs e)
        {
            // проверка на то, что был нажат Enter
            if (e.Key == Key.Enter)
            {
                string number = TextLogin.Text;
                var user = AppData.GetContext().Employees.FirstOrDefault(p => p.TelNumber == number);

                if (user == null)
                {
                    MessageBox.Show("Сотрудника с таким номером нет в базе данных", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else
                {
                    Employee = user;
                    TextPass.IsEnabled = true;
                    TextPass.Focus();
                }
            }
        }

        /// <summary>
        /// Нажатие Enter при вводе пароля
        /// </summary>
        private void TextPass_KeyUp(object sender, KeyEventArgs e)
        {
            // проверка на то, что был нажат Enter
            if (e.Key == Key.Enter)
            {
                string password = TextPass.Password;

                if (Employee.Password == password)
                {
                    GetCode();
                    TextCode.IsEnabled = true;
                    TextCode.Focus();
                    BtnLogin.IsEnabled = true;
                }
                else
                {
                    MessageBox.Show("Неверный пароль", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
        }

        /// <summary>
        /// Генерация случайного кода
        /// </summary>
        private string GenerateRandomCode()
        {
            string code = "";

            string alphabet = "1234567890qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM!@#$%^&*()-_=+";

            Random random = new Random();

            for (int i = 0; i < 8; i++)
            {
                int index = random.Next(0, alphabet.Length - 1);
                code += alphabet[index];
            }

            return code;   
        }

        private void GetCode()
        {
            string code = GenerateRandomCode();

            CurrentCode = code;

            MessageBox.Show(code, "Внимание! Ваш код!", MessageBoxButton.OK, MessageBoxImage.Warning);

            /// дальше будет работа с таймером (код действителен только 10 секунд)
        }
    }
}
