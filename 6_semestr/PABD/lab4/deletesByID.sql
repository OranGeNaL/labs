--Удаление из Course
CREATE OR REPLACE FUNCTION deleteByIDFromCourse(INT)
RETURNS VOID AS $$
BEGIN
  INSERT INTO Log_Users(User_Name, TimeAction, TableAction, Action)
  VALUES (current_user, now(), 'course', 'DELETE');
  DELETE FROM Course
  WHERE number_course=$1;
END;
$$ LANGUAGE plpgsql;

--Удаление из Discipline
CREATE OR REPLACE FUNCTION deleteByIDFromDiscipline(INT)
RETURNS VOID AS $$
BEGIN
  INSERT INTO Log_Users(User_Name, TimeAction, TableAction, Action)
  VALUES (current_user, now(), 'discipline', 'DELETE');
  DELETE FROM Discipline
  WHERE id_disc=$1;
END;
$$ LANGUAGE plpgsql;

--Удаление из Speciality
CREATE OR REPLACE FUNCTION deleteByIDFromSpeciality(INT)
RETURNS VOID AS $$
BEGIN
  INSERT INTO Log_Users(User_Name, TimeAction, TableAction, Action)
  VALUES (current_user, now(), 'speciality', 'DELETE');
  DELETE FROM Speciality
  WHERE id_spec=$1;
END;
$$ LANGUAGE plpgsql;

--Удаление из Uch_Plan
CREATE OR REPLACE FUNCTION deleteByIDFromUchPlan(INT)
RETURNS VOID AS $$
BEGIN
  INSERT INTO Log_Users(User_Name, TimeAction, TableAction, Action)
  VALUES (current_user, now(), 'uch_plan', 'DELETE');
  DELETE FROM Uch_Plan
  WHERE id_uch=$1;
END;
$$ LANGUAGE plpgsql;

--Удаление из Gruppa
CREATE OR REPLACE FUNCTION deleteByIDFromGruppa(INT)
RETURNS VOID AS $$
BEGIN
  INSERT INTO Log_Users(User_Name, TimeAction, TableAction, Action)
  VALUES (current_user, now(), 'gruppa', 'DELETE');
  DELETE FROM Gruppa
  WHERE id_group=$1;
END;
$$ LANGUAGE plpgsql;

--Удаление из Gupr_elem
CREATE OR REPLACE FUNCTION deleteByIDFromGupr_elem(INT)
RETURNS VOID AS $$
BEGIN
  INSERT INTO Log_Users(User_Name, TimeAction, TableAction, Action)
  VALUES (current_user, now(), 'gupr_elem', 'DELETE');
  DELETE FROM Gupr_elem
  WHERE id_gupr_elem=$1;
END;
$$ LANGUAGE plpgsql;

--Удаление из Kafedra
CREATE OR REPLACE FUNCTION deleteByIDFromKafedra(INT)
RETURNS VOID AS $$
BEGIN
  INSERT INTO Log_Users(User_Name, TimeAction, TableAction, Action)
  VALUES (current_user, now(), 'kafedra', 'DELETE');
  DELETE FROM Kafedra
  WHERE id_kaf=$1;
END;
$$ LANGUAGE plpgsql;

--Удаление из Semestr
CREATE OR REPLACE FUNCTION deleteByIDFromSemestr(INT)
RETURNS VOID AS $$
BEGIN
  INSERT INTO Log_Users(User_Name, TimeAction, TableAction, Action)
  VALUES (current_user, now(), 'semestr', 'DELETE');
  DELETE FROM Semestr
  WHERE id_semestr=$1;
END;
$$ LANGUAGE plpgsql;
