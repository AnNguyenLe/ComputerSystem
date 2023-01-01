namespace NumberSystemConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Khoi tao chuong trinh
            Console.WriteLine("Welcome to Number System conversion program!");

            while (true)
            {
                // Hoi nguoi dung muon lam gi tiep theo
                NumberSystem.DisplayConversionOptions();
            }
            Console.WriteLine("Da thoat khoi chuong trinh - De tiep tuc su dung, ban hay khoi dong lai");
            Console.Read();
        }
    }
}