using Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class AccountServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CanReturn_GetAccountInfo_ReturnsAccountInfo()
        {
            AccountService accountService = new AccountService();
            Assert.IsNotNull(accountService.GetAccountInfo(1));

        }
    }
}
