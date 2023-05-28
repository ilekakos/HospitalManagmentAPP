namespace HospitalApp;
public class Person //Δημιουργία κλάσης Person
    
{

    public int ID { get; set; } // Κωδικός 
    public string LastName { get; set; } // Επώνυμο
    public string FirstName { get; set; } // Όνομα
    public int Age { get; set; } // Ηλικία
    public decimal Salary { get; set; } // προσθήκη πεδίου Salary στην κλάση Person για τη κλαση Doctor και Nurse ωστε να μπορούν να κληρονομήσουν το πεδίο Salary

    public Person()
    {
        ID = -50;
        LastName = "Not Available";
        FirstName = "Not Available";
        Age = -69;
    }

    public Person(int id, string lastName, string firstName, int age) //constructor με παραμέτρους 

    { 
        // Αρχικοποίηση της κλάσης 
        ID = id;
        LastName = lastName;
        FirstName = firstName;
        Age = age;
    }

    public override string ToString()
    {
        return ID + ": lastname " + LastName + ": firstname " + FirstName + ": Age " + Age ;
    }
}