using System;
using System.Collections.Generic;
using System.Linq;

namespace ObjectHelpers
{
    public class ObjectHelper
    {
        public static void CopyProperties(object source, object target, List<string> exclude = null)
        {
            Type type = source.GetType();
            var propList = type.GetProperties();
            var propListTarget = target.GetType().GetProperties();

            for (int i = 0; i < propList.Count(); i++)
            {
                var prop = propList[i];
                if (exclude != null && exclude.Contains(prop.Name))
                {
                    continue;
                }
                var sourcePropValue = prop.GetValue(source);
                var targetProp = propListTarget.First(p => p.Name == prop.Name);
                targetProp.SetValue(target, sourcePropValue);
            }

        }
    }
}
