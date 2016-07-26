﻿// Copyright (c) 2013 Richard Long & HexBeerium
//
// Released under the MIT license ( http://opensource.org/licenses/MIT )
//

using System;
using System.Collections.Generic;
using System.Text;
using dotnet.lib.CoreAnnex.exception;
using dotnet.lib.CoreAnnex.json.output;
using dotnet.lib.CoreAnnex.json.input;
using dotnet.lib.CoreAnnex.json;

namespace dotnet.lib.CoreAnnex.json.handlers
{
    public abstract class JsonHandler
    {

        public static JsonHandler getHandler(Object value)
        {
            if (null == value)
            {
                return JsonNullHandler.getInstance();
            }

            ////////////////////////////////////////////////////////////////////////

            if (value is bool)
            {
                return JsonBooleanHandler.getInstance();
            }

            if( value is JsonArray ) 
            {
                return JsonArrayHandler.getInstance();
            }

            if( value is int ) {
                return JsonNumberHandler.getInstance();
            }
            if (value is long)
            {
                return JsonNumberHandler.getInstance();
            }

            if (value is float)
            {
                return JsonNumberHandler.getInstance();
            }
            if (value is double)
            {
                return JsonNumberHandler.getInstance();
            }

            // other numberic types not currently supported 

            if (value is JsonObject)
            {
                return JsonObjectHandler.getInstance();
            }

            if (value is String)
            {
                return JsonStringHandler.INSTANCE;
            }

            Type type = value.GetType();
            String technicalError = String.Format( "unsupported type; type.Name = {0}", type.Name);
            throw new BaseException(typeof(JsonHandler), technicalError);
        }

        public static JsonHandler getHandler(byte tokenBeginning)
        {
            if ('"' == tokenBeginning)
            {
                return JsonStringHandler.INSTANCE;
            }

            if ('0' <= tokenBeginning && tokenBeginning <= '9')
            {
                return JsonNumberHandler.getInstance();
            }

            if ('[' == tokenBeginning)
            {
                return JsonArrayHandler.getInstance();
            }

            if ('{' == tokenBeginning)
            {
                return JsonObjectHandler.getInstance();
            }

            if ('+' == tokenBeginning)
            {
                return JsonNumberHandler.getInstance();
            }
            if ('-' == tokenBeginning)
            {
                return JsonNumberHandler.getInstance();
            }

            if ('t' == tokenBeginning || 'T' == tokenBeginning)
            {
                return JsonBooleanHandler.getInstance();
            }

            if ('f' == tokenBeginning || 'F' == tokenBeginning)
            {
                return JsonBooleanHandler.getInstance();
            }

            if ('n' == tokenBeginning || 'N' == tokenBeginning)
            {
                return JsonNullHandler.getInstance();
            }

            String technicalError = String.Format( "bad tokenBeginning; tokenBeginning = {0} ({1})", tokenBeginning, (char)tokenBeginning);

            throw new BaseException( typeof(JsonHandler), technicalError);
        }


        public abstract void WriteValue(Object value, JsonOutput writer);

        public abstract Object readValue(JsonInput reader);

    }
}
