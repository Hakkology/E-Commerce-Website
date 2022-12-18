using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyFS.Core.Constant
{
    //Error messages for queries
    public class EntityResult
    {
        public object Message { get; }
        public EntityResultType ResultType { get;}
        public EntityResult(object _Message, EntityResultType _ResultType = EntityResultType.Success)
        {
            this.Message = _Message;
            this.ResultType = _ResultType;
        }
    }

    //Error messages if a list is queried
    public class EntityResult<T>:EntityResult
    {
        public T Data { get; set; }
        public EntityResult(T _data, object _Message, EntityResultType _ResultType = EntityResultType.Success):base(_Message, _ResultType)
        {
            Data = _data;
        }
    }
}
