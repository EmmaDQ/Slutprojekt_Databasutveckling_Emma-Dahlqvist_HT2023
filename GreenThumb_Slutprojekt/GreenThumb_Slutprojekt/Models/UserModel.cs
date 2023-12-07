using EntityFrameworkCore.EncryptColumn.Attribute;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenThumb_Slutprojekt.Models
{
    public class UserModel
    {
        [Key]
        [Column("id")]
        public int UserId { get; set; }
        [Column("user_name")]
        public string UserName { get; set; } = null!;
        [Column("password")]
        [EncryptColumn]
        public string Password { get; set; } = null!;
        public GardenModel? Garden { get; set; }
    }
}
