using GreenThumb_Slutprojekt.Models;

namespace GreenThumb_Slutprojekt.Manager
{
    public class InputManager
    {

        public static UserModel LoggedInUser { get; set; }
        public InputManager()
        {

        }
        //private readonly Window currentWindow;

        /*public InputManager(Window currentWindow)
        {
            this.currentWindow = currentWindow;
        }*/

        public void UpdateWindowUi()
        {
            // Ta varje input / lista / whatever i currentWIndow och uppdaterar det!
            // FÖr detta måste vi ha ett sätt att loopa över alla xaml element i fönstret
            //https://stackoverflow.com/questions/874380/wpf-how-do-i-loop-through-the-all-controls-in-a-window

        }

        public bool IsText(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                return true;

            }

            else
            {

                return false;

            }
        }

        public string ListViewOutputFormat(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {

            }


            return text;
        }


    }
}
