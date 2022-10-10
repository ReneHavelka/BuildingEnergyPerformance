using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
	public partial class InitialCreate : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "SpaceTemperatures",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Temperature = table.Column<float>(type: "real", nullable: false),
					Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_SpaceTemperatures", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Storeys",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Storeys", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "ThermalConductivityTables",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Value = table.Column<float>(type: "real", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_ThermalConductivityTables", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "ThermalResistanceTable",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Value = table.Column<float>(type: "real", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_ThermalResistanceTable", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Spaces",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Temperature = table.Column<float>(type: "real", nullable: false),
					StoreysId = table.Column<int>(type: "int", nullable: false),
					Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Spaces", x => x.Id);
					table.ForeignKey(
						name: "FK_Spaces_Storeys_StoreysId",
						column: x => x.StoreysId,
						principalTable: "Storeys",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "BuildingElements",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					ContiguousSpaceId = table.Column<int>(type: "int", nullable: true),
					EffectiveArea = table.Column<float>(type: "real", nullable: false),
					ThermalResistance = table.Column<float>(type: "real", nullable: true),
					EmbededIn = table.Column<int>(type: "int", nullable: false),
					SpacesId = table.Column<int>(type: "int", nullable: false),
					Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_BuildingElements", x => x.Id);
					table.ForeignKey(
						name: "FK_BuildingElements_Spaces_SpacesId",
						column: x => x.SpacesId,
						principalTable: "Spaces",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "Layers",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Thickness = table.Column<float>(type: "real", nullable: true),
					ThermalConductivity = table.Column<float>(type: "real", nullable: true),
					ThermalResistance = table.Column<float>(type: "real", nullable: true),
					BuildingElementsId = table.Column<int>(type: "int", nullable: false),
					Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Layers", x => x.Id);
					table.ForeignKey(
						name: "FK_Layers_BuildingElements_BuildingElementsId",
						column: x => x.BuildingElementsId,
						principalTable: "BuildingElements",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_BuildingElements_SpacesId",
				table: "BuildingElements",
				column: "SpacesId");

			migrationBuilder.CreateIndex(
				name: "IX_Layers_BuildingElementsId",
				table: "Layers",
				column: "BuildingElementsId");

			migrationBuilder.CreateIndex(
				name: "IX_Spaces_StoreysId",
				table: "Spaces",
				column: "StoreysId");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "Layers");

			migrationBuilder.DropTable(
				name: "SpaceTemperatures");

			migrationBuilder.DropTable(
				name: "ThermalConductivityTables");

			migrationBuilder.DropTable(
				name: "ThermalResistanceTable");

			migrationBuilder.DropTable(
				name: "BuildingElements");

			migrationBuilder.DropTable(
				name: "Spaces");

			migrationBuilder.DropTable(
				name: "Storeys");
		}
	}
}
