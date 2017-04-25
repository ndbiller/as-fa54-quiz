/****** Object:  Table [db_ddladmin].[T_Fragebogen_Funk_UBI]    Script Date: 12.02.2017 11:30:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [db_ddladmin].[T_Fragebogen_Funk_UBI](
	[FragebogenNr] [int] NOT NULL,
	[F_id_Funk_UBI] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [db_ddladmin].[T_Funk_UBI]    Script Date: 12.02.2017 11:30:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [db_ddladmin].[T_Funk_UBI](
	[Id] [int] NOT NULL,
	[Frage] [varchar](500) NULL,
	[AntwortA] [varchar](500) NULL,
	[AntwortB] [varchar](500) NULL,
	[AntwortC] [varchar](500) NULL,
	[AntwortD] [varchar](500) NULL,
	[RichtigeAntwort] [char](1) NULL
) ON [PRIMARY]

GO
INSERT [db_ddladmin].[T_Fragebogen_Funk_UBI] ([FragebogenNr], [F_id_Funk_UBI]) VALUES (1, 1)
INSERT [db_ddladmin].[T_Fragebogen_Funk_UBI] ([FragebogenNr], [F_id_Funk_UBI]) VALUES (1, 5)
INSERT [db_ddladmin].[T_Fragebogen_Funk_UBI] ([FragebogenNr], [F_id_Funk_UBI]) VALUES (1, 7)
INSERT [db_ddladmin].[T_Fragebogen_Funk_UBI] ([FragebogenNr], [F_id_Funk_UBI]) VALUES (1, 13)
INSERT [db_ddladmin].[T_Fragebogen_Funk_UBI] ([FragebogenNr], [F_id_Funk_UBI]) VALUES (1, 18)
INSERT [db_ddladmin].[T_Fragebogen_Funk_UBI] ([FragebogenNr], [F_id_Funk_UBI]) VALUES (1, 26)
INSERT [db_ddladmin].[T_Fragebogen_Funk_UBI] ([FragebogenNr], [F_id_Funk_UBI]) VALUES (1, 28)
INSERT [db_ddladmin].[T_Fragebogen_Funk_UBI] ([FragebogenNr], [F_id_Funk_UBI]) VALUES (1, 36)
INSERT [db_ddladmin].[T_Fragebogen_Funk_UBI] ([FragebogenNr], [F_id_Funk_UBI]) VALUES (1, 39)
INSERT [db_ddladmin].[T_Fragebogen_Funk_UBI] ([FragebogenNr], [F_id_Funk_UBI]) VALUES (1, 50)
INSERT [db_ddladmin].[T_Fragebogen_Funk_UBI] ([FragebogenNr], [F_id_Funk_UBI]) VALUES (1, 55)
INSERT [db_ddladmin].[T_Fragebogen_Funk_UBI] ([FragebogenNr], [F_id_Funk_UBI]) VALUES (1, 62)
INSERT [db_ddladmin].[T_Fragebogen_Funk_UBI] ([FragebogenNr], [F_id_Funk_UBI]) VALUES (1, 64)
INSERT [db_ddladmin].[T_Fragebogen_Funk_UBI] ([FragebogenNr], [F_id_Funk_UBI]) VALUES (1, 73)
INSERT [db_ddladmin].[T_Fragebogen_Funk_UBI] ([FragebogenNr], [F_id_Funk_UBI]) VALUES (1, 80)
INSERT [db_ddladmin].[T_Fragebogen_Funk_UBI] ([FragebogenNr], [F_id_Funk_UBI]) VALUES (1, 84)
INSERT [db_ddladmin].[T_Fragebogen_Funk_UBI] ([FragebogenNr], [F_id_Funk_UBI]) VALUES (1, 91)
INSERT [db_ddladmin].[T_Fragebogen_Funk_UBI] ([FragebogenNr], [F_id_Funk_UBI]) VALUES (1, 101)
INSERT [db_ddladmin].[T_Fragebogen_Funk_UBI] ([FragebogenNr], [F_id_Funk_UBI]) VALUES (1, 109)
INSERT [db_ddladmin].[T_Fragebogen_Funk_UBI] ([FragebogenNr], [F_id_Funk_UBI]) VALUES (1, 111)
INSERT [db_ddladmin].[T_Fragebogen_Funk_UBI] ([FragebogenNr], [F_id_Funk_UBI]) VALUES (1, 124)
INSERT [db_ddladmin].[T_Fragebogen_Funk_UBI] ([FragebogenNr], [F_id_Funk_UBI]) VALUES (1, 130)
INSERT [db_ddladmin].[T_Fragebogen_Funk_UBI] ([FragebogenNr], [F_id_Funk_UBI]) VALUES (1, 0)
INSERT [db_ddladmin].[T_Funk_UBI] ([Id], [Frage], [AntwortA], [AntwortB], [AntwortC], [AntwortD], [RichtigeAntwort]) VALUES (1, N'Was ist Binnenschifffahrtsfunk?', N'Internationaler mobiler UKW/VHF- Sprechfunkdienst auf Binnenschifffahrtsstraßen', N'Nationales UKW/VHF-Sprechfunkverfahren im Binnenbereich', N'Nationaler mobiler UKW/VHF-Sprechfunkdienst auf Binnenschifffahrtsstraßen', N'Internationales UKW/VHF-Sprechfunkverfahren im Binnenbereich', N'A')
INSERT [db_ddladmin].[T_Funk_UBI] ([Id], [Frage], [AntwortA], [AntwortB], [AntwortC], [AntwortD], [RichtigeAntwort]) VALUES (5, N'Was ist eine "Revierzentrale"?', N'Zentrale Landfunkstelle', N'Zentrale Telematikdienste', N'Zentrale Schiffsfunkstelle', N'Zentrale Seefunkstelle', N'A')
INSERT [db_ddladmin].[T_Funk_UBI] ([Id], [Frage], [AntwortA], [AntwortB], [AntwortC], [AntwortD], [RichtigeAntwort]) VALUES (7, N'Was ist ein "Blockkanal"?', N'Funkkanal für sicherheitsrelevante Meldungen der Verkehrsposten und Schiffsfunkstellen in den Niederlanden', N'Funkkanal für öffentlichen Nachrichtenaustausch zwischen den Verkehrsposten in den Niederlanden', N'Funkkanal für Routinegespräche der Verkehrsposten und Schiffsfunkstellen in den Niederlanden', N'Gesperrter Funkkanal der Verkehrsposten und Verkehrszentralen in den Niederlanden', N'A')
INSERT [db_ddladmin].[T_Funk_UBI] ([Id], [Frage], [AntwortA], [AntwortB], [AntwortC], [AntwortD], [RichtigeAntwort]) VALUES (13, N'Welches Funkzeugnis berechtigt nicht zur Teilnahme am Binnenschifffahrtsfunk?', N'Amateurfunkzeugnis', N'Beschränkt gültiges Betriebszeugnis für Funker I (BZ I)', N'UKW-Sprechfunkzeugnis für den Binnenschifffahrtsfunk (UBI)', N'Allgemeines Sprechfunkzeugnis für den Seefunkdienst', N'A')
INSERT [db_ddladmin].[T_Funk_UBI] ([Id], [Frage], [AntwortA], [AntwortB], [AntwortC], [AntwortD], [RichtigeAntwort]) VALUES (18, N'Das Abhörverbot und das Fernmeldegeheimnis sind geregelt…', N'im Telekommunikationsgesetz (TKG)', N'
in der Schiffssicherheitsverordnung (SchSV)', N'
in der Binnenschifffahrt-Sprechfunkverordnung (BinSchSprFunkV)', N'im Gesetz über Funkanlagen und Telekommunikationsendeinrichtungen (FTEG)', N'A')
INSERT [db_ddladmin].[T_Funk_UBI] ([Id], [Frage], [AntwortA], [AntwortB], [AntwortC], [AntwortD], [RichtigeAntwort]) VALUES (26, N'Was ist eine "Seefunkstelle"?', N'Funkstelle des Mobilen Seefunkdienstes an Bord eines nicht dauernd verankerten Seefahrzeuges', N'Funkstelle des Binnenschifffahrtsfunks, die im Seebereich an Bord eines Seeschiffes betrieben wird', N'Funkstelle des Mobilen Seefunkdienstes, die im Verkehrskreis Nautische Information betrieben wird', N'Funkstelle des Mobilen Seefunkdienstes, die an Land als Küstenfunkstelle betrieben wird', N'A')
INSERT [db_ddladmin].[T_Funk_UBI] ([Id], [Frage], [AntwortA], [AntwortB], [AntwortC], [AntwortD], [RichtigeAntwort]) VALUES (28, N'Wer stellt in Deutschland die Frequenzzuteilungsurkunde für eine Schiffsfunkstelle aus?', N'Bundesnetzagentur (BNetzA)', N'
Wasser- und Schifffahrtsamt (WSA)', N'Wasser- und Schifffahrtsdirektion (WSD)', N'Fachstelle der WSV für Verkehrstechniken (FVT)', N'A')
INSERT [db_ddladmin].[T_Funk_UBI] ([Id], [Frage], [AntwortA], [AntwortB], [AntwortC], [AntwortD], [RichtigeAntwort]) VALUES (36, N'Welche Teile des Handbuchs Binnenschifffahrtsfunk müssen bei einer Schiffsfunkstelle mitgeführt werden?', N'Allgemeiner Teil sowie Regionale Teile für die Strecken, in denen die Schiffsfunkstelle am Binnenschifffahrtsfunk teilnimmt', N'Regionale Teile für alle europäischen Wasserstraßen', N'Allgemeiner Teil sowie Regionale Teile des Landes, in dem die Schiffsfunkstelle angemeldet wurde', N'Regionale Teile für die Strecke, in der sich die Schiffsfunkstelle gerade befindet', N'A')
INSERT [db_ddladmin].[T_Funk_UBI] ([Id], [Frage], [AntwortA], [AntwortB], [AntwortC], [AntwortD], [RichtigeAntwort]) VALUES (39, N'Was bedeutet "ATIS"?', N'Automatisches Senderidentifizierungssystem', N'Automatisches Schiffsidentifizierungssystem', N'Automatisches Verkehrsinformationssystem', N'Automatisches Transponderabfragesystem', N'A')
INSERT [db_ddladmin].[T_Funk_UBI] ([Id], [Frage], [AntwortA], [AntwortB], [AntwortC], [AntwortD], [RichtigeAntwort]) VALUES (50, N'Je höher die Antenne angebracht ist, desto…', N'größer ist die Reichweite', N'größer wird die Gefährdung von Personen in elektromagnetischen Feldern', N'wetterunabhängiger ist der Funkverkehr', N'
größer ist die erforderliche Sendeleistung', N'A')
INSERT [db_ddladmin].[T_Funk_UBI] ([Id], [Frage], [AntwortA], [AntwortB], [AntwortC], [AntwortD], [RichtigeAntwort]) VALUES (55, N'Wozu dient ein "Verkehrskreis" im Binnenschifffahrtsfunk?', N'Zuordnung von Sprechfunk-Kanälen für bestimmte Zwecke', N'Zuordnung der Rangfolge von bestimmten Arten von Funkgesprächen', N'Zuordnung von Sprechfunk-Rufzeichen für bestimmte Funkstellen', N'Zuordnung von Sprechfunk-Kanälen für bestimmte Schiffsfunkstellen', N'A')
INSERT [db_ddladmin].[T_Funk_UBI] ([Id], [Frage], [AntwortA], [AntwortB], [AntwortC], [AntwortD], [RichtigeAntwort]) VALUES (62, N'Welche Funkstelle kann am Verkehrskreis "Schiff-Schiff" teilnehmen?', N'Segelyacht Robbe DA 5005', N'Lauenburg Schleuse', N'Minden Revierzentrale', N'Duisburg Hafen', N'A')
INSERT [db_ddladmin].[T_Funk_UBI] ([Id], [Frage], [AntwortA], [AntwortB], [AntwortC], [AntwortD], [RichtigeAntwort]) VALUES (64, N'Welche Nachrichten werden im Verkehrskreis "Nautische Information" übermittelt?', N'Nachrichten über den Zustand der Wasserstraßen, über Verkehrsberatung und zur Verkehrslenkung', N'Nachrichten über die Zuweisung von Liegeplätzen oder über die Fahrt in den Häfen', N'
Nachrichten, die sich auf Funkverkehr zwischen Schiffsfunkstellen beziehen', N'Nachrichten über schiffsbetriebliche Angelegenheiten', N'A')
INSERT [db_ddladmin].[T_Funk_UBI] ([Id], [Frage], [AntwortA], [AntwortB], [AntwortC], [AntwortD], [RichtigeAntwort]) VALUES (73, N'Wozu dient der Verkehrskreis "Funkverkehr an Bord"?', N'Funkverkehr an Bord eines Schiffes oder innerhalb einer Gruppe von Fahrzeugen, die geschleppt oder geschoben werden', N'Funkverkehr zwischen Schiffsfunkstellen in Häfen', N'Funkverkehr zwischen Schiffsfunkstellen und Landfunkstellen von Hafenbehörden', N'Funkverkehr von Schiffsfunkstellen über Landfunkstellen mit dem öffentlichen Telekommunikationsnetz', N'A')
INSERT [db_ddladmin].[T_Funk_UBI] ([Id], [Frage], [AntwortA], [AntwortB], [AntwortC], [AntwortD], [RichtigeAntwort]) VALUES (80, N'Wo findet man Regelungen über die Abwicklung des Binnenschifffahrtsfunks?', N'Allgemeiner Teil des Handbuchs Binnenschifffahrtsfunk', N'Binnenschifffahrtsstraßenordnung', N'Regionaler Teil Deutschland des Handbuchs Binnenschifffahrtsfunk', N'Binnenschifffahrt-Sprechfunkverordnung', N'A')
INSERT [db_ddladmin].[T_Funk_UBI] ([Id], [Frage], [AntwortA], [AntwortB], [AntwortC], [AntwortD], [RichtigeAntwort]) VALUES (84, N'Was bedeutet die Betriebsart "Simplex"?', N'Wechselsprechen', N'Gegensprechen', N'Sprechen mit einem Funkgerät', N'Sprechen über Ober- und Unterband', N'A')
INSERT [db_ddladmin].[T_Funk_UBI] ([Id], [Frage], [AntwortA], [AntwortB], [AntwortC], [AntwortD], [RichtigeAntwort]) VALUES (91, N'Auf welchem UKW-Kanal müssen Schiffsfunkstellen – unabhängig von dem befahrenen Streckenabschnitt – während der Fahrt ständig empfangsbereit sein?', N'10', N'20', N'13', N'72', N'A')
INSERT [db_ddladmin].[T_Funk_UBI] ([Id], [Frage], [AntwortA], [AntwortB], [AntwortC], [AntwortD], [RichtigeAntwort]) VALUES (101, N'Warum dürfen Seefunkstellen mit ihrer Seefunkanlage nicht am Binnenschifffahrtsfunk teilnehmen?', N'Seefunkanlagen verfügen weder über eine automatische Sendeleistungsreduzierung auf bestimmten UKW-Kanälen noch können sie einen ATIS-Code aussenden', N'Seefunkanlagen verfügen über einen DSC-Controller, der mit dem ATIS-System nicht kompatibel ist', N'Seefunkanlagen ermöglichen die Hörbereitschaft auf den UKW-Kanälen 16 und 70', N'Seefunkanlagen nutzen ein anderes Frequenzband als Binnenschifffahrtsfunkanlagen', N'A')
INSERT [db_ddladmin].[T_Funk_UBI] ([Id], [Frage], [AntwortA], [AntwortB], [AntwortC], [AntwortD], [RichtigeAntwort]) VALUES (109, N'Welche Funkstellen sind zur Einleitung von Rettungsmaßnahmen vorzugsweise anzurufen?', N'Revierzentralen', N'Polizeifunkstellen', N'Rettungsleitstellen', N'Schiffsfunkstellen', N'A')
INSERT [db_ddladmin].[T_Funk_UBI] ([Id], [Frage], [AntwortA], [AntwortB], [AntwortC], [AntwortD], [RichtigeAntwort]) VALUES (111, N'Wie heißt das Notzeichen im Sprechfunk?', N'MAYDAY', N'SOS', N'SECURITE', N'PAN PAN', N'A')
INSERT [db_ddladmin].[T_Funk_UBI] ([Id], [Frage], [AntwortA], [AntwortB], [AntwortC], [AntwortD], [RichtigeAntwort]) VALUES (124, N'Welcher Funkverkehr ist einzuleiten, wenn an Bord eine Person einen Knochenbruch am Unterarm erlitten hat und ärztlicher Versorgung bedarf?', N'Dringlichkeitsverkehr', N'Sicherheitsverkehr', N'Notverkehr', N'Routineverkehr', N'A')
INSERT [db_ddladmin].[T_Funk_UBI] ([Id], [Frage], [AntwortA], [AntwortB], [AntwortC], [AntwortD], [RichtigeAntwort]) VALUES (130, N'Wer entscheidet über die Art der auszusendenden Sprechfunkmeldung?', N'Schiffsführer', N'Revierzentrale', N'Wasserschutzpolizei', N'Bediener der Funkanlage', N'A')
USE [master]
GO
ALTER DATABASE [Binnenschifffahrtsfunk] SET  READ_WRITE 
GO