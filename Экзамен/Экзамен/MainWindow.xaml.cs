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

namespace Экзамен
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void inSign_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            using (var db = new UsersEntities())
            {
                var login = db.Users.AsNoTracking().FirstOrDefault(u => u.numbers == inputLogin.Text && u.numbers == inputLogin.Text);
                var pass = db.Users.AsNoTracking().FirstOrDefault(u => u.password == inputPassword.Password);
            }
            if(inputLogin.Text.Length == 0)
            {
                MessageBox.Show("Вы не ввели пароль");
            }
            else
            {
                if(inputPassword.Password.Length == 0)
                {
                    MessageBox.Show("Вы неввели пароль");
                }
                else
                {
                    if(pass == null)
                    {
                        MessageBox.Show("Не верный пароль");
                    }
                    else
                    {
                        if(pass.isAdmin == true)
                        {
                            string inpCode = inputCode.Text.ToString();
                            string code = RandomCode.RC.ToString();
                            if( inpCode == code)
                            {
                                Admin ad = new Admin();
                                ad.Show();
                                Close();
                            }
                            else
                            {
                                MessageBox.Show("Не верный код");
                            }
                        }
                        else if (pass.isAdmin == false)
                        {
                            string inpCod = inputCode.Text.ToString();
                            string cod = RandomCode.RC.ToString();
                            if ( inpCod == cod)
                            {
                                NoAdmin ad = new NoAdmin();
                                ad.Show();
                                Close();
                            }
                            else
                            {
                                MessageBox.Show("Не верный код");
                            }
                        }
                    }
                }
            }
        }
    }
}
