using System.Collections.Generic;

namespace ECommerce.Models.ViewModels
{
    public class CategoryTreeEntry
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public List<CategoryTreeEntry> Children { get; set; }
        public int Count { get; set; }
    }
}