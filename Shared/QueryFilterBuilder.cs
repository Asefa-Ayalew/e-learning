using System.Linq.Expressions;
using ELearning.Api.Query.Models;
namespace ELearning.Api.Query;

public static class QueryFilterBuilder<T>
{
    public static IQueryable<T> Apply(
        IQueryable<T> query,
        List<FilterGroup>? groups)
    {
        if (groups == null || groups.Count == 0)
            return query;

        Expression<Func<T, bool>>? final = null;

        foreach (var group in groups)
        {
            Expression<Func<T, bool>>? groupExpr = null;

            foreach (var c in group)
            {
                var expr = Build(c);

                groupExpr = groupExpr == null
                    ? expr
                    : groupExpr.Or(expr);
            }

            if (groupExpr == null) continue;

            final = final == null
                ? groupExpr
                : final.And(groupExpr);
        }

        return final == null ? query : query.Where(final);
    }

    private static Expression<Func<T, bool>> Build(FilterCondition c)
    {
        var param = Expression.Parameter(typeof(T), "x");
        var prop = Expression.Property(param, c.Field);

        var value = Convert.ChangeType(c.Value, Nullable.GetUnderlyingType(prop.Type) ?? prop.Type);
        var constant = Expression.Constant(value, prop.Type);

        Expression body = c.Operator switch
        {
            "=" => Expression.Equal(prop, constant),
            "!=" => Expression.NotEqual(prop, constant),
            ">" => Expression.GreaterThan(prop, constant),
            ">=" => Expression.GreaterThanOrEqual(prop, constant),
            "<" => Expression.LessThan(prop, constant),
            "<=" => Expression.LessThanOrEqual(prop, constant),

            "contains" =>
                Expression.Call(prop, nameof(string.Contains), null, constant),

            "startswith" =>
                Expression.Call(prop, nameof(string.StartsWith), null, constant),

            _ => throw new Exception("Invalid operator")
        };

        return Expression.Lambda<Func<T, bool>>(body, param);
    }
}