using CodePasswordDLL;
using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodePasswordDLL.Tests
{
    [TestClass]
    public class CodePasswordTests
    {
        [TestInitialize]
        public void TestInitialize()
        {
            Debug.WriteLine("Test Initialize");
        }
        [TestCleanup]
        public void TestCleanup()
        {
            Debug.WriteLine("Test Cleanup");
        }

        [TestMethod]
        public void getCodPassword_abc_bcd()
        {
            // arrange
            var strIn = "abc";
            var strExpected = "bcd";

            // act
            var strActual = CodePassword.getCodPassword(strIn);

            //assert
            ExtensionAssert.AreEqual(strExpected, strActual, out var outputMessage);
            Debug.WriteLine(outputMessage);
        }
        [TestMethod()]
        public void getCodPassword_empty_empty()
        {
            // arrange 
            var strIn = "";
            var strExpected = "";

            // act 
            var strActual = CodePassword.getCodPassword(strIn);

            //assert
            ExtensionAssert.AreEqual(strExpected, strActual, out var outputMessage);
            Debug.WriteLine(outputMessage);
        }

        [TestMethod()]
        public void getPassword_bcd_abc()
        {
            // arrange
            var strIn = "bcd";
            var strExpected = "abc";

            // act
            var strActual = CodePassword.getPassword(strIn);

            //assert
            StringAssert.EndsWith(strExpected, strActual, "Строки не совпадают");
        }
        [TestMethod()]
        public void getPassword_empty_empty()
        {
            // arrange 
            var strIn = "";
            var strExpected = "";

            // act 
            var strActual = CodePassword.getPassword(strIn);

            //assert
            ExtensionAssert.AreEqual(strExpected, strActual, out var outputMessage);
            Debug.WriteLine(outputMessage);
        }
    }
}
