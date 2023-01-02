using System;
namespace NumberSystemConverter
{
    public class NumberSystem
    {
        static public string SelectConversionOption()
        {
            string rawInputValue = Console.ReadLine();
            string inputValue = rawInputValue.Trim();
            while (string.IsNullOrWhiteSpace(inputValue))
            {
                Console.Write("You did NOT input value - Please help to input a new value: ");
                inputValue = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(inputValue))
                {
                    break;
                }
            }
            string capitalizeEachFirstLetterOfWord = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(inputValue.ToLower());
            Console.WriteLine($"~~> You select {capitalizeEachFirstLetterOfWord}");
            return capitalizeEachFirstLetterOfWord;
        }

        static public string DisplayConversionOptions()
        {
            Console.WriteLine("Which conversion do you want to conduct: ");
            Console.WriteLine("- Convert from Decimal (base-10) to Binary (base-2): Press A");
            Console.WriteLine("- Convert from Decimal (base-10) to Hexadecimal (base-16): Press B");
            Console.WriteLine("- Convert from Binary (base-2) to Decimal (base-10): Press C");
            Console.WriteLine("- Convert from  Hexadecimal (base-16) to Decimal (base-10): Press D");
            Console.WriteLine("- Convert from Binary (base-2) to Hexaecimal (base-16): Press E");
            Console.WriteLine("(In case of the selected input option is NOT listed in the above - the default option will be A: Decimal (base-10) to Binary (base-2) conversion)");

            Console.Write("==> Your input: ");
            string action = NumberSystem.SelectConversionOption();

            switch (action)
            {
                case "A":
                    NumberSystem.ConvertFromDecToBin();
                    break;
                case "B":
                    NumberSystem.ConvertFromDecToHex();
                    break;
                case "C":
                    NumberSystem.ConvertFromBinToDec();
                    break;
                case "D":
                    NumberSystem.ConvertFromHexToDec();
                    break;
                case "E":
                    NumberSystem.ConvertFromBinToHex();
                    break;
                default:
                    Console.WriteLine("Your input did not match any options listed above. So we assumed A is your selection as a default ^_^");
                    NumberSystem.ConvertFromDecToBin();
                    break;
            }

            return action;
        }

        static public void ConvertFromDecToBin()
        {
            Console.WriteLine("This is ConvertDispFromDecToBin");
            Console.Write("Your decimal number: ");
            int decimalNumber = int.Parse(Console.ReadLine());

            string binaryString = NumberSystem.DecToBinAlgorithm(decimalNumber);
            Console.WriteLine($"Decimal number {decimalNumber} converted to Binary representation is: {binaryString}");
            Console.Read();
        }

        static public string DecToBinAlgorithm(int decNumber)
        {
            int BINARY_VALUE = 2;
            bool isSignedNumber = decNumber < 0;
            if (isSignedNumber)
            {
                Console.WriteLine($"{decNumber} is a negative number - Please help to input a POSITIVE INTEGER");
                NumberSystem.ConvertFromDecToBin();
            }

            // Early return in case of decimal number is either 0 or 1
            if (decNumber == 0 || decNumber == 1)
            {
                return decNumber.ToString();
            }

            // Otherwise, calculate the binary representation of absolute value of input decimal number
            int absValueOfDecNum = Math.Abs(decNumber);

            List<string> binaryElements = new List<string>();

            int dividedDecNum = absValueOfDecNum;

            while (dividedDecNum > 0)
            {
                string remainder = (dividedDecNum % BINARY_VALUE == 0) ? "0" : "1";
                binaryElements.Add(remainder);
                dividedDecNum /= BINARY_VALUE;
            }

            binaryElements.Reverse();

            // We now have the correct order of absolute value of decimal number in binary representation
            string[] binaryElementsArray = binaryElements.ToArray();

            return string.Join("", binaryElementsArray);
        }

        static public string MapDecToHexElement(int decNum)
        {
            switch (decNum)
            {
                case 10:
                    return "A";
                case 11:
                    return "B";
                case 12:
                    return "C";
                case 13:
                    return "D";
                case 14:
                    return "E";
                case 15:
                    return "F";
                default:
                    return decNum.ToString();
            }
        }

        static public void ConvertFromDecToHex()
        {
            Console.Write("Your decimal number: ");
            int decimalNumber = int.Parse(Console.ReadLine());

            string hexadecimalString = NumberSystem.DecToHexAlgorithm(decimalNumber);
            Console.WriteLine($"Decimal number {decimalNumber} converted to Hexadecimal representation is: {hexadecimalString}");
            Console.Read();
        }

