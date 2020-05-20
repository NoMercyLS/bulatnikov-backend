CREATE TABLE users(
	users_id INTEGER PRIMARY KEY AUTOINCREMENT,
	name TEXT NOT NULL
);

CREATE TABLE orders(
	orders_id INTEGER PRIMARY KEY AUTOINCREMENT,
	users_id INTEGER NOT NULL,
	status INTEGER NOT NULL,
	FOREIGN KEY(users_id) REFERENCES users(users_id)
);

INSERT INTO users(name)
VALUES
	('Gena'),
	('Valya'),
	('Pasha'),
	('Misha'),
	('Sasha'),
	('Petya'),
	('Lera'),
	('Gera'),
	('Dasha'),
	('Katya');

INSERT INTO orders(users_id, status)
VALUES
	(1, 1),
	(2, 0),
	(3, 1),
	(4, 0),
	(5, 0),
	(6, 0),
	(7, 1),
	(8, 0),
	(9, 1),
	(10, 1),
	(1, 0),
	(2, 1),
	(3, 0),
	(4, 1),
	(5, 0),
	(6, 1),
	(7, 0),
	(8, 1),
	(9, 1),
	(10, 0),
	(1, 1),
	(2, 1),
	(3, 1),
	(4, 0),
	(5, 0),
	(6, 1),
	(7, 1),
	(8, 1),
	(9, 1),
	(10, 0),
	(1, 1),
	(1, 1),
	(1, 1),
	(1, 1),
	(1, 1),
	(2, 1),
	(2, 1),
	(2, 1),
	(2, 1),
	(3, 1),
	(3, 1),
	(3, 1),
	(3, 1),
	(3, 1),
	(3, 1),
	(4, 1);

--  #1
SELECT "All records status = 0";
SELECT users.name 
FROM users 
EXCEPT
SELECT users.name  FROM users
	LEFT JOIN orders ON users.users_id = orders.users_id 
WHERE orders.status = 1;

-- #2
SELECT "More than 5 records have status = 1";
SELECT 
	users.name
FROM users
LEFT JOIN orders ON users.users_id = orders.users_id
WHERE orders.status = 1
GROUP BY orders.users_id
HAVING COUNT(orders.orders_id) > 5;