use ProjetRH_TEST_V2;

select * from Civilite;

--insert into Civilite(Libelle) values('Homme');
--insert into Civilite(Libelle) values('Femme');

select * from Diplome;

--insert into Diplome(Libelle, Niveau) values('Brevet', 'V');
--insert into Diplome(Libelle, Niveau) values('Bac', 'IV');
--insert into Diplome(Libelle, Niveau) values('BTS', 'III');
--insert into Diplome(Libelle, Niveau) values('Maîtrise', 'II');
--insert into Diplome(Libelle, Niveau) values('Doctorat', 'I');

select * from Evaluation;

--insert into Evaluation(Relation, Qualite, Assiduite) values (4, 3, 5);
--insert into Evaluation(Relation, Qualite, Assiduite) values (1, 2, 2);
--insert into Evaluation(Relation, Qualite, Assiduite) values (5, 4, 4);
--insert into Evaluation(Relation, Qualite, Assiduite) values (2, 1, 3);
--insert into Evaluation(Relation, Qualite, Assiduite) values (3, 5, 1);

select * from Poste;

--insert into Poste(Libelle, DateDeb, DateFin, Responsable) 
--	values('Directeur RH', '10/12/2010', '04/05/2024', 'Toto I');
--insert into Poste(Libelle, DateDeb, DateFin, Responsable) 
--	values('Secrétaire', '12/12/2009', '05/04/2020', 'Toto II');
--insert into Poste(Libelle, DateDeb, DateFin, Responsable) 
--	values('Responsable Marketing', '01/02/2004', '05/12/2016', 'Toto I');
--insert into Poste(Libelle, DateDeb, DateFin, Responsable) 
--	values('Peintre industriel', '03/11/2003', '06/10/2020', 'Toto II');
--insert into Poste(Libelle, DateDeb, DateFin, Responsable) 
--	values('Chef de projet', '10/12/2010', '07/12/2018', 'Toto I');

select * from SouhaitFormation;

--insert into SouhaitFormation(Lieu, AvisResponsable) 
--	values ('Laval', 'Favorable');
--insert into SouhaitFormation(Lieu, AvisResponsable) 
--	values ('Mayenne', 'Défavorable');
--insert into SouhaitFormation(Lieu, AvisResponsable) 
--	values ('Paris', 'Favorable');
--insert into SouhaitFormation(Lieu, AvisResponsable) 
--	values ('Nogent le Rotrou', 'Défavorable');

select * from Personne;

--insert into Personne(Nom, Prenom, Email, DateNais, CodePostal, ID_Civilite, ID_Poste)
--	values('Esnault', 'Florent', 'f.esnault@mail.com', '04/12/1991', 53000, 1, 4);
--insert into Personne(Nom, Prenom, Email, DateNais, CodePostal, ID_Civilite, ID_Poste)
--	values('Daniel', 'Antoine', 'a.daniel@mail.com', '02/10/1985', 91000, 1, 5);
--insert into Personne(Nom, Prenom, Email, DateNais, CodePostal, ID_Civilite, ID_Poste)
--	values('Lechat', 'Marie', 'm.lechat@mail.com', '02/05/1970', 53000, 2, 2);
--insert into Personne(Nom, Prenom, Email, DateNais, CodePostal, ID_Civilite, ID_Poste)
--	values('Fufu', 'Florian', 'f.fufu@mail.com', '06/12/1984', 28000, 1, 3);
--insert into Personne(Nom, Prenom, Email, DateNais, CodePostal, ID_Civilite, ID_Poste)
--	values('Dufman', 'Laura', 'l.dufman@mail.com', '25/01/1959', 53000, 2, 1);
--insert into Personne(Nom, Prenom, Email, DateNais, CodePostal, ID_Civilite, ID_Poste)
--	values('Tchita', 'Sona', 's.tchita@mail.com', '22/04/1990', 28000, 2, 4);
--insert into Personne(Nom, Prenom, Email, DateNais, CodePostal, ID_Civilite, ID_Poste)
--	values('Trema', 'James', 'j.trema@mail.com', '09/09/1950', 91000, 1, 5);
--insert into Personne(Nom, Prenom, Email, DateNais, CodePostal, ID_Civilite, ID_Poste)
--	values('Jack', 'Michel', 'm.jack@mail.com', '04/12/1958', 53000, 1, 1);
--insert into Personne(Nom, Prenom, Email, DateNais, CodePostal, ID_Civilite, ID_Poste)
--	values('Sena', 'Elise', 'e.sena@mail.com', '16/07/1985', 91000, 2, 3);
--insert into Personne(Nom, Prenom, Email, DateNais, CodePostal, ID_Civilite, ID_Poste)
--	values('Jean', 'Jeanne', 'j.jean@mail.com', '29/02/1974', 28000, 2, 2);

select * from Entretien;

