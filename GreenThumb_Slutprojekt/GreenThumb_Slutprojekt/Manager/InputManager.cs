using System.Windows;

namespace GreenThumb_Slutprojekt.Manager
{
    public class InputManager
    {

        public bool IsText(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                return true;

            }

            else
            {
                MessageBox.Show("Please write the name of the plant you want to search for!", "No text found");

                return false;

            }
        }
    }
}
