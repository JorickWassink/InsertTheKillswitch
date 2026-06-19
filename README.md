portofolio pagina: jorickwassink.github.io

Player behavior word omgeruild/toegevoegd doormiddel van de "joker" effecten in AddBurnJoker.cs, AddSlowJoker.cs en AddTazerJoker.cs

componenten worden meer dan 30x hergeberuikt doormiddel van de perks op de torens.
torens zelf hebben 16 combinaties van IShootable en IGetTarget.
Bullets kunnen in totaal 16 combinaties hebben van IBulletEffect.

Events worden gebruikt om componenten meer reusable te maken met de jokers.
Jokers gebruiken geen harde references en gebruiken alleen events om hun functie uit te werken.
Jokers kan je gemakkelijk vinden omdat ze allemaal de IJoker interface gebruiken