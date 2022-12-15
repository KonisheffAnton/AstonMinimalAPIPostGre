using System.ComponentModel.DataAnnotations;

namespace AstonMinimalAPIPostGre.Models
{
    public class Item
    {
        [Key]
        public string ItemId { get; set; }
        [Required]
        public string Name_Item { get; set; }
        [Range(1, 1000)]
        public double Price_Item { get; set; }
        public string Description_Item { get; set; }
        public string CategoryName_Item { get; set; }
        public string ImageUrl_Item { get; set; }
    }
}
