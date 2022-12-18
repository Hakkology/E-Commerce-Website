using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyFS.Core.Entity
{
    public interface IBaseEntity
    {
        //roof interface for all base entity properties, which are both used by products and categories
    }
    public class BaseEntity: IBaseEntity
    {
        public BaseEntity()
        {
            //Determines the actual state of a product once its created with following parameters
            Active = true;
            Deleted = false;
            Created = DateTime.Now;
            Update = DateTime.Now;
        }
        public int Id { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        public DateTime Created { get; set; }
        public DateTime Update { get; set; }
    }
}
