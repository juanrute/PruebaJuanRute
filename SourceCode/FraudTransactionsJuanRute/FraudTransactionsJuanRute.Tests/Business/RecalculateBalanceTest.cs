using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FraudTransactionsJuanRute.Business;
using Model.EntityCode;

namespace FraudTransactionsJuanRute.Tests.Business
{
    [TestClass]
    public class RecalculateBalanceTest
    {
        private RecalculateBalance recalculate;

        [TestInitialize]
        public void setup() {
            recalculate = new RecalculateBalance();
        }

        [TestMethod]
        public void FillTransaction_UserTransfer100_Desthas100_originHas400_resultOk()
        {
            // Arrange
            Transaction tranTest = new Transaction();

            //The user provide the basic data
            tranTest.Amount = 100;
            tranTest.OldBalanceDest = 100;
            tranTest.NameDest = "Destino";
            tranTest.OldbalanceOrg = 400;
            tranTest.NameOrig = "Origen";


            // Act
            recalculate.FillTransaction(tranTest);

            // Assert
            Assert.AreEqual(200,tranTest.NewBalanceDest);
            Assert.AreEqual(300, tranTest.NewbalanceOrig);
        }
    }
}
