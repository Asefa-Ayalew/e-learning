namespace ELearning.Api.Query.Models;

public class FilterCondition
{
    public string Field { get; set; } = null!;
    public string Value { get; set; } = null!;
    public string Operator { get; set; } = "=";
}
public class FilterGroup : List<FilterCondition>
{
}