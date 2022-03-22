using System.ComponentModel.DataAnnotations;

namespace Model_Builder_Journal_Example.Models
{
    public class User
    {
        [Key]
        public string UserNumber { get; set; }
        public string FristName { get; set; }
        public ICollection<Journal> Journals { get; set; }
        public ICollection<UserJournal> UserJournals { get; set; }
        public User()
        {
            Journals = new HashSet<Journal>();
            UserJournals = new HashSet<UserJournal>();
        }
    }
}
