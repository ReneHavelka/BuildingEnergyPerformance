## Rozpracovaný projekt - Building Energy Performance

# Riešenie je  rozdelené na 4 vrstvy (projekty):
1. Domain
2. Application
3. Infrastructure
4. WebUI.

# Vrstvy:
1. Domain (zadefinované modely):
1.1. Entities
1.2. Enums
1.3. Common – abstraktné triedy kvôli prehľadnosti a princípu DRY
2. Application:
2.1. Common:
2.1.1. Interfaces – implementácia v samotnej vrstve Application a vo vrstve Infrastructure 
2.1.2. Mappings: MappingProfile.cs
2.1.3. Models – modely Dto
2.2. Služby pre WebUI v priečínkoch StoreysCQR, SpacesCQR, a ďalšie, pozostávajúce z:
2.2.1. Queries
2.2.2. Commands (Create, Edit, Delete)
2.3. Dictionaries – slovník pre jazykové mutácie, v súčasnosti využitý len čiastočne
2.4. Dependencies – súčasťou sú i nasledovné Packages:
2.4.1. Automapper
2.4.2. Microsoft Entity Framework Core
2.5. ConfigureServices.cs – pre injektáž Automapper s MappingProfile do WebUI
3. Infrastructure:
3.1. Migration – pre vytvorenie a prípadnú modifikáciu databázy
3.2. Persistance: trieda ApplicationDBContext pre komunikáciu s externými zdrojmi (databázou)
3.3. Dependencies – súčasťou sú i nasledovné Packages:
3.3.1. Microsoft Entity Framework Core Design
3.3.2. Microsoft Entity Framework Core SqlServer
3.4. ConfigureServices.cs – pre injektáž ApplicationDbContext do WebUI
4. WebUI
4.1. Prezentačná vrstva – Razor Pages
4.2. wwwroot/js: script v js s knižnicou jQuery


# Závislosti:
1. Domain – žiadna
2. Application – len na Domain
3. Infrastructure – len na Application
4. WebUI – len na Application a Infrastructure (Závislosť na Infrastructure je len v Program.cs.)

# Kategórie s odpovedajúcimi referenciami v aplikácii:
- Storeys: Podlažia
- Spaces: Priestory
- BuildingElements: Stavebné konštrukcie
- BuildingElementComponents: Prvky stavebných konštrukcií
- Layers: Vrstvy
- SpaceTemperatures: Teploty v priestoroch
- ThermalConductivityTable: Tabuľka tepelných vodivostí
- ThermalResistanceTable: Tabuľka tepelných odporov
