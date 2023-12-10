using GreenThumb_Slutprojekt.Database;
using GreenThumb_Slutprojekt.Manager;
using GreenThumb_Slutprojekt.Models;
using System.Windows;
using System.Windows.Controls;
namespace GreenThumb_Slutprojekt
{
    /// <summary>
    /// Interaction logic for GardenWindow.xaml
    /// </summary>
    public partial class GardenWindow : Window
    {
        private UserModel user = InputManager.LoggedInUser;

        public GardenWindow()
        {
            InitializeComponent();

            using (GreenThumbDbContext context = new())
            {
                GreenThumbUow uow = new(context);

                var garden = context.Gardens.First(g => g.UserId == user.UserId);
                lblMyGarden.Content = $"My {garden.Name}";

                var gardenPlantList = uow.GardenPlantRepo.GetAll().Where(gp => gp.GardenId == garden.GardenId).ToList();

                foreach (var gp in gardenPlantList)
                {

                    PlantModel plant = context.Plants.First(p => p.PlantId == gp.PlantId);

                    ListViewItem item = new();
                    item.Tag = plant;
                    item.Content = plant.Name;

                    lstMyPlants.Items.Add(item);
                }

            }

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            PlantWindow plantWin = new();
            plantWin.Show();

            Close();
        }
    }
}
