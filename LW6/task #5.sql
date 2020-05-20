-- Ответ: может, если нет NOT NULL
CREATE TABLE hairstyle(
	id_hairstlye INTEGER PRIMARY KEY AUTOINCREMENT,
	name TEXT NOT NULL
);

CREATE TABLE h_order(
	id_order INTEGER PRIMARY KEY AUTOINCREMENT,
	id_hairstyle INTEGER,
	FOREIGN KEY(id_hairstyle) REFERENCES hairstyle(id_hairstyle)
);

INSERT INTO hairstyle(name)
VALUES
	('Канадка'),
	('Модельная'),
	('Шапочка'),
	('Налысо');
	          
INSERT INTO h_order(id_hairstyle)
VALUES 
	(1),
	(2),
	(3),
	(NULL);
	
SELECT * FROM h_order;