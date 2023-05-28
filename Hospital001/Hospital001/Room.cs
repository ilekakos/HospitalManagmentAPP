using HospitalApp;
public class Room //Δημιουργία κλάσης Room
{
    public int ID { get; set; } // Κωδικός 
    public string Name { get; set; } // Όνομα 
    public List<Patient> Patients { get; set; } // Λίστα ασθενών 
    

    public Room(int id, string name) //constructor με παραμέτρους
    {
         // Αρχικοποίηση της κλάσης
        ID = id;
        Name = name; 
        Patients = new List<Patient>();
    }

    public override string ToString()
    {
        return "Id" + ID +  "Room: " + Name;
    }

}