using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyFS.Core.Constant
{
    public static class ExceptiontoInner
    {
        //Inner exception, as definition for infinite loop execution, resulting in loss of control for the app
        public static Exception ToInner(this Exception ex)
        {
            if (ex.InnerException!=null)
            {
                return ex.InnerException.ToInner();
            }
            return ex;
        }
    }
}
