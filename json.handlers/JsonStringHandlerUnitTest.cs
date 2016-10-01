using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using lib.CoreAnnex.log;
using dotnet.lib.CoreAnnex.json.output;
using dotnet.lib.CoreAnnex.auxiliary;
using dotnet.lib.CoreAnnex.json.input;

namespace dotnet.lib.CoreAnnex.json.handlers
{

        
    [TestFixture]
    [Category("current")]
    public class JsonStringHandlerUnitTest
    {
        private static Log log = Log.getLog(typeof(JsonStringHandlerUnitTest));

        [Test]
        public void test1()
        {
            log.enteredMethod();
        }


        private String EncodeJsonStringValue(String input)
        {

            JsonStringOutput output = new JsonStringOutput();
            JsonStringHandler handler = JsonStringHandler.INSTANCE;

            handler.WriteValue(input, output);

            return output.ToString();

        }

        private String DecodeJsonStringValue(String input)
        {


            MutableData data = new MutableData();
            data.Append(StringHelper.ToUtfBytes(input));

            JsonDataInput jsonDataInput = new JsonDataInput(data);

            String answer = JsonStringHandler.readString(jsonDataInput);
            return answer;

        }


        [Test]
        public void testWriteABC()
        {

            String actual = EncodeJsonStringValue("ABC");
            Assert.AreEqual("\"ABC\"", actual);

        }

        [Test]
        public void testReadABC()
        {

            String actual = DecodeJsonStringValue("\"ABC\"");
            Assert.AreEqual("ABC", actual);
        }


        [Test]
        public void testReadWriteSlashes()
        {

            {
                String encodedValue = EncodeJsonStringValue("\\");
                Assert.AreEqual("\"\\\\\"", encodedValue);
                String decodedValue = DecodeJsonStringValue(encodedValue);
                Assert.AreEqual("\\", decodedValue);
            }

            {
                String encodedValue = EncodeJsonStringValue("/");
                Assert.AreEqual("\"\\/\"", encodedValue);
                String decodedValue = DecodeJsonStringValue(encodedValue);
                Assert.AreEqual("/", decodedValue);
            }


        }


    }
}
