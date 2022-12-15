using AstonMinimalAPIPostGre.Models;
using System.Collections.Generic;
using System.Linq;
using static AstonMinimalAPIPostGre.DbContext.PostgreSqlContext;

namespace AstonMinimalAPIPostGre.Controllers
{
    public class DataAccessProvider : IDataAccessProvider
    {
        private readonly MyApplicationDbContext _context;

        public DataAccessProvider(MyApplicationDbContext context)
        {
            _context = context;
        }

        public void AddItemRecord(Item item)
        {
            _context.items.Add(item);
            _context.SaveChanges();
        }

        public void DeleteItemRecord(string id)
        {
            var entity = _context.items.FirstOrDefault(t => t.id == id);
            _context.items.Remove(entity);
            _context.SaveChanges(entity);
        }

        public Item GetItemSingleRecord(string id)
        {
            throw new System.NotImplementedException();
        }

        public List<Item> GetPatientRecords()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateItemtRecord(Item item)
        {
            throw new System.NotImplementedException();
        }
    }
}
