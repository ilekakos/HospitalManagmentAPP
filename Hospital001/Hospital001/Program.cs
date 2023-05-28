using System;
using System.Collections.Generic;

namespace HospitalApp
{
    //Ορίζεται η κλάση Program, η οποία περιλαμβάνει την στατική μέθοδο Main ως την είσοδο του προγράμματος.
    public class Program
    {
        public static void Main()
        {
            // Δημιουργείται ένα αντικείμενο Hospital για να αντιπροσωπεύει το νοσοκομείο
            Hospital hospital = new Hospital();
            // Δημιουργείται ένα αντικείμενο Database με τη χρήση της κλάσης Database.GetInstance(). Η κλάση Database δίνει πρόσβαση σε μια βάση δεδομένων
            Database db = Database.GetInstance();



            //Τα αντικείμενα των γιατρών, των ασθενών, των δωματίων και των νοσηλειών προστίθενται στη βάση δεδομένων χρησιμοποιώντας τη μέθοδο Add του αντικειμένου db.


            //Με την επανάληψη while εμφανίζεται ένα μενού που κάνει την εκτέλεση των επιλογών του χρήστη
            while (true)

            {


                Console.WriteLine("\n********* -MENU- **********");
                Console.WriteLine("1.  *- Lista giatrwn");
                Console.WriteLine("2.  *- Lista asthenwn");
                Console.WriteLine("3.  *- Lista dwmation");
                Console.WriteLine("4.  *- Lista nosilias");
                Console.WriteLine("5.  *- Lista arithmo dwmatiou astheni");
                Console.WriteLine("6.  *- Katalogos asthenwn pou parakolouthei enas giatros");
                Console.WriteLine("7.  *- Katalogos istoriko asthenous");
                Console.WriteLine("8.  *- Kataxwrisei giatrou");
                Console.WriteLine("9.  *- Kataxwrisei asthenous");
                Console.WriteLine("10. *- Kataxwrisei nosilias");
                Console.WriteLine("11. *- Exitirio asthenous");
                Console.WriteLine("0.  *- Exodos");

                Console.Write("Eisagetai tin epilogi sas: ");
                int choice = Int32.Parse(Console.ReadLine());

                //Οι επιλογές του χρήστη αξιολογούνται με χρήση της εντολής switch
                switch (choice)
                {
                    //Ανάλογα με την επιλογή του χρήστη, καλούνται οι αντίστοιχες μέθοδοι του αντικειμένου hospital για να εκτελέσουν τις αντίστοιχες ενέργειες
                    case 1:
                        hospital.PrintDoctors(); //Εκτύπωση καταλόγου γιατρών
                        break;
                    case 2:
                        hospital.PrintPatients(); //Εκτύπωση καταλόγου ασθενών

                        break;
                    case 3:
                        hospital.PrintRooms(); //Εκτύπωση καταλόγου δωματίων
                        break;
                    case 4:
                        //Εκτύπωση καταλόγου νοσηλειών
                        hospital.PrintHospitalizations();
                        break;
                    case 5:
                        Console.Write("Eisagetai arithmo dwmatiou: "); // Εισαγωγή αριθμού δωματίου
                        string roomNumberInput = Console.ReadLine(); // Αποθήκευση αριθμού δωματίου σε μεταβλητή
                        if (int.TryParse(roomNumberInput, out int roomNumber)) // Έλεγχος αν ο αριθμός δωματίου είναι αριθμός
                        {
                            Room selectedRoom = hospital.GetRoomByID(roomNumber); // Αναζήτηση δωματίου με βάση τον αριθμό
                            if (selectedRoom != null)
                            {
                                hospital.PrintRoomPatients(selectedRoom); // Εκτύπωση ασθενών που βρίσκονται στο dwmatio
                            }
                            else
                            {
                                Console.WriteLine("Lathos airtmos dwmatiou.");
                            }
                        }
                        break;

                    case 6:
                        Console.Write("Eisagetai ID giatrou: "); // Εισαγωγή κωδικού γιατρού
                        int doctorId = int.Parse(Console.ReadLine());
                        // Αναζήτηση του γιατρού με βάση τον κωδικό
                        Doctor doctor = hospital.GetDoctorByID(doctorId);
                        if (doctor != null) // Έλεγχος αν υπάρχει ο γιατρός
                        {
                            hospital.PrintDoctorPatients(doctor); // Εκτύπωση ασθενών που παρακολουθεί ο γιατρός
                        }
                        else
                        {
                            Console.WriteLine("Lathos ID giatrou.");
                        }
                        break;

                    case 7:
                        Console.Write("Eisagetai ID asthenous: ");
                        int patientId = int.Parse(Console.ReadLine());
                        Patient patient = hospital.GetPatientByID(patientId);
                        if (patient != null)
                        {
                            hospital.PrintPatientHospitalizations(patient);
                        }
                        else
                        {
                            Console.WriteLine("Lathos ID asthenous.");
                        }

                        break;

                    case 8: // καταχώρηση νεου γιατρου
                        
                        Console.Write("Eisagetai to ID tou giatrou: "); 
                        int doctorID = int.Parse(Console.ReadLine());
                        Console.Write(" to epwnymo tou giatrou: ");
                        string doctorSurname = Console.ReadLine();
                        Console.Write("Eisagetai to onoma tou giatrou: ");
                        string doctorName = Console.ReadLine();
                        Console.Write("Eisagetai tin ilikia tou giatrou: ");
                        int doctorAge = int.Parse(Console.ReadLine());
                        Console.Write("Eisagetai ton mistho tou giatrou: ");
                        decimal doctorSalary = decimal.Parse(Console.ReadLine());
                        Console.Write("Eisagetai tin eidikotita tou giatrou: ");
                        string doctorSpecialty = Console.ReadLine();

                        Doctor newDoctor = new Doctor(doctorID, doctorSurname, doctorName, doctorAge, doctorSalary, doctorSpecialty);
                        Database.GetInstance().AddDoctor(newDoctor);

                        Console.WriteLine("O giatros proshetike me epitxyia.");
                        break;


                    case 9: // καταχώρηση νεου ασθενους
                        Console.Write("Eisagetai to ID tou asthenous: ");
                        int patientID = int.Parse(Console.ReadLine());

                        Console.Write("Eisagetai to epwnumo touasthenous: ");
                        string patientSurname = Console.ReadLine();

                        Console.Write("Eisagetai to onoma tou asthenous: ");
                        string patientName = Console.ReadLine();

                        Console.Write("Eisagetai tin ilikia tou asthenous: ");
                        int patientAge = int.Parse(Console.ReadLine());
                            
                        Console.Write("Eisagetai tin asfalia tou astheni: "); // Εισαγωγή ασφαλιστικού ασφαλειας
                        string patientInsurance = Console.ReadLine(); // Αποθήκευση ασφαλιστικού ασφαλειας σε μεταβλητή

                        Patient newPatient = new Patient(patientID, patientSurname, patientName, patientAge, patientInsurance);
                        Database.GetInstance().AddPatient(newPatient);
    
                        Console.WriteLine("O asthenis prostethuike me epityxia.");
                        break;
                       
                    case 10: // καταχώρηση νεας νοσηλειας
                        Console.Write("Eisagetai ID nosilias: ");
                        int hospitalizationId = int.Parse(Console.ReadLine());

                        Console.Write("Eisagetai ID asthenous: ");
                        int newpatientId = int.Parse(Console.ReadLine());
                        Patient hospitalizationPatient = Database.GetInstance().GetPatientById(newpatientId);

                        Console.Write("Eisagetai noso asthenous: ");
                        string disease = Console.ReadLine();

                        Console.Write("Eisagetai to ID tou dwmatiou: ");
                        int roomId = int.Parse(Console.ReadLine());
                        Room hospitalizationRoom = Database.GetInstance().GetRoomById(roomId);

                        Console.Write("Eisagetai to ID tou giatrou: ");
                        int newdoctorId = int.Parse(Console.ReadLine());
                        Doctor hospitalizationDoctor = Database.GetInstance().GetDoctorById(newdoctorId);

                        Hospitalization newHospitalization = new Hospitalization(hospitalizationId, hospitalizationPatient, disease, hospitalizationRoom, hospitalizationDoctor);
                        Database.GetInstance().AddHospitalization(newHospitalization);

                        Console.WriteLine("H nosilia kataxwrithike me epityxia.");
                        break;


                    case 11:
                        Console.Write("\"Eisagetai ID asthenous: "); // Εισαγωγή id ασθενούς για εξητήριο
                        int newpatientID = int.Parse(Console.ReadLine()); // Αποθήκευση id ασθενούς σε μεταβλητή
                        Patient dischargePatient = hospital.GetPatientByID(newpatientID); // Αναζήτηση ασθενούς με βάση το id
                        if (dischargePatient != null) // Έλεγχος αν υπάρχει ο ασθενής
                        {
                            hospital.DischargePatient(newpatientID); // Εξιτήριο ασθενούς
                            Console.WriteLine("O asthenis me ID " + newpatientID + " pire exitirio epitixws."); // Εκτύπωση μηνύματος επιτυχίας
                        }
                        else
                        {
                            Console.WriteLine("Lathos ID asthenous.");
                        }
                        
                        break;
                    case 0:
                        Console.WriteLine("Exodos! "); //Έξοδος από το πρόγραμμα
                        return;
                    default:
                        Console.WriteLine("Lathos epilogi parakalw prospathiste xana! ");
                        break;
                }
            }
        }

    }
}
