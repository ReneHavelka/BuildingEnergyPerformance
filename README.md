# Rozpracovaný projekt - Building Energy Performance

## Riešenie je  rozdelené na 4 vrstvy (projekty):
1. Domain
2. Application
3. Infrastructure
4. WebUI.

## Vrstvy:
1. Domain (zadefinované modely):
   - Entities
   - Enums
   - Common – abstraktné triedy kvôli prehľadnosti a princípu DRY
2. Application:
	- Common:
		- Interfaces – implementácia v samotnej vrstve Application a vo vrstve Infrastructure
		- Mappings: MappingProfile.cs
		- Models – modely Dto
		- Služby pre WebUI v priečínkoch StoreysCQR, SpacesCQR, a ďalšie, pozostávajúce z:
			- Queries
			- Commands (Create, Edit, Delete)
		- Dictionaries – slovník pre jazykové mutácie, v súčasnosti využitý len čiastočne
		- Dependencies – súčasťou sú i nasledovné Packages:
			- Automapper
			- Microsoft Entity Framework Core
			- ConfigureServices.cs – pre injektáž Automapper s MappingProfile do WebUI
3. Infrastructure:
	- Migration – pre vytvorenie a prípadnú modifikáciu databázy
	- Persistance: trieda ApplicationDBContext pre komunikáciu s externými zdrojmi (databázou)
	- Dependencies – súčasťou sú i nasledovné Packages:
		- Microsoft Entity Framework Core Design
		- Microsoft Entity Framework Core SqlServer
	- ConfigureServices.cs – pre injektáž ApplicationDbContext do WebUI
4. WebUI
	- Prezentačná vrstva – Razor Pages
	- wwwroot/js: script v js s knižnicou jQuery


## Závislosti:
1. Domain – žiadna
2. Application – len na Domain
3. Infrastructure – len na Application
4. WebUI – len na Application a Infrastructure (Závislosť na Infrastructure je len v Program.cs.)

## Kategórie s odpovedajúcimi referenciami v aplikácii:
	- Storeys: Podlažia
	- Spaces: Priestory
	- BuildingElements: Stavebné konštrukcie
	- BuildingElementComponents: Prvky stavebných konštrukcií
	- Layers: Vrstvy
	- SpaceTemperatures: Teploty v priestoroch
	- ThermalConductivityTable: Tabuľka tepelných vodivostí
	- ThermalResistanceTable: Tabuľka tepelných odporov
