using System.Text.Json.Serialization;

namespace WebApplication3.Models;

public class Items
{
    public int item_id { get; set; }
    public string title { get; set; }
    public  string link{ get; set; }
    public long date{ get; set; }
    
    
    
    [JsonIgnore]
    public ICollection<CatalogItemRelations> CatalogItemRelation { get; set; } = new List<CatalogItemRelations>();
}