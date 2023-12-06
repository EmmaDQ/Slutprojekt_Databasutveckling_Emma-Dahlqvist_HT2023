using GreenThumb_Slutprojekt.Models;
using System.Windows;
using System.Windows.Input;

namespace GreenThumb_Slutprojekt
{
    /// <summary>
    /// Interaction logic for AddPlantWindow.xaml
    /// </summary>
    public partial class AddPlantWindow : Window
    {
        private InputManager inputManager = new();

        private List<InstructionModel> instructions { get; set; } = new List<InstructionModel>();

        string plantName;
        public AddPlantWindow(string plantName)
        {
            InitializeComponent();

            this.plantName = plantName;

            txtNamePlant.Text = plantName;

        }

        public AddPlantWindow()
        {
            InitializeComponent();


        }

        private void btnSaveInstructions_Click(object sender, RoutedEventArgs e)
        {
            string title = char.ToUpper(txtInstructionTitle.Text.Trim()[0]) + txtInstructionTitle.Text.Trim().Substring(1);
            string instruction = txtNewInstruction.Text.Trim();



            new InstructionModel() { };

        }

        private void btnSaveChanges_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
