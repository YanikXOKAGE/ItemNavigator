namespace WebApplication3.Models;

public class Catalogs
{
    public int catalog_id { get; set; }
    public string catalog_name { get; set; }
    
    public ICollection<CatalogItemRelations> CatalogItemRelations { get; set; } = new List<CatalogItemRelations>();
}