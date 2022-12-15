using AstonMinimalAPIPostGre.Models;
using System.Collections.Generic;
using System.Linq;


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
            var entity = _context.items.FirstOrDefault(t => t.ItemId == id);
            _context.items.Remove(entity);
            _context.SaveChanges();
        }

        public Item GetItemSingleRecord(string id)
        {
            return _context.items.FirstOrDefault(t => t.ItemId == id);
        }

        public List<Item> GetPatientRecords(string id)
        {
            
            return _context.items.ToList();
        }

        public List<Item> GetPatientRecords()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateItemtRecord(Item item)
        {
            _context.items.Update(item);
            _context.SaveChanges();
        }
    }
}
