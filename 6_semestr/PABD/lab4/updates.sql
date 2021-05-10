--Изменение Course
CREATE OR REPLACE FUNCTION updateCourse(INT, INT)
RETURNS VOID AS $$
BEGIN
  INSERT INTO Log_Users(User_Name, TimeAction, TableAction, Action)
  VALUES (current_user, now(), 'course', 'UPDATE');
  UPDATE Course
  SET number_course=$2
  WHERE number_course=$1;
END;
$$ LANGUAGE plpgsql;

--Изменение Discipline
CREATE OR REPLACE FUNCTION updateDiscipline(VARCHAR(50), VARCHAR(50))
RETURNS VOID AS $$
BEGIN
  INSERT INTO Log_Users(User_Name, TimeAction, TableAction, Action)
  VALUES (current_user, now(), 'discipline', 'UPDATE');
  UPDATE Discipline
  SET name_disc=$2
  WHERE name_disc=$1;
END;
$$ LANGUAGE plpgsql;

--Изменение Speciality
CREATE OR REPLACE FUNCTION updateSpeciality(VARCHAR(50), VARCHAR(50))
RETURNS VOID AS $$
BEGIN
  INSERT INTO Log_Users(User_Name, TimeAction, TableAction, Action)
  VALUES (current_user, now(), 'speciality', 'UPDATE');
  UPDATE Speciality
  SET name_spec=$2
  WHERE name_spec=$1;
END;
$$ LANGUAGE plpgsql;

--Изменение Uch_Planupdate
CREATE OR REPLACE FUNCTION updateUchPlan(VARCHAR(50), VARCHAR(50), INT, INT)
RETURNS VOID AS $$
BEGIN
  INSERT INTO Log_Users(User_Name, TimeAction, TableAction, Action)
  VALUES (current_user, now(), 'uch_plan', 'UPDATE');
  UPDATE Uch_Plan
  SET name_uch=$2, Speciality_id_spec=$4
  WHERE name_uch=$1 AND Speciality_id_spec=$3;
END;
$$ LANGUAGE plpgsql;

--Изменение Gruppa
CREATE OR REPLACE FUNCTION updateGruppa(VARCHAR(50), VARCHAR(50), DATE, DATE, INT, INT, INT, INT)
RETURNS VOID AS $$
BEGIN
  INSERT INTO Log_Users(User_Name, TimeAction, TableAction, Action)
  VALUES (current_user, now(), 'gruppa', 'UPDATE');
  UPDATE Gruppa
  SET name_group=$2, enter_date=$4, Uch_Plan_id_uch=$6, Speciality_id_spec=$8
  WHERE name_group=$1 AND enter_date=$3 AND Uch_Plan_id_uch=$5 AND Speciality_id_spec=$7;
END;
$$ LANGUAGE plpgsql;

--Изменение Gupr_elem
CREATE OR REPLACE FUNCTION updateGupr_elem(VARCHAR(50), VARCHAR(50))
RETURNS VOID AS $$
BEGIN
  INSERT INTO Log_Users(User_Name, TimeAction, TableAction, Action)
  VALUES (current_user, now(), 'gupr_elem', 'UPDATE');
  UPDATE Gupr_elem
  SET name_gupr_elem=$2
  WHERE name_gupr_elem=$1;
END;
$$ LANGUAGE plpgsql;

--Изменение Gupr
CREATE OR REPLACE FUNCTION updateGupr(INT, INT, INT, INT)
RETURNS VOID AS $$
BEGIN
  INSERT INTO Log_Users(User_Name, TimeAction, TableAction, Action)
  VALUES (current_user, now(), 'gupr', 'UPDATE');
  UPDATE Gupr
  SET duration=$2, Gupr_elem_id_gupr_elem=$4
  WHERE duration=$1 AND Gupr_elem_id_gupr_elem=$3;
END;
$$ LANGUAGE plpgsql;

--Изменение Kafedra
CREATE OR REPLACE FUNCTION updateKafedra(VARCHAR(50), VARCHAR(50))
RETURNS VOID AS $$
BEGIN
  INSERT INTO Log_Users(User_Name, TimeAction, TableAction, Action)
  VALUES (current_user, now(), 'kafedra', 'UPDATE');
  UPDATE Kafedra
  SET name_kaf=$2
  WHERE name_kaf=$1;
END;
$$ LANGUAGE plpgsql;

--Изменение Kaf_Rasp
CREATE OR REPLACE FUNCTION updateKaf_Rasp(INT, INT, INT, INT, INT, INT)
RETURNS VOID AS $$
BEGIN
  INSERT INTO Log_Users(User_Name, TimeAction, TableAction, Action)
  VALUES (current_user, now(), 'kaf_rasp', 'UPDATE');
  UPDATE Kaf_Rasp
  SET Speciality_id_spec=$2, Discipline_id_disc=$4, Kafedra_id_kaf=$6
  WHERE Speciality_id_spec=$1 AND Discipline_id_disc=$3 AND Kafedra_id_kaf=$5;
END;
$$ LANGUAGE plpgsql;

--Изменение Semestr
-- CREATE OR REPLACE FUNCTION updateSemestr()
-- RETURNS VOID AS $$
-- BEGIN
--   INSERT INTO Log_Users(User_Name, TimeAction, TableAction, Action)
--   VALUES (current_user, now(), 'semestr', 'UPDATE');
--   INSERT INTO Semestr () VALUES ();
-- END;
-- $$ LANGUAGE plpgsql;

--Изменение Uch_Load
CREATE OR REPLACE FUNCTION updateUch_Load(INT, INT, INT, INT, INT, INT, INT, INT, INT, INT)
RETURNS VOID AS $$
BEGIN
  INSERT INTO Log_Users(User_Name, TimeAction, TableAction, Action)
  VALUES (current_user, now(), 'uch_load', 'UPDATE');
  UPDATE Uch_Load
  SET hours=$2, Uch_Plan_id_uch=$4, Speciality_id_spec=$6, Semestr_id_semestr=$8, Discipline_id_disc=$10
  WHERE hours=$1 AND Uch_Plan_id_uch=$3 AND Speciality_id_spec=$5 AND Semestr_id_semestr=$7 AND Discipline_id_disc=$9;
END;
$$ LANGUAGE plpgsql;

--Изменение number_weeks
CREATE OR REPLACE FUNCTION updateNumber_Weeks(INT, INT)
RETURNS VOID AS $$
BEGIN
  INSERT INTO Log_Users(User_Name, TimeAction, TableAction, Action)
  VALUES (current_user, now(), 'number_weeks', 'UPDATE');
  UPDATE number_weeks
  SET number=$2
  WHERE number=$1;
END;
$$ LANGUAGE plpgsql;
