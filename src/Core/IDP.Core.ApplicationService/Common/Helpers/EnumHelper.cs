using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDP.Core.ApplicationService.Common.Helpers
{
    public class EnumHelper
    {
        public static string GetEnumDescription<TEnum>(TEnum value)
        {
            try
            {
                var field = value.GetType().GetField(value.ToString());
                if (field != null)
                {
                    var attributes = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);
                    return attributes.Length > 0 ? attributes[0].Description : value.ToString();
                }
                else
                    return string.Empty;
            }
            catch (Exception)
            {
                return value.ToString();
            }
        }
    }
}
