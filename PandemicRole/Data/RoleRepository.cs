using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PandemicRole.Entities;
using PandemicRole.Infrastructure;
using PandemicRole.Utilities.Extensions;
using SQLite;

namespace PandemicRole.Data
{
    public class RoleRepository
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public RoleRepository()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(Role).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(Role)).ConfigureAwait(false);                    
                }
                initialized = true;
            }
        }

        public Task<List<Role>> GetItemsAsync()
        {
            return Database.Table<Role>().ToListAsync();
        }

        public Task<List<Role>> GetItemsNotDoneAsync()
        {
            return Database.QueryAsync<Role>("SELECT * FROM [Role] WHERE [Done] = 0");
        }

        public Task<Role> GetItemAsync(int id)
        {
            return Database.Table<Role>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<Role> GetItemByNameAsync(string name)
        {
            return Database.Table<Role>().Where(i => i.Name == name).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Role item)
        {
            if (item.ID != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Role item)
        {
            return Database.DeleteAsync(item);
        }
    }
}

