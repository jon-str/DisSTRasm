using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace disSTRasm
{
    #region StringValueAttribute

    public class StringEnum
    {
        #region Instance

        #region Properties

        private static  Hashtable  mHT_stringValues             = new Hashtable();

        private         Type        mT_enumType;
        private         bool        mB_enableConventionSupport  = false;   
        
        #endregion


        #region Constructor

        public StringEnum( Type tEnumType )
        {
            if ( ! ConventionSupport.IsTypeEnum( tEnumType ) )
            {
                string sArgExceptionMsg = String.Format("Parameter 'Type' must be an Enum. 'Type' used : {0}", tEnumType.ToString());
                                        
                throw new ArgumentException( ConventionSupport.ProduceErrorMsg(sArgExceptionMsg ));
            }

            mT_enumType = tEnumType;
        }

        public StringEnum( Type tEnumType, bool bEnableConventionSupport)
        {
            mB_enableConventionSupport = bEnableConventionSupport;

            new StringEnum( tEnumType );
        }

        #endregion


        #region Other Types

        public Type EnumType { get { return mT_enumType; } }

        #endregion


        #region Public Methods

        public string GetStringValue( string sValue )
        {
            Enum    eType;
            string  sReturnValue  = string.Empty;

            try
            {
                eType           = (Enum)Enum.Parse( mT_enumType, sValue );
                sReturnValue    = GetStringValue( eType );
            }
            catch ( Exception ) { }

            return sReturnValue;
        }

        public Array GetStringValues()
        {
            ArrayList alValues = new ArrayList();

            foreach( FieldInfo fiInfo in mT_enumType.GetFields() )
            {
                StringValueAttribute[] svaAttribs = fiInfo.GetCustomAttributes(typeof (StringValueAttribute), false) as StringValueAttribute[];

                if( svaAttribs.Length > 0 )
                {
                    alValues.Add( svaAttribs [ 0 ].ValueOf );
                }
            }

            return alValues.ToArray( );
        }

        public IList GetListValues( )
        {
            Type        tUnderlyingType = Enum.GetUnderlyingType(mT_enumType);
            ArrayList   alValues        = new ArrayList();

            foreach ( FieldInfo fiInfo in mT_enumType.GetFields( ) )
            {
                StringValueAttribute[] svaAttribs = fiInfo.GetCustomAttributes(typeof (StringValueAttribute), false) as StringValueAttribute[];

                if(svaAttribs.Length > 0)
                {
                    alValues.Add( new DictionaryEntry( Convert.ChangeType( Enum.Parse( mT_enumType, fiInfo.Name ), tUnderlyingType ), svaAttribs [ 0 ].ValueOf ) );
                }
            }

            return alValues;
        }

        public bool IsStringDefined(string sValue)
        {
            return Parse( mT_enumType, sValue ) != null;
        }

        public bool IsStringDefined( string sValue, bool bIgnoreCase )
        {
            return Parse( mT_enumType, sValue, bIgnoreCase ) != null;
        }

        #endregion


        #region Private Methods
        #endregion


    #endregion


    #region Static

        public static string GetStringValue(Enum eValue)
        {
            string  sReturnValue    = string.Empty;
            Type    tType           = eValue.GetType();

            if(mHT_stringValues.ContainsKey(eValue))
            {
                sReturnValue = ( mHT_stringValues [ eValue ] as StringValueAttribute ).ValueOf;
            }
            else
            {
                FieldInfo               fInfo       = tType.GetField(eValue.ToString());
                StringValueAttribute[]  svaAttribs  = fInfo.GetCustomAttributes(typeof (StringValueAttribute), false) as StringValueAttribute[];

                if(svaAttribs.Length > 0)
                {
                    mHT_stringValues.Add( eValue, svaAttribs [ 0 ] );
                    sReturnValue = svaAttribs [ 0 ].ValueOf;
                }
            }

            return sReturnValue;
        }

        public static object Parse(Type tType, string sValue)
        {
            return Parse( tType, sValue, false );
        }

        public static object Parse(Type tType, string sValue, bool bIgnoreCase)
        {
            object oReturnObj       = null;
            string sEnumStringValue = string.Empty;

            if(! (ConventionSupport.IsTypeEnum(tType)))
            {
                string sArgExceptionMsg = String.Format("Parameter 'Type' must be an Enum. 'Type' used : {0}", tType.ToString());

                throw new ArgumentException( ConventionSupport.ProduceErrorMsg( sArgExceptionMsg ) );
            }

            foreach(FieldInfo fInfo in tType.GetFields())
            {
                StringValueAttribute[] svaAttribs = fInfo.GetCustomAttributes(typeof (StringValueAttribute), false) as StringValueAttribute[];

                if( svaAttribs.Length > 0 )
                {
                    sEnumStringValue = svaAttribs [ 0 ].ValueOf;
                }

                if(string.Compare(sEnumStringValue, sValue, bIgnoreCase ) == 0 )
                {
                    oReturnObj = Enum.Parse( tType, fInfo.Name );
                    break;
                }
            }

            return oReturnObj;
        }

        public static bool IsStringDefined(Type eType, string sValue)
        {
            return Parse( eType, sValue ) != null;
        }

        public static bool IsStringDefined( Type eType, string sValue, bool bIgnoreCase )
        {
            return Parse( eType, sValue, bIgnoreCase ) != null;
        }

        #endregion
    }

    #endregion

    #region StringValueAttribute
    class StringValueAttribute : Attribute
    {
        #region Properties

        public string ValueOf { get; protected set; }

        #endregion

        #region Constructor

        public StringValueAttribute( string sValue )
        {
            this.ValueOf = sValue;
        }
        #endregion

        #endregion
    }
}
