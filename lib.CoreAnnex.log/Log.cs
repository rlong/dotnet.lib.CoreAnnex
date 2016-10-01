// Copyright (c) 2013 Richard Long & HexBeerium
//
// Released under the MIT license ( http://opensource.org/licenses/MIT )
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using dotnet.lib.CoreAnnex.auxiliary;
using dotnet.lib.CoreAnnex.exception;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace lib.CoreAnnex.log
{
    public class Log 
    {


		private Logger _nLog;


		////////////////////////////////////////////////////////////////////////////
		//
		private static bool _isDebugEnabled = true;

		private static LoggingConfiguration _LoggingConfiguration;
		private static void SetupLoggingConfiguration()
		{
			if (null != _LoggingConfiguration)
			{
				return;
			}
			// vvv https://github.com/nlog/NLog/wiki/Configuration-API

			// Step 1. Create configuration object
			_LoggingConfiguration = new LoggingConfiguration();

			// Step 2. Create targets and add them to the configuration

			//var consoleTarget = new ColoredConsoleTarget();
			//var consoleTarget = new NLog.Targets.DebugTarget();
			var consoleTarget = new NLog.Targets.DebuggerTarget();
			_LoggingConfiguration.AddTarget("console", consoleTarget);

			// Step 3. Set target properties 
			consoleTarget.Layout = @"${logger} ${message}";

			// Step 4. Define rules
			var rule1 = new LoggingRule("*", LogLevel.Debug, consoleTarget);
			_LoggingConfiguration.LoggingRules.Add(rule1);

			// Step 5. Activate the configuration
			LogManager.Configuration = _LoggingConfiguration;

			// ^^^ https://github.com/nlog/NLog/wiki/Configuration-API
		}

        ////////////////////////////////////////////////////////////////////////////
        //
        private Type _targetType;

        public Type TargetType()
        {
            return _targetType;
        }

        ////////////////////////////////////////////////////////////////////////////
        //
        String _callerClassName;

        public String CallerClassName()
        {
            return _callerClassName;
        }

        ////////////////////////////////////////////////////////////////////////////
        //
        private Log(Type type) {

			SetupLoggingConfiguration();
            this._targetType = type;
            this._callerClassName = type.Name;
			_nLog = LogManager.GetLogger(this._callerClassName);

        }

        public static Log getLog(Type type) {
            return new Log( type );
        }


        private static String[] ToLogMessages(Exception e)
        {
            List<String> list = new List<String>();

            list.Add("message = " + e.Message);
            list.Add("className = " + e.GetType().Name);


            list.Add("stack = {");

            String[] stackTrace = ExceptionHelper.getStackTrace(e,true);
            foreach (String strackFrame in stackTrace)
            {
                list.Add("    " + strackFrame);
            }

            list.Add("}");
            return list.ToArray();
        }

        public static bool isDebugEnabled()
        {
            return _isDebugEnabled;
        }

		private void nLog(LogLevel logLevel, String message)
		{
			_nLog.Log(logLevel, message);
		}

		public void nLog(LogLevel logLevel,bool value, String name)
		{
			_nLog.Log( logLevel, "{0} = {1}", name, value);
		}

		public void nLog(LogLevel logLevel, int value, String name)
		{
			_nLog.Log(logLevel, "{0} = {1}", name, value);
		}


		public void nLog(LogLevel logLevel, Loggable value, String name)
		{

			if (null == value)
			{
				_nLog.Log(logLevel, "{0} = NULL", name);
				return;
			}

			String[] messages = value.getLogMessages();
			if (0 == messages.Length)
			{
				_nLog.Log(logLevel, "{0} = {}", name);
			}


			if (1 == messages.Length)
			{
				_nLog.Log(logLevel, "{0} = {1}", name, messages[0]);
			}

			StringBuilder lines = new StringBuilder(name);
			lines.Append(" = {");

			foreach (String message in messages)
			{
				lines.AppendFormat("    {0}\n", message);
			}

			lines.Append("}");

			_nLog.Log(logLevel, "{0} = {1}", name, lines.ToString());
		}

		public void nLog(LogLevel logLevel, long value, String name)
		{
			_nLog.Log(logLevel, "{0} = {1}", name, value);
		}


		public void nLog(LogLevel logLevel, Object value, String name)
		{
			if (null == value)
			{
				_nLog.Log(logLevel, "{0} = NULL", name);
				return;
			}

			_nLog.Log(logLevel, "{0} = {1}", name, value.ToString());

		}

		public void nLog( LogLevel logLevel, String value, String name)
		{
			if (null == value)
			{
				_nLog.Log(logLevel, "{0} = NULL", name);
				return;
			}
			_nLog.Log(logLevel, "{0} = '{1}'", name, value);
		}


		public void nLogFormat( LogLevel logLevel, String format, params Object[] values)
		{
			_nLog.Log(logLevel, String.Format(format, values));
		}


		public void nLog( LogLevel logLevel, Exception e)
		{
			String[] messages = null;
			if (e is Loggable)
			{
				Loggable loggable = (Loggable)e;
				messages = loggable.getLogMessages();
			}
			else
			{
				messages = ToLogMessages(e);
			}

			foreach (String message in messages)
			{
				_nLog.Log(logLevel, message);
			}
		}

		/////////////////////////////////////////////////////////////////////////


		public void debug(String message)
        {
			if (!_isDebugEnabled)
			{
				return;
			}
			nLog(LogLevel.Debug, message);
        }


        public void debug(bool value, String name)
        {
			if (!_isDebugEnabled)
			{
				return;
			}
			nLog(LogLevel.Debug, value, name );
		}

        public void debug(int value, String name)
        {
			if (!_isDebugEnabled)
			{
				return;
			}
			nLog(LogLevel.Debug, value, name);
		}


        public void debug( Loggable value, String name )
        {
			if (!_isDebugEnabled)
			{
				return;
			}
			nLog(LogLevel.Debug, value, name);
        }

        public void debug(long value, String name)
        {
			if (!_isDebugEnabled)
			{
				return;
			}
			nLog(LogLevel.Debug, value, name);
        }

        public void debug(Object value, String name)
        {
			if (!_isDebugEnabled)
			{
				return;
			}
			nLog(LogLevel.Debug, value, name);

        }


        public void debug(String value, String name)
        {
			if (!_isDebugEnabled)
			{
				return;
			}
			nLog(LogLevel.Debug, value, name);
        }

        public void debugFormat(String format, params Object[] values)
        {
			if (!_isDebugEnabled)
			{
				return;
			}
			nLogFormat( LogLevel.Debug, format, values);
        }


        public void enteredMethod()
        {
			if (!_isDebugEnabled)
			{
				return;
			}
			nLog(LogLevel.Debug, "entered");
        }

        /////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////

        public void info(String message)
        {
			nLog(LogLevel.Info, message);
        }


        public void info(Loggable value, String name)
        {

			nLog(LogLevel.Info, value, name);
        }

        public void info(long value, String name)
        {
			nLog(LogLevel.Info, value, name);
        }


        public void info(String value, String name)
        {
			nLog(LogLevel.Info, value, name);
        }

        public void infoFormat(String format, params Object[] values)
        {
			nLogFormat(LogLevel.Info, format, values);
        }


		/////////////////////////////////////////////////////////////////////////
		/////////////////////////////////////////////////////////////////////////


		public void warn(String message)
        {
			nLog(LogLevel.Warn, message);
        }




        public void warn(Exception e)
        {
			nLog(LogLevel.Warn, e);
        }

        public void warn(bool value, String name)
        {
			nLog(LogLevel.Warn, value, name);
        }

        public void warn(int value, String name)
        {
			nLog(LogLevel.Warn, value, name);
        }


        public void warn(Loggable value, String name)
        {
			nLog(LogLevel.Warn, value, name);
        }


        public void warn(String value, String name)
        {
  			nLog(LogLevel.Warn, value, name);
 
		}

        public void warn(ulong value, String name)
        {
			nLog(LogLevel.Warn, value, name);
        }

        public void warnFormat(String format, params Object[] values)
        {
			nLogFormat(LogLevel.Warn, format, values);
        }

		/////////////////////////////////////////////////////////////////////////
		/////////////////////////////////////////////////////////////////////////

		public void error(String message)
        {
			nLog(LogLevel.Error, message);
        }

        public void error(Exception e)
        {
			nLog(LogLevel.Error, e);
        }


        public void error(int value, String name)
        {
			nLog(LogLevel.Error, value, name);
        }

        public void error(Loggable value, String name)
        {
			nLog(LogLevel.Error, value, name);
        }


        public void error(String value, String name)
        {
			nLog(LogLevel.Error, value, name);
        }


        public void errorFormat(String format, params Object[] values)
		{
			nLogFormat(LogLevel.Error, format, values);
        }

    }
}
