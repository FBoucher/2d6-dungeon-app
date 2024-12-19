
-- Starting Amour
INSERT INTO db2d6.armour_pieces(name, dice_set, modifier)
VALUES('Jerkin', 4, '-1 Damage');
INSERT INTO db2d6.armour_pieces(name, dice_set, modifier)
VALUES('Padded Tunic', 5, '-1 Damage');
INSERT INTO db2d6.armour_pieces(name, dice_set, modifier)
VALUES('Quilted Coat', 3, '-1 Damage');
INSERT INTO db2d6.armour_pieces(name, dice_set, modifier)
VALUES('Hide doublet', 2, '-1 Damage');

-- Starting Scroll
INSERT INTO db2d6.magic_scrolls(scroll_type, description, modifier)
VALUES('Balance', 'Increses discipline and magical focus for a time', '+1 Discipline for dungeon level');
INSERT INTO db2d6.magic_scrolls(scroll_type, description, modifier)
VALUES('Mental whip', 'A damaging psychic attack', '1 strike of 10 damage');
INSERT INTO db2d6.magic_scrolls(scroll_type, description, modifier)
VALUES('Reflexes', 'Increases combat ability for a time', '+1 Shift for 1 combat');
INSERT INTO db2d6.magic_scrolls(scroll_type, description, modifier)
VALUES('Melt metal', 'Destroys one lock or armour-related interrupt on an enemy', 'Destroy 1 lock or peace of armour');


-- Starting Potion
INSERT INTO db2d6.magic_potions(potion_type, modifier, duration, cost) 
    VALUES('HEALING', 'Heal up to 10 Health Points', 'INSTANT', '18gc');



-- Body Search tables 
INSERT INTO db2d6.body_searches(table_number, roll, description)
VALUES(1, 2, 'The body stinks, and a cloud of spores erupts. Lose 1 HP.');
INSERT INTO db2d6.body_searches(table_number, roll, description)
VALUES(1, 3, 'The body burts into flames destroying any loot. There is dark magic here.');

INSERT INTO db2d6.body_searches(table_number, roll, description)
VALUES(2, 2, 'Blood suddenly spurts from the body. Gain the bloodied status. There is nothing here.');


-- rooms Level 1
-- small
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES (2,1,'Empty space', 'small','There is nothing in this small space', 'Archways',false);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES (3,1,'Strange Text', 'small','This narrow room connects the corridors and has no furniture. On the wall though...', 'Archways',false);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES (4,1,'Grakada Mural', 'small','There is a large mural of Grakada here. Her old faces smiles. If you call for her favour here -2 to roll. There is no space to make offering.', 'Archways',true);


-- regular
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, encounter, exits, is_unique)
VALUES (11,1,'Empty space', 'regular','This room is bare and seems to have been cleared out or forgotten about', 'The room is quiet. You hear nothing', 'Archways',false);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, encounter, exits, is_unique)
VALUES (12,1,'Abandoned Gard post', 'regular','There is dusty table...', 'Beneath the table is a pile of rubbish. Roll on table RUPT1 +1', 'Wooden doors',false);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, encounter, exits, is_unique)
VALUES (13,1,'Gard post', 'regular','A small burner provides warth for two chairs around a low table. It is lit and cast shadows.', 'There is someone here. Roll on L1G. If you survive roll on table IAUT1.', 'Enforced doors',false);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, encounter, exits, is_unique)
VALUES (14,1,'mason''s workshop', 'regular','Large blocks of stone scatter the space, iron tools and an old hammer lay around.', 'Roll a D6. 1-4= An ARTISAN is here. You must fight them. If you survive roll TCT1.', 'random',false);


-- large
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES (2,1,'Stone workshop', 'large','This large space has rough walls and piles of stone laying everywhere. There are the remains of a large stone statue that has been smashed. There is no one here.', 'Wooden doors',false);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES (3,1,'marble hall', 'large','There are evently spaced pillars running along this large marble lined hall, with a round central burner and a metal grill. If you have some wood, you could start a fire.', 'Archways',true);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES (4,1,'old mess hall', 'large','This room was once a mess hall. Some benches and tables are punched to the side. Other chairs are stacked around the edges of the room. Rool on IAUT1.', 'Wooden doors',true);
INSERT INTO db2d6.rooms(roll, level, room_type, size, description, exits, is_unique)
VALUES (5,1,'penitentiary', 'large','THe northeast corner is being used to hold captives. There are whips and knives on table. The floor is covered in bloodied straw. Fight a JAILOR and then roll on ENP1.', 'reinforced doors',true);


-- demo adventurers
INSERT INTO db2d6.adventurers(name, level, xp) VALUES('Toby the Creator', 1, 100);
INSERT INTO db2d6.adventurers(name, level, xp) VALUES('Frank', 0, 0);


-- weapons
INSERT INTO db2d6.weapons(id, name) VALUES(1, 'LONGSWORD');
INSERT INTO db2d6.weapons(id, name) VALUES(2, 'GREATAXE');
INSERT INTO db2d6.weapons(id, name) VALUES(3, 'HEAVY MACE');


