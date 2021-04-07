using GameBoardAuction.Entities;
using GameBoardAuction.Entities.Base;
using GameBoardAuction.Repositories.Base.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameBoardAuction.Repositories.Base
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, IEntity, new()
    {
        protected readonly GameBoardAuctionContext _context;

        public BaseRepository(GameBoardAuctionContext context)
        {
            _context = context;
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            if(entity == null)
                throw new ArgumentNullException($"{nameof(Add)} entity must not be null");

            try
            {
                await _context.AddAsync(entity);
                await _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be saved: {ex.Message}");
            }
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException($"{nameof(Update)} entity must not be null");

            try
            {
                _context.Update(entity);
                await _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated: {ex.Message}");
            }
        }

        public Task Delete(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(IEnumerable<TEntity> entities)
        {
            throw new System.NotImplementedException();
        }
    }
}
