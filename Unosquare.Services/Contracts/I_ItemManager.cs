﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unosquare.Services.Contracts
{
    //TODO: Name of the interfaces should not have underscored, this should be named as IItemManager
    //TODO: The generic repository pattern should be applied at an entity level not at a service level? 
    public interface I_ItemManager<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(long id); 
        // TODO: This can contain a parameter of IEnumerable<TEntity> Get(
        //Expression<Func<TEntity, bool>> filter = null,
        //Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, 
        void Add(TEntity entity);
        void Update(TEntity dbEntity, TEntity entity);
        void Delete(TEntity entity);
    }
}
