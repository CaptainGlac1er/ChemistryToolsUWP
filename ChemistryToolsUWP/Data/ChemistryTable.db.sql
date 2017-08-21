BEGIN TRANSACTION;


DROP TABLE IF EXISTS `AtomicTypes`;
CREATE TABLE IF NOT EXISTS 'AtomicTypes'(
	'ATID' INTEGER PRIMARY KEY,
	'Type' Text NOT NULL
);
INSERT OR REPLACE INTO `AtomicTypes` (ATID, Type) VALUES (0, 'neutral');
INSERT OR REPLACE INTO `AtomicTypes` (ATID, Type) VALUES (1, 'cation');
INSERT OR REPLACE INTO `AtomicTypes` (ATID, Type) VALUES (2, 'anion');

DROP TABLE IF EXISTS `ELEMENT`;
CREATE TABLE IF NOT EXISTS "Element" (
	`AtomicNumber`	INTEGER,
	`Name`	TEXT NOT NULL,
	`ChemicalSymbol`	TEXT NOT NULL,
	`Amu`	NUMERIC NOT NULL,
	`Period`	INTEGER NOT NULL,
	`Root`	TEXT,
	`CatID`	INTEGER,
	`Valence`	INTEGER NOT NULL,
	`Type` INTEGER,
	PRIMARY KEY(`AtomicNumber`),
	FOREIGN KEY(`CatID`) REFERENCES `Categories`(`CatID`),
	FOREIGN KEY(`Type`) REFERENCES `AtomicTypes`(`ATID`)
);                                                                                                     
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (1,'Hydrogen',		'H',	1.00794,	1,	'hydro',	1,	1);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (2,'Helium',		'He',	4.0026,		1,	NULL,		7,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (3,'Lithium',		'Li',	6.941,		2,	NULL,		10,	1);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (4,'Beryllium',	'Be',	9.01218,	2,	NULL,		3,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (5,'Boron',		'B',	10.811,		2,	NULL,		6,	3);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (6,'Carbon',		'C',	12.011,		2,	'carb',		1,	4);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (7,'Nitrogen',		'N',	14.0067,	2,	'nitr',		1,	5);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (8,'Oxygen',		'O',	15.9994,	2,	'ox',		1,	6);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (9,'Fluorine',		'F',	18.9984,	2,	NULL,		4,	7);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (10,'Neon',		'Ne',	20.1797,	2,	NULL,		7,	8);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (11,'Sodium',		'Na',	22.98977,	3,	NULL,		10,	1);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (12,'Magnesium',	'Mg',	24.305,		3,	NULL,		3,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (13,'Aluminium',	'Al',	26.98154,	3,	NULL,		8,	3);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (14,'Silicon',		'Si',	28.0855,	3,	NULL,		6,	4);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (15,'Phosphorus',	'P',	30.97376,	3,	NULL,		1,	5);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (16,'Sulfur',		'S',	32.066,		3,	'sulf',		1,	6);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (17,'Chlorine',	'Cl',	35.4527,	3,	'chlor',	4,	7);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (18,'Argon',		'Ar',	39.948,		3,	NULL,		7,	8);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (19,'Potassium',	'K',	39.0983,	4,	NULL,		10,	1);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (20,'Calcium',		'Ca',	40.078,		4,	NULL,		3,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (21,'Scandium',	'Sc',	44.9559,	4,	NULL,		9,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (22,'Titanium',	'Ti',	47.88,		4,	NULL,		9,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (23,'Vanadium',	'V',	44.9559,	4,	NULL,		9,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (24,'Chromium',	'Cr',	51.996,		4,	NULL,		9,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (25,'Manganese',	'Mn',	54.938,		4,	NULL,		9,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (26,'Iron',		'Fe',	55.847,		4,	NULL,		9,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (27,'Cobalt',		'Co',	58.9332,	4,	NULL,		9,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (28,'Nickel',		'Ni',	58.6934,	4,	NULL,		9,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (29,'Copper',		'Cu',	63.546,		4,	NULL,		9,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (30,'Zinc',		'Zn',	65.39,		4,	NULL,		9,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (31,'Gallium',		'Ga',	69.723,		4,	NULL,		8,	3);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (32,'Germanium',	'Ge',	72.61,		4,	NULL,		6,	4);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (33,'Arsenic',		'As',	74.9216,	4,	'arsen',	6,	5);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (34,'Selenium',	'As',	74.9216,	4,	'selen',	1,	6);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (35,'Bromine',		'Br',	79.904,		4,	'brom',		4,	6);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (36,'Krypton',		'Kr',	83.8,		4,	NULL,		7,	8);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (37,'Rubidium',	'Rb',	85.4678,	5,	NULL,		10,	1);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (38,'Strontium',	'Sr',	87.62,		5,	NULL,		3,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (39,'Yttrium',		'Y',	88.9059,	5,	NULL,		9,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (40,'Zirconium',	'Zr',	83.8,		5,	NULL,		9,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (41,'Niobium',		'Nb',	92.9064,	5,	NULL,		9,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (42,'Molybdenum',	'Mo',	95.94,		5,	NULL,		9,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (43,'Technetium',	'Tc',	98,			5,	NULL,		9,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (44,'Ruthenium',	'Ru',	101.07,		5,	NULL,		9,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (45,'Rhodium',		'Rh',	102.9055,	5,	NULL,		9 ,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (46,'Palladium',	'Pd',	106.42,		5,	NULL,		9,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (47,'Silver',		'Ag',	107.868,	5,	NULL,		9,	1);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (48,'Cadmium',		'Cd',	112.41,		5,	NULL,		9,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (49,'Indium',		'In',	114.82,		5,	NULL,		8,	3);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (50,'Tin',			'Sn',	118.71,		5,	NULL,		8,	4);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (51,'Antimony',	'Sb',	121.757,	5,	NULL,		6 ,	5);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (52,'Tellurium',	'Te',	127.6,		5,	NULL,		6,	6);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (53,'Iodine',		'I',	126.9045,	5,	'tellur',	4,	7);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (54,'Xenon',		'Xe',	131.29,		5,	'iod',		7,	8);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (55,'Cesium',		'Cs',	132.9054,	6,	NULL,		10,	1);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (56,'Barium',		'Ba',	137.33,		6,	NULL,		3,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (57,'Lanthanum',	'La',	138.9055,	6,	NULL,		5,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (58,'Cerium',		'Ce',	140.12,		6,	NULL,		5,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (59,'Praseodymium','Pr',	140.9077,	6,	NULL,		5,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (60,'Neodymium',	'Nd',	144.24,		6,	NULL,		5,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (61,'Promethium',	'Pm',	145,		6,	NULL,		5,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (62,'Samarium',	'Sm',	150.36,		6,	NULL,		5,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (63,'Europium',	'Eu',	151.965,	6,	NULL,		5,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (64,'Gadolinium',	'Gd',	157.25,		6,	NULL,		5,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (65,'Terbium',		'Tb',	158.9253,	6,	NULL,		5,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (66,'Dysprosium',	'Dy',	162.5,		6,	NULL,		5,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (67,'Holmium',		'Ho',	164.9303,	6,	NULL,		5,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (68,'Erbium',		'Er',	167.26,		6,	NULL,		5,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (69,'Thulium',		'Tm',	168.9342,	6,	NULL,		5,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (70,'Ytterbium',	'Yb',	173.04,		6,	NULL,		5,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (71,'Lutetium',	'Lu',	174.967,	6,	NULL,		5,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (72,'Hafnium',		'Hf',	178.49,		6,	NULL,		9,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (73,'Tantalum',	'Ta',	180.9479,	6,	NULL,		9,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (74,'Tungsten',	'W',	157.25,		6,	NULL,		9,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (75,'Rhenium',		'Re',	158.9253,	6,	NULL,		9,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (76,'Osmium',		'Os',	190.2,		6,	NULL,		9,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (77,'Iridium',		'Ir',	192.22,		6,	NULL,		9,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (78,'Platinum',	'Pt',	195.08,		6,	NULL,		9,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (79,'Gold',		'Au',	196.9665,	6,	NULL,		9,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (80,'Mercury',		'Hg',	200.59,		6,	NULL,		9,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (81,'Thallium',	'Tl',	204.383,	6,	NULL,		8,	3);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (82,'Lead',		'Pb',	207.2,		6,	NULL,		8,	4);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (83,'Bismuth',		'Bi',	208.9804,	6,	NULL,		8,	5);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (84,'Polonium',	'Po',	209,		6,	NULL,		6,	6);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (85,'Astatine',	'At',	210,		6,	NULL,		4,	7);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (86,'Radon',		'Rn',	222,		6,	NULL,		7,	8);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (87,'Francium',	'Fr',	223,		7,	NULL,		10,	1);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (88,'Radium',		'Ra',	226.0254,	7,	NULL,		3,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (89,'Actinium',	'Ac',	227,		7,	NULL,		2,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (90,'Thorium',		'Th',	232.0381,	7,	NULL,		2,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (91,'Protactinium','Pa',	231.0359,	7,	NULL,		2,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (92,'Uranium',		'U',	238.029,	7,	NULL,		2,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (93,'Neptunium',	'Np',	237.0482,	7,	NULL,		2,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (94,'Plutonium',	'Pu',	244,		7,	NULL,		2,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (95,'Americium',	'Am',	243,		7,	NULL,		2,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (96,'Curium',		'Cm',	247,		7,	NULL,		2,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (97,'Berkelium',	'Bk',	247,		7,	NULL,		2,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (98,'Californium',	'Cf',	251,		7,	NULL,		2,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (99,'Einsteinium',	'Es',	252,		7,	NULL,		2,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (100,'Fermium',	'Fm',	257,		7,	NULL,		2,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (101,'Mendelevium','Md',	258,		7,	NULL,		2,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (102,'Nobelium',	'No',	259,		7,	NULL,		2,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (103,'Lawrencium',	'Lr',	262,		7,	NULL,		2,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (104,'Rutherfordium','Rf',	261,		7,	NULL,		9,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (105,'Dubnium',	'Db',	262,		7,	NULL,		9,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (106,'Seaborgium',	'Sg',	266,		7,	NULL,		9,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (107,'Bohrium',	'Bh',	264,		7,	NULL,		9,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (108,'Hassium',	'Hs',	269,		7,	NULL,		9,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (109,'Meitnerium',	'Mt',	268,		7,	NULL,		9,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (110,'Darmstadtium','Ds',	269,		7,	NULL,		9,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (111,'Roentgenium','Rg',	272,		7,	NULL,		9,	2);
INSERT OR REPLACE INTO `Element` (AtomicNumber,Name,ChemicalSymbol,Amu,Period,Root,CatID,Valence) VALUES (112,'Copernicium','Cn',	277,		7,	NULL,		9,	2);

DROP TABLE IF EXISTS `Categories`;
CREATE TABLE IF NOT EXISTS `Categories` (
	`CatID`	INTEGER,
	`Name`	TEXT NOT NULL,
	`Color` TEXT,
	PRIMARY KEY(`CatID`)
);
INSERT OR REPLACE INTO `Categories` (CatID,Name, Color) VALUES (1,'Non Metal', '#80FF75');
INSERT OR REPLACE INTO `Categories` (CatID,Name, Color) VALUES (2,'Actinoids', '#DBD63D');
INSERT OR REPLACE INTO `Categories` (CatID,Name, Color) VALUES (3,'Alkaline', '#FF6F3A');
INSERT OR REPLACE INTO `Categories` (CatID,Name, Color) VALUES (4,'Halogen', '#895EFF');
INSERT OR REPLACE INTO `Categories` (CatID,Name, Color) VALUES (5,'Lanthancid', '#476CFF');
INSERT OR REPLACE INTO `Categories` (CatID,Name, Color) VALUES (6,'Metalloid', '#70D1FF');
INSERT OR REPLACE INTO `Categories` (CatID,Name, Color) VALUES (7,'Noble Gas', '#7F0FC5');
INSERT OR REPLACE INTO `Categories` (CatID,Name, Color) VALUES (8,'Poor Metal', '#B210BB');
INSERT OR REPLACE INTO `Categories` (CatID,Name, Color) VALUES (9,'Transition Metal', '#11B7FF');
INSERT OR REPLACE INTO `Categories` (CatID,Name, Color) VALUES (10,'Alkali', '#FFC4EE');
DROP VIEW IF EXISTS `Elements`;
CREATE VIEW IF NOT EXISTS `Elements` as select e.AtomicNumber, e.Name, e.ChemicalSymbol, e.Amu, e.Period, e.Root, e.Valence, c.Name as Category, c.Color from Element e, Categories c where e.CatId = c.CatId;

DROP TABLE IF EXISTS `Molecules`;
CREATE TABLE IF NOT EXISTS 'Molecules' (
	'MolID' INTEGER  PRIMARY KEY AUTOINCREMENT,
	'Name' TEXT NOT NULL,
	'Molecule' TEXT NOT NULL,
	'Charge' INTEGER,
	'Root' TEXT,
	'Type' INTEGER,
	FOREIGN KEY('Type') REFERENCES 'AtomicTypes'('ATID')
);
INSERT OR REPLACE INTO 'Molecules' (Name, Molecule, Charge, Root, Type) VALUES ('ammonium', 'NH4', 1, NULL, 1);
INSERT OR REPLACE INTO 'Molecules' (Name, Molecule, Charge, Root, Type) VALUES ('nitrite', 'NO2', -1, 'nitr', 2);
INSERT OR REPLACE INTO 'Molecules' (Name, Molecule, Charge, Root, Type) VALUES ('nitrate', 'NO3', -1, 'nitr', 2);
INSERT OR REPLACE INTO 'Molecules' (Name, Molecule, Charge, Root, Type) VALUES ('sulfite', 'SO3', -2, 'sulf', 2);
INSERT OR REPLACE INTO 'Molecules' (Name, Molecule, Charge, Root, Type) VALUES ('sulfate', 'SO4', -2, 'sulf', 2);
INSERT OR REPLACE INTO 'Molecules' (Name, Molecule, Charge, Root, Type) VALUES ('hydrogen sulfate', 'HSO4', -1, NULL, 2);
INSERT OR REPLACE INTO 'Molecules' (Name, Molecule, Charge, Root, Type) VALUES ('hydroxide', 'OH', -1, NULL, 2);
INSERT OR REPLACE INTO 'Molecules' (Name, Molecule, Charge, Root, Type) VALUES ('cyanide', 'CN', -1, 'cyan', 2);
INSERT OR REPLACE INTO 'Molecules' (Name, Molecule, Charge, Root, Type) VALUES ('phosphate', 'PO4', -3, 'phosph', 2);
INSERT OR REPLACE INTO 'Molecules' (Name, Molecule, Charge, Root, Type) VALUES ('hydrogen phosphate', 'HPO4', -2, NULL, 2);
INSERT OR REPLACE INTO 'Molecules' (Name, Molecule, Charge, Root, Type) VALUES ('dihydrogen phosphate', 'H2PO4', -1, NULL, 2);
INSERT OR REPLACE INTO 'Molecules' (Name, Molecule, Charge, Root, Type) VALUES ('carbonate', 'CO3', -2, 'carbon', 2);
INSERT OR REPLACE INTO 'Molecules' (Name, Molecule, Charge, Root, Type) VALUES ('hydrogen carbonate', 'HCO3', -2, NULL, 2);
INSERT OR REPLACE INTO 'Molecules' (Name, Molecule, Charge, Root, Type) VALUES ('hypochlorite', 'ClO', -1, 'hypochlor', 2);
INSERT OR REPLACE INTO 'Molecules' (Name, Molecule, Charge, Root, Type) VALUES ('chlorite', 'ClO2', -1, 'chlor', 2);
INSERT OR REPLACE INTO 'Molecules' (Name, Molecule, Charge, Root, Type) VALUES ('chlorate', 'ClO3', -1, 'chlor', 2);
INSERT OR REPLACE INTO 'Molecules' (Name, Molecule, Charge, Root, Type) VALUES ('perchlorate', 'ClO4', -1, 'perchlor', 2);
INSERT OR REPLACE INTO 'Molecules' (Name, Molecule, Charge, Root, Type) VALUES ('acetate', 'C2H3O2', -1, 'acet', 2);
INSERT OR REPLACE INTO 'Molecules' (Name, Molecule, Charge, Root, Type) VALUES ('permanganate', 'MnO4', -1, 'permangan', 2);
INSERT OR REPLACE INTO 'Molecules' (Name, Molecule, Charge, Root, Type) VALUES ('dichromate', 'Cr2O7', -2, 'dichrom', 2);
INSERT OR REPLACE INTO 'Molecules' (Name, Molecule, Charge, Root, Type) VALUES ('peroxide', 'O2', -2, 'perox', 2);

INSERT OR REPLACE INTO 'Molecules' (Name, Molecule, Charge, Root, Type) VALUES ('hydrogen peroxide', 'H2O2', 0, NULL, 0);


DROP TABLE IF EXISTS `Polyatomic`;
CREATE TABLE IF NOT EXISTS 'Polyatomic' (
	'MolID' INTEGER,
	FOREIGN KEY('MolID') REFERENCES 'Molecules'("MolID")
);
INSERT OR REPLACE INTO 'Polyatomic' (MolID) VALUES ((SELECT MolID from Molecules WHERE Molecule = 'NH4'));
INSERT OR REPLACE INTO 'Polyatomic' (MolID) VALUES ((SELECT MolID from Molecules WHERE Molecule = 'NO2'));
INSERT OR REPLACE INTO 'Polyatomic' (MolID) VALUES ((SELECT MolID from Molecules WHERE Molecule = 'NO3'));
INSERT OR REPLACE INTO 'Polyatomic' (MolID) VALUES ((SELECT MolID from Molecules WHERE Molecule = 'SO3'));
INSERT OR REPLACE INTO 'Polyatomic' (MolID) VALUES ((SELECT MolID from Molecules WHERE Molecule = 'SO4'));
INSERT OR REPLACE INTO 'Polyatomic' (MolID) VALUES ((SELECT MolID from Molecules WHERE Molecule = 'HSO4'));
INSERT OR REPLACE INTO 'Polyatomic' (MolID) VALUES ((SELECT MolID from Molecules WHERE Molecule = 'OH'));
INSERT OR REPLACE INTO 'Polyatomic' (MolID) VALUES ((SELECT MolID from Molecules WHERE Molecule = 'CN'));
INSERT OR REPLACE INTO 'Polyatomic' (MolID) VALUES ((SELECT MolID from Molecules WHERE Molecule = 'PO4'));
INSERT OR REPLACE INTO 'Polyatomic' (MolID) VALUES ((SELECT MolID from Molecules WHERE Molecule = 'HPO4'));
INSERT OR REPLACE INTO 'Polyatomic' (MolID) VALUES ((SELECT MolID from Molecules WHERE Molecule = 'H2PO4'));
INSERT OR REPLACE INTO 'Polyatomic' (MolID) VALUES ((SELECT MolID from Molecules WHERE Molecule = 'CO3'));
INSERT OR REPLACE INTO 'Polyatomic' (MolID) VALUES ((SELECT MolID from Molecules WHERE Molecule = 'HCO3'));
INSERT OR REPLACE INTO 'Polyatomic' (MolID) VALUES ((SELECT MolID from Molecules WHERE Molecule = 'ClO'));
INSERT OR REPLACE INTO 'Polyatomic' (MolID) VALUES ((SELECT MolID from Molecules WHERE Molecule = 'ClO2'));
INSERT OR REPLACE INTO 'Polyatomic' (MolID) VALUES ((SELECT MolID from Molecules WHERE Molecule = 'ClO3'));
INSERT OR REPLACE INTO 'Polyatomic' (MolID) VALUES ((SELECT MolID from Molecules WHERE Molecule = 'ClO4'));
INSERT OR REPLACE INTO 'Polyatomic' (MolID) VALUES ((SELECT MolID from Molecules WHERE Molecule = 'C2H3O2'));
INSERT OR REPLACE INTO 'Polyatomic' (MolID) VALUES ((SELECT MolID from Molecules WHERE Molecule = 'MnO4'));
INSERT OR REPLACE INTO 'Polyatomic' (MolID) VALUES ((SELECT MolID from Molecules WHERE Molecule = 'Cr2O7'));
INSERT OR REPLACE INTO 'Polyatomic' (MolID) VALUES ((SELECT MolID from Molecules WHERE Molecule = 'O2'));
COMMIT;