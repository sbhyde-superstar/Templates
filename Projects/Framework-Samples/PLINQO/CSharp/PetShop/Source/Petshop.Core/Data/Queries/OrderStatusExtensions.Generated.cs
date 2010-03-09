﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a CodeSmith Template.
//
//     DO NOT MODIFY contents of this file. Changes to this
//     file will be lost if the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using CodeSmith.Data.Linq;
using CodeSmith.Data.Linq.Dynamic;

namespace PetShop.Core.Data
{
    /// <summary>
    /// The query extension class for OrderStatus.
    /// </summary>
    public static partial class OrderStatusExtensions
    {

        /// <summary>
        /// Gets an instance by the primary key.
        /// </summary>
        public static PetShop.Core.Data.OrderStatus GetByKey(this IQueryable<PetShop.Core.Data.OrderStatus> queryable, int orderId, int lineNum)
        {
            var entity = queryable as System.Data.Linq.Table<PetShop.Core.Data.OrderStatus>;
            if (entity != null && entity.Context.LoadOptions == null)
                return Query.GetByKey.Invoke((PetShop.Core.Data.PetShopDataContext)entity.Context, orderId, lineNum);

            return queryable.FirstOrDefault(o => o.OrderId == orderId 
					&& o.LineNum == lineNum);
        }

        /// <summary>
        /// Immediately deletes the entity by the primary key from the underlying data source with a single delete command.
        /// </summary>
        /// <param name="table">Represents a table for a particular type in the underlying database containing rows are to be deleted.</param>
        /// <returns>The number of rows deleted from the database.</returns>
        public static int Delete(this System.Data.Linq.Table<PetShop.Core.Data.OrderStatus> table, int orderId, int lineNum)
        {
            return table.Delete(o => o.OrderId == orderId 
					&& o.LineNum == lineNum);
        }

        /// <summary>
        /// Gets a query for <see cref="PetShop.Core.Data.OrderStatus.OrderId"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="orderId">OrderId to search for.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        public static IQueryable<PetShop.Core.Data.OrderStatus> ByOrderId(this IQueryable<PetShop.Core.Data.OrderStatus> queryable, int orderId)
        {
            return queryable.Where(o => o.OrderId == orderId);
        }

        /// <summary>
        /// Gets a query for <see cref="PetShop.Core.Data.OrderStatus.OrderId"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="orderId">OrderId to search for.</param>
        /// <param name="comparisonOperator">The comparison operator.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        public static IQueryable<PetShop.Core.Data.OrderStatus> ByOrderId(this IQueryable<PetShop.Core.Data.OrderStatus> queryable, int orderId, ComparisonOperator comparisonOperator)
        {
            switch (comparisonOperator)
            {
                case ComparisonOperator.GreaterThan:
                    return queryable.Where(o => orderId > o.OrderId);
                case ComparisonOperator.GreaterThanOrEquals:
                    return queryable.Where(o => orderId >= o.OrderId);
                case ComparisonOperator.LessThan:
                    return queryable.Where(o => orderId < o.OrderId);
                case ComparisonOperator.LessThanOrEquals:
                    return queryable.Where(o => orderId <= o.OrderId);
                case ComparisonOperator.NotEquals:
                    return queryable.Where(o => o.OrderId != orderId);
                default:
                    return queryable.Where(o => o.OrderId == orderId);
            }
        }

        /// <summary>
        /// Gets a query for <see cref="PetShop.Core.Data.OrderStatus.OrderId"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="orderId">OrderId to search for.</param>
        /// <param name="additionalValues">Additional values to search for.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        public static IQueryable<PetShop.Core.Data.OrderStatus> ByOrderId(this IQueryable<PetShop.Core.Data.OrderStatus> queryable, int orderId, params int[] additionalValues)
        {
            var orderIdList = new List<int> { orderId };

            if (additionalValues != null)
                orderIdList.AddRange(additionalValues);

            if (orderIdList.Count == 1)
                return queryable.ByOrderId(orderIdList[0]);

            return queryable.ByOrderId(orderIdList);
        }

        /// <summary>
        /// Gets a query for <see cref="PetShop.Core.Data.OrderStatus.OrderId"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="values">The values to search for..</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        public static IQueryable<PetShop.Core.Data.OrderStatus> ByOrderId(this IQueryable<PetShop.Core.Data.OrderStatus> queryable, IEnumerable<int> values)
        {
            return queryable.Where(o => values.Contains(o.OrderId));
        }

