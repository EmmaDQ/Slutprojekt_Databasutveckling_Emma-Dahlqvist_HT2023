using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenThumb_Slutprojekt.Models
{
    public class PlantModel
    {
        [Key]
        [Column("id")]
        public int PlantId { get; set; }
        [Column("name")]
        public string Name { get; set; } = null!;
        public List<InstructionModel> Instructions { get; set; } = new();

        public List<GardenModel> Gardens { get; set; } = new();


    }
}
