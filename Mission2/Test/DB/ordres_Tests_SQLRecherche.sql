use ProjetRH_TEST_V2;

select * from Entretien;

select * from Personne
where CodePostal = 53000
and YEAR(DateNais) <= 1984;

select * from Diplome;

select * 
from Personne_NN_Diplome left join Diplome 
on Diplome.Identifiant = Personne_NN_Diplome.ID_Diplome
where ID_Personne = 3 or ID_Personne = 5
and Niveau = 'II';

select * from Personne_NN_Diplome;

select ID_Personne--, Niveau, DateNais, CodePostal, Civilite.Libelle
from Personne_NN_Diplome 
inner join Diplome 
on Diplome.Identifiant = Personne_NN_Diplome.ID_Diplome
inner join Personne
on Personne.Identifiant = Personne_NN_Diplome.ID_Personne
inner join Civilite
on Personne.ID_Civilite = Civilite.Identifiant
where Civilite.Libelle = 'Femme'
and Diplome.Niveau = 'II';

select Nom, Prenom, DateNais, Civilite.Libelle, Date, Responsable 
from Personne
inner join Entretien
on Personne.Identifiant = Entretien.ID_Personne
inner join Civilite
on Personne.ID_Civilite = Civilite.Identifiant
where Civilite.Libelle = 'Femme'
and Responsable = 'Charles II';

select Personne.Identifiant--Nom, Prenom, DateNais, Civilite.Libelle, Date, Responsable 
from Personne
inner join Civilite
on Personne.ID_Civilite = Civilite.Identifiant
inner join Entretien
on Personne.Identifiant = Entretien.ID_Personne
where Civilite.Libelle = 'Femme'
and Responsable = 'Charles II';

Select Entretien.Identifiant--, Entretien.Date, Personne.Identifiant, Poste.Libelle
from Entretien
inner join Personne
on Personne.Identifiant = Entretien.ID_Personne
inner join Civilite
on Personne.ID_Civilite = Civilite.Identifiant
inner join Poste
on Personne.ID_Poste = Poste.Identifiant
where Civilite.Libelle = 'Femme'
and Poste.Libelle = 'Secrétaire';

select ID_Personne, Diplome.Libelle
from Personne_NN_Diplome 
inner join Diplome 
on Diplome.Identifiant = Personne_NN_Diplome.ID_Diplome
inner join Personne
on Personne.Identifiant = Personne_NN_Diplome.ID_Personne
where ID_Personne = 3 or ID_Personne = 10
and Diplome.Libelle = 'Maîtrise';

select Entretien.Identifiant, Poste.Libelle--, Entretien.ID_Personne, Personne.Identifiant
from Entretien
inner join Personne
on Personne.Identifiant = Entretien.ID_Personne
inner join Poste
on Poste.Identifiant = Personne.ID_Poste
where Poste.Libelle = 'Peintre industriel';
-- resultat : 1 et 6

select ID_Personne, Diplome.Libelle, Diplome.Niveau
from Personne_NN_Diplome 
inner join Diplome 
on Diplome.Identifiant = Personne_NN_Diplome.ID_Diplome
inner join Personne
on Personne.Identifiant = Personne_NN_Diplome.ID_Personne
where (ID_Personne = 1 or ID_Personne = 6)
and Diplome.Niveau = 'IV';
-- resultat : 1



select Personne.Identifiant--, Civilite.Libelle
from Personne
inner join Civilite
on Civilite.Identifiant = Personne.ID_Civilite
where Civilite.Libelle = 'Femme';
--resultat : 3, 5, 6, 9, 10

select ID_Personne, Diplome.Libelle, Diplome.Niveau
from Personne_NN_Diplome 
inner join Diplome 
on Diplome.Identifiant = Personne_NN_Diplome.ID_Diplome
inner join Personne
on Personne.Identifiant = Personne_NN_Diplome.ID_Personne
where (Personne.Identifiant = 3 
or Personne.Identifiant = 5
or Personne.Identifiant = 6
or Personne.Identifiant = 9
or Personne.Identifiant = 10)
and Diplome.Niveau = 'I';
-- resultat : 5, 6

select Entretien.ID_Personne--, SouhaitFormation.Lieu
from Entretien_NN_SouhaitFormation
inner join Entretien
on Entretien.Identifiant = Entretien_NN_SouhaitFormation.ID_Entretien
inner join SouhaitFormation
on SouhaitFormation.Identifiant = Entretien_NN_SouhaitFormation.ID_SouhaitFormation
where (ID_Personne = 5 or ID_Personne = 6)
and SouhaitFormation.Lieu = 'Nogent le Rotrou';



select ID_Personne
from (
	select Entretien.ID_Personne
	from Entretien_NN_SouhaitFormation
	inner join Entretien
	on Entretien.Identifiant = Entretien_NN_SouhaitFormation.ID_Entretien
	inner join SouhaitFormation
	on SouhaitFormation.Identifiant = Entretien_NN_SouhaitFormation.ID_SouhaitFormation
	where SouhaitFormation.Lieu = 'Nogent le Rotrou'
) v
where ID_Personne in 
	(
	select ID_Personne
	from Personne_NN_Diplome 
	inner join Diplome 
	on Diplome.Identifiant = Personne_NN_Diplome.ID_Diplome
	inner join Personne
	on Personne.Identifiant = Personne_NN_Diplome.ID_Personne
	where Diplome.Niveau = 'I' 
	)
