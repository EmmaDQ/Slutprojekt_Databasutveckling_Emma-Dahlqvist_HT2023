using GreenThumb_Slutprojekt.Database;
using System.Windows;

namespace GreenThumb_Slutprojekt
{
    /// <summary>
    /// Interaction logic for PlantDetailsWindow.xaml
    /// </summary>
    public partial class PlantDetailsWindow : Window
    {
        internal PlantDetailsWindow(GreenThumbUow uow)
        {
            InitializeComponent();


        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
