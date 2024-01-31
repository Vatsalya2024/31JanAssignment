namespace ClinicAPI.Models
{
    public class Doctor:IEquatable<Doctor>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }

        public string Qualification { get; set; } = string.Empty;

        public string Experience { get; set; } = string.Empty;

        public string Speciality { get; set; } = string.Empty;

        public Doctor()
        {
            Id = 0;
        }
        public Doctor(int id, string name,int age,string qualification,string experience,string speciality)
        {
            Id = id;
            Name = name;
            Age = age;
            Qualification = qualification;
            Experience = experience;
            Speciality = speciality;    
        }
        public Doctor( string name, int age, string qualification, string experience, string speciality)
        {
            
            Name = name;
            Age = age;
            Qualification = qualification;
            Experience = experience;
            Speciality = speciality;
        }

        public bool Equals(Doctor? other)
        {
            var doctor = other ?? new Doctor();
            return this.Id.Equals(doctor.Id);
        }
    }
}
