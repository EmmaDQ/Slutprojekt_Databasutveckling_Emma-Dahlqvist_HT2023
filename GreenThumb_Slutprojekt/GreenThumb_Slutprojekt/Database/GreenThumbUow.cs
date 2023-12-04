using GreenThumb_Slutprojekt.Models;

namespace GreenThumb_Slutprojekt.Database
{
    internal class GreenThumbUow
    {
        private readonly GreenThumbDbContext _context;

        public GreenThumbRepository<PlantModel> PlantRepo { get; }
        public GreenThumbRepository<InstructionModel> InstructionRepo { get; }
        public GreenThumbRepository<GardenModel> GardenRepo { get; }
        public GreenThumbRepository<UserModel> UserRepo { get; }

        public GreenThumbUow(GreenThumbDbContext context)
        {
            _context = context;
            PlantRepo = new(context);
            InstructionRepo = new(context);
            GardenRepo = new(context);
            UserRepo = new(context);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
