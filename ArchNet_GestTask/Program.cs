using ArchNet_GestTask.Models.Entities;
using ArchNet_GestTask.Models.Repositories;
using ArchNet_GestTask.Models.Services;
using System.Data.Common;
using System.Data.SqlClient;

namespace ArchNet_GestTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using(DbConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ArchNet_GestTask;Integrated Security=True;Connect Timeout=60;Encrypt=FALSE;"))
            {
                IPersonneRepository repository = new PersonneService(connection);

                //repository.Inserer(new Personne() { Id = 1024, Nom = "Doe", Prenom = "John" });

                //foreach(Personne personne in repository.Get())
                //{
                //    Console.WriteLine($"{personne.Id} : {personne.Nom}");
                //}

                repository.Modifier(new Personne() { Id = 2, Nom = "Doe", Prenom = "Jane" });
            }

            //using (DbConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ArchNet_GestTask;Integrated Security=True;Connect Timeout=60;Encrypt=FALSE;"))
            //{
            //    IPersonneRepository repository = new PersonneService(connection);
                
            //    foreach (Personne personne in repository.Get())
            //    {
            //        Console.WriteLine($"{personne.Id} : {personne.Nom}");
            //    }
            //}

            using (DbConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ArchNet_GestTask;Integrated Security=True;Connect Timeout=60;Encrypt=FALSE;"))
            {
                ITacheRepository repository = new TacheService(connection);

                //repository.Inserer(new Tache() { Titre = "Test Tache", Description = "Test de création depuis le C#" });
                //repository.Modifier(new Tache() { Id = 1, Titre = "Test Tache", Description = "Test de modification depuis le C#" });
                //repository.Cloturer(1);

                //foreach(Tache tache in repository.Get())
                //{
                //    Console.WriteLine($"{tache.Id} : {tache.Titre} ({(tache.Cloturee ? "Cloturée" : "En Cours")})");
                //}

                Tache? tache = repository.Get(1);

                if (tache is not null)
                {
                    Console.WriteLine($"{tache.Id} : {tache.Titre} ({(tache.Cloturee ? "Cloturée" : "En Cours")})");
                }
            }

        }
    }
}
