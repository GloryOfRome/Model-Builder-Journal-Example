namespace Model_Builder_Journal_Example.Models
{
    public class UserJournal
    {
        public int Id { get; set; }
        public string JournalNumber { get; set; }
        public Journal Journal { get; set; }
        public String UserEditorNumber { get; set; }
        public User UserEditor { get; set; }
    }
}
