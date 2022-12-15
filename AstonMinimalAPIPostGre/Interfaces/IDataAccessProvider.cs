using AstonMinimalAPIPostGre.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AstonMinimalAPIPostGre.Controllers
{
    public interface IDataAccessProvider
    {
        void AddItemRecord(Item item);
        void UpdateItemtRecord(Item item);
        void DeleteItemRecord(string id);
        Item GetItemSingleRecord(string id);
        List<Item> GetPatientRecords();
    }
}
