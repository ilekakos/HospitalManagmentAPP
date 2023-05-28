namespace HospitalApp
{
    public class Patient : Person //Δημιουργία κλάσης Patient που κληρονομεί από την κλάση Person
    { 
        public string Insurance { get; set; } // Ασφάλιση
        
        public List<Hospitalization> Hospitalizations { get; set; } // Λίστα νοσηλειών

        //constructor με παραμέτρους
        public Patient(int id, string lastName, string firstName, int age, string insurance) 
            : base(id, lastName, firstName, age) 
        { 
            // Αρχικοποίηση της κλάσης
           
            Insurance = insurance;
            Hospitalizations = new List<Hospitalization>();
        }

       public override string ToString() // Επιστρέφει τα στοιχεία του ασθενή σε μορφή string 
        {
            return base.ToString() + " Asfalia: " + Insurance;
        }
    }
}