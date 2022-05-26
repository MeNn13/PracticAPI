namespace Practic.Models
{
    public class Timetable
    {
        public string Id { get; set; }
        public string Date { get; set; }
        public int Lesson { get; set; }
        public Subject Subject { get; set; }
        public User User { get; set; }
        public Class Class { get; set; }
        public Classroom Classroom { get; set; }
    }
}
