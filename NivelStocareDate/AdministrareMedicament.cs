using FarmacieLab;

namespace NivelStocareDate
{
    public class AdministrareMedicament
    {
        private const int NR_MAX_MEDICAMENTE = 50;

        private Medicament[] medicamente;
        private int nrMedicamente;

        public AdministrareMedicament()
        {
            medicamente = new Medicament[NR_MAX_MEDICAMENTE];
            nrMedicamente = 0;
        }

        public void AddMedicament(Medicament medicament)
        {
            medicamente[nrMedicamente] = medicament;
            nrMedicamente++;
        }

        public Medicament[] GetMedicamente(out int nrMedicamente)
        {
            nrMedicamente = this.nrMedicamente;
            return medicamente;
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

    }
}
