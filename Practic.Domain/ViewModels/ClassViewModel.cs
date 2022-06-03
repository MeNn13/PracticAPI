using System.ComponentModel.DataAnnotations;

namespace Practic.Domain.ViewModels
{
    public class ClassViewModel
    {
        [Key]
        public int Number { get; set; }
        public string Letter { get; set; }
    }
}
