namespace ELearning.Api.Query.Models;

public class Collection<T>
{
    public List<T> Items { get; set; } = [];
    public int Total { get; set; }
}