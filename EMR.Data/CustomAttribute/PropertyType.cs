using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMR.Data.CustomAttribute
{
    public class FieldTypeAttribute : Attribute
    {
        public FieldTypeAttribute(FieldTypeEnum _propertyType)
        {
            fieldType = _propertyType;
        }

        public FieldTypeEnum fieldType { get; set; }
    }

    public enum FieldTypeEnum
    {
        integer = 0,
        cstring = 1,
        money = 2,
        datetime = 3,
        File = 4,
        DoNotUseSqlParameter = 5,
        Ignore = 6,
    }
}