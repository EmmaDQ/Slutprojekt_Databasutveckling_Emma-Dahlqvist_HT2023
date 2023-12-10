using EntityFrameworkCore.EncryptColumn.Extension;
using EntityFrameworkCore.EncryptColumn.Interfaces;
using EntityFrameworkCore.EncryptColumn.Util;
using GreenThumb_Slutprojekt.Manager;
using GreenThumb_Slutprojekt.Models;
using Microsoft.EntityFrameworkCore;

namespace GreenThumb_Slutprojekt.Database
{
    internal class GreenThumbDbContext : DbContext
    {
        private readonly IEncryptionProvider _provider;
        public GreenThumbDbContext()
        {
            _provider = new GenerateEncryptionProvider(KeyManager.GetEncryptionKey());
        }

        public DbSet<PlantModel> Plants { get; set; }
        public DbSet<InstructionModel> Instructions { get; set; }
        public DbSet<GardenModel> Gardens { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<GardenModelPlantModel> GardenPlants { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=GreenThumbDb;Trusted_Connection=True;");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.UseEncryption(_provider);


            /*modelBuilder.Entity<GardenModelPlantModel>()
                .HasKey(gp => new { gp.GPId });*/



            modelBuilder.Entity<PlantModel>()
                .HasData(
                new PlantModel()
                {
                    PlantId = 1,
                    Name = "Rose",
                },

                new PlantModel()
                {
                    PlantId = 2,
                    Name = "Avocado",
                },

                new PlantModel()
                {
                    PlantId = 3,
                    Name = "Maple tree",
                },

                new PlantModel()
                {
                    PlantId = 4,
                    Name = "Broccoli",
                },

                new PlantModel()
                {
                    PlantId = 5,
                    Name = "Gages",
                },

                new PlantModel()
                {
                    PlantId = 6,
                    Name = "Ranunculus",
                },

                new PlantModel()
                {
                    PlantId = 7,
                    Name = "Loveage",
                },

                new PlantModel()
                {
                    PlantId = 8,
                    Name = "Salsify",
                },

                new PlantModel()
                {
                    PlantId = 9,
                    Name = "Ribes",
                },

                new PlantModel()
                {
                    PlantId = 10,
                    Name = "Asters",
                },

                new PlantModel()
                {
                    PlantId = 11,
                    Name = "Foxgloves",
                },

                new PlantModel()
                {
                    PlantId = 12,
                    Name = "Kniphofia",
                }

                );


            modelBuilder.Entity<InstructionModel>()
                .HasData(
                new InstructionModel()
                {
                    InstructionId = 1,
                    Name = "Watering",
                    CareDescription = "Roses are deep-rooted plants, so once they have settled in they can usually survive on the moisture naturally present in the soil. However, in hot, dry spells or in dry, sandy soils they may need additional water.",
                    PlantId = 1
                },

                new InstructionModel()
                {
                    InstructionId = 2,
                    Name = "Feeding",
                    CareDescription = "Roses are hungry plants and will flower and grow better if given additional feed and mulched with well-rotted manure.",
                    PlantId = 1
                },

                new InstructionModel()
                {
                    InstructionId = 3,
                    Name = "Positioning",
                    CareDescription = "Avocado plants are best grown in containers in a warm, bright spot indoors. They can also be grown in a heated greenhouse.",
                    PlantId = 2
                },

                new InstructionModel()
                {
                    InstructionId = 4,
                    Name = "Watering and humidity",
                    CareDescription = "Water regularly and generously in spring and summer, especially in hot, sunny spells. Reduce watering in winter. See our guide to watering.\r\n\r\nMake sure the \r\n\r\nCan refer to either home-made garden compost or seed/potting compost: • Garden compost is a soil improver made from decomposed plant waste, usually in a compost bin or heap. It is added to soil to improve its fertility, structure and water-holding capacity. Seed or potting composts are used for growing seedlings or plants in containers - a wide range of commercially produced peat-free composts are available, made from a mix of various ingredients, such as loam, composted bark, coir and sand, although you can mix your own.\r\n\r\ncompost is neither excessively wet nor completely dry. The leaves may curl up if the plant is overwatered, and may go brown and drop if underwatered.",
                    PlantId = 2
                },

                new InstructionModel()
                {
                    InstructionId = 5,
                    Name = "Watering",
                    CareDescription = "Water regularly in dry spells during the first two years to aid establishment, especially if planted in spring or later in the season.",
                    PlantId = 3
                },

                new InstructionModel()
                {
                    InstructionId = 6,
                    Name = "Feeding",
                    CareDescription = "Trees in the open ground rarely need feeding. To prevent trees drying out, and to suppress weeds, \r\n\r\nMulch is a layer of material, at least 5cm (2in) thick, applied to the soil surface in late autumn to late winter (Nov-Feb). It is used to provide frost protection, improve plant growth by adding nutrients or increasing organic matter content, reducing water loss from the soil, for decorative purposes and suppressing weeds. Examples include well-rotted garden compost and manure, chipped bark, gravel, grit and slate chippings.\r\n\r\nmulch with a 10cm (4in) layer of garden \r\n\r\nCan refer to either home-made garden compost or seed/potting compost: • Garden compost is a soil improver made from decomposed plant waste, usually in a compost bin or heap. It is added to soil to improve its fertility, structure and water-holding capacity. Seed or potting composts are used for growing seedlings or plants in containers - a wide range of commercially produced peat-free composts are available, made from a mix of various ingredients, such as loam, composted bark, coir and sand, although you can mix your own.\r\n\r\ncompost or \r\n\r\nMulch is a layer of material, at least 5cm (2in) thick, applied to the soil surface in late autumn to late winter (Nov-Feb). It is used to provide frost protection, improve plant growth by adding nutrients or increasing organic matter content, reducing water loss from the soil, for decorative purposes and suppressing weeds. Examples include well-rotted garden compost and manure, chipped bark, gravel, grit and slate chippings.\r\n\r\nmulching bark. Just make sure the mulch doesn’t butt up to the trunk as this would cause it to rot.",
                    PlantId = 3
                },

                new InstructionModel()
                {
                    InstructionId = 7,
                    Name = "Watering",
                    CareDescription = "Water broccoli \r\n\r\nA seedling is a young plant grown from seed.\r\n\r\nseedlings and young plants regularly until well established.\r\n\r\nAfter that, only water during dry weather, every fortnight or so, to avoid any check in their growth, which can lead to bolting (premature flowering). Take care not to overwater winter varieties, to ensure they cope well with lower temperatures.",
                    PlantId = 4
                },

                new InstructionModel()
                {
                    InstructionId = 8,
                    Name = "Protecting from pests",
                    CareDescription = "Broccoli is susceptible to all the usual brassica pests, so keep them protected at all times. Insect-proof mesh or fleece, supported on canes and pinned to the ground, should deter cabbage caterpillars, cabbage root fly and pigeons. See Problem solving, below, for more tips.",
                    PlantId = 4
                },

                new InstructionModel()
                {
                    InstructionId = 9,
                    Name = "Watering",
                    CareDescription = "Newly planted gages should be watered regularly for at least their first growing season. Once established, they usually only need watering during dry spells, especially in early to mid-summer when the fruit is swelling. Lack of water may cause the tree to shed young fruit. \r\n\r\nMulch is a layer of material, at least 5cm (2in) thick, applied to the soil surface in late autumn to late winter (Nov-Feb). It is used to provide frost protection, improve plant growth by adding nutrients or increasing organic matter content, reducing water loss from the soil, for decorative purposes and suppressing weeds. Examples include well-rotted garden compost and manure, chipped bark, gravel, grit and slate chippings.\r\n\r\nMulching (see below) will help to stop the soil drying out.\r\n\r\nTo get a successful crop from containerised trees, they must be watered on a regular basis throughout the growing season. The relatively small amount of potting \r\n\r\nCan refer to either home-made garden compost or seed/potting compost: • Garden compost is a soil improver made from decomposed plant waste, usually in a compost bin or heap. It is added to soil to improve its fertility, structure and water-holding capacity. Seed or potting composts are used for growing seedlings or plants in containers - a wide range of commercially produced peat-free composts are available, made from a mix of various ingredients, such as loam, composted bark, coir and sand, although you can mix your own.\r\n\r\ncompost will dry out quickly, especially in warm weather.",
                    PlantId = 5
                },

                new InstructionModel()
                {
                    InstructionId = 10,
                    Name = "Protecting from frost",
                    CareDescription = "Protecting from frost\r\nGages flower early, so the blossom is vulnerable to frost damage. With smaller trained trees, if frost is forecast during flowering, cover them temporarily in a tent of \r\n\r\nHorticultural fleece is a soft fibrous, translucent material, also known as a crop cover. It is laid over or around vulnerable plants to protect them against the weather (heavier grades of fleece give a about 2°C of protection from frost); pests and to help plants to grow in the warmer conditions underneath.\r\n\r\nhorticultural fleece or hessian, holding it away from the flowers with canes. Remove it during the day, to allow pollinators access.\r\n\r\nIf possible, move potted trees indoors for the night or into a sheltered spot if frosts are due during flowering.",
                    PlantId = 5
                },

                new InstructionModel()
                {
                    InstructionId = 11,
                    Name = "Dead heading",
                    CareDescription = "Remove flowers on alpine and border plants to encourage further flowering\r\nIf growing Persian buttercups (Ranunculus asiaticus) for the vase, cut the stems before the flowers are fully open and they should last 10-12 days",
                    PlantId = 6
                },

                new InstructionModel()
                {
                    InstructionId = 12,
                    Name = "Overwintering",
                    CareDescription = "Most ranunculus are hardy so don't need any special care over winter\r\nGrow Persian buttercups (Ranunculus asiaticus) in a cool greenhouse in winter",
                    PlantId = 6
                },

                new InstructionModel()
                {
                    InstructionId = 13,
                    Name = "Watering",
                    CareDescription = "Water newly planted lovage regularly for the first few months, until settled in and growing strongly.  \r\n\r\nLike its near-relative celery, lovage likes plenty of moisture in the soil, but not \r\n\r\nDescribes soil or potting compost that is saturated with water. The water displaces air from the spaces between soil particles and plant roots can literally drown, unless they are adapted to growing in waterlogged conditions. Waterlogging is common on poorly drained soil or when heavy soil is compacted. \r\n\r\nwaterlogged conditions. Plants may need additional watering in hot summer weather, especially if growing in full sun or free-draining soil.  ",
                    PlantId = 7
                },

                new InstructionModel()
                {
                    InstructionId = 14,
                    Name = "Weeding",
                    CareDescription = "Keep young lovage plants weed-free, to reduce competition for light, water and nutrients. Once established, lovage generally forms a robust leafy clump that shades out any nearby weeds. \r\n\r\nGiven the chance, lovage is a prolific self-seeder. So weed out any unwanted \r\n\r\nA seedling is a young plant grown from seed.\r\n\r\nseedlings in early summer, before they get established, or pot them up and share them with friends. Remove the seedheads before they ripen if you want to prevent self-seeding. ",
                    PlantId = 7
                },

                new InstructionModel()
                {
                    InstructionId = 15,
                    Name = "Watering",
                    CareDescription = "Water young \r\n\r\nA seedling is a young plant grown from seed.\r\n\r\nseedlings regularly if conditions are dry. Once established, salsify should only need watering in long dry spells, to prevent the roots splitting.\r\n \r\nIf growing salsify in a container, water regularly throughout the growing season.",
                    PlantId = 8
                },

                new InstructionModel()
                {
                    InstructionId = 16,
                    Name = "Feeding",
                    CareDescription = "Salsify shouldn’t need any feeding.",
                    PlantId = 8
                },

                new InstructionModel()
                {
                    InstructionId = 17,
                    Name = "Watering",
                    CareDescription = "Once established they are fairly drought tolerant and should not need watering.\r\nHowever, during very dry periods they may need additional water even when established. Signs of water stress are shrivelled leaves with brown edges and leaves falling off the plant.",
                    PlantId = 9
                },

                new InstructionModel()
                {
                    InstructionId = 18,
                    Name = "Feeding",
                    CareDescription = "Ribes do not need regular feeding, but to encourage vigorous growth after pruning, plants can be fed annually in March/April, with a general purpose fertiliser such as Growmore or fish, blood and bone, or \r\n\r\nMulch is a layer of material, at least 5cm (2in) thick, applied to the soil surface in late autumn to late winter (Nov-Feb). It is used to provide frost protection, improve plant growth by adding nutrients or increasing organic matter content, reducing water loss from the soil, for decorative purposes and suppressing weeds. Examples include well-rotted garden compost and manure, chipped bark, gravel, grit and slate chippings.\r\n\r\nmulch with organic matter.",
                    PlantId = 9
                },

                new InstructionModel()
                {
                    InstructionId = 19,
                    Name = "Watering",
                    CareDescription = "Asters in the ground\r\nWater well after planting. On free-draining soil or during prolonged dry spells, they will need additional water to keep the soil around the roots slightly moist, but not soggy. Aim to water well and occasionally, rather than little and often.\r\n\r\nThe height of an aster can vary from year to year according to the amount of water it has received.\r\n\r\nAsters in containers\r\nThese need more frequent watering than plants growing in the ground. Water as often as needed, which could be daily in hot weather. Try not to let the \r\n\r\nCan refer to either home-made garden compost or seed/potting compost: • Garden compost is a soil improver made from decomposed plant waste, usually in a compost bin or heap. It is added to soil to improve its fertility, structure and water-holding capacity. Seed or potting composts are used for growing seedlings or plants in containers - a wide range of commercially produced peat-free composts are available, made from a mix of various ingredients, such as loam, composted bark, coir and sand, although you can mix your own.\r\n\r\ncompost dry out, but do not let it get waterlogged for more than a day or two either.",
                    PlantId = 10
                },

                new InstructionModel()
                {
                    InstructionId = 20,
                    Name = "Overwintering",
                    CareDescription = "The majority of perennial asters are hardy throughout the UK and can withstand low temperatures. Most species and cultivars of Symphyotrichum can survive temperatures down to -20°C (-4°F).\r\n\r\nWinter wet is more likely to be a problem than cold.\r\n\r\nRemove annual Callistephus chinensis when they finish flowering in late autumn or leave overwinter. Add the old plants to your garden compost heaps. ",
                    PlantId = 10
                },

                new InstructionModel()
                {
                    InstructionId = 21,
                    Name = "Watering",
                    CareDescription = "Water newly planted foxgloves regularly for at least the first few months, to help them until their roots have spread out into the soil\r\n\r\nOnce established, foxgloves growing in soil that is rich in organic matter should only need watering in long dry spells in summer. Wilting large leaves are a good indicator that plants need a good long soak\r\n\r\nFoxgloves growing in containers need regular watering throughout the growing season, as the \r\n\r\nCan refer to either home-made garden compost or seed/potting compost: • Garden compost is a soil improver made from decomposed plant waste, usually in a compost bin or heap. It is added to soil to improve its fertility, structure and water-holding capacity. Seed or potting composts are used for growing seedlings or plants in containers - a wide range of commercially produced peat-free composts are available, made from a mix of various ingredients, such as loam, composted bark, coir and sand, although you can mix your own.\r\n\r\ncompost will dry out quickly, especially in summer. Aim to keep the compost slightly moist but never waterlogged",
                    PlantId = 11
                },

                new InstructionModel()
                {
                    InstructionId = 22,
                    Name = "Staking",
                    CareDescription = "The sturdy flower stems don’t generally require staking if the plant is in a sheltered spot, out of strong winds\r\n\r\nPlants in exposed sites and tall cultivars with larger blooms benefit from support, to prevent the spikes snapping. Use a bamboo \r\n\r\nA cane is a slender, straight, length of woody plant material, usually bamboo. Canes are primarily used as plant supports. The fruiting stems of blackberries, raspberries and hybrid berries (such as loganberries and tayberries) are also known as canes, so these crops are often referred to as cane fruit.\r\n\r\ncane and twine, or a wire support with a loop to hold the stem\r\n\r\nIf growing foxgloves for cut flower arrangements, tying the stem to a support will help to ensure the straight, upright flower spike that is often preferred",
                    PlantId = 11
                },

                new InstructionModel()
                {
                    InstructionId = 23,
                    Name = "Watering",
                    CareDescription = "During their first year, kniphofias will need the occasional thorough watering to keep the soil moist\r\n\r\nOnce settled in, they shouldn’t need watering except in prolonged dry spells\r\n\r\nSitting in waterlogged soil can cause the roots to rot, so check that the soil is dry to a depth of 15cm (6in) before watering",
                    PlantId = 12
                },

                new InstructionModel()
                {
                    InstructionId = 24,
                    Name = "Deadheading",
                    CareDescription = "To keep plants looking their best, deadhead after flowering. This also allows newer younger flower stems plenty of space to grow\r\n\r\nSimply cut the whole faded flower stem down at the base\r\n\r\nDeadheading also helps the plant to conserve energy, by stopping seed production. However, if you wish to collect seeds for sowing (see Propagation, below), then leave a few stems in place to set seed",
                    PlantId = 12
                }

                );


            modelBuilder.Entity<UserModel>()
                .HasData(
                new UserModel()
                {
                    UserId = 1,
                    UserName = "user",
                    Password = "password"

                });

            modelBuilder.Entity<GardenModel>()
                .HasData(
                new GardenModel()
                {
                    GardenId = 1,
                    Name = "Lovely garden",
                    UserId = 1
                }

                );




        }
    }



}
