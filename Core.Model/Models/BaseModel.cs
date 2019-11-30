using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Core.Model
{
    public class BaseModel
    {
        private int ModelState { get; set; }
        private int EditVersion { get; set; }

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
