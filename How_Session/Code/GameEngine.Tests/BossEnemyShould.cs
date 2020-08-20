using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests
{

    [Trait("Category", "BossEnemy")]
    public class BossEnemyShould
    {


        private readonly ITestOutputHelper _output;
        public BossEnemyShould(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void HaveCorrectPower()
        {

            _output.WriteLine("Creating Boss Enemy");
            var sut = new BossEnemy();

            Assert.Equal(166.67, sut.TotalSpecialAttackPower, 2);
        }
    }
}
