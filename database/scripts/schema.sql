

CREATE TABLE IF NOT EXISTS 2d6db.starting_amours (
  id int NOT NULL AUTO_INCREMENT,
  armour_type varchar(255) DEFAULT NULL,
  dice_set int DEFAULT 0,
  modifier varchar(255) DEFAULT NULL,
  PRIMARY KEY (id)
);

CREATE TABLE IF NOT EXISTS 2d6db.starting_scrolls (
  id int NOT NULL AUTO_INCREMENT,
  scroll_type varchar(255) DEFAULT NULL,
  modifier varchar(255) DEFAULT NULL,
  PRIMARY KEY (id)
);

CREATE TABLE IF NOT EXISTS 2d6db.body_searches (
  id int NOT NULL AUTO_INCREMENT,
  table_number INT DEFAULT 1,
  roll INT DEFAULT NULL,
  description varchar(255) DEFAULT NULL,
  PRIMARY KEY (id)
);

CREATE TABLE IF NOT EXISTS 2d6db.rooms (
  id int NOT NULL AUTO_INCREMENT,
  roll int DEFAULT 0,
  level int DEFAULT 1,
  size varchar(10) DEFAULT NULL,
  room_type varchar(255) DEFAULT NULL,
  description varchar(255) DEFAULT NULL,
  encounter varchar(255) DEFAULT NULL,
  exits varchar(255) DEFAULT NULL,
  is_unique bool DEFAULT false,
  PRIMARY KEY (id)
);

CREATE TABLE IF NOT EXISTS 2d6db.adventurers (
  id int NOT NULL AUTO_INCREMENT,
  name varchar(255) DEFAULT NULL,
  level int DEFAULT 0,
  xp int DEFAULT 0,
  serialiazedObj longtext DEFAULT NULL,
  PRIMARY KEY (id)
);