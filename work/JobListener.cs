// Copyright (c) 2013 Richard Long & HexBeerium
//
// Released under the MIT license ( http://opensource.org/licenses/MIT )
//

using System;
using System.Collections.Generic;
using System.Text;
using dotnet.lib.CoreAnnex.exception;

namespace dotnet.lib.CoreAnnex.work
{
    public interface JobListener
    {
        void jobCompleted(Job job);
        void jobFailed(Job job, BaseException exception);
    }
}

