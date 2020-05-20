CREATE TABLE vehicle(
	id_auto INTEGER PRIMARY KEY AUTOINCREMENT,
	name TEXT NOT NULL,
	price INTEGER NOT NULL
);

INSERT INTO vehicle(name, price)
VALUES
	("Toyota LC150", 2200000),
	("Mazda RX-8", 1850000),
	("Kia Stinger GT", 2800000),
	("Toyota LC150", 2350000),
	("Mazda RX-8", 2000000);

SELECT DISTINCT name FROM vehicle
ORDER BY name;