using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProject.Models.Entities
{
    [Table("User")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required(ErrorMessage = "E-mail address is required.")]
        [MaxLength(30)]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "E-mail address is invalid.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telephone number is required.")]
        [MaxLength(12)]
        [RegularExpression(@"^(?:(?:00)?549?)?0?(?:11|[2368]\d)(?:(?=\d{0,2}15)\d{2})??\d{8}$", ErrorMessage = "Telephone number is invalid.")]
        public string Telephone { get; set; }
    }
}
