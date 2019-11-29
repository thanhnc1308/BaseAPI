using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BaseAPI.Models
{
    public class BaseModel
    {
        #region Public Methods
        public string GetPrimaryKeyFieldName()
        {
            // use attribute [Key] to get
            return "";
        }

        public object GetPrimaryKeyFieldValue()
        {
            return null;
        }

        public string GetForeignKeyFieldName()
        {
            return "";
        }

        public object GetForeignKeyFieldValue()
        {
            return null;
        }

        public string GetTableName()
        {
            // use GetType and ViewAttribute to return table name
            return "";
        }

        public bool ContainsProperty(string property)
        {
            PropertyInfo propertyInfo = this.GetType().GetProperty(property);
            if (propertyInfo == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion
    }
}
