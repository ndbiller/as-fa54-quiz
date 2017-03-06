# AS - FA54 - Gruppe 2 - Quiz

Quiz with multiple choice questions to prepare students getting their driving licence for sportboats in inland waters.  

(C#, Mysql, Windows, Github)  

*Created by: [R. Krüger](mailto:krueger.rico@web.de), [A. Biller](mailto:andie.biller@gmail.com), [S. Pflüger](mailto:sev@erratic-ink.com)*  

## Project Outline

The project requirements can be found [here](/pdf/Lernsituation.pdf?raw=true).  

## Contributor Roles

- Rico Krüger - Datenbanken  
- Andreas Biller - Frontend  
- Severin Pflüger - Backend  

## Kanban Board

Manage your tasks [here](https://github.com/ndbiller/as-fa54-quiz/projects/2). 

## Kanban Board Workflow

- Create issues for tasks.  
- Add labels and assign someone to issues.  
- Add issues as cards to **new**.  
- Create a local working branch for an issue assigned to you.  
- Move the card to **in progress** when you work at it.  
- If your work is done, move the card to **test**.  
- Write some tests and test your code.  
- If a feature is reasonably tested, move the card to **review** and create a **pull request** for your branch.  
After reviewing the branch in the pull request is finished the card can be moved to **done**.  
We regularly merge all pull requests for cards in done with the master.  

Add the following to the **merge message** using the issue number to reference and close it:  

```
fix <#issue>
```

Then we **delete the merged branch**, **switch to the local master branch** and **pull the updated master** to our local master branch.  
Now **create a new working branch** from the updated local master and **start working on another issue**.  

## UML Drafts

![UML 1.0](/img/2017-02-13_uml.png?raw=true "UML 1.0")  

The first draft of our projects class relations. *13.02.2017*    

![UML 1.1](/img/2017-02-14_uml.png?raw=true "UML 1.1")  

The second draft of our projects class relations. *14.02.2017*  

Our very first draft of the UML can be found [here](/uml/2017-02-13_uml.dia). Created with [Dia](http://dia-installer.de/).  
Second draft of UML created from [2017-02-14_uml.txt](/uml/2017-02-14_uml.txt) with [PlantUML](http://plantuml.com/).  
Documentation can be found [here](http://plantuml.com/PlantUML_Language_Reference_Guide.pdf).  
Requires [Java Runtime Environment](https://www.java.com/en/download/) and [Graphviz](http://www.graphviz.org/) to be installed.  

## Project Design Pattern

![](/img/MVVMPattern.png?raw=true "MVVM design pattern")  

We will use the [model-view-viewmodel design pattern](https://en.wikipedia.org/wiki/Model%E2%80%93view%E2%80%93viewmodel) for our project.

![](/img/MVC-basic.svg.png?raw=true "MVC design pattern")  

This is derived from the [model-view-controller design pattern](https://en.wikipedia.org/wiki/Model%E2%80%93view%E2%80%93controller).  

## Git Workflow

Clone the project locally...  

```
git clone <url>
```

...or pull the master when new changes of a contributor have been merged to it. Make sure you are in your local master branch.  

```
git checkout master
git pull origin HEAD
```

Then check out a new working branch.  

```
git checkout -b <branchname>
```

Make your changes. Then add your changes to the working branch.  

```
git add --all
```

Now commit the changes and give a short description of what you have done in the message.  

```
git commit -m "<message>"
```

Then push the commit of your working branch to the project repository.  

```
git push origin HEAD
```

The code will be reviewed by us regularly and if all is well and the tests were green the working branches will be merged into the master.  
Rinse and repeat.  

## Git Cleanup

You can view all your local branches with:  

```
git branch
```

If you pull the recent master after your working branch has been merged, you can show merged local branches with:  

```
git branch --merged
```

And then you can delete merged local branches with:  

```
git branch -d <branchname>
```

If a working branch is obsolete but not merged with the master you can force-delete it with:  

```
git branch -D <branchname>
```

## Github Markdown

Styling information for the README.md can be found [here](https://guides.github.com/features/mastering-markdown/#GitHub-flavored-markdown).  

## Ergebnisprotokolle

### Protokoll 13.02.2017 - 17.02.2017

**Protokollnummer:** | 1
--- | ---
**Klassenbezeichnung:** | FA54
**Gruppenname (Zahl):** | 2
**Datum:** | 13.02.2017 - 17.02.2017

**AS-Blöcke:**  
- [x] 13.02.2017  
- [x] 14.02.2017  
- [x] 15.02.2017  
- [x] 16.02.2017  
- [x] 17.02.2017  

**Diese Woche erledigte Aufgaben des Frontend-Entwicklers:** |
---|
**tasks**: Klassendiagramm erstellt, Klassendiagramm überarbeitet, Versionskontrolle eingerichtet, Git-Workflow festgelegt, Kanban-Board für Projekt erstellt, Projektrollen verteilt, Aufgabenpackete festgelegt, Informationen zum Themengebiet gesammelt, Dokumentation und Protokollierung begonnen|

**Diese Woche erledigte Aufgaben des Backend-Entwicklers:** |
---|
**tasks**: Klassendiagramm erstellt, Versionskontrolle eingerichtet, Projektrollen verteilt, Aufgabenpackete festgelegt, Informationen zum Themengebiet gesammelt, Dokumentation und Protokollierung begonnen |

**Diese Woche erledigte Aufgaben des Datenbankspezialisten:**|
---|
**tasks**: Klassendiagramm erstellt, Versionskontrolle eingerichtet, Projektrollen verteilt, Aufgabenpackete festgelegt, Informationen zum Themengebiet gesammelt, Dokumentation und Protokollierung begonnen |


### Protokoll 06.03.2017 - 10.03.2017

**Protokollnummer:** | 2
--- | ---
**Klassenbezeichnung:** | FA54
**Gruppenname (Zahl):** | 2
**Datum:** | 06.03.2017 - 10.03.2017

**AS-Blöcke:**  
- [x] 06.03.2017  
- [ ] 07.03.2017  
- [ ] 08.03.2017 - **IHK Zwischenprüfung**  
- [ ] 09.03.2017  
- [ ] 10.03.2017  

**Diese Woche erledigte Aufgaben des Frontend-Entwicklers:** |
---|
**tasks**: Implementierung begonnen, Testklassen erstellt, View zur Ausgabe der Testklassen erstellt|

**Diese Woche erledigte Aufgaben des Backend-Entwicklers:** |
---|
**tasks**: Simple Quiz Auswertung, Zwei Fragen gemockt, um Solve() und Evaluate() zu testen|

**Diese Woche erledigte Aufgaben des Datenbankspezialisten:**|
---|
**tasks**: |
