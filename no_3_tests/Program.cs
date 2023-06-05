using System;
using System.IO;

class Program
{
    static int ConvertProductCodeToId(int charCount, int digitCount, string productCode)
    {
        int productId = 0;

        for(int i=0; i<digitCount; i++)
        {
            //   NOTE -  An ASCII value for the character '0' is 48.
            int digitValue = (int)(((int)productCode[productCode.Count() - i - 1] - 48) * Math.Pow(10, i));
            productId += digitValue;
        }

        for(int i=0; i<charCount; i++)
        {
            //   NOTE -  An ASCII value for the character 'A' is 65.
            int charValue = (int)(((int)productCode[i] - 65) * Math.Pow(26, i) * Math.Pow(10, digitCount));
            productId += charValue;
        }

        return productId;
    }

    static void Main(string[] args)
    {
        int charCount = int.Parse(Console.ReadLine());
        int digitCount = int.Parse(Console.ReadLine());

        StreamWriter sw = new StreamWriter("output.txt");

        for(int i=0; i<Math.Pow(26, charCount) * Math.Pow(10, digitCount); i++)
        {
            string productCode = "";
            int productId = i;

            productCode = string.Format(string.Format("{{0:D{0}}}", digitCount), productId % (int)Math.Pow(10, digitCount));
            productId /= (int)Math.Pow(10, digitCount);

            for(int j=0; j<charCount; j++)
            {
                productCode = (char)((productId % 26) + 65) + productCode;
                productId /= 26;
            }

            sw.WriteLine(productCode);
        }

        sw.Close();
    }
}