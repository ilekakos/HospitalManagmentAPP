using HospitalApp;
// Κλάση Ιατρός που κληρονομεί από την κλάση Πρόσωπο
public class Doctor : Person //Δημιουργία κλάσης Doctor 
{

    public decimal Salary { get; set; } // Μισθός
    public List<Patient> Patients { get; set; } // Λίστα ασθενών 
    public string Specialty { get; set; }

    //constructor με παραμέτρους
    public Doctor(int id, string lastName, string firstName, int age, decimal salary, string speciality) : base(id, lastName, firstName, age)
    { 
        // Αρχικοποίηση της κλάσης
        Salary = salary;
        Patients = new List<Patient>();
        Specialty = speciality;
    }

    public void DoctorsPatient(Patient patient)
    {
        Patients.Add(patient);
    }

    public override string ToString()
    {
        return base.ToString() + $", Salary: {Salary}, Specialty: {Specialty}";
    }
}