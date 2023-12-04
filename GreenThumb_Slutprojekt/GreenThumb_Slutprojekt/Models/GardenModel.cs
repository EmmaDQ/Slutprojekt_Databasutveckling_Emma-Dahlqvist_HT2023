using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenThumb_Slutprojekt.Models
{
    public class GardenModel
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; } = null!;
        public List<PlantModel> Plants { get; set; } = new();
        public UserModel UserModel { get; set; } = null!;
    }
}
