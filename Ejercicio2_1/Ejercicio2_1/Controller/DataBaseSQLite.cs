using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ejercicio2_1.Model;
using SQLite;

namespace Ejercicio2_1.Controller
{
   public class DataBaseSQLite
    {

        readonly SQLiteAsyncConnection db;
 
        //constructor de la clase DataBaseSQLite
        public DataBaseSQLite(string pathdb)
        {
             db = new SQLiteAsyncConnection(pathdb);
            db.CreateTableAsync<foto>().Wait();
        }

        //Operaciones crud de sqlite
        //Read List way
        public Task<List<foto>> ObtenerListafotov()
        {
            return db.Table<foto>().ToListAsync();
        }

        //read one by one 
        public Task<foto> Obtenerfotov(int pcodigo)
        {
            return db.Table<foto>()
                .Where(i => i.codigo == pcodigo)
                .FirstOrDefaultAsync();
        }

        //Create o update personas
        public Task<int> Grabarfotov(foto fotov)
        {
            if (fotov.codigo != 0)
            {
               return db.UpdateAsync(fotov);
            }
            else
            {
                return db.InsertAsync(fotov);
            }
            
        }

  

        //delete
        public Task<int> Eliminarfotov(foto fotov)
        {
            return db.DeleteAsync(fotov);
        }


    }
}
