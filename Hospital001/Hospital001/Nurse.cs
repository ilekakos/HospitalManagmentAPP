namespace HospitalApp;
public class Nurse : Person
{
    public int NurseID { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public int Age { get; set; }
    public decimal Salary { get; set; }
    public Room AssignedRoom { get; set; }

    public Nurse(int nurseID, string lastName, string firstName, int age, decimal salary, Room assignedRoom)
    {
        NurseID = nurseID;
        LastName = lastName;
        FirstName = firstName;
        Age = age;
        Salary = salary;
        AssignedRoom = assignedRoom;
    }
}
