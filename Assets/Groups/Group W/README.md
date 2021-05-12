Im Folgenden finden sich TODOs und DONEs.

# TODOs
## Vorbereitungsmodus
### Auswahl der Waffe / des Ziels über entsprechende Tasten
Vorschlag Tastenbelegung (anhand Beispiel des WASD-Charakters)
* Q = Lego
* W = Paper
* E = Scissors
* R = Front row
* F = Back row

Das Standardprojekt hat bereits Tasten zum Laufen + Springen belegt. Umbelegen!


### Feedback für "Waffe ausgewählt" und "Ziel ausgewählt" (lokaler Gegner soll Auswahl nicht sehen können)
z.B. triggern einer entsprechenden Animation des Charakters.
Verfügbare Animationen finden sich in Assets/Packages/LEGO/Scripts/Lego Minifig/MinifigController.cs, enum SpecialAnimation.

Vorschlag:
* Waffe ausgewählt: Dance
* Ziel ausgewählt: Wave


## Kampfmodus
### Charaktere bekommen ausgewählte Waffen in die Hand gespawned
### Schadensverteilung entsprechend ausgewählter Waffen / Ziele
### Angriffsanimation
* Front: zu Gegner hinlaufen, angreifen
* Back: stehenbleiben, Fernkampfwaffe nutzen


## Environment
- Zusammenbasteln einer hübschen Umgebung
- Beleuchtung
- Waffen - Fernkampf + Nahkampf unterschiedlich

# DONEs
* Scenes, Scripts Ordner in unserem Group W Ordner angelegt
* Charaktere entsprechend der Kampfsituation plaziert
* Erstes simples Skript zum definieren von:
  * Maximaler / aktueller HP
  * auswählbaren Waffen / aktueller Waffe
  * möglicher Reihenplazierungen / aktueller Reihenplazierung
 * Timeranzeige (inkl. Beschreibung, in welcher Phase wir uns befinden, und was zu tun ist)
  * x Sek. bis Entscheidungsphase vorbei.
  * Wenn abgelaufen: Übergang zu Kampfphase
  * Hier gibt es einen Boolean der entscheidet, ob die Kampfphase vorbei ist; sollte vorbei sein, wenn alle Kampfanimationen vorbei sind und demnach über eine andere Komponente gesetzt werden, wenn wir soweit sind. Bis dahin: erstmal gleicher Zeitablauf wie in der Entscheidungsphase
