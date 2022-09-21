using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;    // SqlException
using System.Data.Entity.Core;  // UpdateException

//using System.Reflection; // MethodBase.

namespace Resign_Procedure.CYPCC_Tools.Debug
{
    public class ExceptionHandler
    {
        public static string Get_Exception_Message(Exception ex)
        {
            var excption_type = ex.InnerException.GetType();
            if (excption_type == typeof(UpdateException))
            {
                UpdateException update_ex = (UpdateException)ex.InnerException;

                if (update_ex.InnerException.GetType() == typeof(SqlException))
                {
                    SqlException sql_error = (SqlException)update_ex.InnerException;
                    return "sql inner:" + sql_error.Message + ", hresult:" + string.Format("{0:x}", sql_error.HResult);
                }
            }

            return ex.Message;
        }
    }
}