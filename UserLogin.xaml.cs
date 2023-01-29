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
using System.Windows.Shapes;

namespace login_prova
{
    /// <summary>
    /// Interaction logic for UserLogin.xaml
    /// </summary>
    public partial class UserLogin : Window
    {
        public UserLogin()
        {
            InitializeComponent();
        }

        private void BtnSubmit_OnClick(object sender, RoutedEventArgs e)
        {
            var Username = txtBoxUsername.Text;
            var Password = txtBoxPassword.Password;

            using (UserDataContext context = new UserDataContext())
            {
                bool userfoud = context.Users.Any(user => user.Name == Username && user.Password == Password);
                
                if (userfoud)
                {
                    GrantAccess();
                    Close();
                }
                else
                {
                    MessageBox.Show("User Not Found!");
                }
            }
        }

        public void GrantAccess()
        {
            MainWindow main = new MainWindow();
            main.Show();
        }
    }
}
