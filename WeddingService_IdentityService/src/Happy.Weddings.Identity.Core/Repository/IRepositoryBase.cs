#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  04-Aug-2020 |    Sumith C       | Implemented. 
//              |                   | IRepositoryBase interface.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

#endregion

namespace Happy.Weddings.Identity.Core.Repository
{
    /// <summary>
    /// Generic respository interface to handle operations
    /// </summary>
    public interface IRepositoryBase<T>
    {
        /// <summary>
        /// Finds all.
        /// </summary>
        /// <returns></returns>
        IQueryable<T> FindAll();

        /// <summary>
        /// Finds the specified expression.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Creates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Create(T entity);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Update(T entity);

        /// <summary>
        /// Updates the range.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void UpdateRange(IEnumerable<T> entity);

        /// <summary>
        /// Creates the range.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void CreateRange(IEnumerable<T> entity);

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Delete(T entity);
    }
}
