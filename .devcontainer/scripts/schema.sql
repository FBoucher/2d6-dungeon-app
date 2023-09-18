

CREATE TABLE IF NOT EXISTS 2d6db.StartingAmour (
  StartingArmourID int NOT NULL AUTO_INCREMENT,
  ArmourType varchar(255) DEFAULT NULL,
  DiceSet int DEFAULT 0,
  Modifier varchar(255) DEFAULT NULL,
  PRIMARY KEY (StartingArmourID)
);

CREATE TABLE IF NOT EXISTS 2d6db.StartingScroll (
  StartingScrollID int NOT NULL AUTO_INCREMENT,
  ScrollType varchar(255) DEFAULT NULL,
  Modifier varchar(255) DEFAULT NULL,
  PRIMARY KEY (StartingScrollID)
);

CREATE TABLE IF NOT EXISTS 2d6db.BodySearch (
  BodySearchID int NOT NULL AUTO_INCREMENT,
  TableNumber INT DEFAULT 1,
  Roll INT DEFAULT NULL,
  Description varchar(255) DEFAULT NULL,
  PRIMARY KEY (BodySearchID)
);

CREATE TABLE IF NOT EXISTS 2d6db.Rooms (
  RoomID int NOT NULL AUTO_INCREMENT,
  Roll int DEFAULT 0,
  Level int DEFAULT 1,
  RoomType varchar(255) DEFAULT NULL,
  Description varchar(255) DEFAULT NULL,
  Encounter varchar(255) DEFAULT NULL,
  Exits varchar(255) DEFAULT NULL,
  isUnique bool DEFAULT false,
  PRIMARY KEY (RoomID)
);