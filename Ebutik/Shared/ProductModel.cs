namespace BlazorEcom.Shared;

public class ProductModel
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Category { get; set; } = String.Empty;
    public int Stock { get; set; }
    public bool Loaned { get; set; }
    public string ImgUrl { get; set; } = String.Empty;
    public double Price { get; set; }
}