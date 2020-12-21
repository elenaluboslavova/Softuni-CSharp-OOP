using Chainblock.Contracts;
using Chainblock.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Diagnostics;

namespace Chainblock.Tests
{
    [TestFixture]
    public class ChainblockTests
    {
        ITransaction transaction;
        IChainblock chainblock;

        [SetUp]
        public void SetUp()
        {
            transaction = new Transaction()
            {
                Id = 1,
                From = "Filip",
                To = "Viktor",
                Status = TransactionStatus.Successfull,
                Amount = 1
            };
            chainblock = new Models.Chainblock();
        }

        [Test]
        [Category("{Add method}")]
        public void Given_Transaction_When_AddTransactionISCalled_Then_TransactionsCountIncrease()
        {
            //Arrange
            int expectedCahinblockCount = 1;

            //Act
            chainblock.Add(transaction);

            //Assert
            Assert.AreEqual(expectedCahinblockCount, chainblock.Count);
        }

        [Test]
        [Category("{Add method}")]
        public void Given_DuplicateTransaction_When_AddTransactionISCalled_Then_ThrowInvalidOperationException()
        {
            //Act
            chainblock.Add(transaction);

            //Assert
            Assert.Throws<InvalidOperationException>(() => chainblock.Add(transaction));
        }

        [Test]
        [Category("{Count property}")]
        public void Given_PropertyCountValue_When_CountGetterIsCalled_Then_ProperNumberIsReturned()
        {
            int expectedResult = 0;
            Assert.AreEqual(expectedResult, chainblock.Count);
        }

        [Test]
        [Category("{Contains --> id method}")]
        public void Given_ExistingId_When_ContainsMethodByIdIsCalled_Then_ReturnsTrue()
        {
            chainblock.Add(transaction);

            Assert.IsTrue(chainblock.Contains(transaction.Id));
        }

        [Test]
        [Category("{Contains --> id method}")]
        public void Given_NonExistingId_When_ContainsMethodByIdIsCalled_Then_ReturnsFalse()
        {
            Assert.IsFalse(chainblock.Contains(transaction.Id));
        }

        [Test]
        [Category("{Contains --> id method}")]
        public void Given_NegativeId_When_ContainsMethodByIdIsCalled_Then_ThrowsArgumentException()
        {
            int invalidId = -1;
            Assert.Throws<ArgumentException>(() => chainblock.Contains(invalidId));
        }

        [Test]
        [Category("{Contains --> transaction method}")]
        public void Given_ExistingTransaction_When_ContainsMethodByTransactionIsCalled_Then_ReturnsTrue()
        {
            chainblock.Add(transaction);
            Assert.That(chainblock.Contains(transaction));
        }

        [Test]
        [Category("{Contains --> transaction method}")]
        public void Given_NonExistingTransaction_When_ContainsMethodByTransactionIsCalled_Then_ReturnsFalse()
        {
            Assert.IsFalse(chainblock.Contains(transaction));
        }

        [Test]
        [Category("{ChangeTransactionStatus method}")]
        public void Given_ValidIdAndStatus_When_ChangeTransactionStatusIsCalled_Then_StatusIsChanged()
        {
            transaction.Status = TransactionStatus.Successfull;
            chainblock.Add(transaction);
            TransactionStatus newStatus = TransactionStatus.Aborted;

            chainblock.ChangeTransactionStatus(transaction.Id, newStatus);

            Assert.AreEqual(newStatus, transaction.Status);
        }

        [Test]
        [Category("{ChangeTransactionStatus method}")]
        public void Given_ValidIdAndSameStatus_When_ChangeTransactionStatusIsCalled_Then_ThrowInvalidOperationException()
        {
            transaction.Status = TransactionStatus.Successfull;
            chainblock.Add(transaction);
            TransactionStatus newStatus = TransactionStatus.Successfull;

            Assert.Throws<Exception>(
                () => chainblock.ChangeTransactionStatus(transaction.Id, newStatus));
        }

        [Test]
        [Category("{ChangeTransactionStatus method}")]
        public void Given_InvalidIdAndStatus_When_ChangeTransactionStatusIsCalled_Then_ThrowArgumentException()
        {
            chainblock.Add(transaction);
            int notExistingId = 2;

            Assert.Throws<ArgumentException>(
                () => chainblock.ChangeTransactionStatus(notExistingId, TransactionStatus.Aborted));
        }

        [Test]
        [Category("{ChangeTransactionStatus method}")]
        public void Given_ValidIdAndNonExistingStatus_When_ChangeTransactionStatusIsCalled_Then_ThrowInvalidOperationException()
        {
            int invalidTransactionStatusValue = 15;

            Assert.Throws<InvalidOperationException>(
                () => chainblock.ChangeTransactionStatus(transaction.Id, (TransactionStatus)invalidTransactionStatusValue));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [Category("{ChangeTransactionStatus method}")]
        public void Given_InvalidIdAndNonExistingStatus_When_ChangeTransactionStatusIsCalled_Then_ThrowArgumentException(int invalidId)
        {
            string expectedErrorMessage = "Id cannot be less or equal to 0.";

            ArgumentException ex = Assert.Throws<ArgumentException>(
                delegate
                {
                    chainblock.ChangeTransactionStatus(invalidId, TransactionStatus.Successfull);
                });
            Assert.AreEqual(ex.Message, expectedErrorMessage);
        }
    }
}
