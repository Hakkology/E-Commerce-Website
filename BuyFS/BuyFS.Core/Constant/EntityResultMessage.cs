using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyFS.Core.Constant
{
    public static class EntityResultMessage
    {
        //Error messages in constant file as strings
        public static string Add()
        {
            return "Successfully added.";
        }

        public static string Warning()
        {
            return "Unexpected Error occured.";
        }

        public static string Error(Exception ex)
        {
            return "Operation unsuccessful." + ex.ToInner().Message;
        }
    }
}
