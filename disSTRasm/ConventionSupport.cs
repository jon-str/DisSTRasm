using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace disSTRasm
{
    public static class ConventionSupport
    {
        public const string ErrorMsgPrefix  = "[ERR]" + ConventionSupport.Space + ":";

        public const string Space           = " ";

        public const string NewLine         = "\n";

        public static bool IsTypeEnum(Type t_Type)
        {
            if( t_Type.IsEnum )
            {
                return true;
            }
            return false;
        }

        public static string GetCurrentMethodName()
        {
            return GetCurrentMethodName(new StackTrace());
        }

        public static string ProduceErrorMsg(string sMsg)
        {
            return ConventionSupport.ErrorMsgPrefix +
                   ConventionSupport.GetCurrentMethodName( ) +
                   sMsg +
                   ConventionSupport.NewLine;
        }

        private static string GetCurrentMethodName(StackTrace oStackTrace)
        {
            if(oStackTrace == null)
            {
                return string.Empty;
            }

            StackFrame oStackFrame = oStackTrace.GetFrame( 1 );

            return oStackFrame.GetMethod( ).Name;
        }

        public class CON_SUPP_StringEnum : StringEnum
        {
        #region Implementation


            #region Constructor
            public CON_SUPP_StringEnum( Type tEnumType ) : base(tEnumType, true)
            {
               
            }
            #endregion


            #region Public Methods

            public string HEX_GetStringValue( string sValue )
            {
                return base.GetStringValue( sValue ); //add hex wrapper
            }


            #endregion

        #endregion


            #region Private Methods
            #endregion


        #region Static

            //public string HEX_GetStringValue( Enum eValue )
            //{
            //    return StringEnum.GetStringValue(eValue);
            //}

        #endregion
        }
    }
}

