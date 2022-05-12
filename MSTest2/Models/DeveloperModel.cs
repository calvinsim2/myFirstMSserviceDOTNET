using System.ComponentModel.DataAnnotations;

namespace MSTest2.Models
{
    public class DeveloperModel
    {
        [Key]
        public int DeveloperID { get; set; }

        public string DeveloperName { get; set; }
    }
}
