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
    }
}
