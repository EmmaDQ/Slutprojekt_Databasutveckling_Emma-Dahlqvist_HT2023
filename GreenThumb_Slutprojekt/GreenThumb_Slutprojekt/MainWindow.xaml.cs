using GreenThumb_Slutprojekt.Database;
using GreenThumb_Slutprojekt.Manager;
using System.Windows;

namespace GreenThumb_Slutprojekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private InputManager input = new();
        public MainWindow()
        {
            InitializeComponent();


        }




        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            using (GreenThumbDbContext context = new())
            {

                GreenThumbUow uow = new(context);

                string userName = txtUsername.Text.Trim();
                string password = pwbPassword.Password.ToString();


                if (input.IsText(userName))
                {


                    if (input.IsText(password))
                    {
                        try
                        {
                            var ExistingUser = context.Users.First(u => u.UserName == userName);

                            if (ExistingUser.Password == password)
                            {
                                //TODO: show password

                                InputManager.LoggedInUser = ExistingUser;

                                PlantWindow plantWin = new PlantWindow();

                                plantWin.Show();

                                Close();
                            }

                            else
                            {
                                MessageBox.Show("Incorrect password, please try again!");
                                pwbPassword.Clear();
                            }

                        }

                        catch
                        {
                            MessageBox.Show($"We're sorry but there is no user named {userName}. Please try again or register to log in!", "Username not found");
                            txtUsername.Text = "";
                        }



                    }

                    else
                    {
                        MessageBox.Show("Please type your password", "Passwordbox empty");
                    }

                }

                else
                {
                    MessageBox.Show("Please type in your username!", "Usernamebox empty");
                }
            }

        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow regWin = new RegisterWindow();
            regWin.Show();
            Close();
        }
    }
}