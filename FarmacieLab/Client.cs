namespace FarmacieLab
{
    public class Client
    {
        string nume;
        int varsta;

            public Client()
        {
            nume = string.Empty;
            varsta = 0;
        }
            public Client(string _nume , int _varsta)
        {
            nume   = _nume;
            varsta = _varsta;
        }
            public string Info()
        {
            return $"Numele Clientului : {nume} , varsta clentului : {varsta}";
        }

    }
}
