using System;
using static System.Console;

namespace ISIT324_Anvils
{
    class Program
    {
        static void Main(string[] args)
        {
            string fullName;
            string streetAddress;
            string city;
            string state;
            string zipCode;
            int qty;

            //GET ORDER INFO
            WriteLine("Enter the respective information for shipping: ");
            WriteLine(":::SHIPPING INFO:::");
            Write("Name: ");
            fullName = GetValidString(ReadLine(), 1, 32);
            Write("Street Address: ");
            streetAddress = GetValidString(ReadLine(), 1, 32);
            Write("City: ");
            city = GetValidString(ReadLine(), 1, 20);
            Write("State (Please use TWO (2) letters): ");
            state = GetValidString(ReadLine(), 2, 2);
            Write("Zip Code: ");
            zipCode = GetValidString(ReadLine(), 5, 5);
            Write("# of anvils to order: ");
            qty = Convert.ToInt32(ReadLine());

            //PRINT RECEIPT
            WriteLine();
            WriteLine("\t:::::SHIPPING INFORMATION::::");
            WriteLine("\t{0}", fullName);
            WriteLine("\t{0}", streetAddress);
            WriteLine("\t{0}", city);
            WriteLine("\t{0}", state);
            WriteLine("\t{0}", zipCode);
            WriteLine();
            WriteLine("\t:::TRANSACTION INFORMATION:::");
            WriteLine("\tAnvils ordered:\t\t{0}", qty);
            WriteLine("\tPrice per anvil:\t{0:C}", CalcVolumeDiscount(qty));
            WriteLine("\tShipping:\t\t{0:C}", CalcShipping(qty, state));
            WriteLine("\t\t\t\t----");
            WriteLine("\tSubtotal:\t\t{0:C}", CalcSub(qty, state));
            WriteLine("\tSales Tax (10.85%):\t{0:C}", CalcTax(qty, state));
            WriteLine("\t\t\t\t----");
            WriteLine("\tGRAND TOTAL:\t\t{0:C}", CalcGrand(qty, state));
            WriteLine();
        }
        public static decimal CalcGrand(int qty, string state) //Grand Total
        {
            decimal grandTotal;
            grandTotal = CalcVolumeDiscount(qty) + (CalcShipping(qty, state)) + (CalcTax(qty, state));
            return grandTotal;
        }

        public static decimal CalcSub(int qty, string state) //Subtotal
        {
            return CalcVolumeDiscount(qty) + (CalcShipping(qty, state));
        }

        public static decimal CalcTax(int qty, string state) //Tax Total
        {
            return (0.1085m * CalcSub(qty, state));
        }

        public static decimal CalcShipping(int qty, string state) //Shipping Total
        {
            decimal shippingRate = 112.00m;
            if (state == "CA")
            {
                shippingRate = 0.00m;
            }
            return (shippingRate * qty); 
        }

        public static decimal CalcVolumeDiscount(int qty) //Volume Discount
        {
            if (qty >= 1 && qty <= 9)
            {
                return 88.50m;
            }
            else if (qty >= 10 && qty <= 19)
            {
                return 70.00m;
            }
            else
            {
                return 68.25m;
            }
        }

        private static string GetValidString(string prompt, int min, int max) //User must input valid string length
        {
            int promptStringLength = prompt.Length;
            while (promptStringLength < min || promptStringLength > max)
            {
                Write("Input length is invalid." +
                    " Please re-enter.  ");
                prompt = ReadLine();
                promptStringLength = prompt.Length;
            }
            return prompt;
        }
    }
}