Im Folgenden finden sich TODOs und DONEs.

# TODOs
## Vorbereitungsmodus
* Anzeige HP-Balken der Charaktere

## Kampfmodus
### Charaktere bekommen ausgewählte Waffen in die Hand gespawned
* Methode/Funktion mit folgendem Verhalten:
	* eine Reihe (Front/Back) und einen Waffentyp (Lego/Paper/Scissors) als Parameter entgegen nehmen
		*  für entsprechende Enums, siehe PlayerProperties.cs
	* der entsprechende Charakter, an dem das Script attached ist, sollte dann (visuell) die entsprechende Waffe in die Hand gelegt bekommen
		* Waffe sollte sich bei Bewegung des Charakters mitbewegen
### Schadensverteilung entsprechend ausgewählter Waffen / Ziele
### Angriffsanimation
* Front: zu Gegner hinlaufen, angreifen
* Back: stehenbleiben, Fernkampfwaffe nutzen
* Anzeige des Schadens, Update der HP-Balken


## Environment
- Zusammenbasteln einer hübschen Umgebung
- Beleuchtung
- Waffen - Fernkampf + Nahkampf unterschiedlich

# DONEs Larissa
* Scenes, Scripts Ordner in unserem Group W Ordner angelegt
* Charaktere entsprechend der Kampfsituation plaziert
* PlayerProperties Skript zum definieren von:
  * Maximaler / aktueller HP
  * möglicher Reihenpositionen / aktueller Reihenposition
  * auswählbaren Waffen / aktueller Waffe
	* kann nun über enstprechende Tastenbelegung während Decision Phase gesetzt werden
  * auswählbaren Ziel-Reihenpositionen / aktuell ausgewählte Ziel-Reihenposition
	* kann nun über enstprechende Tastenbelegung während Decision Phase gesetzt werden

 * Timeranzeige (inkl. Beschreibung, in welcher Phase wir uns befinden, und was zu tun ist)
  * x Sek. bis Entscheidungsphase vorbei.
  * Wenn abgelaufen: Übergang zu Action Phase
  * Hier gibt es einen Boolean der entscheidet, ob die Kampfphase vorbei ist; sollte vorbei sein, wenn alle Kampfanimationen vorbei sind und demnach über eine andere Komponente gesetzt werden, wenn wir soweit sind. Bis dahin: erstmal gleicher Zeitablauf wie in der Entscheidungsphase
  * Auswahl der Waffe / des Ziels über entsprechende Tasten. Standard-Tastenbelegung wurde ausgetauscht.
	* Tastenbelegung (anhand Beispiel des WASD-Charakters)
	* Q = Lego
	* W = Paper
	* E = Scissors
	* R = Front row
	* F = Back row
* Feedback für "Waffe ausgewählt" und "Ziel ausgewählt" (lokaler Gegner soll Auswahl nicht sehen können!)
	* Feedback über triggern einer entsprechenden Animation des Charakters.
	* Verfügbare Animationen finden sich in Assets/Packages/LEGO/Scripts/Lego Minifig/MinifigController.cs, enum SpecialAnimation.
	* Wenn in Decision Phase:
		* Waffe ausgewählt: Dance
		* Ziel ausgewählt: Wave
	* Wenn in Action Phase:
		* Waffe/Ziel ausgwählt: IdleImpatient

# DONEs Polina
* ?