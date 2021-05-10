--Вставка в Course
CREATE OR REPLACE FUNCTION insertIntoCourse(INT)
RETURNS VOID AS $$
BEGIN
  INSERT INTO Log_Users(User_Name, TimeAction, TableAction, Action)
  VALUES (current_user, now(), 'course', 'INSERT');
  INSERT INTO Course (number_course) VALUES ($1);
END;
$$ LANGUAGE plpgsql;

--Вставка в Discipline
CREATE OR REPLACE FUNCTION insertIntoDiscipline(VARCHAR(50))
RETURNS VOID AS $$
BEGIN
  INSERT INTO Log_Users(User_Name, TimeAction, TableAction, Action)
  VALUES (current_user, now(), 'discipline', 'INSERT');
  INSERT INTO Discipline (name_disc) VALUES ($1);
END;
$$ LANGUAGE plpgsql;

--Вставка в Speciality
CREATE OR REPLACE FUNCTION insertIntoSpeciality(VARCHAR(50))
RETURNS VOID AS $$
BEGIN
  INSERT INTO Log_Users(User_Name, TimeAction, TableAction, Action)
  VALUES (current_user, now(), 'speciality', 'INSERT');
  INSERT INTO Speciality (name_spec) VALUES ($1);
END;
$$ LANGUAGE plpgsql;

--Вставка в Uch_Plan
CREATE OR REPLACE FUNCTION insertIntoUchPlan(VARCHAR(50), INT)
RETURNS VOID AS $$
BEGIN
  INSERT INTO Log_Users(User_Name, TimeAction, TableAction, Action)
  VALUES (current_user, now(), 'uch_plan', 'INSERT');
  INSERT INTO Uch_Plan (name_uch, Speciality_id_spec) VALUES ($1, $2);
END;
$$ LANGUAGE plpgsql;

--Вставка в Gruppa
CREATE OR REPLACE FUNCTION insertIntoGruppa(VARCHAR(50), DATE, INT, INT)
RETURNS VOID AS $$
BEGIN
  INSERT INTO Log_Users(User_Name, TimeAction, TableAction, Action)
  VALUES (current_user, now(), 'gruppa', 'INSERT');
  INSERT INTO Gruppa (name_group, enter_date, Uch_Plan_id_uch, Speciality_id_spec) VALUES ($1, $2, $3, $4);
END;
$$ LANGUAGE plpgsql;

--Вставка в Gupr_elem
CREATE OR REPLACE FUNCTION insertIntoGupr_elem(VARCHAR(50))
RETURNS VOID AS $$
BEGIN
  INSERT INTO Log_Users(User_Name, TimeAction, TableAction, Action)
  VALUES (current_user, now(), 'gupr_elem', 'INSERT');
  INSERT INTO Gupr_elem (name_gupr_elem) VALUES ($1);
END;
$$ LANGUAGE plpgsql;

--Вставка в Gupr
CREATE OR REPLACE FUNCTION insertIntoGupr(INT, INT)
RETURNS VOID AS $$
BEGIN
  INSERT INTO Log_Users(User_Name, TimeAction, TableAction, Action)
  VALUES (current_user, now(), 'gupr', 'INSERT');
  INSERT INTO Gupr (duration, Gupr_elem_id_gupr_elem) VALUES ($1, $2);
END;
$$ LANGUAGE plpgsql;

--Вставка в Kafedra
CREATE OR REPLACE FUNCTION insertIntoKafedra(VARCHAR(50))
RETURNS VOID AS $$
BEGIN
  INSERT INTO Log_Users(User_Name, TimeAction, TableAction, Action)
  VALUES (current_user, now(), 'kafedra', 'INSERT');
  INSERT INTO Kafedra (name_kaf) VALUES ($1);
END;
$$ LANGUAGE plpgsql;

--Вставка в Kaf_Rasp
CREATE OR REPLACE FUNCTION insertIntoKaf_Rasp(INT, INT, INT)
RETURNS VOID AS $$
BEGIN
  INSERT INTO Log_Users(User_Name, TimeAction, TableAction, Action)
  VALUES (current_user, now(), 'kaf_rasp', 'INSERT');
  INSERT INTO Kaf_Rasp (Speciality_id_spec, Discipline_id_disc, Kafedra_id_kaf) VALUES ($1, $2, $3);
END;
$$ LANGUAGE plpgsql;

--Вставка в Semestr
-- CREATE OR REPLACE FUNCTION insertIntoSemestr()
-- RETURNS VOID AS $$
-- BEGIN
--   INSERT INTO Log_Users(User_Name, TimeAction, TableAction, Action)
--   VALUES (current_user, now(), 'semestr', 'INSERT');
--   INSERT INTO Semestr () VALUES ();
-- END;
-- $$ LANGUAGE plpgsql;

--Вставка в Uch_Load
CREATE OR REPLACE FUNCTION insertIntoUch_Load(INT, INT, INT, INT, INT)
RETURNS VOID AS $$
BEGIN
  INSERT INTO Log_Users(User_Name, TimeAction, TableAction, Action)
  VALUES (current_user, now(), 'uch_load', 'INSERT');
  INSERT INTO Uch_Load (hours, Uch_Plan_id_uch, Speciality_id_spec, Semestr_id_semestr, Discipline_id_disc) VALUES ($1, $2, $3, $4, $5);
END;
$$ LANGUAGE plpgsql;

--Вставка в number_weeks
CREATE OR REPLACE FUNCTION insertIntoNumber_Weeks(INT)
RETURNS VOID AS $$
BEGIN
  INSERT INTO Log_Users(User_Name, TimeAction, TableAction, Action)
  VALUES (current_user, now(), 'number_weeks', 'INSERT');
  INSERT INTO number_weeks (number) VALUES ($1);
END;
$$ LANGUAGE plpgsql;
