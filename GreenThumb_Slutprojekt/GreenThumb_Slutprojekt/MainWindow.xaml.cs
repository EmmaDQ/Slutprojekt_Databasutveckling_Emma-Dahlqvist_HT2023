using GreenThumb_Slutprojekt.Database;
using GreenThumb_Slutprojekt.Models;
using System.Windows;

namespace GreenThumb_Slutprojekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            using (GreenThumbDbContext context = new())
            {
                GreenThumbRepository<PlantModel> repo1 = new(context);

                var plants = repo1.GetAll();

                GreenThumbRepository<InstructionModel> repo2 = new(context);

                var instructions = repo2.GetAll();
            }
        }
    }
}