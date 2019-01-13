using EFCoreUpdateDelete.BusinessModels;
using EFCoreUpdateDelete.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EFCoreUpdateDelete
{
    class Program
    {
        static void Main(string[] args)
        {
            //UpdateWithSelect();

            //UpdateWithoutSelect();

            //DeleteWithoutSelect();

            Console.ReadLine();
        }

        private static void UpdateWithSelect()
        {
            using (var db = new DbNbaPlayerContext())
            {
                var playerFromDb = db.Players.Where(p => p.PlayerName == "Jaroslaw").FirstOrDefault();
                playerFromDb.PlayerName = "JAROSLAW";
                db.Entry(playerFromDb).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        private static void UpdateWithoutSelect()
        {
            using (var db = new DbNbaPlayerContext())
            {
                NbaPlayer playerToEdit = new NbaPlayer { Id = 1 };
                db.Players.Attach(playerToEdit);
                playerToEdit.PlayerLastNate = "RUDNIK";
                playerToEdit.PlayerName = "New Name";
                db.SaveChanges();
            }
        }

        private static void DeleteWithoutSelect()
        {
            using (var db = new DbNbaPlayerContext())
            {
                NbaPlayer playerToDelete = new NbaPlayer { Id = 1 };
                db.Players.Attach(playerToDelete);
                db.Players.Remove(playerToDelete);
                db.SaveChanges();
            }
        }
    }
}
