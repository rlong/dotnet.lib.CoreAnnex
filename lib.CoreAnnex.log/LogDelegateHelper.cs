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
    public class LogDelegateHelper
    {

        public static String getMethodName(Log origin)
        {
            StackTrace st = new StackTrace(2, true);
            for (int i = 0, count = st.FrameCount; i < count; i++)
            {
                StackFrame frame = st.GetFrame(i);
                Type frameType = frame.GetMethod().DeclaringType;
                if (origin.TargetType().IsAssignableFrom(frameType))
                {
                    return frame.GetMethod().Name;
                }
            }
            return "<undefined>";
        }

        public static String toIp4AddressString(int value, String name)
        {

            int ip1 = value & 0xFF;
            int ip2 = (value >> 8) & 0xFF;
            int ip3 = (value >> 16) & 0xFF;
            int ip4 = (value >> 24) & 0xFF;

            String answer = String.Format("{0} = {1}.{2}.{3}.{4}", name, ip1, ip2, ip3, ip4);
            return answer;
        }

        public static String FormatString(String format, params Object[] values)
        {
            return String.Format(format, values);
        }



    }
}
