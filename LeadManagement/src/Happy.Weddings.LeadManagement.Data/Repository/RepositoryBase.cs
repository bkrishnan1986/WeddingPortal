#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  08-Sep-2020 |    Sumith C       | Created and implemented. 
//              |                   | RepositoryBase class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using Happy.Weddings.LeadManagement.Data.DatabaseContext;
using Happy.Weddings.LeadManagement.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

#endregion

namespace Happy.Weddings.LeadManagement.Data.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        /// <summary>
        /// Gets or sets the repository context.
        /// </summary>
        /// <value>
        /// The repository context.
        /// </value>
        protected LeadContext RepositoryContext { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryBase{T}"/> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        public RepositoryBase(LeadContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        /// <summary>
        /// Finds all.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public IQueryable<T> FindAll(string query, params object[] parameters)
        {
            return RepositoryContext.Set<T>().FromSqlRaw(query, parameters).AsNoTracking();
        }

        /// <summary>
        /// Finds all.
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> FindAll()
        {
            return RepositoryContext.Set<T>().AsNoTracking();
        }

        /// <summary>
        /// Finds the specified expression.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return RepositoryContext.Set<T>()
                .Where(expression).AsNoTracking();
        }

        /// <summary>
        /// Creates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Create(T entity)
        {
            RepositoryContext.Set<T>().Add(entity);
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Update(T entity)
        {
            RepositoryContext.Set<T>().Update(entity);
        }

        /// <summary>
        /// Creates the range.
        /// </summary>
        /// <param name="entities">The entities.</param>
        public void CreateRange(IEnumerable<T> entities)
        {
            RepositoryContext.Set<T>().AddRange(entities);
        }

        /// <summary>
        /// Updates the range.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void UpdateRange(IEnumerable<T> entities)
        {
            RepositoryContext.Set<T>().UpdateRange(entities);
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Delete(T entity)
        {
            RepositoryContext.Set<T>().Remove(entity);
        }
    }
}
