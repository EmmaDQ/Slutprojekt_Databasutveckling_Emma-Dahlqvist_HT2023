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
                var garden = context.Gardens.First(g => g.UserId == user.UserId);
                lblMyGarden.Content = $"My {garden.Name}";

                var plantList = garden.Plants.ToList();

                foreach (var plant in plantList)
                {
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
