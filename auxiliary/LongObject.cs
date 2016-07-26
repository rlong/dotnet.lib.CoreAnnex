// Copyright (c) 2013 Richard Long & HexBeerium
//
// Released under the MIT license ( http://opensource.org/licenses/MIT )
//

using System;
using System.Collections.Generic;
using System.Text;

namespace dotnet.lib.CoreAnnex.auxiliary
{

    public class LongObject
    {

        long _value;

        public LongObject(long value)
        {
            _value = value;
        }

        public long longValue()
        {
            return _value;
        }

    }

}
