using System;
using System.Collections.Generic;

namespace ExceptionManagement
{
    sealed class  MyException: Exception
    {
        public MyException(string message):base(message)
        {
           
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int a = 5;
            int b = 0;
            List<int> liste=new List<int>();

            try
            {
                throw (new MyException("hata özel hata"));

                liste = null;

                liste.Add(6);
                int aasd = Convert.ToInt32("asad");
                int result = a / b;
            }
            catch(DivideByZeroException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            catch(FormatException ex1)
            {
                Console.WriteLine("Hatalı giriş");
            }
            catch(NullReferenceException ex2)
            {

            }
            catch(MyException ex)
            {

            }
            catch(Exception ex)
            {

            }
           

           

          //  int sayi = Convert.ToInt32("asd");
        }
    }
}
