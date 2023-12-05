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


            /*using (GreenThumbDbContext context = new())
            {
                GreenThumbRepository<PlantModel> repo1 = new(context);

                var plants = repo1.GetAll();

                GreenThumbRepository<InstructionModel> repo2 = new(context);

                var instructions = repo2.GetAll();
            }*/
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PlantWindow plant = new PlantWindow();
            plant.Show();

            Close();
        }
    }
}