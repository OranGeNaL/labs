--Удаление из Course
CREATE OR REPLACE FUNCTION deleteFromCourse(INT)
RETURNS VOID AS $$
BEGIN
  INSERT INTO Log_Users(User_Name, TimeAction, TableAction, Action)
  VALUES (current_user, now(), 'course', 'DELETE');
  DELETE FROM Course
  WHERE number_course=$1;
END;
$$ LANGUAGE plpgsql;

--Удаление из Discipline
CREATE OR REPLACE FUNCTION deleteFromDiscipline(VARCHAR(50))
RETURNS VOID AS $$
BEGIN
  INSERT INTO Log_Users(User_Name, TimeAction, TableAction, Action)
  VALUES (current_user, now(), 'discipline', 'DELETE');
  DELETE FROM Discipline
  WHERE name_disc=$1;
END;
$$ LANGUAGE plpgsql;

--Удаление из Speciality
CREATE OR REPLACE FUNCTION deleteFromSpeciality(VARCHAR(50))
RETURNS VOID AS $$
BEGIN
  INSERT INTO Log_Users(User_Name, TimeAction, TableAction, Action)
  VALUES (current_user, now(), 'speciality', 'DELETE');
  DELETE FROM Speciality
  WHERE name_spec=$1;
END;
$$ LANGUAGE plpgsql;

--Удаление из Uch_Plan
CREATE OR REPLACE FUNCTION deleteFromUchPlan(VARCHAR(50), INT)
RETURNS VOID AS $$
BEGIN
  INSERT INTO Log_Users(User_Name, TimeAction, TableAction, Action)
  VALUES (current_user, now(), 'uch_plan', 'DELETE');
  DELETE FROM Uch_Plan
  WHERE name_uch=$1 AND Speciality_id_spec=$2;
END;
$$ LANGUAGE plpgsql;

--Удаление из Gruppa
CREATE OR REPLACE FUNCTION deleteFromGruppa(VARCHAR(50), DATE, INT, INT)
RETURNS VOID AS $$
BEGIN
  INSERT INTO Log_Users(User_Name, TimeAction, TableAction, Action)
  VALUES (current_user, now(), 'gruppa', 'DELETE');
  DELETE FROM Gruppa
  WHERE name_group=$1 AND enter_date=$2 AND Uch_Plan_id_uch=$3 AND Speciality_id_spec=$4;
END;
$$ LANGUAGE plpgsql;

--Удаление из Gupr_elem
CREATE OR REPLACE FUNCTION deleteFromGupr_elem(VARCHAR(50))
RETURNS VOID AS $$
BEGIN
  INSERT INTO Log_Users(User_Name, TimeAction, TableAction, Action)
  VALUES (current_user, now(), 'gupr_elem', 'DELETE');
  DELETE FROM Gupr_elem
  WHERE name_gupr_elem=$1;
END;
$$ LANGUAGE plpgsql;

--Удаление из Gupr
CREATE OR REPLACE FUNCTION deleteFromGupr(INT, INT)
RETURNS VOID AS $$
BEGIN
  INSERT INTO Log_Users(User_Name, TimeAction, TableAction, Action)
  VALUES (current_user, now(), 'gupr', 'DELETE');
  DELETE FROM Gupr
  WHERE duration=$1 AND Gupr_elem_id_gupr_elem=$2;
END;
$$ LANGUAGE plpgsql;

--Удаление из Kafedra
CREATE OR REPLACE FUNCTION deleteFromKafedra(VARCHAR(50))
RETURNS VOID AS $$
BEGIN
  INSERT INTO Log_Users(User_Name, TimeAction, TableAction, Action)
  VALUES (current_user, now(), 'kafedra', 'DELETE');
  DELETE FROM Kafedra
  WHERE name_kaf=$1;
END;
$$ LANGUAGE plpgsql;

--Удаление из Kaf_Rasp
CREATE OR REPLACE FUNCTION deleteFromKaf_Rasp(INT, INT, INT)
RETURNS VOID AS $$
BEGIN
  INSERT INTO Log_Users(User_Name, TimeAction, TableAction, Action)
  VALUES (current_user, now(), 'kaf_rasp', 'DELETE');
  DELETE FROM Kaf_Rasp
  WHERE Speciality_id_spec=$1 AND Discipline_id_disc=$2 AND Kafedra_id_kaf=$3;
END;
$$ LANGUAGE plpgsql;

--Удаление из Semestr
-- CREATE OR REPLACE FUNCTION deleteFromSemestr()
-- RETURNS VOID AS $$
-- BEGIN
--   INSERT INTO Log_Users(User_Name, TimeAction, TableAction, Action)
--   VALUES (current_user, now(), 'semestr', 'DELETE');
--   INSERT INTO Semestr () VALUES ();
-- END;
-- $$ LANGUAGE plpgsql;

--Удаление из Uch_Load
CREATE OR REPLACE FUNCTION deleteFromUch_Load(INT, INT, INT, INT, INT)
RETURNS VOID AS $$
BEGIN
  INSERT INTO Log_Users(User_Name, TimeAction, TableAction, Action)
  VALUES (current_user, now(), 'uch_load', 'DELETE');
  DELETE FROM Uch_Load
  WHERE hours=$1 AND Uch_Plan_id_uch=$2 AND Speciality_id_spec=$3 AND Semestr_id_semestr=$4 AND Discipline_id_disc=$5;
END;
$$ LANGUAGE plpgsql;

--Удаление из number_weeks
CREATE OR REPLACE FUNCTION deleteFromNumber_Weeks(INT)
RETURNS VOID AS $$
BEGIN
  INSERT INTO Log_Users(User_Name, TimeAction, TableAction, Action)
  VALUES (current_user, now(), 'number_weeks', 'DELETE');
  DELETE FROM number_weeks
  WHERE number=$1;
END;
$$ LANGUAGE plpgsql;
