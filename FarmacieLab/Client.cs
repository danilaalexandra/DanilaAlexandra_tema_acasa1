namespace FarmacieLab
{
    public class Client
    {
        string nume { get; set; }
        string prenume { get; set; }
        DateOnly data_nasterii { get; set; }

            public Client()
        {
            nume = string.Empty;
            prenume = string.Empty;
            data_nasterii = DateOnly.MinValue;
        }
            public Client(string _nume, string _prenume , DateOnly _data_nasterii)
        {
            nume   = _nume;
            prenume = _prenume;
            data_nasterii = _data_nasterii;
        }
            public string Info()
        {
            return $"Numele Clientului : {nume} { prenume}, data nasterii a clientului : {data_nasterii}";
        }

    }
}
