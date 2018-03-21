using System;
using System.Collections.Generic;
using System.Text;

namespace disSTRasm
{
    class Register
    {
        //private string msMnuemonic;
        //private int miMnuemonicHexCode;
        //private string miMnuemonicHexCodeAsString;
        //private string msValueAsString;
        //private int miValueAsNumber;
        //private int miEvalState;

        //private static string msDefaultHexPrefix    = "0x";
        //private static string msOverrideHexPrefix = string.Empty;

        //private static string msHexToStringParseArg = "X4";

        //enum EVAL_STATE : int
        //{
        //    BAD = 0,            // 0 = Bad, 
        //    SG_IB = 1,          // 1 = sValueAsString is good, iValueAsNumber is not, 
        //    IG_SB = 2,          // 2 = iValueAsNumber is good sValueAsString is not
        //    NEW = 3,            // 3 = new, set both to 0
        //}

        //public Register(string sMnuemonic, int iHexValueOfMnuemonic)
        //{
        //    this.miEvalState = (int)EVAL_STATE.NEW;

        //    this.msMnuemonic = sMnuemonic;
        //    this.miMnuemonicHexCode = iHexValueOfMnuemonic;
        //    this.miMnuemonicHexCodeAsString = GetHexAsString(this.miMnuemonicHexCode);

        //    this.miValueAsNumber = (int)0x0000;
        //    this.msValueAsString = this.GetHexAsString(this.miValueAsNumber);

        //    this.miValueAsNumber = this.GetStringAsHex(this.msValueAsString);

        //    if (miValueAsNumber != 0)
        //    {
        //        Console.WriteLine("FAIL");
        //    }
        //}


        //public void Dump()
        //{
        //    Console.WriteLine(msMnuemonic + " : " + GetHexFormattedString(miMnuemonicHexCodeAsString) + " | " + miMnuemonicHexCode);
        //    Console.WriteLine("VALUE : " + miValueAsNumber + " | " + GetHexFormattedString(msValueAsString));
        //    Console.WriteLine(miEvalState);
        //}
    }
}
