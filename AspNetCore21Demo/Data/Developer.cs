using System.ComponentModel.DataAnnotations;

namespace AspNetCore21Demo.Data
{
    public class Developer
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        public string Skills { get; set; }
    }
}
