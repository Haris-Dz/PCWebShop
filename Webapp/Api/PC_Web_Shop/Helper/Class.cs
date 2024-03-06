using SkiaSharp;
using System.Security.Cryptography;
using System.Text;

namespace PC_Web_Shop.Helper
{
    public static class Class
    {
        public static byte[] ParsirajBase64(this string base64string)
        {
            base64string = base64string.Split(',')[1];
            return System.Convert.FromBase64String(base64string);
        }
        public static string HashirajSHA256(this string pass)
        {

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(pass);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }
                return sb.ToString();
            }



        }
    }
}