--insert into Entretien(Date, Responsable, HeureDeb, HeureFin, ID_Personne, ID_Evaluation)
--	values('01/01/2014', 'Charles', '9h00', '10h30', 1, 1);
--insert into Entretien(Date, Responsable, HeureDeb, HeureFin, ID_Personne, ID_Evaluation)
--	values('01/01/2014', 'Charles', '11h00', '12h30', 2, 3);
--insert into Entretien(Date, Responsable, HeureDeb, HeureFin, ID_Personne, ID_Evaluation)
--	values('01/01/2014', 'Charles', '14h00', '16h00', 3, 1);
--insert into Entretien(Date, Responsable, HeureDeb, HeureFin, ID_Personne, ID_Evaluation)
--	values('01/01/2014', 'Charles', '16h30', '18h00', 4, 4);
--insert into Entretien(Date, Responsable, HeureDeb, HeureFin, ID_Personne, ID_Evaluation)
--	values('02/03/2014', 'Charles II', '9h00', '10h00', 5, 5);
--insert into Entretien(Date, Responsable, HeureDeb, HeureFin, ID_Personne, ID_Evaluation)
--	values('02/03/2014', 'Charles II', '10h30', '11h00', 6, 2);
--insert into Entretien(Date, Responsable, HeureDeb, HeureFin, ID_Personne, ID_Evaluation)
--	values('02/03/2014', 'Charles II', '14h00', '15h00', 7, 3);
--insert into Entretien(Date, Responsable, HeureDeb, HeureFin, ID_Personne, ID_Evaluation)
--	values('02/03/2014', 'Charles II', '15h15', '16h00', 8, 1);
--insert into Entretien(Date, Responsable, HeureDeb, HeureFin, ID_Personne, ID_Evaluation)
--	values('03/03/2014', 'Charles II', '09h00', '10h00', 9, 2);
--insert into Entretien(Date, Responsable, HeureDeb, HeureFin, ID_Personne, ID_Evaluation)
--	values('02/03/2014', 'Charles II', '10h30', '12h00', 10, 5);

select * from Civilite;
select * from Evaluation;
select * from Poste;

select * from Diplome;
select * from Personne;
select * from Personne_NN_Diplome;

--insert into Personne_NN_Diplome(ID_Diplome, ID_Personne) values(2, 1);
--insert into Personne_NN_Diplome(ID_Diplome, ID_Personne) values(3, 2);
--insert into Personne_NN_Diplome(ID_Diplome, ID_Personne) values(4, 3);
--insert into Personne_NN_Diplome(ID_Diplome, ID_Personne) values(1, 4);
--insert into Personne_NN_Diplome(ID_Diplome, ID_Personne) values(5, 5);
--insert into Personne_NN_Diplome(ID_Diplome, ID_Personne) values(5, 6);
--insert into Personne_NN_Diplome(ID_Diplome, ID_Personne) values(3, 7);
--insert into Personne_NN_Diplome(ID_Diplome, ID_Personne) values(4, 8);
--insert into Personne_NN_Diplome(ID_Diplome, ID_Personne) values(2, 9);
--insert into Personne_NN_Diplome(ID_Diplome, ID_Personne) values(1, 10);

select * from SouhaitFormation;
select * from Entretien;
select * from Entretien_NN_SouhaitFormation;

--insert into Entretien_NN_SouhaitFormation(ID_Entretien, ID_SouhaitFormation)
--	values(1, 1);
--insert into Entretien_NN_SouhaitFormation(ID_Entretien, ID_SouhaitFormation)
--	values(2, 2);
--insert into Entretien_NN_SouhaitFormation(ID_Entretien, ID_SouhaitFormation)
--	values(3, 3);
--insert into Entretien_NN_SouhaitFormation(ID_Entretien, ID_SouhaitFormation)
--	values(4, 4);
--insert into Entretien_NN_SouhaitFormation(ID_Entretien, ID_SouhaitFormation)
--	values(5, 4);
--insert into Entretien_NN_SouhaitFormation(ID_Entretien, ID_SouhaitFormation)
--	values(6, 4);
--insert into Entretien_NN_SouhaitFormation(ID_Entretien, ID_SouhaitFormation)
--	values(7, 1);
--insert into Entretien_NN_SouhaitFormation(ID_Entretien, ID_SouhaitFormation)
--	values(8, 2);
--insert into Entretien_NN_SouhaitFormation(ID_Entretien, ID_SouhaitFormation)
--	values(9, 3);
--insert into Entretien_NN_SouhaitFormation(ID_Entretien, ID_SouhaitFormation)
--	values(10, 1);

select * from Civilite;
select * from Evaluation;
select * from Poste;
select * from Diplome;
select * from Personne;
select * from Personne_NN_Diplome;
select * from SouhaitFormation;
select * from Entretien;
select * from Entretien_NN_SouhaitFormation;