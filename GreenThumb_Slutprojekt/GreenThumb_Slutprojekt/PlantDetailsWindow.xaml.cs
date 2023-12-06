using GreenThumb_Slutprojekt.Database;
using GreenThumb_Slutprojekt.Models;
using System.Windows;
using System.Windows.Controls;

namespace GreenThumb_Slutprojekt
{
    /// <summary>
    /// Interaction logic for PlantDetailsWindow.xaml
    /// </summary>
    public partial class PlantDetailsWindow : Window
    {
        private PlantModel plant;

        private List<InstructionModel> instructions { get; set; }
        internal PlantDetailsWindow(PlantModel plant)
        {
            InitializeComponent();

            this.plant = plant;

            UpdateUI();

        }

        private void UpdateUI()
        {
            lstInstructions.Items.Clear();

            txtNewInstruction.Visibility = Visibility.Hidden;
            lblNewInstruction.Visibility = Visibility.Hidden;
            btnSaveInstructions.Visibility = Visibility.Hidden;
            lblTitleInstruction.Visibility = Visibility.Hidden;
            txtInstructionTitle.Visibility = Visibility.Hidden;
            btnDeleteInstructions.Visibility = Visibility.Hidden;
            txtNamePlant.Text = plant.Name;

            txtNamePlant.IsEnabled = false;

            btnSaveChanges.Content = "Back";

            using (GreenThumbDbContext context = new())
            {
                GreenThumbUow uow = new(context);

                var listOfInstructions = context.Instructions.ToList().Where(p => p.PlantId == plant.PlantId);

                foreach (InstructionModel instruction in listOfInstructions)
                {
                    ListViewItem item = new();
                    item.Tag = instruction;
                    item.Content = $"{instruction.Name}\n{instruction.CareDescription}\n\n";

                    lstInstructions.Items.Add(item);
                }

            }


        }


        private void btnSaveInstructions_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDeleteInstructions_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSaveChanges_Click(object sender, RoutedEventArgs e)
        {

            if (btnSaveChanges.Content == "Save changes")
            {


            }

            else
            {
                PlantWindow plantWin = new();
                plantWin.Show();

                Close();
            }


        }

        private void cbMakeChanges_Unchecked(object sender, RoutedEventArgs e)
        {
            txtNewInstruction.Visibility = Visibility.Hidden;
            lblNewInstruction.Visibility = Visibility.Hidden;
            btnSaveInstructions.Visibility = Visibility.Hidden;
            lblTitleInstruction.Visibility = Visibility.Hidden;
            txtInstructionTitle.Visibility = Visibility.Hidden;
            btnDeleteInstructions.Visibility = Visibility.Hidden;
            txtNamePlant.Text = plant.Name;

            txtNamePlant.IsEnabled = false;

            btnSaveChanges.Content = "Back";
        }

        private void cbMakeChanges_Checked(object sender, RoutedEventArgs e)
        {
            txtNewInstruction.Visibility = Visibility.Visible;
            lblNewInstruction.Visibility = Visibility.Visible;
            btnSaveInstructions.Visibility = Visibility.Visible;
            lblTitleInstruction.Visibility = Visibility.Visible;
            txtInstructionTitle.Visibility = Visibility.Visible;
            btnDeleteInstructions.Visibility = Visibility.Visible;

            txtNamePlant.IsEnabled = true;


            btnSaveChanges.Content = "Save changes";



        }
    }
}
