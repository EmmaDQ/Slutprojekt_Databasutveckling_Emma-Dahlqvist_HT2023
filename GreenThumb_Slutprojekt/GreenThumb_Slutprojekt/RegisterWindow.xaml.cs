using System.Windows;

namespace GreenThumb_Slutprojekt
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();

            lblPasswordNoMatch.Visibility = Visibility.Hidden;
            lblUsernameTaken.Visibility = Visibility.Hidden;


        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