and ID_personne in
	(
	select Personne.Identifiant--, Civilite.Libelle
	from Personne
	inner join Civilite
	on Civilite.Identifiant = Personne.ID_Civilite
	where Civilite.Libelle = 'Femme'
	)



select Personne.Identifiant
from Personne
where Identifiant in 
	(
	select Entretien.ID_Personne
	from Entretien_NN_SouhaitFormation
	inner join Entretien
	on Entretien.Identifiant = Entretien_NN_SouhaitFormation.ID_Entretien
	inner join SouhaitFormation
	on SouhaitFormation.Identifiant = Entretien_NN_SouhaitFormation.ID_SouhaitFormation
	where SouhaitFormation.Lieu = 'Nogent le Rotrou'
	)
and Identifiant in 
	(
	select ID_Personne
	from Personne_NN_Diplome 
	inner join Diplome 
	on Diplome.Identifiant = Personne_NN_Diplome.ID_Diplome
	inner join Personne
	on Personne.Identifiant = Personne_NN_Diplome.ID_Personne
	where Diplome.Niveau = 'I' 
	)
and Identifiant in
	(
	select Personne.Identifiant
	from Personne
	inner join Civilite
	on Civilite.Identifiant = Personne.ID_Civilite
	where Civilite.Libelle = 'Femme'
	)




select Personne.Identifiant, Civilite.Libelle
from Personne inner join Civilite
on Personne.ID_Civilite = Civilite.Identifiant
where Personne.Identifiant in  
	(
	select Entretien.ID_Personne
	from Entretien_NN_SouhaitFormation
	inner join Entretien
	on Entretien.Identifiant = Entretien_NN_SouhaitFormation.ID_Entretien
	inner join SouhaitFormation
	on SouhaitFormation.Identifiant = Entretien_NN_SouhaitFormation.ID_SouhaitFormation
	where SouhaitFormation.Lieu = 'Nogent le Rotrou'
	)
order by Civilite.Libelle



select SouhaitFormation.Lieu, Personne.Identifiant
from Entretien_NN_SouhaitFormation
inner join Entretien
on Entretien.Identifiant = Entretien_NN_SouhaitFormation.ID_Entretien
inner join SouhaitFormation
on SouhaitFormation.Identifiant = Entretien_NN_SouhaitFormation.ID_SouhaitFormation
inner join Personne 
on Entretien.ID_Personne = Personne.Identifiant
where Personne.ID_Civilite in  
	(
	select Identifiant
	from Civilite
	where Libelle = 'Femme'
	)
order by SouhaitFormation.Lieu


select CodePostal, Personne.Identifiant
from Personne
where Identifiant in
	(
	select Personne.Identifiant
	from Civilite
	inner join Personne
	on Civilite.Identifiant = Personne.ID_Civilite
	where Civilite.Libelle = 'Femme'
	)
and Identifiant in
	(
	select Personne.Identifiant
	--from Entretien_NN_SouhaitFormation
	--inner join Entretien
	--on Entretien.Identifiant = Entretien_NN_SouhaitFormation.ID_Entretien
	--inner join SouhaitFormation
	--on SouhaitFormation.Identifiant = Entretien_NN_SouhaitFormation.ID_SouhaitFormation
	--inner join Personne
	--on Personne.Identifiant = Entretien.ID_Personne
	from Personne
	inner join Entretien
	on Entretien.ID_Personne = Personne.Identifiant
	inner join Entretien_NN_SouhaitFormation
	on Entretien_NN_SouhaitFormation.ID_Entretien = Entretien.Identifiant
	inner join SouhaitFormation
	on Entretien_NN_SouhaitFormation.ID_SouhaitFormation = SouhaitFormation.Identifiant
	where SouhaitFormation.Lieu = 'Paris'
	)
order by CodePostal



select Entretien.Identifiant, Diplome.Niveau
from Entretien
inner join Personne
on Entretien.ID_Personne = Personne.Identifiant
inner join Civilite
on Civilite.Identifiant = Personne.ID_Civilite
inner join Entretien_NN_SouhaitFormation
on Entretien.Identifiant = Entretien_NN_SouhaitFormation.ID_Entretien
inner join SouhaitFormation
on SouhaitFormation.Identifiant = Entretien_NN_SouhaitFormation.ID_SouhaitFormation
inner join Personne_NN_Diplome
on Personne.Identifiant = Personne_NN_Diplome.ID_Personne
left join Diplome
on Diplome.Identifiant = Personne_NN_Diplome.ID_Diplome
where Civilite.Libelle = 'Femme'
--and SouhaitFormation.Lieu = 'Paris'	
order by Diplome.Niveau	
--and Diplome.Niveau = 'IV'

select Entretien.Identifiant, Diplome.Niveau
from Personne
inner join Entretien
on Entretien.ID_Personne = Personne.Identifiant
inner join Civilite
on Civilite.Identifiant = Personne.ID_Civilite
inner join Entretien_NN_SouhaitFormation
on Entretien.Identifiant = Entretien_NN_SouhaitFormation.ID_Entretien
inner join SouhaitFormation
on SouhaitFormation.Identifiant = Entretien_NN_SouhaitFormation.ID_SouhaitFormation
inner join Personne_NN_Diplome
on Personne.Identifiant = Personne_NN_Diplome.ID_Personne
left join Diplome
on Diplome.Identifiant = Personne_NN_Diplome.ID_Diplome
where Civilite.Libelle = 'Femme'
--and SouhaitFormation.Lieu = 'Paris'	
order by Diplome.Niveau	


select * from Evaluation;