using Bank.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bank.Domain.Tests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            // Act
            account.Debit(debitAmount);
            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        public void Credit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double creditAmount = 4.55;
            double expected = 16.54;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            // Act
            account.Credit(creditAmount);
            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not credited correctly");
        }

        [TestMethod]
        public void Constructor_SetsPropertiesCorrectly()
        {
            // Arrange
            string customerName = "John Doe";
            double balance = 100.0;

            // Act
            BankAccount account = new BankAccount(customerName, balance);

            // Assert
            Assert.AreEqual(customerName, account.CustomerName);
            Assert.AreEqual(balance, account.Balance);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Debit_WithNegativeAmount_ThrowsException()
        {
            // Arrange
            BankAccount account = new BankAccount("Test", 100.0);

            // Act & Assert
            account.Debit(-10.0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Credit_WithNegativeAmount_ThrowsException()
        {
            // Arrange
            BankAccount account = new BankAccount("Test", 100.0);

            // Act & Assert
            account.Credit(-10.0);
        }
    }
}