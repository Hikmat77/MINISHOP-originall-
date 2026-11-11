namespace Application.DTOs;

public class CategoryWithProducts
{
    public int Id {get; set;}
    public string Name {get; set;}=null!;

    public List<ProductDto> Products {get; set;}=[];
}
