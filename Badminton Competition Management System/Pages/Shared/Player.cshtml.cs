namespace Badminton_Competition_Management_System.Pages.Shared
{
    public class PlayerModel
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get ; set; }
        public int FederationNumber { get; set; }

        public string GetGenderToString()
        {
            // return this.Gender ? "Male" : "Female"; Alternatieve oplossing ~ Onno
            if (this.Gender)
            {
                return "Male";
            }
            else
            {
                return "Female";
            }
            
        }
    }
}
