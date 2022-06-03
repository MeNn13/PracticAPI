using Practic.Models;
using System;

namespace Practic.Domain.ViewModels
{
    public class TimetableViewModel
    {
        public string Id { get; set; }
        public int Lesson { get; set; }
        public DateTime Date { get; set; }

        public string Subject { get; set; }
        public string User { get; set; }
        public ClassViewModel Class { get; set; }
        public int Classroom { get; set; }
    }
}
