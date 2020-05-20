CREATE TABLE student (
	id_student INTEGER PRIMARY KEY AUTOINCREMENT,
	name TEXT NOT NULL
);

CREATE TABLE course (
	id_course INTEGER PRIMARY KEY AUTOINCREMENT,
	name TEXT NOT NULL
);

CREATE TABLE course_student (
	id_course_student INTEGER PRIMARY KEY AUTOINCREMENT,
	id_course INTEGER NOT NULL,
	id_student INTEGER NOT NULL,
	FOREIGN KEY(id_student) REFERENCES student(id_student),
	FOREIGN KEY(id_course) REFERENCES course(id_course)
);

INSERT INTO student(name)
VALUES
	('Вася'),
	('Ваня'),
	('Гена'),
	('Петя'),
	('Женя'),
	('Кирилл'),
	('Лера'),
	('Вика'),
	('Дима');
	
INSERT INTO course(name)
VALUES
	('Физика'),
	('ООП');

INSERT INTO course_student(id_course, id_student)
VALUES
	(1, 1),
	(1, 2),
	(1, 3),
	(1, 4),
	(1, 5),
	(1, 6),
	(1, 7),
	(1, 8),
	(2, 1),
	(2, 2),
	
-- #1
SELECT 
	COUNT(curse) AS count_curse
FROM (
  SELECT 
	course_student.id_course AS curse
  FROM course_student
  GROUP BY course_student.id_course
  HAVING COUNT(course_student.id_student) > 5);

-- #2
SELECT 
	student.name, 
	GROUP_CONCAT(course.name) AS courses
FROM course_student
INNER JOIN course ON course_student.id_course = course.id_course
INNER JOIN student ON course_student.id_student = student.id_student 
GROUP BY course_student.id_student;