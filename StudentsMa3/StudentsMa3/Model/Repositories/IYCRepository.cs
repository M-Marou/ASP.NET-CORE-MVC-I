using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsMa3.Model.Repositories
{
    interface IYCRepository<TEntity>
    {
        TEntity Get(int id);
    }
}
