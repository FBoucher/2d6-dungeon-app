
-- Starting Amour
INSERT INTO 2d6db.starting_amours(armour_type, dice_set, modifier)
VALUES('Jerkin', 4, '-1 Damage');
INSERT INTO 2d6db.starting_amours(armour_type, dice_set, modifier)
VALUES('Padded Tunic', 5, '-1 Damage');
INSERT INTO 2d6db.starting_amours(armour_type, dice_set, modifier)
VALUES('Quilted Coat', 3, '-1 Damage');
INSERT INTO 2d6db.starting_amours(armour_type, dice_set, modifier)
VALUES('Hide doublet', 2, '-1 Damage');

-- Starting Scroll
INSERT INTO 2d6db.starting_scrolls(scroll_type, modifier)
VALUES('Scroll of balance', '+1 Discipline for dungeon level');
INSERT INTO 2d6db.starting_scrolls(scroll_type, modifier)
VALUES('Scroll of mental whip', '1 strike of 10 damage');
INSERT INTO 2d6db.starting_scrolls(scroll_type, modifier)
VALUES('Scroll of reflexes', '+1 Shift for 1 combat');
INSERT INTO 2d6db.starting_scrolls(scroll_type, modifier)
VALUES('Scroll of melt metal', 'Destroy 1 lock or peace of armour');

-- Body Search tables 
INSERT INTO 2d6db.body_searches(table_number, roll, description)
VALUES(1, 2, 'The body stinks, and a cloud of spores erupts. Lose 1 HP.');
INSERT INTO 2d6db.body_searches(table_number, roll, description)
VALUES(1, 3, 'The body burts into flames destroying any loot. There is dark magic here.');

INSERT INTO 2d6db.body_searches(table_number, roll, description)
VALUES(2, 2, 'Blood suddenly spurts from the body. Gain the bloodied status. There is nothing here.');


-- rooms Level 1
INSERT INTO 2d6db.rooms(roll, level, room_type, description, encounter, exits, is_unique)
VALUES (11,1,'Empty space','This room is bare and seems to have been cleared out or forgotten about', 'The room is quiet. You hear nothing', 'Archways',false);
INSERT INTO 2d6db.rooms(roll, level, room_type, description, encounter, exits, is_unique)
VALUES (12,1,'Abandoned Gard post','There is dusty table...', 'Beneath the table is a pile of rubbish...', 'Wooden doors',false);
INSERT INTO 2d6db.rooms(roll, level, room_type, description, encounter, exits, is_unique)
VALUES (13,1,'Gard post','A small burner provides...', 'There is someone here...', 'Enforced doors',false);


-- demo adventurers
INSERT INTO 2d6db.adventurers(name, level, xp) VALUES('Toby the Creator', 1, 100)
INSERT INTO 2d6db.adventurers(name, level, xp) VALUES('Frank', 0, 0)