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
    public class CanNotBuyProductIfAmountIs0Steps
    {
        private Account _account;
        private Product _product;
        private PurchaseService _service;

        [Given(@"I have an account")]
        public void GivenIHaveAnAccount()
        {
            _account = new Account { Id = 1, Name = "Account1", Balance = 1 };
        }

        [Given(@"I am going to by product out of stock")]
        public void GivenIAmGoingToByProductAmountIs()
        {
            _product = new Product { Id = 1, Amount = 0, Price = 1, Title = "Test product" };
        }

        [When(@"I use service")]
        public void WhenIBuyProduct()
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

            //_service.Purchase(_account.Id, new[] { _product.Id }, _product.Price);
        }
        
        [Then(@"purchase should throw an exception")]
        public void ThenPurchaseShouldThrowAnException()
        {
            Assert.Throws<PurchaseException>(() => _service.Purchase(_account.Id, new[] { _product.Id }, _product.Price));
        }
    }
}
