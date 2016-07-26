// Copyright (c) 2013 Richard Long & HexBeerium
//
// Released under the MIT license ( http://opensource.org/licenses/MIT )
//

using System;
using System.Collections.Generic;
using System.Text;
using dotnet.lib.CoreAnnex.auxiliary;

namespace dotnet.lib.CoreAnnex.json.input
{
    public interface JsonInput
    {

        bool hasNextByte();
        byte nextByte();
        byte currentByte();
        MutableDataPool GetMutableDataPool();


    }
}
