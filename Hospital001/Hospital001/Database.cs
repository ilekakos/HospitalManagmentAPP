using HospitalApp;
public class Database //Δημιουργία κλάσης Database 
{
    // Στατική μεταβλητή για την υλοποίηση του singleton

    public static Database? instance = null; //Δημιουργία μεταβλητής instance 
    public List<Doctor> doctors; //Δημιουργία λίστας για τους ιατρούς
    public List<Patient> patients; //Δημιουργία λίστας για τους ασθενείς 
    public List<Room> rooms; //Δημιουργία λίστας για τα δωμάτια 
    public List<Hospitalization> hospitalizations; //Δημιουργία λίστας για τις νοσηλείες
    public List<Nurse> nurses; //Δημιουργία λίστας για τις νοσοκόμες
    private int nextDoctorId = 1; //Δημιουργία μεταβλητής για τον κωδικό του ιατρού

    private Database() //constructor 
    {
        doctors = new List<Doctor>(); //Αρχικοποίηση της κλάσης
        patients = new List<Patient>();
        rooms = new List<Room>();
        hospitalizations = new List<Hospitalization>();
        nurses = new List<Nurse>();
        GetDoctors(); //Επιστροφή των ιατρών
        GetPatients();
        GetRooms();

    }

    public static Database GetInstance() //Δημιουργία μεθόδου για την υλοποίηση του singleton
    {
        if (instance == null) //Αν η μεταβλητή instance είναι κενή 
        {
            instance = new Database(); //Δημιουργία νέου instance 
        }
        return instance; //Επιστροφή της μεταβλητής instance
    }

    public void GetDoctors() //Δημιουργία μεθόδου για την επιστροφή των ιατρών
    {
        doctors.Add(new Doctor(1, "Argiriou", "Dimitris", 41, 9000, "kardiologos"));//Προσθήκη ιατρών στη λίστα
        doctors.Add(new Doctor(2, "Papakvsta", "Eleni", 45, 8000, "pathologos"));
        doctors.Add(new Doctor(3, "Papadopoulos", "Giorgos", 35, 7000, "xeirourgos"));
    }
    public void AddNurse(Nurse nurse)
    {
        nurses.Add(nurse);
    }

    public List<Nurse> GetNurses()
    {
        return nurses;
    }



    private void GetPatients()
    {
        patients.Add(new Patient(1, "Dimitriou", "Katerina", 25, "ABC123"));
        patients.Add(new Patient(2, "Papadopoulou", "Maria", 35, "DEF456"));
        patients.Add(new Patient(3, "Stavropoulos", "Georgios", 32, "DEF456"));

    }
    public void GetRooms()
    {
        rooms.Add(new Room(1, "101"));
        rooms.Add(new Room(2, "102"));
        rooms.Add(new Room(3, "103"));

    }

    public List<Hospitalization> GetHospitalizations() //Δημιουργία μεθόδου για την επιστροφή των νοσηλειών
    {

        return hospitalizations; //Επιστροφή της λίστας hospitalizations
    }

    public void AddDoctor(Doctor doctor) //Δημιουργία μεθόδου για την προσθήκη ιατρού
    {

        doctor.ID = nextDoctorId; //Αύξηση του κωδικού του ιατρού
        doctors.Add(doctor);//Προσθήκη του ιατρού στη λίστα doctors
        nextDoctorId++; //Αύξηση του κωδικού του ιατρού
    }


    public void AddPatient(Patient patient) //Δημιουργία μεθόδου για την προσθήκη ασθενούς
    {
        patient.ID = nextDoctorId; //Αύξηση του κωδικού του ασθενούς
        patients.Add(patient); //Προσθήκη του ασθενούς στη λίστα patients
        nextDoctorId++; //Αύξηση του κωδικού του ασθενούς

    }


    public void AddRoom(Room room) //Δημιουργία μεθόδου για την προσθήκη δωματίου
    {
        //Αύξηση του κωδικού του δωματίου
        room.ID = nextDoctorId; //Αύξηση του κωδικού του δωματίου
        rooms.Add(room); //Προσθήκη του δωματίου στη λίστα rooms
        nextDoctorId++; //Αύξηση του κωδικού του δωματίου
    }

    public void AddHospitalization(Hospitalization hospitalization) //Δημιουργία μεθόδου για την προσθήκη νοσηλείας
    {
        hospitalization.Id = nextDoctorId; //Αύξηση του κωδικού της νοσηλείας
        hospitalizations.Add(hospitalization); //Προσθήκη της νοσηλείας στη λίστα hospitalizations
        nextDoctorId++; //Αύξηση του κωδικού της νοσηλείας

    }

    public Patient GetPatientById(int patientId) //Δημιουργία μεθόδου για την επιστροφή ασθενούς με βάση το ID
    {
        foreach (Patient patient in patients) //Για κάθε ασθενή στη λίστα patients 
        {
            if (patient.ID == patientId)
            {
                return patient;
            }
        }
        return null;
    }

    public Room GetRoomById(int roomId) //Δημιουργία μεθόδου για την επιστροφή δωματίου με βάση το ID
    {
        foreach (Room room in rooms)
        {
            if (room.ID == roomId)
            {
                return room;
            }
        }

        return null; // Επιστρέφουμε null αν δεν βρεθεί δωμάτιο με το συγκεκριμένο ID
    }
    public Doctor GetDoctorById(int doctorId) //Δημιουργία μεθόδου για την επιστροφή ιατρού με βάση το ID
    {
        foreach (Doctor doctor in doctors)
        {
            if (doctor.ID == doctorId)
            {
                return doctor;
            }
        }

        return null; // Επιστρέφουμε null αν δεν βρεθεί γιατρός με το συγκεκριμένο ID
    }
}