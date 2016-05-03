using System.IO;

namespace Encoding
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(@"C:\testfiles\boot.txt");
            StreamWriter sw = new StreamWriter(@"C:\testfiles\boot-utf7.txt", false, System.Text.Encoding.UTF7);

            sw.WriteLine(sr.ReadToEnd());
            sw.Close();
            sr.Close();
        }
    }
}
