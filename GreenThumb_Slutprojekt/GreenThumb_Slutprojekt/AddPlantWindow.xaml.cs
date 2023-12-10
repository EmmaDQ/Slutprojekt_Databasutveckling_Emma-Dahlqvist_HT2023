using GreenThumb_Slutprojekt.Database;
using GreenThumb_Slutprojekt.Manager;
using GreenThumb_Slutprojekt.Models;
using System.Windows;
using System.Windows.Controls;

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

            UpdateUI();

        }

        public AddPlantWindow()
        {
            InitializeComponent();

            UpdateUI();
        }

        private void UpdateUI()
        {
            txtInstructionTitle.Text = "";
            txtNewInstruction.Text = "";

            lstInstructions.Items.Clear();

            foreach (InstructionModel model in instructions)
            {
                ListViewItem item = new();
                item.Tag = model;
                item.Content = model.Name;

                lstInstructions.Items.Add(item);
            }


        }

        private void btnSaveInstructions_Click(object sender, RoutedEventArgs e)
        {
            string title = txtInstructionTitle.Text.Trim();
            string instruction = txtNewInstruction.Text.Trim();

            if (inputManager.IsText(title))
            {
                title = char.ToUpper(title[0]) + title.Substring(1);

                if (inputManager.IsText(instruction))
                {
                    if (instruction.Length > 15)
                    {

                        instructions.Add(new InstructionModel() { Name = title, CareDescription = instruction });

                        UpdateUI();
                    }
                    else
                    {
                        MessageBox.Show("Please give advice on how to care for the new plant!", "Instruction to short");
                    }
                }

                else
                {
                    MessageBox.Show("Please fill inte the instructions to care for the plant!", "No instructions found");
                }
            }

            else
            {
                MessageBox.Show("Please fill in the title of the instruction, it can be something like -Watering- or -Overwintering-.", "No title");
            }



        }

        private void btnSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            string name = txtNamePlant.Text.Trim();
            name = char.ToUpper(name[0]) + name.Substring(1);
            bool plantExist = false;

            if (inputManager.IsText(name))
            {

                if (instructions.Count() >= 2)
                {
                    using (GreenThumbDbContext context = new())
                    {
                        GreenThumbUow uow = new(context);

                        PlantModel newPlant = new() { Name = name, Instructions = instructions };

                        foreach (var p in context.Plants)
                        {

                            if (name == p.Name)
                            {
                                plantExist = true;

                            }

                        }

                        if (plantExist)
                        {
                            MessageBox.Show($"We already have a {name}! Please register a new plant.", "Plant exist");
                        }

                        else
                        {
                            uow.PlantRepo.Add(newPlant);

                            uow.SaveChanges();

                            PlantWindow plantWin = new();
                            plantWin.Show();

                            Close();
                        }





                    }
                }

                else
                    MessageBox.Show($"You need to write at least 2 instructions on how to care for the {name}");



            }

            else
            {
                MessageBox.Show("Please write the name of the plant that you would like to add!", "Plants have names");
            }



        }
    }
}
