using FarmacieLab;
using System;


    class Program
    {
        static void Main()
        {

            Client client1 = new Client("Danila Alexandra", 20);
            string s1 = client1.Info();
            Console.WriteLine(s1);

            var medicament1 = new Medicament();
            string s = medicament1.InfoMedicament();
            Console.WriteLine(s);

           

            Console.ReadKey();
        }
    }

