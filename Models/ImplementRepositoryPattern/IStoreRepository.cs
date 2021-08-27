using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnica_WebMaster.Models.ImplementRepositoryPattern
{
    public interface IStoreRepository
    {
        void SaveStore(Store store);
        IEnumerable<Store> GetAllStores();
        Store GetStore(long id);
        void DeleteStore(long id);
        void UpdateStore(Store store);
    }
}
