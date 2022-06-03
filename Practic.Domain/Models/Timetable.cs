using Practic.Domain.ViewModels;
using Practic.Domain.ViewModels.User;
using System;

namespace Practic.Models
{
    public class Timetable
    {
        public string Id { get; set; }
        public DateTime Date_First { get; set; }
        public DateTime Date_Last { get; set; }
        public string Date { get; set; }
        public int Lesson { get; set; }

        public string Subject { get; set; }
        public string User { get; set; }
        public string Class { get; set; }
        public int Classroom { get; set; }
    }
}
