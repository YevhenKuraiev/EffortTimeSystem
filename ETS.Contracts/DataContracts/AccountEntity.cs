namespace ETS.Contracts.DataContracts
{
    public class AccountEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string MiddleName { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public int AccessLevel { get; set; }

        public string NameSurname { get { return $"{Name} {Surname}"; } }
    }
}
