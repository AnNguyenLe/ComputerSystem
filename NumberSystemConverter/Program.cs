namespace NumberSystemConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Khoi tao chuong trinh
            Console.WriteLine("Welcome to Computer System program!");

            while (true)
            {

                //NumberSystem.DisplayConversionOptions();

                LogicalOperators.DisplayArithmeticOperationsOptions();
            }
            Console.WriteLine("Da thoat khoi chuong trinh - De tiep tuc su dung, ban hay khoi dong lai");
            Console.Read();
        }
    }
}