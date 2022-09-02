using SCGPS.Domain.Enums;
using SCGPS.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCGPS.Domain
{
    public static class Extensions
    {
		public static string GetErrorDescription(this ErrorCodes code)
		{
			var fieldInfo = code.GetType().GetField(code.ToString());
			var descriptionAttributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

			return descriptionAttributes.Length > 0 ? descriptionAttributes[0].Description : code.ToString();
		}

		public static string GetErrorCode(this ErrorCodes code)
		{
			return $"{(int)code:D4}";
		}

		public static ScGpsException GetException(this Exception ex)
        {
            if (ex is null)
            {
                throw new ArgumentNullException(nameof(ex));
            }

			if(ex is ScGpsValidationException)
            {
				return new ScGpsException(ErrorCodes.ValidationError);
            }else if(ex is ScGpsException scGpsEx)
            {
				return scGpsEx;
            }
            else
            {
                return new ScGpsException(ErrorCodes.UncategorizedError);
            }
        }

        public static float GetMaxRating(this string rating)
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            var max = rating.Split('/');

            if(max == null)
            {
                throw new InvalidOperationException("Nem sikerült a stringet szétbontani");
            }

            return float.Parse(max[1]);
        }

        public static float GetCurrentRating(this string rating)
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            var current = rating.Split('/');

            if (current == null)
            {
                throw new InvalidOperationException("Nem sikerült a stringet szétbontani");
            }

            return float.Parse(current[0]);
        }
    }
}
