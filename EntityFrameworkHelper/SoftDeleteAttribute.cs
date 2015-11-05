using System;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;

namespace EntityFrameworkHelper
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class SoftDeleteAttribute : Attribute
    {
        public SoftDeleteAttribute(string columnName)
        {
            ColumnName = columnName;
        }

        public string ColumnName { get; private set; }

        public static string GetSoftDeleteColumnName(EdmType type)
        {
            // TODO Find the soft delete annotation and get the property name
            //      Name of annotation will be something like: 
            //      http://schemas.microsoft.com/ado/2013/11/edm/customannotation:SoftDeleteColumnName

            MetadataProperty annotation = type.MetadataProperties
                .Where(p => p.Name.EndsWith("customannotation:SoftDeleteColumnName"))
                .SingleOrDefault();

            return annotation == null ? null : (string)annotation.Value;
        }
    }
}
