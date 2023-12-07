using GreenThumb_Slutprojekt.Database;
using GreenThumb_Slutprojekt.Manager;
using GreenThumb_Slutprojekt.Models;
using System.Windows;
using System.Windows.Controls;

namespace GreenThumb_Slutprojekt
{
    /// <summary>
    /// Interaction logic for PlantWindow.xaml
    /// </summary>
    public partial class PlantWindow : Window
    {
        private InputManager input = new();

        private string newPlant = "";

        private UserModel? user = null;

        public static List<string> diffGardens = new List<string>()
        {
            "Beautiful garden",
            "Lovely garden",
            "Soothing garden",
            "Tasty garden",
            "Shady garden",
            "Tranquil garden"



        };

        public PlantWindow()
        {
            InitializeComponent();

            UpdateUI();

        }
        public PlantWindow(UserModel user)
        {
            InitializeComponent();

            this.user = user;

            UpdateUI();

        }

        public PlantWindow(UserModel user, string newUser)
        {
            InitializeComponent();

            this.user = user;

            UpdateUI();


            wait StartUpAsync();



        }

        private async Task StartUpAsync()
        {
            MessageBoxResult m = MessageBox.Show($"Welcome {user.UserName}!\nI see that you're missing a garden! Press the \"Yes\"-button to generate one and press \"No\" to delete your account", "New account created", MessageBoxButton.YesNo);

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
                        UserId = user.UserId

                    };

                    uow.GardenRepo.Add(newGarden);

                    uow.SaveChanges();


                }

                else
                {
                    uow.UserRepo.Delete(user.UserId);

                    uow.SaveChanges();

                    MainWindow mainWin = new();

                    mainWin.Show();
                    Close();


                }



            }
        }

        private void UpdateUI()
        {
            lstPlants.Items.Clear();
            lblErrorMessage.Visibility = Visibility.Hidden;
            txtSearch.Text = "";




            using (GreenThumbDbContext context = new())
            {

                GreenThumbUow uow = new(context);

                var plants = uow.PlantRepo.GetAll();

                foreach (var plant in plants)
                {
                    ListViewItem item = new();
                    item.Tag = plant;
                    item.Content = plant.Name;

                    lstPlants.Items.Add(item);
                }

            }




        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(newPlant))
            {
                AddPlantWindow win = new(newPlant);
                win.Show();
                Close();
            }

            else
            {
                AddPlantWindow win = new();
                win.Show();
                Close();
            }


        }

        private void btnDetails_Click(object sender, RoutedEventArgs e)
        {

            if (lstPlants.SelectedItem != null)
            {
                using (GreenThumbDbContext context = new())
                {
                    GreenThumbUow uow = new(context);

                    ListViewItem selectedItem = (ListViewItem)lstPlants.SelectedItem;
                    PlantModel selectedPlant = (PlantModel)selectedItem.Tag;

                    PlantDetailsWindow detail = new(selectedPlant);
                    detail.Show();
                    Close();

                }
            }

            else
            {
                MessageBox.Show("Please choose a plant in the list above for more details!", "No plant selected");
            }


        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            using (GreenThumbDbContext context = new())
            {
                if (lstPlants.SelectedItems != null)
                {
                    GreenThumbUow uow = new(context);

                    ListViewItem selectedItem = (ListViewItem)lstPlants.SelectedItem;
                    PlantModel selectedPlant = (PlantModel)selectedItem.Tag;

                    MessageBoxResult m = MessageBox.Show($"Are you sure you want to delete {selectedItem.Content}?", "Delete", MessageBoxButton.YesNo);


                    if (m == MessageBoxResult.Yes)
                    {
                        uow.PlantRepo.Delete(selectedPlant.PlantId);

                        uow.SaveChanges();

                        UpdateUI();
                    }

                }

                else
                {
                    MessageBox.Show("Please choose a plant to delete from the list!", "No selection");
                }


            }



        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

            using (GreenThumbDbContext context = new())
            {
                GreenThumbUow uow = new(context);

                string search = txtSearch.Text.Trim();


                //om textboxen är tom
                if (!input.IsText(search))
                {
                    UpdateUI();

                    lblErrorMessage.Visibility = Visibility.Visible;

                    MessageBox.Show("Please write the name of the plant you want to search for!", "No text found");

                }

                //om textboxen har input
                else if (input.IsText(search))
                {
                    bool isAdded = false;
                    lblErrorMessage.Visibility = Visibility.Hidden;

                    //Fixar så att första bokstaven blir stor 
                    search = char.ToUpper(search[0]) + search.Substring(1);
                    txtSearch.Text = search;

                    //var plant = uow.PlantRepo.GetAll().First(p => p.Name == search);

                    foreach (var plant in uow.PlantRepo.GetAll())
                    {
                        if (plant.Name == search)
                        {

                            lstPlants.Items.Clear();

                            ListViewItem item = new();

                            item.Tag = plant;
                            item.Content = plant.Name;

                            lstPlants.Items.Add(item);

                            isAdded = true;

                        }


                    }

                    if (!isAdded)
                    {
                        UpdateUI();


                        search = char.ToUpper(search[0]) + search.Substring(1);

                        txtSearch.Text = search.ToUpper();

                        newPlant = search;

                        lblErrorMessage.Visibility = Visibility.Visible;
                    }


                }


            }

        }
    }
}
