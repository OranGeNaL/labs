--CREATE TABLE IF NOT EXISTS Course (number_course INTEGER);

CREATE TABLE IF NOT EXISTS Discipline (id_disc SERIAL, name_disc VARCHAR(50) UNIQUE NOT NULL, PRIMARY KEY (id_disc));

CREATE TABLE IF NOT EXISTS Speciality (id_spec SERIAL, name_spec VARCHAR(50) UNIQUE NOT NULL, PRIMARY KEY (id_spec));

CREATE TABLE IF NOT EXISTS Uch_Plan (id_uch SERIAL, name_uch VARCHAR(50) UNIQUE NOT NULL, Speciality_id_spec INTEGER, PRIMARY KEY (id_uch),  FOREIGN KEY (Speciality_id_spec) REFERENCES Speciality (id_spec) ON DELETE CASCADE ON UPDATE RESTRICT);

CREATE TABLE IF NOT EXISTS Gruppa (id_group SERIAL, name_group VARCHAR(50) UNIQUE NOT NULL, enter_date DATE NOT NULL, Uch_Plan_id_uch INTEGER, Speciality_id_spec INTEGER, PRIMARY KEY (id_group),  FOREIGN KEY (Speciality_id_spec) REFERENCES Speciality (id_spec) ON DELETE CASCADE ON UPDATE RESTRICT,  FOREIGN KEY (Uch_Plan_id_uch) REFERENCES Uch_Plan (id_uch) ON DELETE CASCADE ON UPDATE RESTRICT);

CREATE TABLE IF NOT EXISTS Gupr_elem (id_gupr_elem SERIAL, name_gupr_elem VARCHAR(50) UNIQUE NOT NULL, PRIMARY KEY (id_gupr_elem));

--CREATE TABLE IF NOT EXISTS Gupr (duration INTEGER, Gupr_elem_id_gupr_elem INTEGER,  FOREIGN KEY (Gupr_elem_id_gupr_elem) REFERENCES Gupr_elem (id_gupr_elem) ON DELETE CASCADE ON UPDATE RESTRICT);

CREATE TABLE IF NOT EXISTS Gupr (duration INTEGER, number_course INTEGER, number_weeks INTEGER, Gupr_elem_id_gupr_elem INTEGER, uch_plan_id_gupr INTEGER,  FOREIGN KEY (Gupr_elem_id_gupr_elem) REFERENCES Gupr_elem (id_gupr_elem) ON DELETE CASCADE ON UPDATE RESTRICT, FOREIGN KEY (uch_plan_id_gupr) REFERENCES Uch_Plan (id_uch) ON DELETE CASCADE ON UPDATE RESTRICT);

CREATE TABLE IF NOT EXISTS Kafedra (id_kaf SERIAL, name_kaf VARCHAR(50) UNIQUE NOT NULL, PRIMARY KEY (id_kaf));

CREATE TABLE IF NOT EXISTS Kaf_Rasp (Speciality_id_spec INT, Discipline_id_disc INTEGER, Kafedra_id_kaf INTEGER, PRIMARY KEY (Speciality_id_spec, Discipline_id_disc),  FOREIGN KEY (Discipline_id_disc) REFERENCES Discipline (id_disc) ON DELETE CASCADE ON UPDATE RESTRICT,  FOREIGN KEY (Kafedra_id_kaf) REFERENCES Kafedra (id_kaf) ON DELETE CASCADE ON UPDATE RESTRICT,  FOREIGN KEY (Speciality_id_spec) REFERENCES Speciality (id_spec) ON DELETE CASCADE ON UPDATE RESTRICT);

--CREATE TABLE IF NOT EXISTS Semestr (id_semestr INT, PRIMARY KEY (id_semestr));

--CREATE TABLE IF NOT EXISTS Uch_Load (hours INTEGER, Uch_Plan_id_uch INTEGER, Speciality_id_spec INTEGER, Semestr_id_semestr INTEGER, Discipline_id_disc INTEGER, PRIMARY KEY (Uch_Plan_id_uch, Semestr_id_semestr, Discipline_id_disc),  FOREIGN KEY (Discipline_id_disc) REFERENCES Discipline (id_disc) ON DELETE CASCADE ON UPDATE RESTRICT,  FOREIGN KEY (Semestr_id_semestr) REFERENCES Semestr (id_semestr) ON DELETE CASCADE ON UPDATE RESTRICT,  FOREIGN KEY (Speciality_id_spec) REFERENCES Speciality (id_spec) ON DELETE CASCADE ON UPDATE RESTRICT,  FOREIGN KEY (Uch_Plan_id_uch) REFERENCES Uch_Plan (id_uch) ON DELETE CASCADE ON UPDATE RESTRICT);

CREATE TABLE IF NOT EXISTS Uch_Load (hours VARCHAR(50), Uch_Plan_id_uch INTEGER, Speciality_id_spec INTEGER, Semestr_id_semestr INTEGER, Discipline_id_disc INTEGER, PRIMARY KEY (Uch_Plan_id_uch, Semestr_id_semestr, Discipline_id_disc),  FOREIGN KEY (Discipline_id_disc) REFERENCES Discipline (id_disc) ON DELETE CASCADE ON UPDATE RESTRICT,  FOREIGN KEY (Speciality_id_spec) REFERENCES Speciality (id_spec) ON DELETE CASCADE ON UPDATE RESTRICT,  FOREIGN KEY (Uch_Plan_id_uch) REFERENCES Uch_Plan (id_uch) ON DELETE CASCADE ON UPDATE RESTRICT);

--CREATE TABLE IF NOT EXISTS number_weeks (number INTEGER);

CREATE TABLE IF NOT EXISTS Log_Users (id_action SERIAL UNIQUE NOT NULL, User_Name VARCHAR(50), TimeAction TIMESTAMP, TableAction VARCHAR(30), Action VARCHAR(50), PRIMARY KEY(id_action));
