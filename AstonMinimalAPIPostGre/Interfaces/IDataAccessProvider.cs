using AstonMinimalAPIPostGre.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AstonMinimalAPIPostGre.Controllers
{
    public interface IDataAccessProvider
    {
        void AddItemRecord(Person item);
        void UpdateItemtRecord(Person item);
        void DeleteItemRecord(string id);
        Person GetItemSingleRecord(string id);
        List<Person> GetPatientRecords();
    }
}
