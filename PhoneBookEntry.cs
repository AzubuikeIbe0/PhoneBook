using System.ComponentModel.DataAnnotations;

namespace PhoneBook
{
    public class PhoneBookEntry
    {
        [Key]
        public String Number { get; set; }

        [Required]
        public String Name { get; set; }

        [Required]
        public String Address { get; set; }

    }
}
