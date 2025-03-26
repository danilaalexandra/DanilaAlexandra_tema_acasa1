using FarmacieLab;
using NivelStocareDate;
using System;
using System.Configuration;


class Program
    {
        static void Main()
        {

        string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
        string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;

        //Client client1 = Citeste_tastatura_c();

        // Console.WriteLine(client1.Info());

        // Medicament medicament1=Citeste_tastatura_m();
        // Console.WriteLine(medicament1.InfoMedicament());


        string numeFisierClienti = ConfigurationManager.AppSettings["FisierClienti"];
        AdministrareClientFisier adminClienti = new AdministrareClientFisier(numeFisierClienti);

        string numeFisierMedicamente = ConfigurationManager.AppSettings["FisierMedicamente"];
        AdministrareMedicamentFisier adminMedicamente = new AdministrareMedicamentFisier(numeFisierMedicamente);

        //Client[] clienti = adminClient.GetClient(out int nrClienti); 
        //Console.WriteLine(" Clienți citiți din fișier :");

        // foreach (var client in clienti)
        //{
        //    Console.WriteLine(client.ConversieLaSir_PentruFisier());  
        //}

        //Medicament[] medicamente = adminMedicamente.GetMedicamente(out int nrMedicamente);
        //Console.WriteLine(" Clienți citiți din fișier :");

        //foreach (var client in clienti)
        //{
        //    Console.WriteLine(client.ConversieLaSir_PentruFisier());
        //}



        //AdministrareMedicament adminMed = new AdministrareMedicament();
        //Console.WriteLine("Numarul de medicamente pe care doriti sa il adaugati este :");
        //int nrMed = int.Parse(Console.ReadLine());

        //for(int i = 0; i<nrMed; i++)
        //{
        //   Medicament medicament = Citeste_tastatura_m();
        //   adminMed.AddMedicament(medicament);
        //}

        // Medicament[] medicamente = adminMed.GetMedicamente(out int nrMedicament);
        // Console.WriteLine("\n Medicamente salvate: ");
        //   for(int i=0; i<nrMedicament; i++)
        //{
        //  Console.WriteLine(medicamente[i].InfoMedicament());

        //}
        Client client_nou = new Client();
        int nrClienti = 0;
        Medicament medicament_nou = new Medicament();
        int nrMedicamente = 0;

        Console.WriteLine("Numarul de medicamente pe care doriti sa il adaugati este :");
        int nrMed = int.Parse(Console.ReadLine());

        for (int i = 0; i < nrMed; i++)
        {
            medicament_nou = Citeste_tastatura_m();
            adminMedicamente.AddMedicament(medicament_nou);
        }

        Console.WriteLine("Numarul de clienti pe care doriti sa il adaugati este :");
        int nrClt = int.Parse(Console.ReadLine());
       
        for(int i = 0; i<nrClt; i++)
        {
          client_nou = Citeste_tastatura_c();
             adminClienti.AddClient(client_nou);
        }


        //medicament_nou = Citeste_tastatura_m();
        //client_nou = Citeste_tastatura_c();



        //adaugare  in fisier
        //adminClienti.AddClient(client_nou);
        //adminMedicamente.AddMedicament(medicament_nou);



        //Console.WriteLine();

        //AdministrareClient adminClt = new AdministrareClient();
        //Console.WriteLine("Numarul de clienti ai farmaciei :");
        //int nrClt = int.Parse(Console.ReadLine());

        //for (int i = 0; i < nrClt; i++)
        //{
        //    Client client = Citeste_tastatura_c();
        //    adminClt.AddClient(client);
        //}

        //Client[] clienti = adminClt.GetClient(out int nrClienti);
        //Console.WriteLine("\n Clientii farmaciei: ");
        //for (int i = 0; i < nrClt; i++)
        //{
        //    Console.WriteLine(clienti[i].Info());

        //}

        //Console.WriteLine("Introduceti cuvantul cautat: ");
        //string cuvantCautat = Console.ReadLine();
        //Medicament[] rezultate = Medicament.cautareINdenumire(medicamente, cuvantCautat);

        //if (rezultate.Length > 0)
        //{
        //    Console.WriteLine("Medicamente gasite: ");
        //    foreach (var med in rezultate)
        //    {
        //        Console.WriteLine($"Denumire: {med.denumire}, Pret: {med.pret},Necesita reteta?: {med.necesitaReteta}");

        //    }
        //}
        //else
        //{
        //    Console.WriteLine($"\nNu s-a gasit niciun medicament");
        //}



    }
    static Medicament Citeste_tastatura_m()
    {
        string denumire="" ;
        while (Medicament.ValidareDenumire(denumire) != true)
        {
            Console.WriteLine("Introduceti denumirea medicamentului: ");
            denumire = Console.ReadLine();
        }
        Console.WriteLine("Introduceti pretul medicamentului: ");
        int pret;
        while (!int.TryParse(Console.ReadLine(), out pret) || pret < 0)
        {
            Console.WriteLine("Pret invalid!");
            
        }
        Console.WriteLine("Necesita reteta? (da/nu) :");
        string raspuns = Console.ReadLine().ToLower();
        bool necesitaReteta = raspuns == "da";

        Console.WriteLine("Alegeti din ce categorie face parte medicamentul: ");
        Console.WriteLine("1 - Analgezice \n" +
        "2 - Antibiotice \n" +
        "3 - Antimicrobiene \n" +
        "4 - Cardiovasculare \n" +
        "5 - Respiratorii \n" +
        "6 - Gastrointestinale \n"+
        "7 - Psihiatrice \n" +
        "8- Hormonale ");
        

        string opt = Console.ReadLine();
        bool valid = Enum.TryParse(opt, out Categorie cat);
        if (valid && Enum.IsDefined(typeof(Categorie), cat)) ;
        {

            Medicament medicament = new Medicament(denumire, pret, necesitaReteta);
            medicament.categorie = cat;
            return medicament;
        }


        
    }
    static Client Citeste_tastatura_c()
    {
        string nume = "";
        while (Client.ValidareNume(nume) != true)
        {
            Console.WriteLine("Introduceti numele clientului: ");
            nume = Console.ReadLine();
        }

        string prenume = "";
        while (Client.ValidarePrenume(prenume) != true)
        {
            Console.WriteLine("Introduceti prenumele clientului: ");
            prenume = Console.ReadLine();
        }
        DateOnly dataNasterii;
        Console.WriteLine("Introduceti data nasterii a clientului: ");
        string data = Console.ReadLine();
        while (!DateOnly.TryParseExact(data , "dd.MM.yyyy" , null , System.Globalization.DateTimeStyles.None , out dataNasterii))
        {
            Console.WriteLine("Data nasterii invalida! Format : dd.MM.yyyy");
            data = Console.ReadLine();
        }
        
        return new Client(nume ,prenume , dataNasterii);
    }

 
}

