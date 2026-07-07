namespace ELearning.Api.Query.Models;

public class CollectionResult<T>
{
    public IReadOnlyList<T> Items { get; set; } = [];
    public int Total { get; set; }
}