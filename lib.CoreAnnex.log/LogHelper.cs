// Copyright (c) 2013 Richard Long & HexBeerium
//
// Released under the MIT license ( http://opensource.org/licenses/MIT )
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace lib.CoreAnnex.log
{
    public class LogHelper
    {

        private static String getCallerClassName(Object caller)
        {
            Type callerClass;

            if (caller is Type)
            {
                callerClass = (Type)caller;
            }
            else
            {
                callerClass = caller.GetType();
            }

            return callerClass.Name;
        }

    }
}
