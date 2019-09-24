# Testni zadatak - backend

## Struktura solutiona

Solution sadrži 2 projekta: Combis.Backend i Combis.Backend.Tests

Combis.Backend je strukturiran na sljedeći način:
	- Contracts (sučelja)
	- Controllers
	- Data (BLL)
	- DTO
	- Models
	- Utilities (sadrži klasu za rad s validacijama)

Combis.Backend.Tests je strukturiran na sljedeći način:
	- Utilities (priprema konteksta)
	- <Testovi>

## Tehnologije koje se koriste:

- ASP.NET Core Web API (.NET Core 2.2)
- PostgreSQL

## Paketi koji se koriste:

- AutoMapper
- FluentValidation
- Entity Framework Core
- Newtonsoft.Json
- Npgsql
- Serilog

## Rad sa aplikacijom

Za početak je potrebno u "Combis.Backend" otvoriti appsettings.json i u njemu podesiti:
	- "ConnectionStrings" -> "Default" (format je pripremljen, samo treba unijeti validne podatke)
	- "Serilog" -> "WriteTo" -> "Args" -> "pathFormat" (treba napisati ispravnu putanju do "log-{Date}.txt" datoteke u kojoj se zapisuju logovi)

Nakon toga potrebno je napraviti migraciju (u Package Manager Console napisati "add-migration" i unijeti proizvoljni naziv migracije),
te ažurirati bazu podataka (u Package Manager Console napisati "update-database").

Backend aplikaciju je obavezno potrebno pokrenuti prije frontend aplikacije.

