using finalPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace finalPro.Repositories
{
    public interface IRequest
    {
        List<Requist> getAll();
        //IQueryable<T> getAllFilter();
        Requist getByID(params object[] id);
        Requist Add(Requist R);
        bool Update(Requist R);
        bool Delete(Requist R);
    }
}
