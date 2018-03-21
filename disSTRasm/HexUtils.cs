using System;
using System.Collections.Generic;
using System.Text;

namespace disSTRasm
{
    public static class HexUtils
    {
        //private const string C_msNYBL_HexFormatArg      = "X1";
        //private const string C_msBYTE_HexFormatArg      = "X2";
        //private const string C_msWORD_HexFormatArg      = "X4";
        //private const string C_msDWORD_HexFormatArg     = "X8";
        //private const string C_msQWORD_HexFormatArg     = "X16";

        //public sealed class HexFormat
        //{
        //    private const string NYBLE   = C_msNYBL_HexFormatArg;
        //    private const string BYTE    = C_msBYTE_HexFormatArg;
        //    private const string WORD    = C_msWORD_HexFormatArg;
        //    private const string DWORD   = C_msDWORD_HexFormatArg;
        //    private const string QWORD   = C_msQWORD_HexFormatArg;

        //    private static readonly Lazy<HexFormat> lazy =
        //        new Lazy<HexFormat>(() => new HexFormat());

        //    public static HexFormat Instance {  get { return lazy.Value;  } }

        //    private HexFormat() { }

        //    public static class _SIZE_STRING
        //    {
        //        private static string m_sNYBLE     = HexFormat.NYBLE;
        //        private static string m_sBYTE      = HexFormat.BYTE;
        //        private static string m_sWORD      = HexFormat.WORD;
        //        private static string m_sDWORD     = HexFormat.DWORD;
        //        private static string m_sQWORD     = HexFormat.QWORD;
                
        //        public static string NYBLE { get { return m_sNYBLE; } }
        //        public static string BYTE  { get { return m_sBYTE; } }
        //        public static string WORD  { get { return m_sWORD; } }
        //        public static string DWORD { get { return m_sDWORD; } }
        //        public static string QWORD { get { return m_sQWORD; } }

        //        private static readonly Lazy<_SIZE_STRING> lazy =
        //            new Lazy<_SIZE_STRING>(() => new _SIZE_STRING());

        //        public static _SIZE_STRING Instance { get { return lazy.Value; } }

        //        private _SIZE_STRING() { }
        //    }
        //}

        //private static string msDefaultHexFormatArg     = HexFormat.SIZE_STRING.NYBLE;
        //private static string msCurrentHexFormatArg     = msDefaultHexFormatArg;

        //public static bool SetCurrentHexFormatArg(HexFormat formatArg)
        //{
        //    return true;
        //}

        //public static string GetStringWithPrefix(string sString, string sPrefix)
        //{
        //    return sPrefix + sString;
        //}

        //public static string GetHexFormattedString(string sString)
        //{
        //    return GetStringWithPrefix(sString, Register.msDefaultHexPrefix);
        //}

        //public static string GetHexAsString(int iHexValue)
        //{
        //    return iHexValue.ToString(Register.msHexToStringParseArg);
        //}

        //public static string GetHexAsString(int iHexValue, string sPrefix)
        //{
        //    return GetStringWithPrefix(sPrefix, iHexValue.ToString(Register.msHexToStringParseArg));
        //}

        //public static string GetHexAsString(int iHexValue, bool bShouldPrefix)
        //{
        //    string sPrefix = string.Empty;
        //    if (bShouldPrefix)
        //    {
        //        sPrefix = Register.msDefaultHexPrefix;
        //    }

        //    return GetHexAsString(iHexValue, sPrefix);
        //}

        //public static int GetStringAsHex(string sHexString)
        //{
        //    return Convert.ToInt32(sHexString);
        //}
    }
}
