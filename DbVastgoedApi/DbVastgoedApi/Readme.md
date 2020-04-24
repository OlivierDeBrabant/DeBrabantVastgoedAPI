#DbVastgoedAPI
Deze api maakt connectie met de databank om de projecten en producten toe te voegen/ verwijderen/ aanpassen.

##Instalatie
Om de website werkend te krijgen moet er manueel een secret token toegevoegd worden.

..*Rechterklik op solutionnaam > Manage user secrets

```
{
  "Tokens": { "Key": " IfThisEndsUpInGithubYouFailTheClass" } 
}
```

##Aanmeldingsgegevens

..*Email = db@db.com
..*Wachtwoord = P@ssword1111

##Projecten
De website bestaat uit projecten. Ieder project is een verzameling van 1 of meerdere producten.
Een product is doorgaans een appartement of een huis.

##Administrator
Om aanpassingen te doen aan de database is er op de website een inlogfunctie voorzien. Ingelogde administrators kunnen:

..*Projecten toevoegen
..*Projecten aanpassen
..*Projecten verwijderen (samen met alle producten van dit project)

..*Producten toevoegen aan project
..*Producten aanpassen
..*Producten verwijderen

..*Nieuwe administrator aanmaken