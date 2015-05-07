namespace DreamFactory.Api.Implementation
{
    using System;
    using DreamFactory.Http;
    using DreamFactory.Model.Database;

    internal static class HttpAddressExtensions
    {
        public static IHttpAddress WithSqlQuery(this IHttpAddress httpAddress, SqlQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException("query");
            }

            if (query.ids != null)
            {
                httpAddress = httpAddress.WithParameter("ids", query.ids);
            }

            if (query.filter != null)
            {
                httpAddress = httpAddress.WithParameter("filter", query.filter);
            }

            if (query.order != null)
            {
                httpAddress = httpAddress.WithParameter("order", query.order);
            }

            if (query.offset.HasValue)
            {
                httpAddress = httpAddress.WithParameter("offset", query.offset.Value);
            }

            if (query.limit.HasValue)
            {
                httpAddress = httpAddress.WithParameter("limit", query.limit.Value);
            }

            if (query.fields != null)
            {
                httpAddress = httpAddress.WithParameter("fields", query.fields);
            }

            if (query.related != null)
            {
                httpAddress = httpAddress.WithParameter("related", query.related);
            }

            if (query.@continue.HasValue)
            {
                httpAddress = httpAddress.WithParameter("continue", query.@continue);
            }

            if (query.rollback.HasValue)
            {
                httpAddress = httpAddress.WithParameter("rollback", query.rollback);
            }

            return httpAddress;
        }
    }
}
