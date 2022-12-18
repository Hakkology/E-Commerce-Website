using BuyFS.Core.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyFS.Core.BAL
{
    //Service functions interface, BAL represents Business Logic Layer
    public interface IGenericService<T>
    {
        EntityResult Add(T entity);
        EntityResult Update(T entity);
        EntityResult Delete(T entity);
        EntityResult <IEnumerable<T>> Get();
        EntityResult<T> Get(int id);
    }
}
