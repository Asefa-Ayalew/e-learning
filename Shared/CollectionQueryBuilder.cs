using System.Linq.Expressions;
using ELearning.Api.Query;

public static class CollectionQueryBuilder<T>
{
    public static IQueryable<T> Apply(
        IQueryable<T> query,
        CollectionQuery request)
    {
        if (request.Filter != null)
        {
            query = QueryFilterBuilder<T>.Apply(query, request.Filter);
        }

        if (!string.IsNullOrWhiteSpace(request.Search) &&
            request.SearchFrom?.Length > 0)
        {
            query = ApplySearch(query, request.Search, request.SearchFrom);
        }

        if (request.OrderBy?.Count > 0)
        {
            query = ApplyOrdering(query, request.OrderBy);
        }

        if (request.Skip.HasValue)
            query = query.Skip(request.Skip.Value);

        if (request.Top.HasValue)
            query = query.Take(request.Top.Value);

        return query;
    }

    private static IQueryable<T> ApplySearch(
        IQueryable<T> query,
        string search,
        string[] fields)
    {
        var parameter = Expression.Parameter(typeof(T), "x");

        Expression? body = null;

        foreach (var field in fields)
        {
            var property = Expression.Property(parameter, field);

            if (property.Type != typeof(string))
                continue;

            var method = typeof(string).GetMethod("Contains", new[] { typeof(string) })!;
            var searchExpr = Expression.Constant(search);

            var contains = Expression.Call(property, method, searchExpr);

            body = body == null ? contains : Expression.OrElse(body, contains);
        }

        if (body == null)
            return query;

        var lambda = Expression.Lambda<Func<T, bool>>(body, parameter);
        return query.Where(lambda);
    }

    private static IQueryable<T> ApplyOrdering(
        IQueryable<T> query,
        List<OrderBy> orderBy)
    {
        IOrderedQueryable<T>? ordered = null;

        for (int i = 0; i < orderBy.Count; i++)
        {
            var ob = orderBy[i];

            var param = Expression.Parameter(typeof(T), "x");
            var property = Expression.Property(param, ob.Field);
            var lambda = Expression.Lambda(property, param);

            string method =
                i == 0
                    ? (ob.Direction == "desc" ? "OrderByDescending" : "OrderBy")
                    : (ob.Direction == "desc" ? "ThenByDescending" : "ThenBy");

            var result = typeof(Queryable)
                .GetMethods()
                .First(m => m.Name == method && m.GetParameters().Length == 2)
                .MakeGenericMethod(typeof(T), property.Type);

            ordered = (IOrderedQueryable<T>?)result.Invoke(null, new object[] { ordered ?? query, lambda });
        }

        return ordered ?? query;
    }
}