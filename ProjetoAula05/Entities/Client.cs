namespace ProjetoAula05.Entities
{
    public class Client
    {
        #region Attributes

        private Guid? _id;
        private string? _name;
        private string? _cpf;
        private Address? _address;

        #endregion

        #region Properties

        public Guid? Id;
        public string? Name;
        public string? Cpf;
        public Address? Address;

        #endregion
    }
}
