# Building Energy Performance

Aplikácia je postavená na platforme ASP.NET Core s využitím renderovania na serveri prostredníctvom Razor Pages. Jej rozpracovanosť je len v počiatočnom stave. 
Je nevyhnutné nasadiť testy, prejsť na TDD a refaktoring existujúceho kódu. Počiatočné testy pre komunikáciu s databázou (integračné pre Application/StoreysCQR) už boli využité.
Prvé kroky refaktoringu viedli k úprave niektorých metód.
Metódy sú postupne modifikované na asynchrónne.


## Riešenie obsahuje 4 vrstvy (projekty):
1. Domain
2. Application
3. Infrastructur
4. WebUI.

plus

5. Piaty projekt - testovanie

## Vrstvy:
1. Domain (zadefinované modely):
   - Entities
   - Enums
   - Common – abstraktné referenčné typy record class
   
2. Application:
	- Common:
		- Interfaces – implementácia v samotnej vrstve Application a vo vrstve Infrastructure
		- Mappings: MappingProfile.cs
		- Models – modely Dto
		- HandleServices – služby pre vrstvu WebUI, konkrétne pre ošetrenie udalostí
	- Služby CQR pre kategórie Storeys, Spaces, BuildingElements, BuildingElementComponents, Layers, SpaceTemperatures, ThermalConductivityTable, ThermalResistanceTable:
		- Queries
		- Commands (Create, Edit, Delete)
		- pre Storeys – StoreyCommandValidator. Validácia bude doplnená aj pre ďalšie kategórie a pre viaceré bude neskôr uplatnený princíp DRY.
	- Dictionaries – slovník pre jazykové mutácie, v súčasnosti využitý len čiastočne
	- Main index – anglické názvy jednotlivých kategórií nahradené slovenskými
	- Dependencies – súčasťou sú i nasledovné Packages:
		- Automapper
		- Microsoft Entity Framework Core
		- Fluent Validation
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
	- wwwroot/js: Pre ošetrenie niektorých udalostí bolo vhodnejšie použitie kódovania v js a využite knižnice jQuery.


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
	
## Testovanie.
Testovanie je realizované prostredníctvom testovacieho framework-u MSTest a Moq.
