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

        public void AddItemRecord(Person item)
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

        public Person GetItemSingleRecord(string id)
        {
            return _context.items.FirstOrDefault(t => t.ItemId == id);
        }

        public List<Person> GetPatientRecords(string id)
        {
            
            return _context.items.ToList();
        }

        public List<Person> GetPatientRecords()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateItemtRecord(Person item)
        {
            _context.items.Update(item);
            _context.SaveChanges();
        }
    }
}
