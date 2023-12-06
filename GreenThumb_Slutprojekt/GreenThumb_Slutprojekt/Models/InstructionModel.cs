using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenThumb_Slutprojekt.Models
{
    public class InstructionModel
    {
        [Key]
        [Column("id")]
        public int InstructionId { get; set; }
        [Column("name")]
        public string? Name { get; set; }
        [Column("care_description")]
        public string CareDescription { get; set; } = null!;
        [Column("plant_id")]
        public int PlantId { get; set; }
        public PlantModel Plant { get; set; } = null!;



    }
}
