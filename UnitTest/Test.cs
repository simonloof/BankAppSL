using SimonsBankApp.Bank;
using SimonsBankApp.Business;
using System;
using System.Linq;
using Xunit;


namespace UnitTest
{

    public class Test
    {
        private BankRepository GetBankRepository()
        {
            BankRepository.Reset();
            return BankRepository.Instance;
        }
        [Theory]
        [InlineData(1, 100, 0)]
        [InlineData(2, 100, 100)]
        [InlineData(3, 1000, 1000)]
        public void Withdraw_WithValidArguments(int accountNo, int sum, decimal expectedBalance)
        {
            var bankRepository = GetBankRepository();
            var accountLogic = new AccountLogic(bankRepository);

            var account = bankRepository.Customers.First(x => x.Accounts.First().AccountNo == accountNo).Accounts.Single();

            var resultStatus = account.WithDrawal(sum);

            Assert.Equal("success", resultStatus);
            Assert.Equal(expectedBalance, account.Balance);
        }

        [Theory]
        [InlineData(1, 0, 100)]
        [InlineData(2, 220, 200)]
        [InlineData(3, -3, 2000)]
        public void Withdraw_WithInvalidArguments(int accountNo, int sum, decimal expectedBalance)
        {
            var bankRepository = GetBankRepository();
            var accountLogic = new AccountLogic(bankRepository);

            var account = bankRepository.Customers.First(x => x.Accounts.First().AccountNo == accountNo).Accounts.Single();

            var resultStatus = account.WithDrawal(sum);

            Assert.NotEqual("success", resultStatus);
            Assert.Equal(account.Balance, expectedBalance);

        }

        [Theory]
        [InlineData(1, 120, 220)]
        [InlineData(2, 22, 222)]
        [InlineData(3, 2500, 4500)]
        public void Deposit_WithValidArguments(int accountNo, int sum, decimal expectedBalance)
        {
            var bankRepository = GetBankRepository();
            var accountLogic = new AccountLogic(bankRepository);

            var account = bankRepository.Customers.First(x => x.Accounts.First().AccountNo == accountNo).Accounts.Single();

            var resultStatus = account.Deposit(sum);

            Assert.Equal("success", resultStatus);
            Assert.Equal(account.Balance, expectedBalance);


        }

        [Theory]
        [InlineData(1, 0, 100)]
        [InlineData(2, -22, 200)]
        [InlineData(3, -3, 2000)]
        public void Deposit_WithInvalidArguments(int accountNo, int sum, decimal expectedBalance)
        {
            var bankRepository = GetBankRepository();
            var accountLogic = new AccountLogic(bankRepository);

            var account = bankRepository.Customers.First(x => x.Accounts.First().AccountNo == accountNo).Accounts.Single();

            var resultStatus = account.Deposit(sum);

            Assert.NotEqual("success", resultStatus);
            Assert.Equal(account.Balance, expectedBalance);


        }

        [Theory]
        [InlineData(1, 2, 50, 50, 250, "success")]
        [InlineData(2, 3, 200, 0, 2200, "success")]
        [InlineData(3, 1, 1000, 1000, 1100, "success")]
        [InlineData(2, 1, 201, 200, 100, "Det finns inte tillräckligt med tecking på frånkontot")]
        [InlineData(1, 2, -1, 100, 200, "Överföringen kan inte vara negativt")]
        [InlineData(1, 2, 0, 100, 200, "Fel format på indata")]
        
        public void Transfer_WithValidOrInvalidArguments(int sourceAccountNo, int targetAccountNo, int sum,
                             decimal sourceAccountExpectedBalance, decimal targetAccountExpectedBalance, string expectedResultStatus)
        {
            var bankRepository = GetBankRepository();
            var customers = bankRepository.Customers;
            var sourceAccount = customers.FirstOrDefault(c => c.Accounts.Any(a => a.AccountNo == sourceAccountNo))
                                ?.Accounts.Single(a => a.AccountNo == sourceAccountNo);
            var targetAccount = customers.FirstOrDefault(c => c.Accounts.Any(a => a.AccountNo == targetAccountNo))
                                ?.Accounts.Single(a => a.AccountNo == targetAccountNo);

            var resultStatus = targetAccount.TransferFrom(sourceAccount, sum);
            Assert.Equal(expectedResultStatus, resultStatus);
            Assert.Equal(sourceAccountExpectedBalance, sourceAccount.Balance);
            Assert.Equal(targetAccountExpectedBalance, targetAccount.Balance);
        }

        //[Theory]
        //[InlineData(1, 2, 50, 50, 250)]
        //[InlineData(2, 3, 200, 0, 2200)]
        //[InlineData(3, 1, 1000, 1000, 1100)]
        //public void Transfer_WithInValidArguments(int sourceAccountNo, int targetAccountNo, int sum,
        //                    decimal sourceAccountExpectedBalance, decimal targetAccountExpectedBalance)
        //{
        //    var bankRepository = GetBankRepository();
        //    var customers = bankRepository.Customers;
        //    var sourceAccount = customers.FirstOrDefault(c => c.Accounts.Any(a => a.AccountNo == sourceAccountNo))
        //                        ?.Accounts.Single(a => a.AccountNo == sourceAccountNo);
        //    var targetAccount = customers.FirstOrDefault(c => c.Accounts.Any(a => a.AccountNo == targetAccountNo))
        //                        ?.Accounts.Single(a => a.AccountNo == targetAccountNo);

        //    var resultStatus = targetAccount.TransferFrom(sourceAccount, sum);

        //    Assert.NotEqual("success", resultStatus);
        //    Assert.Equal(sourceAccountExpectedBalance, sourceAccount.Balance);
        //    Assert.Equal(targetAccountExpectedBalance, targetAccount.Balance);
        //}


    }
}
