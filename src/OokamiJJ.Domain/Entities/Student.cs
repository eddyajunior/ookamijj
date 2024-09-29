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
            : base(id)
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
            return ValidateName() && ValidateBornDate() && ValidateResponsibleFor() && ValidateEmail() && ValidatePhone();
        }

        public bool ValidateName()
        {
            if (string.IsNullOrEmpty(Name))
                return false;

            if (Name.Length < 5 || Name.Length > 50)
                return false;

            return true;
        }

        public bool ValidateBornDate()
        {
            if (BornDate == default)
                return false;

            if (BornDate > DateTime.UtcNow)
                return false;

            return true;
        }

        public bool ValidateResponsibleFor()
        {
            if (string.IsNullOrEmpty(ResponsibleFor))
                return false;

            if (ResponsibleFor.Length < 5 || ResponsibleFor.Length > 50)
                return false;

            return true;
        }

        public bool ValidateEmail()
        {
            if (string.IsNullOrEmpty(Email))
                return false;

            try
            {
                var addr = new System.Net.Mail.MailAddress(Email);
                return addr.Address == Email;
            }
            catch
            {
                return false;
            }
        }

        public bool ValidatePhone()
        {
            if (string.IsNullOrEmpty(Phone))
                return false;

            if (Phone.Length < 10 || Phone.Length > 11)
                return false;

            return true;
        }
    }
}
