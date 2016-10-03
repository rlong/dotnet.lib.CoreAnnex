// Copyright (c) 2013 Richard Long & HexBeerium
//
// Released under the MIT license ( http://opensource.org/licenses/MIT )
//

using System;
using System.Collections.Generic;
using System.Text;
using dotnet.lib.CoreAnnex.exception;

namespace dotnet.lib.CoreAnnex.auxiliary
{
    public class NumericUtilities
    {


		public static int ParseInteger(String integerValue)
		{
			try
			{
				return Int32.Parse(integerValue);
			}
			catch (Exception e)
			{

				String technicalError = String.Format("failed to parse '{0}' as an integer", integerValue);

				throw new BaseException(e, typeof(NumericUtilities), technicalError);
			}
		}

		[Obsolete("deprecated, use `ParseInteger` instead.")]
		public static int parseInteger(String integerValue)
        {
			return ParseInteger(integerValue);
        }


		public static long ParseLong(String longValue)
		{
			try
			{
				return Int64.Parse(longValue);
			}
			catch (Exception e)
			{
				String technicalError = String.Format("failed to parse '{0}' as an long", longValue);
				throw new BaseException(e, typeof(NumericUtilities), technicalError);
			}
		}

		[Obsolete("deprecated, use `ParseLong` instead.")]
		public static long parseLong(String longValue)
        {
			return ParseLong(longValue);
        }

        public static float parseFloat(String floatValue)
        {
            try
            {
                return float.Parse(floatValue);
            }
            catch (Exception e)
            {
                String technicalError = String.Format("failed to parse '{0}' as a float", floatValue);

                throw new BaseException(e, typeof(NumericUtilities), technicalError);
            }

        }

    }
}
