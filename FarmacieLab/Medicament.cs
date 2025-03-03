
namespace FarmacieLab
{
    public class Medicament
    {
            string denumire;
            int pret;
            bool necesitaReteta;

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
