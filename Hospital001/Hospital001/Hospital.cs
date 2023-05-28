using System;
using System.Collections.Generic;

// Η κλάση Hospital αντιπροσωπεύει το νοσοκομείο 
namespace HospitalApp 
{
    public class Hospital //Δημιουργία κλάσης Hospital
    {
        public Database db; // Η βάση δεδομένων του νοσοκομείου

        public Hospital() //constructor
        {
            db = Database.GetInstance(); // Αρχικοποίηση της βάσης δεδομένων
        }

        // Προσθέτει έναν ιατρό στη βάση δεδομένων
        public void AddDoctor(Doctor doctor) //Μέθοδος για την προσθήκη ιατρού
        {
            db.AddDoctor(doctor); // Προσθήκη ιατρού
        }



        // Προσθέτει έναν ασθενή στη βάση δεδομένων
        public void AddPatient(Patient patient) //Μέθοδος για την προσθήκη ασθενή
        {
            db.AddPatient(patient); // Προσθήκη ασθενή
        }

        // Προσθέτει ένα δωμάτιο στη βάση δεδομένων
        public void AddRoom(Room room) //Μέθοδος για την προσθήκη δωματίου
        {
            db.AddRoom(room); // Προσθήκη δωματίου
        }

        // Προσθέτει μια νοσηλεία στη βάση δεδομένων
        public void AddHospitalization(Hospitalization hospitalization) //Μέθοδος για την προσθήκη νοσηλείας
        {
            db.AddHospitalization(hospitalization); // Προσθήκη νοσηλείας
        }

        // Εκτυπώνει τις νοσηλείες στο νοσοκομείο
        public void PrintHospitalizations() //Μέθοδος για την εκτύπωση νοσηλειών
        {
            Console.WriteLine("Nosilies sto nosokomio:"); // Εκτύπωση νοσηλειών
            foreach (Hospitalization hospitalization in db.hospitalizations)
            {
                Console.WriteLine(hospitalization); // Εκτύπωση νοσηλειών
            }
        }

        //DischargePatient εξιτήριο ασθενή
        public void DischargePatient(int id) //Μέθοδος για την εξιτήριο ασθενή
        {
            Hospitalization hospitalization = db.GetHospitalizations().Find(h => h.Patient.ID == id); // Αναζήτηση νοσηλείας
            if (hospitalization != null) // Αν βρεθεί η νοσηλεία
            {
                hospitalization.DischargeDate = DateTime.UtcNow; // Εξιτήριο
            }
        }
        
        



        // Εκτυπώνει τα δωμάτια στο νοσοκομείο
        public void PrintRooms() //Μέθοδος για την εκτύπωση δωματίων
        {
            Console.WriteLine("Dwmatia sto nosokomio:"); // Εκτύπωση δωματίων
            foreach (Room room in db.rooms) 
                {
                    Console.WriteLine(room); // Εκτύπωση δωματίων
                }
            
        }

        public void PrintDoctors() //Μέθοδος για την εκτύπωση ιατρών
        {
          
            Console.WriteLine("Iatroi sto nosokomio:");
            foreach (Doctor doctor in db.doctors)
            {
                    Console.WriteLine(doctor);
            }
            
        }

        public void PrintPatients() //Μέθοδος για την εκτύπωση ασθενών
        {
              Console.WriteLine("Asthenois sto nosokomio:");
            foreach (Patient patient in db.patients)
            {
                    Console.WriteLine(patient);
            }
        }


        // Εκτυπώνει τους ασθενείς που ανήκουν σε έναν συγκεκριμένο ιατρό
        public void PrintDoctorPatients(Doctor doctor) 
        {
            // Λίστα με τους 

            if (doctor.Patients.Count > 0) // Αν υπάρχουν ασθενείς
            {
                Console.WriteLine($"Asthenois giatou {doctor}:"); // Εκτύπωση ασθενών
                foreach (Patient patient in doctor.Patients) 
                {
                    Console.WriteLine(patient); 
                }
            }
            else // Αν δεν υπάρχουν ασθενείς
            {
                Console.WriteLine($"Den vrethikan astheneis gia ton giatro {doctor}."); // Εκτύπωση μηνύματος
            }
        }

        // Εκτυπώνει τους ασθενείς που ανήκουν σε ένα δωμάτιο
        public void PrintRoomPatients(Room room)
        {
            if (room.Patients.Count > 0) // Αν υπάρχουν ασθενείς
            {
                Console.WriteLine($"Astheneis dwmatiou {room}:"); // Εκτύπωση ασθενών
                foreach (Patient patient in room.Patients)
                {
                    Console.WriteLine(patient); 
                }
            }
            else // Αν δεν υπάρχουν ασθενείς
            {
                Console.WriteLine($"Den vrethikan astheneis sto dwmatio {room}."); // Εκτύπωση μηνύματος
            }
        }

        public Room GetRoomByID(int roomNumber) //Μέθοδος για την εύρεση δωματίου με βάση το ID
        {
            foreach (Room room in db.rooms) //Επανάληψη για κάθε δωμάτιο
            {
                if (room.ID == roomNumber)
                {
                    return room;
                }
            }
            return null;
        }

        public Doctor GetDoctorByID(int doctorID) //Μέθοδος για την εύρεση ιατρού με βάση το ID
        {
            foreach (Doctor doctor in db.doctors)
            {
                if (doctor.ID == doctorID)
                {
                    return doctor;
                }
            }
            return null;
        }

        public Patient GetPatientByID(int patientID) //Μέθοδος για την εύρεση ασθενή με βάση το ID
        {
            foreach (Patient patient in db.patients)
            {
                if (patient.ID == patientID)
                {
                    return patient;
                }
            }
            return null;
        }

        public void PrintPatientHospitalizations(Patient patient) //Μέθοδος για την εκτύπωση νοσηλειών ασθενή
        {
            if (patient.Hospitalizations.Count > 0) // Αν υπάρχουν νοσηλείες
            {
                Console.WriteLine($"Nosilies asthenous {patient}:"); // Εκτύπωση νοσηλειών
                foreach (Hospitalization hospitalization in patient.Hospitalizations)
                {
                    Console.WriteLine(hospitalization); // Εκτύπωση νοσηλειών
                }
            }
            else // Αν δεν υπάρχουν νοσηλείες
            {
                Console.WriteLine($"Den vrethikan nosilies gia ton astheni {patient}."); // Εκτύπωση μηνύματος
            }
        }

        public void PrintEmployeesBySalary()
        {
            var allEmployees = new List<Person>();
            var doctors = db.doctors.Cast<Person>().ToList();
            var nurses = db.nurses.Cast<Person>().ToList();
            allEmployees.AddRange(doctors);
            allEmployees.AddRange(nurses);

            var sortedEmployees = allEmployees.OrderBy(employee => employee.Salary);

            foreach (var employee in sortedEmployees)
            {
                Console.WriteLine($"{employee.FirstName} {employee.LastName} - Salary: {employee.Salary}");
            }
        }


    }


}

