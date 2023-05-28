using HospitalApp;

// Η κλάση Hospitalization αντιπροσωπεύει μια νοσηλεία με σχετικές πληροφορίες
public class Hospitalization //Δημιουργία κλάσης Hospitalization
{
    public int Id { get; set; } // Κωδικός
    public Doctor Doctor { get; set; } // Ιατρός
    public Patient Patient { get; set; } // Ασθενής
    public string Disease { get; set; }     // Νόσος
    public DateTime AdmissionDate { get; set; } // Ημερομηνία εισαγωγής
    public DateTime? DischargeDate { get; set; } // Ημερομηνία εξιτηρίου
    public Room Room { get; set; } // Δωμάτιο

    
    //constructor με παραμέτρους 
    public Hospitalization(int id, Patient patient, string disease, Room room, Doctor doctor)
    {
        // Αρχικοποίηση της κλάσης

        Id = 1;
        Patient = patient;
        Disease = disease;
        Doctor = doctor;
        AdmissionDate = DateTime.UtcNow ;
        DischargeDate = null;
        Room = room;
        Id++;
    }
}