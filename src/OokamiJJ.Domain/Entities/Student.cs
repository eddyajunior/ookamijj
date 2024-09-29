namespace OokamiJJ.Domain.Entities
{
    public class Student : EntityBase
    {
        public Student(string name,
                       DateTime bornDate,
                       string responsibleFor,
                       string email,
                       string phone,
                       Guid? id)
            :base(id)
        {
            Name = name;
            BornDate = bornDate;
            ResponsibleFor = responsibleFor;
            Email = email;
            Phone = phone;
        }

        public string Name { get; private set; }
        public DateTime BornDate { get; private set; }
        public string ResponsibleFor { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }

        public bool Validate()
        {
            if (!string.IsNullOrEmpty(Name))
                return false;

            if (Name.Length < 5)
                return false;

            if (Name.Length > 50)
                return false;

            return true;
        }
    }
}
