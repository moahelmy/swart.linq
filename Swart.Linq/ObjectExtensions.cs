using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Swart.DomainDrivenDesign.Linq
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Get all properties that are objects of derived classes of the given type.
        /// </summary>
        /// <param name="obj">object</param>
        /// <param name="type">base type</param>
        /// <returns></returns>
        public static IEnumerable<PropertyInfo> GetAllPropertiesOfType(this object obj, Type type)
        {
            return obj.GetType().GetAllPropertiesOfType(type);
        }

        /// <summary>
        /// Get all properties that are objects of derived classes of the given type.
        /// </summary>
        /// <param name="type">type</param>
        /// <param name="testedType">tested type</param>
        /// <returns></returns>
        public static IEnumerable<PropertyInfo> GetAllPropertiesOfType(this Type type, Type testedType)
        {
            return type.GetProperties().Where(p => p.PropertyType.IsSubclassOf(testedType));
        }
    }
}