-- weapon_manoeuvres
INSERT INTO db2d6.weapon_manoeuvres(level, weapon_id ,dice_set, description, modifier) VALUES(1, 1, '1-2', 'DISGUISED SWOOP', '6D +2');
INSERT INTO db2d6.weapon_manoeuvres(level, weapon_id ,dice_set, description, modifier) VALUES(1, 1, '5-2', 'INCISIVE CUT', '6D +1');
INSERT INTO db2d6.weapon_manoeuvres(level, weapon_id ,dice_set, description, modifier) VALUES(1, 1, '3-2', 'THRUST', '6D');

INSERT INTO db2d6.weapon_manoeuvres(level, weapon_id ,dice_set, description, modifier) VALUES(1, 2, '1-2', 'WEIGHTED CHARGE', '6D +3');
INSERT INTO db2d6.weapon_manoeuvres(level, weapon_id ,dice_set, description, modifier) VALUES(1, 2, '5-2', 'LOW SWISH', '6D +1');
INSERT INTO db2d6.weapon_manoeuvres(level, weapon_id ,dice_set, description, modifier) VALUES(1, 2, '3-2', 'HACK', '6D');

INSERT INTO db2d6.weapon_manoeuvres(level, weapon_id ,dice_set, description, modifier) VALUES(1, 3, '1-2', 'SOLID BELTING', '6D +2');
INSERT INTO db2d6.weapon_manoeuvres(level, weapon_id ,dice_set, description, modifier) VALUES(1, 3, '5-2', 'POMMEL THUMP', '6D +1');
INSERT INTO db2d6.weapon_manoeuvres(level, weapon_id ,dice_set, description, modifier) VALUES(1, 3, '3-2', 'CARVING HIT', '6D +1');


-- creatures
INSERT INTO db2d6.creatures(name, level, creature_type, health_points, experience, shift_points, treasure, interrupt1, interrupt2, manoeuvre1, manoeuvre2, description, prime_attack_rolls, mishap_attack_rolls)
VALUES('THUG', 1, 'Humanoid', 3, 6, 1, 'None', 'Forearm block on Secondary|4s|-1 damage', '', '3-2|PUNCH|D6 -3 damage', '', 'This rough looking brute has few skill...', 'The thud tries a combo of swing... Gain 1 extra attack', 'The thud manages to grip you.... take D3 damage.');

INSERT INTO db2d6.creatures(name, level, creature_type, health_points, experience, shift_points, treasure, interrupt1, interrupt2, manoeuvre1, manoeuvre2, description, prime_attack_rolls, mishap_attack_rolls)
VALUES('GUARD', 1, 'Humanoid', 7, 13, 1, 'Roll on PT1 -1', 'Shield BLock on Secondary|3s|-1 damage', 'Shield BLock on Secondary|5s|-1 damage', '5-3|STAB|D6 -3 damage', '6-2|SWIPE|D6 -2 damage', 'A trainer guard wearing light armour who has some basic skills in combat. They have duties within the dungeon and can be seen on patrols and at guard posts.', 'The guard lunges carelessly opens his side and you elbow them hard causing 1 damage.', 'With an unexpected move the guard disarms you. Lose 1 turn as you grab it back off the ground.');

INSERT INTO db2d6.creatures(name, level, creature_type, health_points, experience, shift_points, treasure, interrupt1, interrupt2, manoeuvre1, manoeuvre2, description, prime_attack_rolls, mishap_attack_rolls)
VALUES('ARTISAN', 1, 'Humanoid', 3, 5, 1, 'Roll on PT1 -2|+ 2D6 SC', 'Deflect on Secondary|1s|-2 damage', 'Distract on Secondary|6s|-1 damage', '5-4|JAB|D6 -3 damage', '', 'A skilled worker who has spent many years learning their art. They are not fither but are well coordinated and wear sturdy leather work clothes. They will defend their home.', 'They grab up a lenght of wood, but it is brittle and crumbles in their hand. Gain an extra attack.', 'The artisant pulls a handful of nails from a pocket and throws them in your face. Take 2 damage.');

INSERT INTO db2d6.creatures(name, level, creature_type, health_points, experience, shift_points, treasure, interrupt1, interrupt2, manoeuvre1, manoeuvre2, description, prime_attack_rolls, mishap_attack_rolls)
VALUES('JAILOR', 1, 'Humanoid', 6, 10, 1, 'Roll on PT1 +1', 'Barge on Secondary|2s|-2 damage', '', '5-1|SHARP KICK|D6 -2 damage', '3-3|PUNCH|D6 - 3 damage', 'Being a jailor has made them tough but their skill in combat is limited/ As they come forward wrapping a chain around their knuckles, a mad look in theur eyes.', 'The jailor swigs but appears tired and falls back on their haunches giving you an extra attack.', 'With a whip of their fist the chain shoots out and lashes your knucles. Lose 1 HP if not wearing gloves.');
