using System;
using System.Data.SqlTypes;

namespace NumberSystemConverter
{
    public class LogicalOperators
    {
        static public string DisplayArithmeticOperationsOptions()
        {
            Console.WriteLine("Which Binary's Arithmetic Operations do you want to conduct: ");
            Console.WriteLine("- Binary Addition : Press A");
            Console.WriteLine("- Binary Subtraction: Press B");
            Console.WriteLine("- Binary Multiplication: Press C");
            Console.WriteLine("- Binary Division: Press D");
            Console.WriteLine("(In case of the selected input option is NOT listed in the above - the default option will be A: Binary Addition)");

            Console.Write("==> Your input: ");
            string action = NumberSystem.SelectConversionOption();

            switch (action)
            {
                case "A":
                    LogicalOperators.AddTwoBinaryNumbers();
                    break;
                case "B":
                    LogicalOperators.SubtractTwoBinaryNumbers();
                    break;
                case "C":
                    LogicalOperators.MultiplyTwoBinaryNumbers();
                    break;
                case "D":
                    NumberSystem.ConvertFromHexToDec();
                    break;
                default:
                    Console.WriteLine("Your input did not match any options listed above. So we assumed A is your selection as a default ^_^");
                    LogicalOperators.AddTwoBinaryNumbers();
                    break;
            }

            return action;
        }

        static public void AddTwoBinaryNumbers()
        {
            Console.WriteLine("This is AddTwoBinaryNumbers");

            Console.Write("Your 1st binary number (8 bits): ");
            string firstBinaryString = Console.ReadLine();

            Console.Write("Your 2nd binary number (8 bits): ");
            string secondBinaryString = Console.ReadLine();

            string result = LogicalOperators.AddTwoBinaryNumberAlgorithm(firstBinaryString, secondBinaryString);

            Console.WriteLine($"Sum of two binary numbers: {firstBinaryString} and {secondBinaryString} is {result}");

            Console.WriteLine("--------------------");
        }

        static public string AddTwoBinaryNumberAlgorithm(string firstBinaryString, string secondBinaryString, int bitLength = 8)
        {
            char[] firstBinaryDigits = firstBinaryString.PadLeft(bitLength, '0').ToCharArray();
            char[] secondBinaryDigits = secondBinaryString.PadLeft(bitLength, '0').ToCharArray();

            int[] resultElements = new int[bitLength];

            int currentCarryValue = 0;
            for (int i = bitLength - 1; i >= 0; i--)
            {
                int nextCarryValue = 0;
                int firstDigit = (int)Char.GetNumericValue(firstBinaryDigits[i]);
                int secondDigit = (int)Char.GetNumericValue(secondBinaryDigits[i]);
                int elementResult = firstDigit ^ secondDigit;

                if ((firstDigit == 1 && elementResult == 0) || elementResult == 1 && (elementResult ^ currentCarryValue) == 0)
                {
                    nextCarryValue = 1;
                }

                if (currentCarryValue == 1)
                {
                    elementResult = elementResult ^ currentCarryValue;
                }

                resultElements[i] = elementResult;
                currentCarryValue = nextCarryValue;
            }

            string sumString = "";
            foreach (int bitValue in resultElements)
            {
                sumString += bitValue;
            }

            return sumString;
        }

        static public string TwosComplementOfBinaryNumber(string inputBinaryString, int bitLength = 8)
        {
            char[] binaryDigits = inputBinaryString.PadLeft(bitLength, '0').ToCharArray();
            int binaryLength = binaryDigits.Length;

            string outputBinaryString = "";
            for (int i = 0; i < binaryLength; i++)
            {
                outputBinaryString += binaryDigits[i] == '0' ? "1" : "0";
            }

            return LogicalOperators.AddTwoBinaryNumberAlgorithm(outputBinaryString, "1", bitLength);
        }

        static public void SubtractTwoBinaryNumbers()
        {
            Console.WriteLine("This is SubtractTwoBinaryNumbers: A - B");

            Console.Write("Your 1st binary number (8 bits) as A: ");
            string firstBinaryString = Console.ReadLine();

            Console.Write("Your 2nd binary number (8 bits) as B: ");
            string secondBinaryString = Console.ReadLine();

            string result = LogicalOperators.AddTwoBinaryNumberAlgorithm(firstBinaryString, LogicalOperators.TwosComplementOfBinaryNumber(secondBinaryString));
            Console.WriteLine($"Subtraction of two signed binary numbers of {firstBinaryString} and {secondBinaryString} is {result}");
            Console.WriteLine("--------------------");
        }

        static public void MultiplyTwoBinaryNumbers()
        {
            Console.WriteLine("This is MultiplyTwoBinaryNumbers: A x B");

            Console.Write("Your 1st binary number (8 bits) as A: ");
            string firstBinaryString = Console.ReadLine();

            Console.Write("Your 2nd binary number (8 bits) as B: ");
            string secondBinaryString = Console.ReadLine();

            string result = LogicalOperators.MultiplyTwoBinaryNumberAlgorithm(firstBinaryString, secondBinaryString);

            Console.WriteLine($"Multiplication of two signed binary numbers of {firstBinaryString} and {secondBinaryString} is {result}");
        }

        static public string MultiplyTwoBinaryNumberAlgorithm(string firstBinaryString, string secondBinaryString, int bitLength = 4)
        {
            string twosComplementOfFirstBinaryNumber = LogicalOperators.TwosComplementOfBinaryNumber(firstBinaryString, bitLength);
            List<string> firstBinaryDigits = firstBinaryString.Select(element => element.ToString()).ToList();

            List<string> secondBinaryDigits = secondBinaryString.Select(element => element.ToString()).ToList();

            string secondBinaryAdditionalBit = "0";

            List<string> accumulator = new List<string>(bitLength);
            accumulator.AddRange(Enumerable.Repeat("0", bitLength));

            for (int i = 0; i < bitLength; i++)
            {
                string currentAccString = String.Join("", accumulator);

                if (secondBinaryDigits[bitLength - 1] == "1" && secondBinaryAdditionalBit == "0")
                {
                    accumulator = LogicalOperators.AddTwoBinaryNumberAlgorithm(currentAccString, twosComplementOfFirstBinaryNumber, bitLength).Select(element => element.ToString()).ToList();
                }
                else if (secondBinaryDigits[bitLength - 1] == "0" && secondBinaryAdditionalBit == "1")
                {
                    accumulator = LogicalOperators.AddTwoBinaryNumberAlgorithm(currentAccString, firstBinaryString, bitLength).Select(element => element.ToString()).ToList();
                }

                secondBinaryAdditionalBit = secondBinaryDigits[bitLength - 1];

                secondBinaryDigits.RemoveAt(bitLength - 1);
                secondBinaryDigits.Insert(0, accumulator[bitLength - 1].ToString());

                accumulator.RemoveAt(bitLength - 1);
                accumulator.Insert(0, secondBinaryAdditionalBit);
            }

            return String.Join("", accumulator.Concat(secondBinaryDigits));


        }
    }
}

