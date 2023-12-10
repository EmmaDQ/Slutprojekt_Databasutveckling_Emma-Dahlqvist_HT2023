using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenThumb_Slutprojekt.Migrations
{
    public partial class reboot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Instructions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    care_description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    plant_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructions", x => x.id);
                    table.ForeignKey(
                        name: "FK_Instructions_Plants_plant_id",
                        column: x => x.plant_id,
                        principalTable: "Plants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gardens",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gardens", x => x.id);
                    table.ForeignKey(
                        name: "FK_Gardens_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GardenPlants",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    garden_id = table.Column<int>(type: "int", nullable: false),
                    plant_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GardenPlants", x => x.id);
                    table.ForeignKey(
                        name: "FK_GardenPlants_Gardens_garden_id",
                        column: x => x.garden_id,
                        principalTable: "Gardens",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GardenPlants_Plants_plant_id",
                        column: x => x.plant_id,
                        principalTable: "Plants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Plants",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Rose" },
                    { 2, "Avocado" },
                    { 3, "Maple tree" },
                    { 4, "Broccoli" },
                    { 5, "Gages" },
                    { 6, "Ranunculus" },
                    { 7, "Loveage" },
                    { 8, "Salsify" },
                    { 9, "Ribes" },
                    { 10, "Asters" },
                    { 11, "Foxgloves" },
                    { 12, "Kniphofia" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "password", "user_name" },
                values: new object[] { 1, "iSG2P/e++yYRlkujpu84zA==", "user" });

            migrationBuilder.InsertData(
                table: "Gardens",
                columns: new[] { "id", "name", "user_id" },
                values: new object[] { 1, "Lovely garden", 1 });

            migrationBuilder.InsertData(
                table: "Instructions",
                columns: new[] { "id", "care_description", "name", "plant_id" },
                values: new object[,]
                {
                    { 1, "Roses are deep-rooted plants, so once they have settled in they can usually survive on the moisture naturally present in the soil. However, in hot, dry spells or in dry, sandy soils they may need additional water.", "Watering", 1 },
                    { 2, "Roses are hungry plants and will flower and grow better if given additional feed and mulched with well-rotted manure.", "Feeding", 1 },
                    { 3, "Avocado plants are best grown in containers in a warm, bright spot indoors. They can also be grown in a heated greenhouse.", "Positioning", 2 },
                    { 4, "Water regularly and generously in spring and summer, especially in hot, sunny spells. Reduce watering in winter. See our guide to watering.\r\n\r\nMake sure the \r\n\r\nCan refer to either home-made garden compost or seed/potting compost: • Garden compost is a soil improver made from decomposed plant waste, usually in a compost bin or heap. It is added to soil to improve its fertility, structure and water-holding capacity. Seed or potting composts are used for growing seedlings or plants in containers - a wide range of commercially produced peat-free composts are available, made from a mix of various ingredients, such as loam, composted bark, coir and sand, although you can mix your own.\r\n\r\ncompost is neither excessively wet nor completely dry. The leaves may curl up if the plant is overwatered, and may go brown and drop if underwatered.", "Watering and humidity", 2 },
                    { 5, "Water regularly in dry spells during the first two years to aid establishment, especially if planted in spring or later in the season.", "Watering", 3 },
                    { 6, "Trees in the open ground rarely need feeding. To prevent trees drying out, and to suppress weeds, \r\n\r\nMulch is a layer of material, at least 5cm (2in) thick, applied to the soil surface in late autumn to late winter (Nov-Feb). It is used to provide frost protection, improve plant growth by adding nutrients or increasing organic matter content, reducing water loss from the soil, for decorative purposes and suppressing weeds. Examples include well-rotted garden compost and manure, chipped bark, gravel, grit and slate chippings.\r\n\r\nmulch with a 10cm (4in) layer of garden \r\n\r\nCan refer to either home-made garden compost or seed/potting compost: • Garden compost is a soil improver made from decomposed plant waste, usually in a compost bin or heap. It is added to soil to improve its fertility, structure and water-holding capacity. Seed or potting composts are used for growing seedlings or plants in containers - a wide range of commercially produced peat-free composts are available, made from a mix of various ingredients, such as loam, composted bark, coir and sand, although you can mix your own.\r\n\r\ncompost or \r\n\r\nMulch is a layer of material, at least 5cm (2in) thick, applied to the soil surface in late autumn to late winter (Nov-Feb). It is used to provide frost protection, improve plant growth by adding nutrients or increasing organic matter content, reducing water loss from the soil, for decorative purposes and suppressing weeds. Examples include well-rotted garden compost and manure, chipped bark, gravel, grit and slate chippings.\r\n\r\nmulching bark. Just make sure the mulch doesn’t butt up to the trunk as this would cause it to rot.", "Feeding", 3 },
                    { 7, "Water broccoli \r\n\r\nA seedling is a young plant grown from seed.\r\n\r\nseedlings and young plants regularly until well established.\r\n\r\nAfter that, only water during dry weather, every fortnight or so, to avoid any check in their growth, which can lead to bolting (premature flowering). Take care not to overwater winter varieties, to ensure they cope well with lower temperatures.", "Watering", 4 },
                    { 8, "Broccoli is susceptible to all the usual brassica pests, so keep them protected at all times. Insect-proof mesh or fleece, supported on canes and pinned to the ground, should deter cabbage caterpillars, cabbage root fly and pigeons. See Problem solving, below, for more tips.", "Protecting from pests", 4 },
                    { 9, "Newly planted gages should be watered regularly for at least their first growing season. Once established, they usually only need watering during dry spells, especially in early to mid-summer when the fruit is swelling. Lack of water may cause the tree to shed young fruit. \r\n\r\nMulch is a layer of material, at least 5cm (2in) thick, applied to the soil surface in late autumn to late winter (Nov-Feb). It is used to provide frost protection, improve plant growth by adding nutrients or increasing organic matter content, reducing water loss from the soil, for decorative purposes and suppressing weeds. Examples include well-rotted garden compost and manure, chipped bark, gravel, grit and slate chippings.\r\n\r\nMulching (see below) will help to stop the soil drying out.\r\n\r\nTo get a successful crop from containerised trees, they must be watered on a regular basis throughout the growing season. The relatively small amount of potting \r\n\r\nCan refer to either home-made garden compost or seed/potting compost: • Garden compost is a soil improver made from decomposed plant waste, usually in a compost bin or heap. It is added to soil to improve its fertility, structure and water-holding capacity. Seed or potting composts are used for growing seedlings or plants in containers - a wide range of commercially produced peat-free composts are available, made from a mix of various ingredients, such as loam, composted bark, coir and sand, although you can mix your own.\r\n\r\ncompost will dry out quickly, especially in warm weather.", "Watering", 5 },
                    { 10, "Protecting from frost\r\nGages flower early, so the blossom is vulnerable to frost damage. With smaller trained trees, if frost is forecast during flowering, cover them temporarily in a tent of \r\n\r\nHorticultural fleece is a soft fibrous, translucent material, also known as a crop cover. It is laid over or around vulnerable plants to protect them against the weather (heavier grades of fleece give a about 2°C of protection from frost); pests and to help plants to grow in the warmer conditions underneath.\r\n\r\nhorticultural fleece or hessian, holding it away from the flowers with canes. Remove it during the day, to allow pollinators access.\r\n\r\nIf possible, move potted trees indoors for the night or into a sheltered spot if frosts are due during flowering.", "Protecting from frost", 5 },
                    { 11, "Remove flowers on alpine and border plants to encourage further flowering\r\nIf growing Persian buttercups (Ranunculus asiaticus) for the vase, cut the stems before the flowers are fully open and they should last 10-12 days", "Dead heading", 6 },
                    { 12, "Most ranunculus are hardy so don't need any special care over winter\r\nGrow Persian buttercups (Ranunculus asiaticus) in a cool greenhouse in winter", "Overwintering", 6 },
                    { 13, "Water newly planted lovage regularly for the first few months, until settled in and growing strongly.  \r\n\r\nLike its near-relative celery, lovage likes plenty of moisture in the soil, but not \r\n\r\nDescribes soil or potting compost that is saturated with water. The water displaces air from the spaces between soil particles and plant roots can literally drown, unless they are adapted to growing in waterlogged conditions. Waterlogging is common on poorly drained soil or when heavy soil is compacted. \r\n\r\nwaterlogged conditions. Plants may need additional watering in hot summer weather, especially if growing in full sun or free-draining soil.  ", "Watering", 7 },
                    { 14, "Keep young lovage plants weed-free, to reduce competition for light, water and nutrients. Once established, lovage generally forms a robust leafy clump that shades out any nearby weeds. \r\n\r\nGiven the chance, lovage is a prolific self-seeder. So weed out any unwanted \r\n\r\nA seedling is a young plant grown from seed.\r\n\r\nseedlings in early summer, before they get established, or pot them up and share them with friends. Remove the seedheads before they ripen if you want to prevent self-seeding. ", "Weeding", 7 },
                    { 15, "Water young \r\n\r\nA seedling is a young plant grown from seed.\r\n\r\nseedlings regularly if conditions are dry. Once established, salsify should only need watering in long dry spells, to prevent the roots splitting.\r\n \r\nIf growing salsify in a container, water regularly throughout the growing season.", "Watering", 8 },
                    { 16, "Salsify shouldn’t need any feeding.", "Feeding", 8 },
                    { 17, "Once established they are fairly drought tolerant and should not need watering.\r\nHowever, during very dry periods they may need additional water even when established. Signs of water stress are shrivelled leaves with brown edges and leaves falling off the plant.", "Watering", 9 },
                    { 18, "Ribes do not need regular feeding, but to encourage vigorous growth after pruning, plants can be fed annually in March/April, with a general purpose fertiliser such as Growmore or fish, blood and bone, or \r\n\r\nMulch is a layer of material, at least 5cm (2in) thick, applied to the soil surface in late autumn to late winter (Nov-Feb). It is used to provide frost protection, improve plant growth by adding nutrients or increasing organic matter content, reducing water loss from the soil, for decorative purposes and suppressing weeds. Examples include well-rotted garden compost and manure, chipped bark, gravel, grit and slate chippings.\r\n\r\nmulch with organic matter.", "Feeding", 9 },
                    { 19, "Asters in the ground\r\nWater well after planting. On free-draining soil or during prolonged dry spells, they will need additional water to keep the soil around the roots slightly moist, but not soggy. Aim to water well and occasionally, rather than little and often.\r\n\r\nThe height of an aster can vary from year to year according to the amount of water it has received.\r\n\r\nAsters in containers\r\nThese need more frequent watering than plants growing in the ground. Water as often as needed, which could be daily in hot weather. Try not to let the \r\n\r\nCan refer to either home-made garden compost or seed/potting compost: • Garden compost is a soil improver made from decomposed plant waste, usually in a compost bin or heap. It is added to soil to improve its fertility, structure and water-holding capacity. Seed or potting composts are used for growing seedlings or plants in containers - a wide range of commercially produced peat-free composts are available, made from a mix of various ingredients, such as loam, composted bark, coir and sand, although you can mix your own.\r\n\r\ncompost dry out, but do not let it get waterlogged for more than a day or two either.", "Watering", 10 },
                    { 20, "The majority of perennial asters are hardy throughout the UK and can withstand low temperatures. Most species and cultivars of Symphyotrichum can survive temperatures down to -20°C (-4°F).\r\n\r\nWinter wet is more likely to be a problem than cold.\r\n\r\nRemove annual Callistephus chinensis when they finish flowering in late autumn or leave overwinter. Add the old plants to your garden compost heaps. ", "Overwintering", 10 },
                    { 21, "Water newly planted foxgloves regularly for at least the first few months, to help them until their roots have spread out into the soil\r\n\r\nOnce established, foxgloves growing in soil that is rich in organic matter should only need watering in long dry spells in summer. Wilting large leaves are a good indicator that plants need a good long soak\r\n\r\nFoxgloves growing in containers need regular watering throughout the growing season, as the \r\n\r\nCan refer to either home-made garden compost or seed/potting compost: • Garden compost is a soil improver made from decomposed plant waste, usually in a compost bin or heap. It is added to soil to improve its fertility, structure and water-holding capacity. Seed or potting composts are used for growing seedlings or plants in containers - a wide range of commercially produced peat-free composts are available, made from a mix of various ingredients, such as loam, composted bark, coir and sand, although you can mix your own.\r\n\r\ncompost will dry out quickly, especially in summer. Aim to keep the compost slightly moist but never waterlogged", "Watering", 11 },
                    { 22, "The sturdy flower stems don’t generally require staking if the plant is in a sheltered spot, out of strong winds\r\n\r\nPlants in exposed sites and tall cultivars with larger blooms benefit from support, to prevent the spikes snapping. Use a bamboo \r\n\r\nA cane is a slender, straight, length of woody plant material, usually bamboo. Canes are primarily used as plant supports. The fruiting stems of blackberries, raspberries and hybrid berries (such as loganberries and tayberries) are also known as canes, so these crops are often referred to as cane fruit.\r\n\r\ncane and twine, or a wire support with a loop to hold the stem\r\n\r\nIf growing foxgloves for cut flower arrangements, tying the stem to a support will help to ensure the straight, upright flower spike that is often preferred", "Staking", 11 },
                    { 23, "During their first year, kniphofias will need the occasional thorough watering to keep the soil moist\r\n\r\nOnce settled in, they shouldn’t need watering except in prolonged dry spells\r\n\r\nSitting in waterlogged soil can cause the roots to rot, so check that the soil is dry to a depth of 15cm (6in) before watering", "Watering", 12 },
                    { 24, "To keep plants looking their best, deadhead after flowering. This also allows newer younger flower stems plenty of space to grow\r\n\r\nSimply cut the whole faded flower stem down at the base\r\n\r\nDeadheading also helps the plant to conserve energy, by stopping seed production. However, if you wish to collect seeds for sowing (see Propagation, below), then leave a few stems in place to set seed", "Deadheading", 12 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GardenPlants_garden_id",
                table: "GardenPlants",
                column: "garden_id");

            migrationBuilder.CreateIndex(
                name: "IX_GardenPlants_plant_id",
                table: "GardenPlants",
                column: "plant_id");

            migrationBuilder.CreateIndex(
                name: "IX_Gardens_user_id",
                table: "Gardens",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Instructions_plant_id",
                table: "Instructions",
                column: "plant_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GardenPlants");

            migrationBuilder.DropTable(
                name: "Instructions");

            migrationBuilder.DropTable(
                name: "Gardens");

            migrationBuilder.DropTable(
                name: "Plants");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
