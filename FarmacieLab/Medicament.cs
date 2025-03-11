
namespace FarmacieLab
{
    public class Medicament
    {
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

       
        
    }
}
