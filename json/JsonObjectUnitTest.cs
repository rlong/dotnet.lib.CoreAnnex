// Copyright (c) 2013 Richard Long & HexBeerium
//
// Released under the MIT license ( http://opensource.org/licenses/MIT )
//

using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using dotnet.lib.CoreAnnex.log;


namespace dotnet.lib.CoreAnnex.json
{
    [TestFixture]
    //[Category("current")]
    class JsonObjectUnitTest
    {

        private static Log log = Log.getLog(typeof(JsonObjectUnitTest));

        [Test]
        public void test1()
        {
            log.enteredMethod();
        }


        [Test]
        public void testPutNull()
        {
            JsonObject jo = new JsonObject();
            jo.put("key", null);
        }


    }
}
