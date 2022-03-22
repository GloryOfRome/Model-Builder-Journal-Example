using System.ComponentModel.DataAnnotations;

namespace Model_Builder_Journal_Example.Models
{
    public class Journal//日志
    {
        [Key]
        public string JournalNumber { get; set; }
        public string Tital { get; set; }
        public string Body { get; set; }

        //关系1
        //public User UserEditorNumber { get; set; }
        //public ICollection<User> UserEditors { get; set; }

        //关系2
        public string UserOwnerNumber { get; set; }
        public User UserOwner { get; set; }

        public ICollection<UserJournal> UserJournals { get; set; }

        //构造函数
        public Journal()
        {
            //UserEditors=new HashSet<User>();
            UserJournals = new HashSet<UserJournal>();
        }

    }
}
