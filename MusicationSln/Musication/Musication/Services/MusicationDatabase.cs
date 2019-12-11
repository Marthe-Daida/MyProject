using Musication.Model;
using Musication.Model.Security;
using Musication.Services.Interfaces;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Musication.Services
{
    public class MusicationDatabase : IDatabase
    {
        private readonly SQLiteAsyncConnection database;
        public MusicationDatabase()
        {
            var dbPath = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Musication.db3");
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<UserProfile>().Wait();
        }
        public Task<List<UserProfile>> GetItemsAsync()
        {
            return database.Table<UserProfile>().ToListAsync();
        }
        public Task<List<UserProfile>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<UserProfile>("SELECT * FROM [Info]");
        }
        public Task<UserProfile> GetItemAsync(int id)
        {
            return database.Table<UserProfile>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }
        public Task<int> InsertTShirtOrder(UserProfile info)
        {
            return database.InsertAsync(info);
        }
        public Task<int> UpdateTShirtOrder(UserProfile info)
        {
            return database.UpdateAsync(info);
        }
        public Task<int> SaveItemAsync(UserProfile item)
        {
            return database.InsertAsync(item);
        }
    }
}

