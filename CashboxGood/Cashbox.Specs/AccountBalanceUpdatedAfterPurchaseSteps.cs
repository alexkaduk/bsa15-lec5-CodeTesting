using TechTalk.SpecFlow;
using System.Linq;
using Cashbox.DataAccess;
using Cashbox.Models;
using Cashbox.Services;
using NUnit.Framework;
using FakeItEasy;

namespace Cashbox.Specs
{
    [Binding]
    public class AccountBalanceUpdatedAfterPurchaseSteps
    {
        private Account _account;
        private Product _product;
        private PurchaseService _service;
        private decimal _updatedBalance;

        [Given(@"I have an account with (.*) on balance")]
        public void GivenIHaveAnAccountWithOnBalance(int p0)
        {
            _account = new Account { Id = 1, Name = "Account1", Balance = p0 };
        }

        [Given(@"I am going to by product which price is (.*)")]
        public void GivenIAmGoingToByProductWhichPriceIs(int p0)
        {
            _product = new Product { Id = 1, Amount = 1, Price = p0, Title = "Test product" };
        }

        [Given(@"I buy product")]
        public void GivenIBuyProduct()
        {
            var accountRepository = A.Fake<IRepository<Account>>();
            A.CallTo(() => accountRepository.Get(A<int>._)).Returns(_account);

            var productRepository = A.Fake<IRepository<Product>>();
            A.CallTo(() => productRepository.Query()).Returns(new[] { _product }.AsQueryable());

            var unitOfWork = A.Fake<IUnitOfWork>();
            A.CallTo(() => unitOfWork.Repository<Product>()).Returns(productRepository);
            A.CallTo(() => unitOfWork.Repository<Account>()).Returns(accountRepository);

            var unitOfWorkFactory = A.Fake<IUnitOfWorkFactory>();
            A.CallTo(() => unitOfWorkFactory.Create()).Returns(unitOfWork);

            _service = new PurchaseService(unitOfWorkFactory);

            _service.Purchase(_account.Id, new[] { _product.Id }, _product.Price);
        }

        [When(@"I check account balance")]
        public void WhenICheckAccountBalance()
        {
            _updatedBalance = _account.Balance;
        }

        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(int p0)
        {
            Assert.That(_updatedBalance, Is.EqualTo(p0));
        }
    }
}
