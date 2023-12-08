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

        private UserModel _user = InputManager.LoggedInUser;

        public static List<string> diffGardens = new List<string>()
        {
            "Beautiful garden",
            "Lovely garden",
            "Soothing garden",
            "Tasty garden",
            "Shady garden",
            "Tranquil garden"



        };


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

                                InputManager.LoggedInUser = newUser;
                                _user = newUser;

                                StartUp(username);



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

        private void StartUp(string username)
        {
            MessageBoxResult m = MessageBox.Show($"Welcome {_user.UserName}!\nI see that you're missing a garden! Press the \"Yes\"-button to generate one and press \"No\" to delete your account", "New account created", MessageBoxButton.YesNo);



            using (GreenThumbDbContext context = new())
            {
                GreenThumbUow uow = new(context);

                if (m == MessageBoxResult.Yes)
                {

                    Random r = new();

                    int choosingGarden = r.Next(diffGardens.Count);
                    string garden = diffGardens[choosingGarden];

                    GardenModel newGarden = new GardenModel()
                    {
                        Name = garden,
                        UserId = _user.UserId

                    };

                    uow.GardenRepo.Add(newGarden);

                    uow.SaveChanges();

                    PlantWindow plantWin = new PlantWindow(username);

                    plantWin.Show();
                    Close();


                }

                else
                {
                    uow.UserRepo.Delete(_user.UserId);

                    uow.SaveChanges();

                    InputManager.LoggedInUser = null;
                    _user = null;

                    MainWindow mainWin = new();
                    mainWin.Show();

                    Close();


                }


            }
        }

    }


}
