# Øvingsoppgave i WCF

Du skal lage en WCF service som kan liste opp og registrere nye problemer som må fikses i nabolaget ditt. Ta utgangspunkt i prosjektet som er vedlagt.

1. WCF Service
  1. Lag en ny WCF service med to servicemetoder. Disse skal henholdsvis registrere et nytt problem i nabolaget og returnere en liste med alle registrerte problemer.
  2. Start servicen i browseren.
	  
  *TIPS*: du kan lese og lagre til filen "data.txt" i App_Data-folderen ved å legge til linjen under i service-klassen din og bruke GetAll()- og Add()-metodene

  ```private Utilities.ProblemFileRepository repository = new Utilities.ProblemFileRepository("data.txt");```
  
2. Klient
	1. Lag en klient (website eller console-app) og legg til service referanse. Høyeklikk på servicereferansen og velg "view in object explorer" for å inspisere de genererte klassene.
	2. Legg til `DataContract`-attributt på `NeighbourhoodProblem`-klassen og `DataMember`-attributt på et par av attributtene, men ikke alle. Inspisér de genererte klassene i object explorer på nytt og legg merke til forskjellen fra tidligere.
	3. Bruk `DataMember`-attributter til å gjøre de viktigste feltene påkrevd.
	4. Test bruk av begge service-metodene.
	
3. Delte klasser
	1. Flytt filene `NeighbourhoodProblem` og `GeoLocation` til et nytt prosjekt av typen klassebibliotek. Legg til vanlige prosjektreferanser i både serviceprosjektet og klientprosjektet til det nye.
	2. Bygg servicen på nytt og oppdatér servicereferansen i klienten. Inspisér de genererte klassene i object explorer på nytt og legg merke til forskjellen fra tidligere.

4. Nyhetsfeed
	1. Lag en RSS-feed som returnerer alle problemene
	2. Lag en Atom-feed som gjør det samme
	3. Lag en feed som kan returnere både RSS og Atom
	
	*TIPS*: Artikkelen [WCF Syndication](https://msdn.microsoft.com/en-us/library/bb412202(v=vs.110).aspx) på MSDN bør være til god hjelp 
	
