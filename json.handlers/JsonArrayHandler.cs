﻿// Copyright (c) 2013 Richard Long & HexBeerium
//
// Released under the MIT license ( http://opensource.org/licenses/MIT )
//

using System;
using System.Collections.Generic;
using System.Text;
using dotnet.lib.CoreAnnex.json.output;
using dotnet.lib.CoreAnnex.json.input;
using dotnet.lib.CoreAnnex.json;

namespace dotnet.lib.CoreAnnex.json.handlers
{
    public class JsonArrayHandler : JsonHandler
    {
        private static readonly JsonArrayHandler _instance = new JsonArrayHandler();
	
        public static JsonArrayHandler getInstance() 
        {
		    return _instance;
        }


	    ////////////////////////////////////////////////////////////////////////////

        private JsonArrayHandler() 
        {
	    }


        public static JsonArray readJsonArray(JsonInput input)
        {
            JsonArray answer = new JsonArray();

            input.nextByte(); // move past the '['

            byte b = JsonInputHelper.scanToNextToken( input );

            while (']' != b)
            {

                JsonHandler valueHandler = JsonHandler.getHandler(b);

                Object obj = valueHandler.readValue(input);

                answer.Add(obj);

                b = JsonInputHelper.scanToNextToken( input );
            }

            // move past the ']' if we can
            if (input.hasNextByte())
            {
                input.nextByte();
            }

            return answer;

        }

        public JsonArray readJSONArray(JsonInput reader)
        {
            return JsonArrayHandler.readJsonArray(reader);
        }


        public override Object readValue(JsonInput reader)
        {
            return readJSONArray(reader);
        }

        ////////////////////////////////////////////////////////////////////////////

        public override void WriteValue(Object value, JsonOutput writer)
        {
            JsonArray array = (JsonArray)value;

            writer.append('[');


            int count = array.Count();
            if (count > 0)
            {
                Object obj = array.GetObject(0, null);
                JsonHandler valueHandler = JsonHandler.getHandler(obj);

                valueHandler.WriteValue(obj, writer);
            }

            for (int i = 1; i < count; i++)
            {
                writer.append(',');

                Object obj = array.GetObject(i, null);
                JsonHandler valueHandler = JsonHandler.getHandler(obj);

                valueHandler.WriteValue(obj, writer);

            }

            writer.append(']');

        }


    }
}
