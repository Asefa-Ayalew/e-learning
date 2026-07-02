using ELearning.Api.Query.Models;

public class CollectionQuery
{
    public int? Skip { get; set; }
    public int? Top { get; set; }
    public string? Search { get; set; }
    public string[]? SearchFrom { get; set; }
    public List<OrderBy>? OrderBy { get; set; }
    public List<FilterGroup>? Filter { get; set; }
}

public class OrderBy
{
    public string Field { get; set; } = null!;
    public string Direction { get; set; } = "asc";
}