        /// <summary>
        /// Gets a query for <see cref="PetShop.Core.Data.OrderStatus.LineNum"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="lineNum">LineNum to search for.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        public static IQueryable<PetShop.Core.Data.OrderStatus> ByLineNum(this IQueryable<PetShop.Core.Data.OrderStatus> queryable, int lineNum)
        {
            return queryable.Where(o => o.LineNum == lineNum);
        }

        /// <summary>
        /// Gets a query for <see cref="PetShop.Core.Data.OrderStatus.LineNum"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="lineNum">LineNum to search for.</param>
        /// <param name="comparisonOperator">The comparison operator.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        public static IQueryable<PetShop.Core.Data.OrderStatus> ByLineNum(this IQueryable<PetShop.Core.Data.OrderStatus> queryable, int lineNum, ComparisonOperator comparisonOperator)
        {
            switch (comparisonOperator)
            {
                case ComparisonOperator.GreaterThan:
                    return queryable.Where(o => lineNum > o.LineNum);
                case ComparisonOperator.GreaterThanOrEquals:
                    return queryable.Where(o => lineNum >= o.LineNum);
                case ComparisonOperator.LessThan:
                    return queryable.Where(o => lineNum < o.LineNum);
                case ComparisonOperator.LessThanOrEquals:
                    return queryable.Where(o => lineNum <= o.LineNum);
                case ComparisonOperator.NotEquals:
                    return queryable.Where(o => o.LineNum != lineNum);
                default:
                    return queryable.Where(o => o.LineNum == lineNum);
            }
        }

        /// <summary>
        /// Gets a query for <see cref="PetShop.Core.Data.OrderStatus.LineNum"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="lineNum">LineNum to search for.</param>
        /// <param name="additionalValues">Additional values to search for.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        public static IQueryable<PetShop.Core.Data.OrderStatus> ByLineNum(this IQueryable<PetShop.Core.Data.OrderStatus> queryable, int lineNum, params int[] additionalValues)
        {
            var lineNumList = new List<int> { lineNum };

            if (additionalValues != null)
                lineNumList.AddRange(additionalValues);

            if (lineNumList.Count == 1)
                return queryable.ByLineNum(lineNumList[0]);

            return queryable.ByLineNum(lineNumList);
        }

        /// <summary>
        /// Gets a query for <see cref="PetShop.Core.Data.OrderStatus.LineNum"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="values">The values to search for..</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        public static IQueryable<PetShop.Core.Data.OrderStatus> ByLineNum(this IQueryable<PetShop.Core.Data.OrderStatus> queryable, IEnumerable<int> values)
        {
            return queryable.Where(o => values.Contains(o.LineNum));
        }

        /// <summary>
        /// Gets a query for <see cref="PetShop.Core.Data.OrderStatus.Timestamp"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="timestamp">Timestamp to search for.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        public static IQueryable<PetShop.Core.Data.OrderStatus> ByTimestamp(this IQueryable<PetShop.Core.Data.OrderStatus> queryable, System.DateTime timestamp)
        {
            return queryable.Where(o => o.Timestamp == timestamp);
        }

        /// <summary>
        /// Gets a query for <see cref="PetShop.Core.Data.OrderStatus.Timestamp"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="timestamp">Timestamp to search for.</param>
        /// <param name="comparisonOperator">The comparison operator.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        public static IQueryable<PetShop.Core.Data.OrderStatus> ByTimestamp(this IQueryable<PetShop.Core.Data.OrderStatus> queryable, System.DateTime timestamp, ComparisonOperator comparisonOperator)
        {
            switch (comparisonOperator)
            {
                case ComparisonOperator.GreaterThan:
                    return queryable.Where(o => timestamp > o.Timestamp);
                case ComparisonOperator.GreaterThanOrEquals:
                    return queryable.Where(o => timestamp >= o.Timestamp);
                case ComparisonOperator.LessThan:
                    return queryable.Where(o => timestamp < o.Timestamp);
                case ComparisonOperator.LessThanOrEquals:
                    return queryable.Where(o => timestamp <= o.Timestamp);
                case ComparisonOperator.NotEquals:
                    return queryable.Where(o => o.Timestamp != timestamp);
                default:
                    return queryable.Where(o => o.Timestamp == timestamp);
            }
        }

