using System;

namespace FarmacieLab
{
    public class Medicament
    {
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';
        private const int DENUMIRE = 0;
        private const int PRET = 1;
        private const int NECESITARETETA = 2;
        public string denumire { get; set; }
            public int pret { get; set; }
            public bool necesitaReteta { get; set; }

            public Medicament()
            {
                denumire = string.Empty;
                pret = 0;
                necesitaReteta = false;


            }

            public Medicament(string _denumire, int _pret , bool _necesitaReteta)
            {
                denumire = _denumire;
                pret = _pret;
                necesitaReteta = _necesitaReteta;
            }

            public string InfoMedicament()
            {
                return $"Denumirea medicamentului: {denumire}, Pretul medicamentului: {pret} , Reteta: {necesitaReteta}";
            }
        public static Medicament[] cautareINdenumire(Medicament[] medicamente, string cuvantCautat)
        {
            List<Medicament> rezultate = new List<Medicament>();

            foreach (var medicament in medicamente)
            {
                if (medicament != null && medicament.denumire.Contains(cuvantCautat, StringComparison.OrdinalIgnoreCase))
                {
                    rezultate.Add(medicament);
                }
            }
            return rezultate.ToArray();
        }
        public Medicament(string linieFisier)
        {
            var dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);

            //ordinea de preluare a campurilor este data de ordinea in care au fost scrise in fisier prin apelul implicit al metodei ConversieLaSir_PentruFisier()
            
            this.denumire = dateFisier[DENUMIRE];
            this.pret = Convert.ToInt32(dateFisier[PRET]);
            this.necesitaReteta = Convert.ToBoolean(dateFisier[NECESITARETETA]);
        }

   


        public string ConversieLaSir_PentruFisier()
        {
            string obiectMedicamentPentruFisier = string.Format("{1}{0}{2}{0}{3}{0}",
                SEPARATOR_PRINCIPAL_FISIER,
                (denumire ?? " NECUNOSCUT "),
                pret.ToString(),
                (necesitaReteta ? "da" : "nu"));

            return obiectMedicamentPentruFisier;
        }
    }
}
