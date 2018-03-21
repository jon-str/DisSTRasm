using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace disSTRasm
{
    public class UNIT_TESTS_StringEnum
    {
        private bool bHasRun        = false;

        private static class Assert
        {
            public static bool AreEqual(bool bConditon)
            {
                if(bConditon != true)
                {
                    Debug.WriteLine( "AssertFailed" );
                    ConventionSupport.GetCurrentMethodName( );
                }

                return bConditon;
            }

            public static bool IsNull( bool bConditon )
            {
                if( ( ! (bConditon) != true ) )
                {
                    Debug.WriteLine( "AssertFailed" );
                    ConventionSupport.GetCurrentMethodName( );
                }
                return bConditon;
            }

            public static bool IsFalse( bool bConditon )
            {
                if ( ( ! ( bConditon != false ) ) )
                {
                    Debug.WriteLine( "AssertFailed" );
                    ConventionSupport.GetCurrentMethodName( );
                }
                return bConditon;
            }

            public static bool IsTrue( bool bConditon )
            {
                if ( bConditon != true )
                {
                    Debug.WriteLine( "AssertFailed" );
                    ConventionSupport.GetCurrentMethodName( );
                }

                return bConditon;
            }

            private static void ErrorDump()
            {
                ConventionSupport.GetCurrentMethodName( );
            }
        }

        enum REGISTERS_WithStrings
        {
            [StringValue( "AX" )]
            AX       = 0xF0,
            [StringValue( "BX" )]
            BX       = 0xE0,
            [StringValue( "CX" )]
            CX         = 0x0D,
            [StringValue( "DX" )]
            DX        = 0xAA,
        }

        enum REGISTERS_WithDifferentStrings
        {
            [StringValue( "Ax" )]
            AX = 0xF0,
            [StringValue( "Bx" )]
            BX = 0xE0,
            [StringValue( "Cx" )]
            CX = 0x0D,
            [StringValue( "Dx" )]
            DX = 0xAA,
        }

        enum REGISTERS_WithNoStrings
        {
            AX = 0xA0,
            BX = 0xB0,
            CX = 0xC0,
            DX = 0xD0
        }

        enum REGISTERS_WithPartialStrings
        {
            BP,
            [StringValue( "RND STR" )]
            SP,
            DI
        }

        public void RunTests()
        {
            TestStaticGetStringValue( );
            TestStaticGetStringValueCaching( );
            TestStaticParse( );
            TestStaticIsStringDefined( );
        }

        public void TestStaticGetStringValue( )
        {
            //Expect to retrieve a string value
            Assert.AreEqual( ("CX" == StringEnum.GetStringValue( REGISTERS_WithStrings.CX ) ) );
            //No string value to retrieve
            Assert.IsNull( StringEnum.GetStringValue( REGISTERS_WithNoStrings.DX ) == null );
            //String values exist but not for this enum value
            Assert.IsNull( StringEnum.GetStringValue( REGISTERS_WithPartialStrings.DI ) == null );

        }

        /// <summary>
        /// Tests GetStringValue caching (Static implementation)
        /// </summary>
        public void TestStaticGetStringValueCaching( )
        {
            //Expect to retrieve a string value (and cache this value)
            Assert.AreEqual( ( "CX" == StringEnum.GetStringValue( REGISTERS_WithStrings.CX ) ) );

            //Expect to retrieve a different value (as this is from a different enum)
            Assert.AreEqual( ( "Cx" == StringEnum.GetStringValue( REGISTERS_WithDifferentStrings.CX ) ) );

            //Expect to retrieve both values again (cached)
            Assert.AreEqual( ( "CX" == StringEnum.GetStringValue( REGISTERS_WithStrings.CX ) ) );
            Assert.AreEqual( ( "Cx" == StringEnum.GetStringValue( REGISTERS_WithDifferentStrings.CX ) ) );

        }

        /// <summary>
        /// Parse a string value to retrieve an enum value
        /// </summary>
        public void TestStaticParse( )
        {
            //Case Sensitive (not found)
            Assert.IsNull( StringEnum.Parse( typeof( REGISTERS_WithPartialStrings ), "RnD sTr" ) == null );
            //Case Sensitive (found)
            Assert.AreEqual( REGISTERS_WithPartialStrings.SP ==  ( REGISTERS_WithPartialStrings) StringEnum.Parse( typeof( REGISTERS_WithPartialStrings ), "RND STR" ) );
            //Case insensitive (found)
            Assert.AreEqual( REGISTERS_WithPartialStrings.SP == (REGISTERS_WithPartialStrings)StringEnum.Parse( typeof( REGISTERS_WithPartialStrings ), "RnD sTr", true ) );

        }

        /// <summary>
        /// Test whether a given string is defined within the given enum
        /// </summary>
        public void TestStaticIsStringDefined( )
        {
            Assert.IsFalse( StringEnum.IsStringDefined( typeof( REGISTERS_WithStrings ), "DI" ) == false );
            Assert.IsTrue( StringEnum.IsStringDefined( typeof( REGISTERS_WithPartialStrings ), "RnD sTr", true ) == true );
        }


        #region Instance Tests

        /// <summary>
        /// Create new instance from non enum type - expect argument exception
        /// </summary>

        //public void TestInstanceConstructorExpectArgumentException( )
        //{
        //    new StringEnum( typeof( string ) );
        //}

        ///// <summary>
        ///// Create new instance and return enum value from the given string value
        ///// </summary>
        //public void TestInstanceGetStringValue( )
        //{
        //    StringEnum stringEnum = new StringEnum(typeof(EnumWithStrings));
        //    Assert.AreEqual( "Fourth Value", stringEnum.GetStringValue( "Lazy" ) );
        //    //Expect null as this value doesn't exist
        //    Assert.IsNull( stringEnum.GetStringValue( "clearly not there" ) );
        //}

        ///// <summary>
        ///// Test retrieving an array of string values from a supplied enum
        ///// </summary>
        //public void TestInstanceGetStringValues( )
        //{
        //    StringEnum stringEnum = new StringEnum(typeof(EnumWithoutStrings));
        //    Assert.AreEqual( 0, stringEnum.GetStringValues( ).Length );

        //    stringEnum = new StringEnum( typeof( EnumPartialStrings ) );
        //    Assert.AreEqual( 1, stringEnum.GetStringValues( ).Length );
        //    Assert.AreEqual( "Jack be nimble", stringEnum.GetStringValues( ).GetValue( 0 ).ToString( ) );

        //}

        ///// <summary>
        ///// Test whether the given string is defined using instance methods
        ///// </summary>
        //[Test]
        //public void TestInstanceIsStringDefined( )
        //{
        //    StringEnum stringEnum = new StringEnum(typeof(EnumWithStrings));
        //    Assert.IsFalse( stringEnum.IsStringDefined( "Something that's not there" ) );
        //    Assert.IsFalse( stringEnum.IsStringDefined( "first value" ) );
        //    Assert.IsTrue( stringEnum.IsStringDefined( "First Value" ) );
        //}

        ///// <summary>
        ///// Test basic property get access
        ///// </summary>
        //public void TestInstancePropertyEnum( )
        //{
        //    StringEnum stringEnum = new StringEnum(typeof(EnumWithoutStrings));
        //    Assert.IsTrue( stringEnum.EnumType.IsEnum );

        //}

        //public void TestStructImplementation( )
        //{
        //    string myString = "My Value 1";
        //    switch ( myString )
        //    {
        //        case MyStringEnum.MyValue1:
        //            break;
        //        case MyStringEnum.MyValue2:
        //            Assert.Fail( );
        //            break;
        //    }
        //}

        #endregion

    }


    #region Struct Implementation

    /// <summary>
    /// Struct implementation of String Enum
    /// </summary>
    public struct MyStringEnum
    {
        public const string MyValue1 = "My Value 1";
        public const string MyValue2 = "My Value 2";

    }
}
#endregion