        static public string DecToHexAlgorithm(int decNumber)
        {
            int HEXADECIMAL_VALUE = 16;

            bool isSignedNumber = decNumber < 0;
            if (isSignedNumber)
            {
                Console.WriteLine($"{decNumber} is a negative number - Please help to input a POSITIVE INTEGER");
                NumberSystem.ConvertFromDecToHex();
            }

            // Early return in case of decimal number is in range from 0 to 15
            if (decNumber >= 0 && decNumber <= HEXADECIMAL_VALUE - 1)
            {
                return NumberSystem.MapDecToHexElement(decNumber);
            }

            // Otherwise, calculate the hexadecimal representation of absolute value of input decimal number
            int absValueOfDecNum = Math.Abs(decNumber);

            List<string> hexElements = new List<string>();

            int dividedDecNum = absValueOfDecNum;

            while (dividedDecNum > 0)
            {
                string remainder = NumberSystem.MapDecToHexElement(dividedDecNum % HEXADECIMAL_VALUE);
                hexElements.Add(remainder);
                dividedDecNum /= HEXADECIMAL_VALUE;
            }

            hexElements.Reverse();

            // We now have the correct order of absolute value of decimal number in binary representation
            string[] hexaElementsArray = hexElements.ToArray();

            return string.Join("", hexaElementsArray);
        }

        static public double MapHexElementValueToDecimalValue(char elementValue)
        {
            switch (elementValue)
            {
                case 'A':
                    return 10;
                case 'B':
                    return 11;
                case 'C':
                    return 12;
                case 'D':
                    return 13;
                case 'E':
                    return 14;
                case 'F':
                    return 15;
                default:
                    return double.Parse(elementValue.ToString());
            }
        }

        static public void ConvertFromBinToDec()
        {
            int BINARY_VALUE = 2;
            Console.Write("Your binary number: ");
            string binaryString = Console.ReadLine();

            double decimalNumber = NumberSystem.ConvertOtherNumberSystemToDecimalSystem(binaryString, BINARY_VALUE);
            Console.WriteLine($"Binary representation of {binaryString} converted to Decimal number is: {decimalNumber}");
            Console.Read();
        }

        static public void ConvertFromHexToDec()
        {
            int HEXADECIMAL_VALUE = 16;
            Console.Write("Your hexadecimal number: ");
            string hexaString = Console.ReadLine();

            double decimalNumber = NumberSystem.ConvertOtherNumberSystemToDecimalSystem(hexaString, HEXADECIMAL_VALUE);
            Console.WriteLine($"Hexadecimal representation of {hexaString} converted to Decimal number is: {decimalNumber}");
            Console.Read();
        }

        static public double ConvertOtherNumberSystemToDecimalSystem(string rawStringValue, int numberSystemValue)
        {
            string stringValue = string.Join("", rawStringValue.Split(" "));
            char[] elements = stringValue.ToCharArray();

            int elementsLength = elements.Length;
            double sum = 0;
            for (int i = 0; i < elementsLength; i++)
            {
                sum += NumberSystem.MapHexElementValueToDecimalValue(elements[i]) * Math.Pow(numberSystemValue, elementsLength - 1 - i);
            }
            return sum;
        }

        static public string MapBinaryValueToHexaDecimalElement(string binaryString)
        {
            switch (binaryString)
            {
                case "0010": return "2";
                case "0011": return "3";
                case "0100": return "4";
                case "0101": return "5";
                case "0110": return "6";
                case "0111": return "7";
                case "1000": return "8";
                case "1001": return "9";
                case "1010": return "A";
                case "1011": return "B";
                case "1100": return "C";
                case "1101": return "D";
                case "1110": return "E";
                case "1111": return "F";
                default: return int.Parse(binaryString).ToString();
            }
        }
        static public void ConvertFromBinToHex()
        {
            Console.Write("Your binary string: ");
            string rawBinaryString = Console.ReadLine();
            string binaryString = string.Join("", rawBinaryString.Split(" "));
            int numberOfBinaryGrouping = 4;
            int binaryStringLength = binaryString.Length;
            int remainder = binaryStringLength % numberOfBinaryGrouping;
            int noOfZeroPadding = numberOfBinaryGrouping - remainder;
            int lengthAfterZeroPadding = binaryStringLength + noOfZeroPadding;
            string zeroPaddedBinaryString = binaryString.PadLeft(lengthAfterZeroPadding, '0');

            int currentIndex = 0;
            int eleIndex = 0;
            string[] binaryElements = new string[lengthAfterZeroPadding / numberOfBinaryGrouping];
            while (currentIndex < lengthAfterZeroPadding)
            {
                binaryElements[eleIndex] = zeroPaddedBinaryString.Substring(currentIndex, numberOfBinaryGrouping);

                currentIndex += numberOfBinaryGrouping;
                ++eleIndex;
            }


            string hexRepresentation = "";
            foreach (string binStringVal in binaryElements)
            {
                hexRepresentation += NumberSystem.MapBinaryValueToHexaDecimalElement(binStringVal);
            }

            Console.WriteLine($"Binary representation of {rawBinaryString} converted to Hexadecimal number is: {hexRepresentation}");
            Console.Read();
        }

        //static public string[] CalculateTwosComplementOfBinaryNumber(string[] unsignedValueElements)
        //{
        //    int elementsArrayLength = unsignedValueElements.Length;
        //    string[] signedValueElements = new string[elementsArrayLength];

        //    for(int i = 0; i < elementsArrayLength; i++)
        //    {
        //        signedValueElements[i: return unsignedValueElements[i: return= "0" ? "1" : "0";
        //    }


        //}
    }
}