        /// <summary>
        /// Gets a query for <see cref="PetShop.Core.Data.OrderStatus.Timestamp"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="timestamp">Timestamp to search for.</param>
        /// <param name="additionalValues">Additional values to search for.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        public static IQueryable<PetShop.Core.Data.OrderStatus> ByTimestamp(this IQueryable<PetShop.Core.Data.OrderStatus> queryable, System.DateTime timestamp, params System.DateTime[] additionalValues)
        {
            var timestampList = new List<System.DateTime> { timestamp };

            if (additionalValues != null)
                timestampList.AddRange(additionalValues);

            if (timestampList.Count == 1)
                return queryable.ByTimestamp(timestampList[0]);

            return queryable.ByTimestamp(timestampList);
        }

        /// <summary>
        /// Gets a query for <see cref="PetShop.Core.Data.OrderStatus.Timestamp"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="values">The values to search for..</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        public static IQueryable<PetShop.Core.Data.OrderStatus> ByTimestamp(this IQueryable<PetShop.Core.Data.OrderStatus> queryable, IEnumerable<System.DateTime> values)
        {
            return queryable.Where(o => values.Contains(o.Timestamp));
        }

        /// <summary>
        /// Gets a query for <see cref="PetShop.Core.Data.OrderStatus.Status"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="status">Status to search for.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        public static IQueryable<PetShop.Core.Data.OrderStatus> ByStatus(this IQueryable<PetShop.Core.Data.OrderStatus> queryable, string status)
        {
            return queryable.Where(o => o.Status == status);
        }

        /// <summary>
        /// Gets a query for <see cref="PetShop.Core.Data.OrderStatus.Status"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="status">Status to search for.</param>
        /// <param name="containmentOperator">The containment operator.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        public static IQueryable<PetShop.Core.Data.OrderStatus> ByStatus(this IQueryable<PetShop.Core.Data.OrderStatus> queryable, string status, ContainmentOperator containmentOperator)
        {
            if (status == null && containmentOperator != ContainmentOperator.Equals && containmentOperator != ContainmentOperator.NotEquals)
                throw new ArgumentNullException("status", "Parameter 'status' cannot be null with the specified ContainmentOperator.  Parameter 'containmentOperator' must be ContainmentOperator.Equals or ContainmentOperator.NotEquals to support null.");

            switch (containmentOperator)
            {
                case ContainmentOperator.Contains:
                    return queryable.Where(o => o.Status.Contains(status));
                case ContainmentOperator.StartsWith:
                    return queryable.Where(o => o.Status.StartsWith(status));
                case ContainmentOperator.EndsWith:
                    return queryable.Where(o => o.Status.EndsWith(status));
                case ContainmentOperator.NotContains:
                    return queryable.Where(o => o.Status.Contains(status) == false);
                case ContainmentOperator.NotEquals:
                    return queryable.Where(o => o.Status != status);
                default:
                    return queryable.Where(o => o.Status == status);
            }
        }

        /// <summary>
        /// Gets a query for <see cref="PetShop.Core.Data.OrderStatus.Status"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="status">Status to search for.</param>
        /// <param name="additionalValues">Additional values to search for.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        public static IQueryable<PetShop.Core.Data.OrderStatus> ByStatus(this IQueryable<PetShop.Core.Data.OrderStatus> queryable, string status, params string[] additionalValues)
        {
            var statusList = new List<string> { status };

            if (additionalValues != null)
                statusList.AddRange(additionalValues);

            if (statusList.Count == 1)
                return queryable.ByStatus(statusList[0]);

            return queryable.ByStatus(statusList);
        }

        /// <summary>
        /// Gets a query for <see cref="PetShop.Core.Data.OrderStatus.Status"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="values">The values to search for..</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        public static IQueryable<PetShop.Core.Data.OrderStatus> ByStatus(this IQueryable<PetShop.Core.Data.OrderStatus> queryable, IEnumerable<string> values)
        {
            return queryable.Where(o => values.Contains(o.Status));
        }

        #region Query
        /// <summary>
        /// A private class for lazy loading static compiled queries.
        /// </summary>
        private static partial class Query
        {

            internal static readonly Func<PetShop.Core.Data.PetShopDataContext, int, int, PetShop.Core.Data.OrderStatus> GetByKey =
                System.Data.Linq.CompiledQuery.Compile(
                    (PetShop.Core.Data.PetShopDataContext db, int orderId, int lineNum) =>
                        db.OrderStatus.FirstOrDefault(o => o.OrderId == orderId 
							&& o.LineNum == lineNum));

        }
        #endregion
    }
}
