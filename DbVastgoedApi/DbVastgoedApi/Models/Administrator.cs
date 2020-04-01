namespace DbVastgoedApi.Models
{
    public class Administrator
    {
        #region Properties
        public int AdministratorId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
        #endregion

        #region Constructor
        public Administrator() { }
        #endregion
    }
}
