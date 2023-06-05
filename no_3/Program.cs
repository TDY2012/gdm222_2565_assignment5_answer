using System;

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

        List<string> productNameList = new List<string>();
        string productName;

        while(true)
        {
            productName = Console.ReadLine();
            if(productName == "Stop")
            {
                break;
            }
            else
            {
                productNameList.Add(productName);
            }
        }

        string productCode = Console.ReadLine();
        int productId = ConvertProductCodeToId(charCount, digitCount, productCode);
        
        if(productId >= 0 && productId < productNameList.Count)
        {
            Console.WriteLine(productNameList[productId]);
        }
        else
        {
            Console.WriteLine("Not found!");
        }
    }
}