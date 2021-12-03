using System;

namespace Day_17_Task_1
{
    class Program
    {
        public static string GetAllInnerMessageTogether(Exception ex)
        {
            string result = "";
            while (ex != null)
            {
                if (string.IsNullOrEmpty(ex.InnerException.Message))
                {
                    break;
                }
                else
                {
                    result += ex.Message;
                }
                ex = ex.InnerException;
            }
            return result;
        }

        public static string GetLastInnerException(Exception ex)
        {
            string result = "";
            while (ex != null)
            {
                if (ex.InnerException == null)
                    return ex.Message;
               

                ex = ex.InnerException;
            }
            return result;
        }
        static void Main(string[] args)
        {
            var debit = new DebitIBAN();
            Console.WriteLine("Input amount on your debit IBAN");
            try
            {
                try
                {
                    string temp = Console.ReadLine();
                    debit.Amount = decimal.Parse(temp);
                }
                catch (Exception)
                {
                    throw  new IncorrectInputedAmountException();
                }
            }
            catch(IncorrectInputedAmountException ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
