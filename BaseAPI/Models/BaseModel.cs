using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseAPI.Models
{
    public class BaseModel
    {
        #region Public Methods
        public string GetPrimaryKeyFieldName()
        {
            return "";
        }

        public string GetForeignKeyFieldName()
        {
            return "";
        }

        public string GetTableName()
        {
            // use GetType and ViewAttribute to return table name
            return "";
        }
        #endregion
    }
}
