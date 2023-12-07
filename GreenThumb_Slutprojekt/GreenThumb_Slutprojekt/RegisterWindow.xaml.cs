using GreenThumb_Slutprojekt.Database;
using GreenThumb_Slutprojekt.Manager;
using GreenThumb_Slutprojekt.Models;
using System.Windows;

namespace GreenThumb_Slutprojekt
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private InputManager InputManager = new();
        public RegisterWindow()
        {
            InitializeComponent();

            lblPasswordNoMatch.Visibility = Visibility.Hidden;
            lblUsernameTaken.Visibility = Visibility.Hidden;


        }



        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = pwbPassword.Password.ToString().Trim();
            string passwordAgain = pwbPasswordAgain.Password.ToString().Trim();

            using (GreenThumbDbContext context = new())
            {
                GreenThumbUow uow = new(context);


                if (InputManager.IsText(username))
                {

                    foreach (var user in context.Users)
                    {
                        if (user.UserName == username)
                        {
                            lblUsernameTaken.Visibility = Visibility.Visible;

                        }


                    }

                    if (InputManager.IsText(password) && password.Length >= 5)
                    {
                        if (InputManager.IsText(passwordAgain))
                        {
                            if (password == passwordAgain)
                            {
                                UpdateUI();

                                UserModel newUser = new UserModel()
                                {
                                    UserName = username,
                                    Password = passwordAgain

                                };

                                uow.UserRepo.Add(newUser);

                                uow.SaveChanges();

                                PlantWindow plantWin = new PlantWindow(newUser, username);
                                plantWin.Show();
                                Close();

                            }
                            else
                            {
                                lblPasswordNoMatch.Visibility = Visibility.Visible;


                            }
                        }
                        else
                        {
                            MessageBox.Show("Please write the same password again!", "Comfirm passwordbox is empty");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Please choose a password for your account that is more than 5 characters!", "Empty or to short password");
                    }
                }
                else
                {
                    MessageBox.Show("Please type the username you want to register!", "Empty usernamebox");
                }
            }
        }


        private void UpdateUI()
        {
            lblPasswordNoMatch.Visibility = Visibility.Hidden;
            lblUsernameTaken.Visibility = Visibility.Hidden;

        }
    }
}
