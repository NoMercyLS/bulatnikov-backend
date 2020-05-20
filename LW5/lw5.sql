-- Task 2
CREATE TABLE dvd (
	dvd_id	INTEGER PRIMARY KEY AUTOINCREMENT,
	title	INTEGER NOT NULL,
	production_year	INTEGER NOT NULL
);
SELECT "Table 'dvd' created";
SELECT "";

CREATE TABLE customer (
	customer_id	INTEGER PRIMARY KEY AUTOINCREMENT,
	first_name	TEXT NOT NULL,
	last_name	TEXT NOT NULL,
	passport_code	INTEGER NOT NULL,
	registration_date	TEXT NOT NULL
);
SELECT "Table 'customer' created";
SELECT "";

CREATE TABLE offer (
	offer_id	INTEGER PRIMARY KEY AUTOINCREMENT,
	dvd_id	INTEGER NOT NULL,
	customer_id	INTEGER NOT NULL,
	offer_date	TEXT NOT NULL,
	return_date	TEXT NOT NULL,
	FOREIGN KEY(dvd_id) REFERENCES dvd(dvd_id),
	FOREIGN KEY(customer_id) REFERENCES customer(customer_id)
);
SELECT "Table 'offer' created";
SELECT "";

-- Task 3
INSERT INTO dvd (title, production_year) 
VALUES 
	('One life', 2011), 
	('Law Abiding Citizen', 2009), 
	('The Young Victoria', 2008), 
	('The Bank Job', 2008), 
	('Da bing xiao jiang', 2010),
	('Inception', 2010), 
	('W.E.', 2011),
	('Unthinkable', 2009);
SELECT "Data inserted to 'dvd'";
SELECT "";

INSERT INTO customer (first_name, last_name, passport_code, registration_date) 
VALUES
	('John', 'John', 888888, '1971-01-01'), 
	('Me', 'Me', 111111, '2000-02-25'), 
	('Gena', 'Gennadiev', 333333, '1973-02-27');
SELECT "Data inserted to 'customer'";
SELECT "";

INSERT INTO offer (dvd_id, customer_id, offer_date, return_date) 
VALUES 
	(1, 3, '2000-12-13', '2020-01-01'), 
	(2, 2, '2000-11-12', '2020-01-02'), 
	(3, 1, '2000-10-11', '2020-01-03'),
	(4, 1, '2000-09-10', '2020-01-04'),
	(5, 2, '2000-08-09', '2020-01-05'),
	(6, 3, '2020-01-01', '2020-01-20'),
	(7, 2, '2000-06-07', '2020-09-08'),
	(8, 1, '2020-05-06', '2020-09-09');
SELECT "Data inserted to 'offer'";
SELECT "";

-- Task 4
SELECT "Films from 2010: ";
SELECT * 
FROM dvd 
WHERE production_year = 2010 
ORDER BY title ASC;
SELECT "";

-- Task 5
SELECT "Still in customer hands: ";
SELECT 
	dvd.dvd_id, 
	dvd.title, 
	dvd.production_year 
FROM dvd
INNER JOIN offer ON dvd.dvd_id = offer.dvd_id
WHERE 
	offer.offer_date <= date('now') AND date('now') < offer.return_date;
SELECT "";

-- Task 6
SELECT "They took some dvds at this year: ";
SELECT 
	customer.customer_id, 
	customer.first_name, 
	customer.last_name, 
	dvd.dvd_id, 
	dvd.title,
	dvd.production_year
FROM customer
INNER JOIN offer ON customer.customer_id = offer.customer_id
INNER JOIN dvd ON dvd.dvd_id = offer.dvd_id
WHERE 
	offer.offer_date = date(strftime('%Y', date('now')) || strftime('-%m-%d', offer_date));