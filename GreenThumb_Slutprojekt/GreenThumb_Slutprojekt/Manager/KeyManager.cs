using System.IO;
using System.Security.Cryptography;


namespace GreenThumb_Slutprojekt.Manager
{
    internal static class KeyManager
    {

        public static string GetEncryptionKey()
        {


            if (File.Exists("C:\\Users\\Emma\\Desktop\\Slutprojekt_Databasutveckling_Emma Dahlqvist_HT2023\\Key.txt"))
            {
                return File.ReadAllText("C:\\Users\\Emma\\Desktop\\Slutprojekt_Databasutveckling_Emma Dahlqvist_HT2023\\Key.txt");
            }

            else
            {
                string key = GernerateEncryptionKey();
                File.WriteAllText("C:\\Users\\Emma\\Desktop\\Slutprojekt_Databasutveckling_Emma Dahlqvist_HT2023\\Key.txt", key);

                return key;
            }
        }
        public static string GernerateEncryptionKey()
        {
            var rng = new RNGCryptoServiceProvider();
            var byteArray = new byte[16];
            rng.GetBytes(byteArray);

            return Convert.ToBase64String(byteArray);

        }

    }
}
