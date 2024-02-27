using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApplication3.Models;

[Table("catalog_item_relations")]
public class CatalogItemRelations
{
    public int item_id { get; set; }
    public int catalog_id { get; set; }
    
    [JsonIgnore]
    public Items Items { get; set; }
    [JsonIgnore]
    public Catalogs Catalogs { get; set; }
}