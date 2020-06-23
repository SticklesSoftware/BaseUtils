//========================================================================================================================
// Component: BaseUtils - Common utility methods
// Copyright: Dale Medical Products
//
// ConversionTests.cs
//      This class contains unit tests for the conversions class
//========================================================================================================================
using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaseUtils;

namespace UnitTests
{
    [TestClass]
    public class ConversionTests
    {
        #region Database Value Conversions
        //================================================================================================================
        //================================================================================================================

        [TestMethod]
        public void Test_DBValueString()
        //================================================================================================================
        // Test the DBNull2String method using a string value
        //================================================================================================================
        {
            object dbValue = "This is a test.";
            string expectedValue = "This is a test.";
            string actualValue = Conversions.DBValue2String(dbValue);
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void Test_DBValueNumeric()
        //================================================================================================================
        // Test the DBNull2String method using a numeric value
        //================================================================================================================
        {
            object dbValue = 12345.678;
            string expectedValue = "12345.678";
            string actualValue = Conversions.DBValue2String(dbValue);
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void Test_DBValueNull()
        //================================================================================================================
        // Test the DBNull2String method using a null value
        //================================================================================================================
        {
            object dbValue = DBNull.Value;
            string expectedValue = "";
            string actualValue = Conversions.DBValue2String(dbValue);
            Assert.AreEqual(expectedValue, actualValue);
        }

        //================================================================================================================
        //================================================================================================================
        #endregion  // Database Value Conversions

        #region String Conversions
        //================================================================================================================
        //================================================================================================================

        [TestMethod]
        public void Test_ByteArray2String()
        //================================================================================================================
        // Test the ByteArray2String method
        //================================================================================================================
        {
            byte[] testValue = Encoding.ASCII.GetBytes("This is a test.");
            string expectedValue = "This is a test.";
            string actualValue = Conversions.ByteArray2String(testValue);
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void Test_String2Date()
        //================================================================================================================
        // Test the String2Date method
        //================================================================================================================
        {
            string testValue = "12/09/1962";
            DateTime expectedValue = new DateTime(1962, 12, 9);
            DateTime actualValue = Conversions.String2Date(testValue);
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void Test_String2Int()
        //================================================================================================================
        // Test the String2Int method
        //================================================================================================================
        {
            string testValue = "12345";
            int expectedValue = 12345;
            int actualValue = Conversions.String2Int(testValue);
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void Test_String2Double()
        //================================================================================================================
        // Test the String2Double method
        //================================================================================================================
        {
            string testValue = "12345.678";
            Double expectedValue = 12345.678;
            Double actualValue = Conversions.String2Double(testValue);
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void Test_String2Percent()
        //================================================================================================================
        // Test the String2Percent method
        //================================================================================================================
        {
            string testValue = "99.98%";
            double expectedValue = .9998;
            double actualValue = Conversions.String2Percent(testValue);
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void Test_ReformatYearBasedDate()
        //================================================================================================================
        // Test the ReformatYearBasedDate method
        //================================================================================================================
        {
            string testValue = "19621209";
            string expectedValue = "12/09/1962";
            string actualValue = Conversions.ReformatYearBasedDate(testValue);
            Assert.AreEqual(expectedValue, actualValue);
        }

        //================================================================================================================
        //================================================================================================================
        #endregion  // String Conversions
    }
}
