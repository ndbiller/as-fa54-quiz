# AS - FA54 - Gruppe 2 - Quiz 

*Created by: [R. Krüger](mailto:krueger.rico@web.de), [A. Biller](mailto:andie.biller@gmail.com), [S. Pflüger](mailto:sev@erratic-ink.com)*  

---  

# Table of Contents

* [AS \- FA54 \- Gruppe 2 \- Quiz](#as---fa54---gruppe-2---quiz)
* [Table of Contents](#table-of-contents)
* [Documentation](#documentation)
  * [Project Outline](#project-outline)
  * [Contributor Roles](#contributor-roles)
  * [Kanban Board](#kanban-board)
  * [UML \- First Draft](#uml---first-draft)
  * [Software Design Pattern \- MVVM](#software-design-pattern---mvvm)
    * [Model Responsibilities](#model-responsibilities)
    * [View Responsibilities](#view-responsibilities)
    * [ViewModel Responsibilities](#viewmodel-responsibilities)
    * [Advantages](#advantages)
      * [Maintainability](#maintainability)
      * [Testability](#testability)
      * [Extensibility](#extensibility)
  * [Frontend Design](#frontend-design)
  * [Backend Development](#backend-development)
  * [Database Integration](#database-integration)
  * [Test Couverage](#test-couverage)
  * [Final Touches](#final-touches)
  * [Ergebnisprotokolle](#ergebnisprotokolle)
    * [Protokoll 1 \- 13\.02\.2017 \- 15\.02\.2017](#protokoll-1---13022017---15022017)
    * [Protokoll 2 \- 16\.02\.2017 \- 17\.02\.2017](#protokoll-2---16022017---17022017)
    * [Protokoll 3 \- 06\.03\.2017 \- 07\.03\.2017](#protokoll-3---06032017---07032017)
    * [Protokoll 4 \- 09\.03\.2017 \- 10\.03\.2017](#protokoll-4---09032017---10032017)
    * [Protokoll 5 \- 27\.03\.2017 \- 28\.03\.2017](#protokoll-5---27032017---28032017)
    * [Protokoll 6 \- 29\.03\.2017 \- 30\.03\.2017](#protokoll-6---29032017---30032017)
    * [Protokoll 7 \- 31\.03\.2017 \- 01\.04\.2017](#protokoll-7---31032017---01042017)
    * [Protokoll 8 \- 07\.04\.2017 \- 09\.04\.2017](#protokoll-8---07042017---09042017)
    * [Protokoll 9 \- 14\.04\.2017 \- 16\.04\.2017](#protokoll-9---14042017---16042017)
    * [Protokoll 10 \- 21\.04\.2017 \- 23\.04\.2017](#protokoll-10---21042017---23042017)
    * [Protokoll 11 \- 24\.04\.2017 \- 25\.04\.2017](#protokoll-11---24042017---25042017)
* [Project Workflow Guides](#project-workflow-guides)
  * [Kanban Board Workflow](#kanban-board-workflow)
  * [Git Workflow](#git-workflow)
  * [Continuous\-Integration\-Script / Updated Workflow](#continuous-integration-script--updated-workflow)
  * [Test\-Driven\-Development Workflow](#test-driven-development-workflow)
  * [Branch Cleanup Workflow](#branch-cleanup-workflow)
  * [Documentation Workflow](#documentation-workflow)
    * [Github Flavored Markdown](#github-flavored-markdown)
    * [Table\-Of\-Content\-Script](#table-of-content-script)
  * [Visual Studio Workflow / Shortcuts](#visual-studio-workflow--shortcuts)
    * [Console\.WriteLine() Shortcut](#consolewriteline-shortcut)
    * [Basic Constructor Shortcut](#basic-constructor-shortcut)
    * [Add Required Namespace Shortcut](#add-required-namespace-shortcut)
    * [Implement Interface Shortcut](#implement-interface-shortcut)
    * [Got More?](#got-more)
  * [Credits](#credits)

(*Created by [gh-md-toc](https://github.com/ekalinin/github-markdown-toc.go) because we can't be bothered with updating this table manually every time someone adds more stuff to the chapters here*)  

---  

# Documentation

## Project Outline

C# / WPF / MVVM / Windows - Quiz application with multiple choice questions to prepare students trying to get their drivers licence for sportboats in inland waters for their test. The project requirements can be found [here](/pdf/Lernsituation.pdf?raw=true).  

---  

## Contributor Roles

- [Rico Krüger](mailto:krueger.rico@web.de) - Datenbanken  
- [Andreas Biller](mailto:andie.biller@gmail.com) - Frontend  
- [Severin Pflüger](mailto:sev@erratic-ink.com) - Backend  

---  

## Kanban Board

The task management of our work on the project is done [here](https://github.com/ndbiller/as-fa54-quiz/projects/2). The workflow guidlines of our team for the use of the board, creating issues, working with github, pushing with continuous integration scripts, try test-driven-development, using markdown and some helpfull IDE shortcuts are listed at the [bottom](#project-workflow-guides) of this guide.  

---  

## UML - First Draft

![UML 1.1](/img/2017-02-14_uml.png?raw=true "UML 1.1")  

The first draft of our projects object relations was done quickly and without knowing the first thing about how to write a windows application, use embedded databases in C#, work with object oriented design patterns, use lambdas and delegates, how tho bind data to views or work as a team with separated responsibilities towards on a common codebase using github. Needles to say, it wasn't very good. Still, here's the [picture](/img/2017-02-13_uml.png) and here's the [file](/uml/2017-02-13_uml.dia). Made with [Dia](http://dia-installer.de/). The second first draft of our apps UML shown above was finished shortly thereafter. This draft was created from this simple textfile [here](/uml/2017-02-14_uml.txt) with the help of [PlantUML](http://plantuml.com/). Documentation for PlantUML can be found [here](http://plantuml.com/PlantUML_Language_Reference_Guide.pdf). Requires the [Java Runtime Environment](https://www.java.com/en/download/) and [Graphviz](http://www.graphviz.org/) to be installed on your system, but is well worth it. Give it a try sometimes.  

---  

## Software Design Pattern - MVVM

![MVVM design pattern](/img/MVVMPattern.png?raw=true "MVVM design pattern")  

We will use the [model-view-viewmodel design pattern](https://www.tutorialspoint.com/mvvm/index.htm) for our project. For a very short but good video tutorial that explains all the basic key elements involved in using MVVM with C# and WPF, go [here](https://www.youtube.com/watch?v=UgnSYx6iU8Y).  

---  

### Model Responsibilities

In general, model is the simplest one to understand. It is the client side data model that supports the views in the application.  

- It is composed of objects with properties and some variables to contain data in memory.  
- Some of those properties may reference other model objects and create the object graph which as a whole is the model objects.  
- Model objects should raise property change notifications which in WPF means data binding.  
- The last responsibility is validation which is optional, but you can embed the validation information on the model objects by using the WPF data binding validation features via interfaces like INotifyDataErrorInfo/IDataErrorInfo  

### View Responsibilities

The main purpose and responsibilities of views is to define the structure of what the user sees on the screen. The structure can contain static and dynamic parts.  

- Static parts are the XAML hierarchy that defines the controls and layout of controls that a view is composed of.  
- Dynamic part is like animations or state changes that are defined as part of the View.  
- The primary goal of MVVM is that there should be no code behind in the view.  
- It’s impossible that there is no code behind in view. In view you at least need the constructor and a call to initialize component.  
- The idea is that the event handling, action and data manipulation logic code shouldn’t be in the code behind in View.  
- There are also other kinds of code that have to go in the code behind any code that's required to have a reference to UI element is inherently view code.  

### ViewModel Responsibilities

ViewModel is the main point of MVVM application. The primary responsibility of the ViewModel is to provide data to the view, so that view can put that data on the screen.  

- It also allows the user to interact with data and change the data.  
- The other key responsibility of a ViewModel is to encapsulate the interaction logic for a view, but it does not mean that all of the logic of the application should go into ViewModel.  
- It should be able to handle the appropriate sequencing of calls to make the right thing happen based on user or any changes on the view.  
- ViewModel should also manage any navigation logic like deciding when it is time to navigate to a different view.  

---  

### Advantages

#### Maintainability

- A clean separation of different kinds of code should make it easier to go into one or several of those more granular and focused parts and make changes without worrying.  
- That means you can remain agile and keep moving out to new releases quickly.  

#### Testability

- With MVVM each piece of code is more granular and if it is implemented right your external and internal dependences are in separate pieces of code from the parts with the core logic that you would like to test.  
- That makes it a lot easier to write unit tests against a core logic.  
- Make sure it works right when written and keeps working even when things change in maintenance.  

#### Extensibility

- It sometimes overlaps with maintainability, because of the clean separation boundaries and more granular pieces of code.  
- You have a better chance of making any of those parts more reusable.  
- It has also the ability to replace or add new pieces of code that do similar things into the right places in the architecture.  

---  

## Frontend Design

**TODO:** Describe the design process from first view drafts to finished product and the many pitfalls along the way. Maybe elaborate, how little help our teacher was. Add lots of screenshot to make it look pretty.  

---  

## Backend Development

**TODO:** Write about our apps main model object relations and their development process. Also a good spot to add our apps updated class diagram and show how our app evolved from our first draft, once work on it is finally done.  

---  

## Database Integration

**TODO:** Write about the way we implement and how we query for the data in the embeded database we use. Show how we switch them and how we save our user data. Maybe some database alternatives we could have used.  

---  

## Test Couverage

**TODO:** Write about our projects test coverage, the framework used and give a short overview about CI/TDD and show some principles / best practices of test-driven-development and continuous integration here.  

---  

## Final Touches

**TODO:** Finish the documentation, link some sources and references, add some screenshots, spellcheck and proofread it, make a presentation, take a vacation... in short, get this shit done. And then move on to something that's more fun. And praise the sun!  

---  

## Ergebnisprotokolle

### Protokoll 1 - 13.02.2017 - 15.02.2017

**Protokollnummer:** | 1
--- | ---
**Klassenbezeichnung:** | FA54
**Gruppenname (Zahl):** | 2
**Datum:** | 13.02.2017 - 15.02.2017

**AS-Blöcke:**  
- [x] 13.02.2017  
- [x] 14.02.2017  
- [x] 15.02.2017   

**Diese Blöcke erledigte Aufgaben des Frontend-Entwicklers:** |
---|
**tasks**: Klassendiagramm erstellt, Klassendiagramm überarbeitet, Versionskontrolle eingerichtet, Git-Workflow festgelegt, Kanban-Board für Projekt erstellt, Projektrollen verteilt, Dokumentation und Protokollierung begonnen|

**Diese Blöcke erledigte Aufgaben des Backend-Entwicklers:** |
---|
**tasks**: Klassendiagramm erstellt, Versionskontrolle eingerichtet, Projektrollen verteilt, Aufgabenpackete festgelegt, Informationen zum Themengebiet gesammelt, Dokumentation und Protokollierung begonnen |

**Diese Blöcke erledigte Aufgaben des Datenbankspezialisten:** |
---|
**tasks**: Klassendiagramm erstellt, Versionskontrolle eingerichtet, Projektrollen verteilt, Aufgabenpackete festgelegt, Informationen zum Themengebiet gesammelt, Dokumentation und Protokollierung begonnen |

---  

### Protokoll 2 - 16.02.2017 - 17.02.2017

**Protokollnummer:** | 2
--- | ---
**Klassenbezeichnung:** | FA54
**Gruppenname (Zahl):** | 2
**Datum:** | 16.02.2017 - 17.02.2017

**AS-Blöcke:**   
- [x] 16.02.2017  
- [x] 17.02.2017  

**Diese Blöcke erledigte Aufgaben des Frontend-Entwicklers:** |
---|
**tasks**: Aufgabenpackete festgelegt, Informationen zum Themengebiet gesammelt, Dokumentation und Protokollierung fortgesetzt |

**Diese Blöcke erledigte Aufgaben des Backend-Entwicklers:** |
---|
**tasks**: Aufgabenpackete festgelegt, Informationen zum Themengebiet gesammelt, Dokumentation und Protokollierung fortgesetzt |

**Diese Blöcke erledigte Aufgaben des Datenbankspezialisten:** |
---|
**tasks**: Aufgabenpackete festgelegt, Informationen zum Themengebiet gesammelt, Dokumentation und Protokollierung fortgesetzt |

---  

### Protokoll 3 - 06.03.2017 - 07.03.2017

**Protokollnummer:** | 3
--- | ---
**Klassenbezeichnung:** | FA54
**Gruppenname (Zahl):** | 2
**Datum:** | 06.03.2017 - 07.03.2017

**AS-Blöcke:**  
- [x] 06.03.2017  
- [x] 07.03.2017   

**Diese Blöcke erledigte Aufgaben des Frontend-Entwicklers:** |
---|
**tasks**: Implementierung begonnen, View zur Ausgabe der Testklassen erstellt |

**Diese Blöcke erledigte Aufgaben des Backend-Entwicklers:** |
---|
**tasks**: Simple Quiz Auswertung, Zwei Fragen gemockt, um Solve() und Evaluate() zu testen |

**Diese Blöcke erledigte Aufgaben des Datenbankspezialisten:** |
---|
**tasks**: krank |


---  

### Protokoll 4 - 09.03.2017 - 10.03.2017

**Protokollnummer:** | 4
--- | ---
**Klassenbezeichnung:** | FA54
**Gruppenname (Zahl):** | 2
**Datum:** | 09.03.2017 - 10.03.2017

**AS-Blöcke:**  
- [x] 09.03.2017  
- [x] 10.03.2017  

**Diese Blöcke erledigte Aufgaben des Frontend-Entwicklers:** |
---|
**tasks**: Ausgabe der Testdaten im View, gitignore zur Vermeidung von Mergekonflikten angelegt, gitconfig für Aliase angelegt, Änderung der Protokolle von Wöchentlich auf alle 2 Tage |

**Diese Blöcke erledigte Aufgaben des Backend-Entwicklers:** |
---|
**tasks**: |

**Diese Blöcke erledigte Aufgaben des Datenbankspezialisten:** |
---|
**tasks**: Embedded Datenbank angelegt |

---  

### Protokoll 5 - 27.03.2017 - 28.03.2017

**Protokollnummer:** | 5
--- | ---
**Klassenbezeichnung:** | FA54
**Gruppenname (Zahl):** | 2
**Datum:** | 27.03.2017 - 28.03.2017

**AS-Blöcke:**  
- [x] 27.03.2017  
- [x] 28.03.2017  

**Diese Blöcke erledigte Aufgaben des Frontend-Entwicklers:** |
---|
**tasks**: Verbindung zu den Daten aus dem Backend herstellen, Datenausgabe im View, updated gitignore um mdf Datenbank in Github zu speichern, Eventhandling für Propertychanges in Quiz einbauen, view_test zur Erklärung von DataBinding und INotifyPropertyChanged für Teammitglieder erstellt |

**Diese Blöcke erledigte Aufgaben des Backend-Entwicklers:** |
---|
**tasks**: krank |

**Diese Blöcke erledigte Aufgaben des Datenbankspezialisten:** |
---|
**tasks**: |

---  

### Protokoll 6 - 29.03.2017 - 30.03.2017

**Protokollnummer:** | 6
--- | ---
**Klassenbezeichnung:** | FA54
**Gruppenname (Zahl):** | 2
**Datum:** | 29.03.2017 - 30.03.2017

**AS-Blöcke:**  
- [x] 29.03.2017  
- [x] 30.03.2017  

**Diese Blöcke zu erledigende Aufgaben des Frontend-Entwicklers:** |
---|
**tasks**: NUnit Test-Framework eingebunden, Datenbank wieder hinzugefügt, gitignore angepasst, Weitere Recherche: WPF, XAML Objects, Events, Actions, Delegates, ICommand, Data Binding, MVVM-Design Pattern |

**Diese Blöcke erledigte Aufgaben des Backend-Entwicklers:** |
---|
**tasks**: krank |

**Diese Blöcke erledigte Aufgaben des Datenbankspezialisten:** |
---|
**tasks**: |

---  

### Protokoll 7 - 31.03.2017 - 01.04.2017

**Protokollnummer:** | 7
--- | ---
**Klassenbezeichnung:** | FA54
**Gruppenname (Zahl):** | 2
**Datum:** | 31.03.2017 - 01.04.2017

**AS-Blöcke:**  
- [x] 31.03.2017  
- [x] 01.04.2017  

**Diese Blöcke erledigte Aufgaben des Frontend-Entwicklers:** |
---|
**tasks**: Questionaire View Page erstellt, View Pages in Main Window Frame anzeigen, Page Switch Methode implementiert, Quit Application Methode implementiert, Settings View Page erstellt, Start View Page erstellt, Fontawesome für Icons eingebunden, Project Files reorganized, Some View Bugfixes |

**Diese Blöcke erledigte Aufgaben des Backend-Entwicklers:** |
---|
**tasks**: krank |

**Diese Blöcke erledigte Aufgaben des Datenbankspezialisten:** |
---|
**tasks**: |

---  

### Protokoll 8 - 07.04.2017 - 09.04.2017  

**Protokollnummer:** | 8
--- | ---
**Klassenbezeichnung:** | FA54
**Gruppenname (Zahl):** | 2
**Datum:** | 07.04.2017 - 09.04.2017

**Wochenend-Blöcke:**  
- [x] 07.04.2017  
- [x] 08.04.2017  
- [x] 09.04.2017  

**Diese Blöcke erledigte Aufgaben des Frontend-Entwicklers:** |
---|
**tasks**: Results View Page erstellt, Question Data Binding zwischen View und Dummy Question Object im Backend hergestellt, Question View Model erstellt, Projektzustand erreicht, bei dem Teammitglieder ihre Fortschritte im View sehen können, Code kommentiert, Beispielprojekt entfernt |  

**Diese Blöcke erledigte Aufgaben des Backend-Entwicklers:** |
---|
**tasks**: |

**Diese Blöcke erledigte Aufgaben des Datenbankspezialisten:** |
---|
**tasks**: |

---  

### Protokoll 9 - 14.04.2017 - 16.04.2017  

**Protokollnummer:** | 9
--- | ---
**Klassenbezeichnung:** | FA54
**Gruppenname (Zahl):** | 2
**Datum:** | 14.04.2017 - 16.04.2017

**Wochenend-Blöcke:**  
- [x] 14.04.2017  
- [x] 15.04.2017  
- [x] 16.04.2017  

**Diese Blöcke erledigte Aufgaben des Frontend-Entwicklers:** |  
---|  
**tasks**: Antworten aus Liste anzeigen, Antwort Klasse aus Question.AnswerList im QuestionViewModel für ObservableCollection<Answer> hinzugefügt, Klasse User für Settings und History erstellt, Benutzereingaben aus dem View ans QuestionViewModel und dann von da aus an das Model und den User übergeben, Commands mit ICommand implementiert, Dokumentation erweitert |  

**Diese Blöcke erledigte Aufgaben des Backend-Entwicklers:** |  
---|  
**tasks**: |  

**Diese Blöcke erledigte Aufgaben des Datenbankspezialisten:** |  
---|  
**tasks**: |  

---  

### Protokoll 10 - 21.04.2017 - 23.04.2017  

**Protokollnummer:** | 10
--- | ---
**Klassenbezeichnung:** | FA54
**Gruppenname (Zahl):** | 2
**Datum:** | 21.04.2017 - 23.04.2017

**Wochenend-Blöcke:**  
- [ ] 21.04.2017  
- [ ] 22.04.2017  
- [ ] 23.04.2017  

**Diese Blöcke erledigte Aufgaben des Frontend-Entwicklers:** |
---|
**tasks**: |

**Diese Blöcke erledigte Aufgaben des Backend-Entwicklers:** |
---|
**tasks**: |

**Diese Blöcke erledigte Aufgaben des Datenbankspezialisten:** |
---|
**tasks**: |

**TODO:** |  
---|  
**tasks**: Funktionalität herstellen (Fragebogen wählen, Fragen aus Fragebogen generieren, Fragen vor u. zurück, Auswertung am Ende, Darstellung der History), User in Datei speichern, User aus Datei laden, Bilder im View einbinden, Push-Script zum Testen erstellen, Unit-Tests schreiben, Fragebögen aus Datenbank auslesen, Datenbank wechseln, Funktionalität der anderen Datenbank-Fragen in App herstellen, Test-Coverage für Dokumentation dokumentieren, Kanban-Board-Screenshot für Doku machen, Commit-History zeigen, neues UML-Diagramm der App erstellen, Doku beenden, Präsentation vorbereiten, Abgabedatum in Erfahrung bringen |  

---  

### Protokoll 11 - 24.04.2017 - 25.04.2017  

**Protokollnummer:** | 11
--- | ---
**Klassenbezeichnung:** | FA54
**Gruppenname (Zahl):** | 2
**Datum:** | 24.04.2017 - 25.04.2017

**AS-Blöcke:**  
- [ ] 24.04.2017  
- [ ] 25.04.2017    

**Diese Blöcke erledigte Aufgaben des Frontend-Entwicklers:** |
---|
**tasks**: |

**Diese Blöcke erledigte Aufgaben des Backend-Entwicklers:** |
---|
**tasks**: |

**Diese Blöcke erledigte Aufgaben des Datenbankspezialisten:** |
---|
**tasks**: |

---  

# Project Workflow Guides

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

---  

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

---  

## Continuous-Integration-Script / Updated Workflow

To work in this way you need to merge your changes locally into the local master and then push this updated master to the remote running the test suit in the process. Finish your changes in your local branch, switch to the local master, pull the remote master into it (to add all possible changes made by other members of the team), then merge your branch into your master and resolve all conflicts that may occur. Only then push your updated local master back to the remote master at github. If you know (or research) how to do this you should be good to go. If not, stick to the workflow described above.  
If you know what you are doing you may push your merged commits directly to the master if you are using the continuous integration script. This scrip will hook into the git push command and first run all the unit tests of our project and if a test fails (i. e. you broke something or the tests need to be improved further) will exit and stop the push. You then can try to fix either your code or the tests to push to the master, or you just check your changes out to a new branch and push that, so we all can have a look at the problem and try to fix it.  

---  

## Test-Driven-Development Workflow

**TODO:** Describe this better.

1. write a failing test  
2. write code/refactor it until test is green  
3. update tests or write another failing test for a new feature  
4. rinse and repeat   

---  

## Branch Cleanup Workflow

You can view all branching commits with a fancy ascii graph in your console with:  

```
git log --graph
```

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

---  

## Documentation Workflow 

### Github Flavored Markdown

Styling information for the README.md can be found [here](https://guides.github.com/features/mastering-markdown/#GitHub-flavored-markdown).  

---  

### Table-Of-Content-Script

You can create a new table of contents from the html-headers of the chapters in this `README.md` file in your console with the included golang script. Just execute it in your git bash by running:  

```
./gh-md-toc README.md
```

Then copy and paste the output into the space where the old Table sits, shift + tab it to the left side and save the updated `README.md` file. Then commit the changes to github.  

---  

## Visual Studio Workflow / Shortcuts

Make your life easier with these handy shortcuts while working in visual studio:  

### Console.WriteLine() Shortcut

Enter the following, followed by a double tab. You'll get a quick `Console.WriteLine();` for debugging your code. For our application you should rather use `Trace.WriteLine()` or `Debug.WriteLine()` and set a breakpoint on the same line, though.  

```
cw
```

### Basic Constructor Shortcut

Type the following, followed by a double tab to create a standard constructor for the class you currently write in.  

```
ctor
```

### Add Required Namespace Shortcut

Want to use a `private List<T> somename` without first looking up and including the needed collections namespace? Just write the name or command and when visual studio complains about it (with a red wiggly line under the word) press the following key combination (**control** and **dot**) to quickly open up and select from the quick actions menu. Do that by hitting **enter**. There's your `using System.Collections.Generic;`. And the compiler warning is gone.  

```
"CTRL" + "."
```

### Implement Interface Shortcut

Want to implement an interface in your class? Maybe inherit from `ICommand`? Just write its name next to the classname, like you would normally do. Then do the previous shortcut again and rid yourself of the initial compiler warning, adding the namespace. You're still not satisfied? Hit **control** and **dot** once more followed by **enter**. And thereyou are, your basic interface has methods, ready to throw `NotImplementedException()` exceptions. Pretty neat.  

```
"CTRL" + "."
```

### Got More?

I'm sure there's more. Feel free to also add your own favorite little time savers here, so all of us can share them.   

---  

## Credits

> “It's so quiet this high up, the feeling you get  
> is that you're one of those space monkeys.  
> You do the little job you're trained to do.  
> Pull a lever. Push a button.  
> You don't understand any of it, and then you just die.”  

**Chuck Palahniuk, Fight Club**  

---  
