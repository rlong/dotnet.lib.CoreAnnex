// Copyright (c) 2013 Richard Long & HexBeerium
//
// Released under the MIT license ( http://opensource.org/licenses/MIT )
//

using System;
using System.Collections.Generic;
using System.Text;
using dotnet.lib.CoreAnnex.auxiliary;
using dotnet.lib.CoreAnnex.json.input;
using System.IO;
using dotnet.lib.CoreAnnex.json.output;

namespace dotnet.lib.CoreAnnex.json
{
    public class JsonObjectHelper
    {


        public static JsonObject FromString(String jsonString)
        {

            byte[] rawData = StringHelper.ToUtfBytes(jsonString);
            Data data = new Data(rawData);
            JsonInput input = new JsonDataInput(data);

            JsonBuilder builder = new JsonBuilder();
            JsonReader.read(input, builder);
            
            JsonObject answer = builder.getObjectDocument();

            return answer;

        }

        public static byte[] ToBytes(JsonObject jsonObject)
        {
            MemoryStream memoryStream = new MemoryStream();
            write(jsonObject, memoryStream);
            return memoryStream.ToArray();
        }


        public static void write(JsonObject jsonObject, Stream destination)
        {
            JsonStreamOutput jsonStreamOutput = new JsonStreamOutput(destination);
            JsonWriter writer = new JsonWriter(jsonStreamOutput);
            JsonWalker.walk(jsonObject, writer);
            jsonStreamOutput.Flush();
        }
    }
}
