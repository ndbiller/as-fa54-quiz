# AS - FA54 - Gruppe 2 - Quiz

Quiz with multiple choice questions to prepare students getting their driving licence for sportboats in inland waters.  

(C#, Mysql, Windows, Github)  

*Created by: [R. Krüger](mailto:krueger.rico@web.de), [A. Biller](mailto:andie.biller@gmail.com), [S. Pflüger](mailto:sev@erratic-ink.com)*  

---  

# Table of Contents

- [AS \- FA54 \- Gruppe 2 \- Quiz](#as---fa54---gruppe-2---quiz)
- [Table of Contents](#table-of-contents)
- [Documentation](#documentation)
  - [Project Outline](#project-outline)
  - [Contributor Roles](#contributor-roles)
  - [UML Drafts](#uml-drafts)
  - [Project Design Pattern](#project-design-pattern)
- [Ergebnisprotokolle](#ergebnisprotokolle)
  - [Protokoll 1 \- 13\.02\.2017 \- 15\.02\.2017](#protokoll-1---13022017---15022017)
  - [Protokoll 2 \- 16\.02\.2017 \- 17\.02\.2017](#protokoll-2---16022017---17022017)
  - [Protokoll 3 \- 06\.03\.2017 \- 07\.03\.2017](#protokoll-3---06032017---07032017)
  - [Protokoll 4 \- 09\.03\.2017 \- 10\.03\.2017](#protokoll-4---09032017---10032017)
  - [Protokoll 5 \- 27\.03\.2017 \- 28\.03\.2017](#protokoll-5---27032017---28032017)
- [Working with Git](#working-with-git)
  - [Kanban Board](#kanban-board)
  - [Kanban Board Workflow](#kanban-board-workflow)
  - [Git Workflow](#git-workflow)
  - [Cleanup](#cleanup)
  - [Github Flavored Markdown](#github-flavored-markdown)

*Created by [gh-md-toc](https://github.com/ekalinin/github-markdown-toc.go)*

---  

# Documentation

## Project Outline

The project requirements can be found [here](/pdf/Lernsituation.pdf?raw=true).  

## Contributor Roles

- Rico Krüger - Datenbanken  
- Andreas Biller - Frontend  
- Severin Pflüger - Backend  

## UML Drafts

The first draft of our object relations (*13.02.2017*). Can be found [here](/uml/2017-02-13_uml.dia). Created with [Dia](http://dia-installer.de/).  

![UML 1.0](/img/2017-02-13_uml.png?raw=true "UML 1.0")  

The second draft of our object relations (*14.02.2017*). Second draft of UML created from [2017-02-14_uml.txt](/uml/2017-02-14_uml.txt) with [PlantUML](http://plantuml.com/). Documentation can be found [here](http://plantuml.com/PlantUML_Language_Reference_Guide.pdf). Requires [Java Runtime Environment](https://www.java.com/en/download/) and [Graphviz](http://www.graphviz.org/) to be installed.  

![UML 1.1](/img/2017-02-14_uml.png?raw=true "UML 1.1")    

---  

We will use the [model-view-viewmodel design pattern](https://en.wikipedia.org/wiki/Model%E2%80%93view%E2%80%93viewmodel) for our project.  

![MVVM design pattern](/img/MVVMPattern.png?raw=true "MVVM design pattern")  

This is derived from the [model-view-controller design pattern](https://en.wikipedia.org/wiki/Model%E2%80%93view%E2%80%93controller).  

![MVC design pattern](/img/MVC-basic.svg.png?raw=true "MVC design pattern")  

---  

# Ergebnisprotokolle

## Protokoll 1 - 13.02.2017 - 15.02.2017

**Protokollnummer:** | 1
--- | ---
**Klassenbezeichnung:** | FA54
**Gruppenname (Zahl):** | 2
**Datum:** | 13.02.2017 - 15.02.2017

**AS-Blöcke:**  
- [x] 13.02.2017  
- [x] 14.02.2017  
- [x] 15.02.2017   

**Diese Woche erledigte Aufgaben des Frontend-Entwicklers:** |
---|
**tasks**: Klassendiagramm erstellt, Klassendiagramm überarbeitet, Versionskontrolle eingerichtet, Git-Workflow festgelegt, Kanban-Board für Projekt erstellt, Projektrollen verteilt, Dokumentation und Protokollierung begonnen|

**Diese Woche erledigte Aufgaben des Backend-Entwicklers:** |
---|
**tasks**: Klassendiagramm erstellt, Versionskontrolle eingerichtet, Projektrollen verteilt, Aufgabenpackete festgelegt, Informationen zum Themengebiet gesammelt, Dokumentation und Protokollierung begonnen |

**Diese Woche erledigte Aufgaben des Datenbankspezialisten:** |
---|
**tasks**: Klassendiagramm erstellt, Versionskontrolle eingerichtet, Projektrollen verteilt, Aufgabenpackete festgelegt, Informationen zum Themengebiet gesammelt, Dokumentation und Protokollierung begonnen |

---  

## Protokoll 2 - 16.02.2017 - 17.02.2017

**Protokollnummer:** | 2
--- | ---
**Klassenbezeichnung:** | FA54
**Gruppenname (Zahl):** | 2
**Datum:** | 16.02.2017 - 17.02.2017

**AS-Blöcke:**   
- [x] 16.02.2017  
- [x] 17.02.2017  

**Diese Woche erledigte Aufgaben des Frontend-Entwicklers:** |
---|
**tasks**: Aufgabenpackete festgelegt, Informationen zum Themengebiet gesammelt, Dokumentation und Protokollierung fortgesetzt |

**Diese Woche erledigte Aufgaben des Backend-Entwicklers:** |
---|
**tasks**: Aufgabenpackete festgelegt, Informationen zum Themengebiet gesammelt, Dokumentation und Protokollierung fortgesetzt |

**Diese Woche erledigte Aufgaben des Datenbankspezialisten:** |
---|
**tasks**: Aufgabenpackete festgelegt, Informationen zum Themengebiet gesammelt, Dokumentation und Protokollierung fortgesetzt |

---  

## Protokoll 3 - 06.03.2017 - 07.03.2017

**Protokollnummer:** | 3
--- | ---
**Klassenbezeichnung:** | FA54
**Gruppenname (Zahl):** | 2
**Datum:** | 06.03.2017 - 07.03.2017

**AS-Blöcke:**  
- [x] 06.03.2017  
- [x] 07.03.2017   

**Diese Woche erledigte Aufgaben des Frontend-Entwicklers:** |
---|
**tasks**: Implementierung begonnen, View zur Ausgabe der Testklassen erstellt |

**Diese Woche erledigte Aufgaben des Backend-Entwicklers:** |
---|
**tasks**: Simple Quiz Auswertung, Zwei Fragen gemockt, um Solve() und Evaluate() zu testen |

**Diese Woche erledigte Aufgaben des Datenbankspezialisten:** |
---|
**tasks**: krank |


---  

## Protokoll 4 - 09.03.2017 - 10.03.2017

**Protokollnummer:** | 4
--- | ---
**Klassenbezeichnung:** | FA54
**Gruppenname (Zahl):** | 2
**Datum:** | 09.03.2017 - 10.03.2017

**AS-Blöcke:**  
- [x] 09.03.2017  
- [x] 10.03.2017  

**Diese Woche erledigte Aufgaben des Frontend-Entwicklers:** |
---|
**tasks**: Ausgabe der Testdaten im View, gitignore zur Vermeidung von Mergekonflikten angelegt, gitconfig für Aliase angelegt, Änderung der Protokolle von Wöchentlich auf alle 2 Tage |

**Diese Woche erledigte Aufgaben des Backend-Entwicklers:** |
---|
**tasks**: |

**Diese Woche erledigte Aufgaben des Datenbankspezialisten:** |
---|
**tasks**: Embedded Datenbank angelegt |

---  

## Protokoll 5 - 27.03.2017 - 28.03.2017

**Protokollnummer:** | 5
--- | ---
**Klassenbezeichnung:** | FA54
**Gruppenname (Zahl):** | 2
**Datum:** | 27.03.2017 - 28.03.2017

**AS-Blöcke:**  
- [x] 27.03.2017  
- [x] 28.03.2017  

**Diese Woche erledigte Aufgaben des Frontend-Entwicklers:** |
---|
**tasks**: Verbindung zu den Daten aus dem Backend herstellen, Datenausgabe im View, updated gitignore um mdf Datenbank in Github zu speichern, Eventhandling für Propertychanges in Quiz einbauen, view_test zur Erklärung von DataBinding und INotifyPropertyChanged für Teammitglieder erstellt |

**Diese Woche erledigte Aufgaben des Backend-Entwicklers:** |
---|
**tasks**: krank |

**Diese Woche erledigte Aufgaben des Datenbankspezialisten:** |
---|
**tasks**: |

---  

## Protokoll 6 - 29.03.2017 - 30.03.2017

**Protokollnummer:** | 6
--- | ---
**Klassenbezeichnung:** | FA54
**Gruppenname (Zahl):** | 2
**Datum:** | 29.03.2017 - 30.03.2017

**AS-Blöcke:**  
- [x] 29.03.2017  
- [x] 30.03.2017  

**Diese Woche zu erledigende Aufgaben des Frontend-Entwicklers:** |
---|
**tasks**: NUnit Test-Framework eingebunden, Datenbank wieder hinzugefügt, gitignore angepasst, Weitere Recherche: WPF, XAML Objects, Events, Actions, Delegates, ICommand, Data Binding, MVVM-Design Pattern |

**Diese Woche erledigte Aufgaben des Backend-Entwicklers:** |
---|
**tasks**: krank |

**Diese Woche erledigte Aufgaben des Datenbankspezialisten:** |
---|
**tasks**: |

---  

## Protokoll 7 - 31.03.2017 - 01.04.2017

**Protokollnummer:** | 7
--- | ---
**Klassenbezeichnung:** | FA54
**Gruppenname (Zahl):** | 2
**Datum:** | 31.03.2017 - 01.04.2017

**AS-Blöcke:**  
- [x] 31.03.2017  
- [x] 01.04.2017  

**Diese Woche erledigte Aufgaben des Frontend-Entwicklers:** |
---|
**tasks**: Questionaire View erstellt, View Pages in Frame switch Method implementiert, Quit Method implementiert, Settings-View ertellt, Start View erstellt, Font für Icons eingebunden, Project Files reorganized, View Bugfixes |

**Diese Woche erledigte Aufgaben des Backend-Entwicklers:** |
---|
**tasks**: krank |

**Diese Woche erledigte Aufgaben des Datenbankspezialisten:** |
---|
**tasks**: |

---  

## Protokoll 8 - 07.04.2017 - 09.04.2017  

**Protokollnummer:** | 8
--- | ---
**Klassenbezeichnung:** | FA54
**Gruppenname (Zahl):** | 2
**Datum:** | 07.04.2017 - 09.04.2017

**Wochenend-Blöcke:**  
- [x] 07.04.2017  
- [ ] 08.04.2017  
- [ ] 09.04.2017  

**Diese Woche zu erledigende Aufgaben des Frontend-Entwicklers:** |
---|
**tasks**: TODO: Push-Script zum Testen erstellen, Unit-Tests schreiben, Commands implementieren, Implementierung von view_test in quiz, Data Binding in Views erstellen, Bilder einbinden, Bebnutzerdaten speichern, Fragen aus Datenbank auslesen, Test-Coverage für Dokumentation, Kanban-Board-Screenshot für Dokumentation |

**Diese Woche erledigte Aufgaben des Backend-Entwicklers:** |
---|
**tasks**: |

**Diese Woche erledigte Aufgaben des Datenbankspezialisten:** |
---|
**tasks**: |

---  

## Protokoll 9 - 14.04.2017 - 16.04.2017  

**Protokollnummer:** | 9
--- | ---
**Klassenbezeichnung:** | FA54
**Gruppenname (Zahl):** | 2
**Datum:** | 14.04.2017 - 16.04.2017

**Wochenend-Blöcke:**  
- [ ] 14.04.2017  
- [ ] 15.04.2017  
- [ ] 16.04.2017  

**Diese Woche erledigte Aufgaben des Frontend-Entwicklers:** |
---|
**tasks**: |

**Diese Woche erledigte Aufgaben des Backend-Entwicklers:** |
---|
**tasks**: |

**Diese Woche erledigte Aufgaben des Datenbankspezialisten:** |
---|
**tasks**: |

---  

## Protokoll 10 - 21.04.2017 - 23.04.2017  

**Protokollnummer:** | 10
--- | ---
**Klassenbezeichnung:** | FA54
**Gruppenname (Zahl):** | 2
**Datum:** | 21.04.2017 - 23.04.2017

**Wochenend-Blöcke:**  
- [ ] 21.04.2017  
- [ ] 22.04.2017  
- [ ] 23.04.2017  

**Diese Woche erledigte Aufgaben des Frontend-Entwicklers:** |
---|
**tasks**: |

**Diese Woche erledigte Aufgaben des Backend-Entwicklers:** |
---|
**tasks**: |

**Diese Woche erledigte Aufgaben des Datenbankspezialisten:** |
---|
**tasks**: |

---  

## Protokoll 11 - 24.04.2017 - 25.04.2017  

**Protokollnummer:** | 11
--- | ---
**Klassenbezeichnung:** | FA54
**Gruppenname (Zahl):** | 2
**Datum:** | 24.04.2017 - 25.04.2017

**AS-Blöcke:**  
- [ ] 24.04.2017  
- [ ] 25.04.2017    

**Diese Woche erledigte Aufgaben des Frontend-Entwicklers:** |
---|
**tasks**: |

**Diese Woche erledigte Aufgaben des Backend-Entwicklers:** |
---|
**tasks**: |

**Diese Woche erledigte Aufgaben des Datenbankspezialisten:** |
---|
**tasks**: |

---  

# Working with Git

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
- After reviewing the branch in the pull request is finished the card can be moved to **done**.  
- We'll regularly merge all pull requests for cards in done with the master adding the following to the merge message using the issue number like this #11 to reference and close it:
  ```
  fix <#issue>
  ```
- Then delete the merged branch, switch to the local master branch and pull the updated master to our local master branch.
- Now create a new working branch from the updated local master and start working on another issue.

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

The code will be reviewed by us regularly and if all is well and the tests were green the working branches will be merged into the master. Rinse and repeat.  

**Workflow-Update:** If you know what you are doing you may push your commits directly to the the master. To do this finish your changes in your branch, switch to the master, pull the remote master to add changes made by teammembers to it, then merge your branch into the master and resolve any conflicts that may occur. Then push the updated master back to github. If you know how to do this you should be good to go. If not, **google it** or ask someone who knows how to do it (*learning to work in a more efficient way with git*).  

## Cleanup

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

## Github Flavored Markdown

Styling information for the README.md can be found [here](https://guides.github.com/features/mastering-markdown/#GitHub-flavored-markdown).  

---  
