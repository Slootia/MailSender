using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodePasswordDLL.Tests
{
    //Т.к. нельзя расширить статический метод, создал класс-обёртку
    public static class ExtensionAssert
    {
        public static void AreEqual(string expected, string actual, out string message)
        {
            message = "Тест прошёл успешно";
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception e)
            {
                message = e.Message;
            }
        }
    }
}
