﻿// Copyright (c) 2013 Richard Long & HexBeerium
//
// Released under the MIT license ( http://opensource.org/licenses/MIT )
//

using System;
using System.Collections.Generic;
using System.Text;
using dotnet.lib.CoreAnnex.exception;

namespace dotnet.lib.CoreAnnex.json
{
    public class JsonArray
    {

        List<Object> _values;

        public JsonArray()
        {
            _values = new List<Object>();
        }

        public JsonArray(int capacity)
        {
            _values = new List<Object>(capacity);
        }

        public int GetInteger(int index)
        {
            Object blob = _values[index];


            if (null == blob)
            {
                String technicalError = String.Format("null == blob; index = {0}", index);
                throw new BaseException(this, technicalError);
            }


            if (!(blob is int))
            {
                String technicalError = String.Format("!(blob is int); index = {0}; blob.GetType().Name = {1}", index, blob.GetType().Name);

                throw new BaseException(this, technicalError );
                
            }

            return (int)blob;
        }


        public JsonArray GetJsonArray( int index ) 
        {
		
            Object blob = _values[index];


            if (null == blob)
            {
                return null;
            }
		
            if( !(blob is JsonArray) ) {


                String technicalError = String.Format("!(blob is JSONArray); index = {0}; blob.GetType().Name = {1}", index, blob.GetType().Name);

                throw new BaseException(this, technicalError);
		    }
		
		    return (JsonArray)blob;
		}



        public JsonObject GetJsonObject( int index ) 
        {
		
            Object blob = _values[index];

            if (null == blob)
            {
                return null;
            }
		
            if (!(blob is JsonObject)) 
            {

                String technicalError = String.Format("!(blob is JSONObject); index = {0}; blob.GetType().Name = {1}", index, blob.GetType().Name);
                throw new BaseException(this, technicalError);
		    }
		
		    return (JsonObject)blob;
		}

        public Object GetObject(int index)
        {
            Object blob = _values[index];

            if (null == blob)
            {
                String technicalError = String.Format("null == blob; index = {0}", index);
                throw new BaseException(this, technicalError);
            }


            return blob;
        }

        public Object GetObject(int index, Object defaultValue )
        {
            Object blob = _values[index];

            if (null == blob)
            {
                return defaultValue;
            }

            return blob;
        }


        public String GetString(int index)
        {
            Object blob = _values[index];

            if (null == blob)
            {
                return null;
            }

            if (!(blob is String))
            {

                String technicalError = String.Format("!(blob is String); index = {0}; blob.GetType().Name = {1}", index, blob.GetType().Name);
                throw new BaseException(this, technicalError);
            }

            return (String)blob;

        }

        public String GetString(int index, String defaultValue)
        {
            Object blob = _values[index];

            if (null == blob)
            {
                return defaultValue;
            }


            if (!(blob is String))
            {
                String technicalError = String.Format("!(blob is String); index = {0}; blob.GetType().Name = {1}", index, blob.GetType().Name);
                throw new BaseException(this, technicalError);
            }

            return (String)blob;


        }


        public void Add(Object obj)
        {
            _values.Add(obj);
        }

        public int Count()
        {
            return _values.Count;
        }

        public int Length()
        {
            return _values.Count;
        }


    }
}
