using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;
using Projecte.Entity;
using Projecte.Persistence;
using MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Projecte.Service
{
    class ResponsableService
    {
        public static List<Responsable> GetAll()
        {
            IMongoCollection<Responsable> responsables = DbContext.GetResponsable();

            var result = responsables.AsQueryable<Responsable>().ToList();
            return result;
        }

        /// <summary>
        /// Afegeix un nou usuari a la base de dades
        /// </summary>
        /// <param name="user">Entitat usuari</param>
        /// <returns>El número d'usuaris afegits</returns>
        public int Add(Responsable responsable)
        {
            IMongoCollection<Responsable> responsables = DbContext.GetResponsable();

            responsables.InsertOne(responsable);

            return 1;
        }

        /// <summary>
        /// Actualitza un usuari
        /// </summary>
        /// <param name="user">Entitat usuari que es vol modificar</param>
        /// <returns>El número de usuaris modificats</returns>
        public long Update(Responsable responsable)
        {
            IMongoCollection<Responsable> responsables = DbContext.GetResponsable();

            var filter = Builders<Tasca>.Filter.Eq(s => s.ID, responsable.ID);
            var result = responsables.ReplaceOne(filter, responsable);

            return result.MatchedCount;
        }

        /// <summary>
        /// Elimina un usuari
        /// </summary>
        /// <param name="Id">Codi d'usuari que es vol eliminar</param>
        /// <returns>El número d'usuaris eliminats></returns>
        public long Delete(ObjectId ID)
        {
            IMongoCollection<Responsable> responsables = DbContext.GetResponsable();

            var result = responsables.DeleteOne(s => s.ID == ID);

            return result.DeletedCount;
        }
    }
}


        //Crear taula responsables
      /*  public static IEnumerable<Responsable> GetAll()
        {
            var result = new List<Responsable>();

            using (var ctx = DbContext.GetInstance())
            {
                var query = "SELECT * FROM Responsable";

                using (var command = new SQLiteCommand(query, ctx))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new Responsable
                            {
                                ID = Convert.ToInt32(reader["id"].ToString()),
                                Name = reader["Name"].ToString(),
                                
                            });
                        }
                    }
                }
            }
            return result;
        }
        public static int Add(Responsable responsable)
        {
            int rows_afected = 0;
            using (var ctx = DbContext.GetInstance())
            {
                string query = "INSERT INTO Responsable (name) VALUES (?)";
                using (var command = new SQLiteCommand(query, ctx))
                {
                    command.Parameters.Add(new SQLiteParameter("name", responsable.Name));
                 

                    rows_afected = command.ExecuteNonQuery();
                }
            }

            return rows_afected;
        }
        public static int Delete(int ID)
        {
            int rows_afected = 0;
            using (var ctx = DbContext.GetInstance())
            {
                string query = "DELETE FROM Responsable WHERE Id = ?";
                using (var command = new SQLiteCommand(query, ctx))
                {
                    command.Parameters.Add(new SQLiteParameter("ID", ID));
                    rows_afected = command.ExecuteNonQuery();
                }
            }

            return rows_afected;
        }

    }


}


    */