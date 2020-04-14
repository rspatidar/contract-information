using EvolentHealth.Core.DataInterface.Base;
using EvolentHealth.Core.Model.Base;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EvolentHealth.Data.Repositories.Base
{
    public class FileRepositoryBase<T> : IRepository<T> where T : IEntity
    {
        private static readonly string _fileDirectory = "DataStore";

        private readonly string _filePath;

        public FileRepositoryBase(string fileName)
        {
            _filePath = Path.Combine(_fileDirectory, fileName);
        }

        public virtual Task<IEnumerable<T>> GetAllAsync()
        {
            IEnumerable<T> items = null;
            if (File.Exists(_filePath))
            {
                var json = File.ReadAllText(_filePath);
                if (!string.IsNullOrEmpty(json))
                {
                    items = JsonConvert.DeserializeObject<List<T>>(json);
                }
            }

            return Task.FromResult(items ?? Enumerable.Empty<T>());
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            var allItems = await GetAllAsync();
            return allItems.Single(x => x.Id == id);
        }

        public virtual async Task<T> CreateAsync(T item)
        {
            var allItemsEnumerable = await GetAllAsync();
            var allItems = allItemsEnumerable.ToList();

            var isNew = item.Id == 0;
            if (isNew)
            {
                item.Id = GetNextId(allItems);
            }

            InsertOrUpdateItem(item, allItems);

            WriteCollectionToFile(allItems);

            return item;
        }

        public virtual async Task<T> UpdateAsync(T item)
        {
            var allItemsEnumerable = await GetAllAsync();
            var allItems = allItemsEnumerable.ToList();

            InsertOrUpdateItem(item, allItems);
            WriteCollectionToFile(allItems);

            return item;
        }

        public virtual async Task<T>DeleteAsync(T item)
        {
            var allItemsEnumerable = await GetAllAsync();
            var allItems = allItemsEnumerable.ToList();

            DeleteItem(item, allItems);
            WriteCollectionToFile(allItems);

            return item;
        }

        private static int GetNextId(List<T> allItems)
        {
            var maxId = allItems.Any() ? allItems.Max(x => x.Id) : 0;
            return maxId + 1;
        }

        private static void InsertOrUpdateItem(T item, List<T> allItems)
        {
            var existingItem = allItems.SingleOrDefault(x => x.Id == item.Id);
            if (existingItem != null)
            {
                var index = allItems.IndexOf(existingItem);
                allItems.Insert(index, item);
                allItems.Remove(existingItem);
            }
            else
            {
                allItems.Add(item);
            }
        }
        private static void DeleteItem(T item, List<T> allItems)
        {
            var existingItem = allItems.SingleOrDefault(x => x.Id == item.Id);
            if (existingItem != null)
            {
                var index = allItems.IndexOf(existingItem);
                allItems.Remove(existingItem);
            }

        }

        private void WriteCollectionToFile(IEnumerable<T> allItems)
        {
            var json = JsonConvert.SerializeObject(allItems);
            File.WriteAllText(_filePath, json);
        }
    }

}
