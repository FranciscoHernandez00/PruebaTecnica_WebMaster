using Microsoft.EntityFrameworkCore;
using PruebaTecnica_WebMaster.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnica_WebMaster.Models.ImplementRepositoryPattern
{
    public class StoreRepository : IStoreRepository
    {
        private PruebaTecnica_WebMasterDbContext _context;
        private DbSet<Store> storesEntity;
        public StoreRepository(PruebaTecnica_WebMasterDbContext _context)
        {
            this._context = _context;
            storesEntity = _context.Set<Store>();
        }

        public void SaveStore(Store store)
        {
            _context.Entry(store).State = EntityState.Added;
            _context.SaveChanges();
        }

        public IEnumerable<Store> GetAllStores()
        {
            return storesEntity.AsEnumerable();
        }

        public Store GetStore(long id)
        {
            return storesEntity.SingleOrDefault(x => x.Id == id);
        }

        public void DeleteStore(long id)
        {
            Store store = GetStore(id);
            storesEntity.Remove(store);
            _context.SaveChanges();
        }

        public void UpdateStore(Store store)
        {
            _context.SaveChanges();
        }
    }
}
