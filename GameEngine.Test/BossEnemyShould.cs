using FluentAssertions;
using System;
using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Test
{
    [Trait("Category", "Boss")]
    public class BossEnemyShould : IDisposable
    {
        private readonly ITestOutputHelper _output;
        private BossEnemy _sut;
        public BossEnemyShould(ITestOutputHelper output)
        {
            _sut = new BossEnemy();
            _output = output;
        }

        public void Dispose()
        {
            _output.WriteLine("Disposing of sut");
           // _sut.Dispose();
        }

        [Fact]
       
        public void HaveCorrectPower()
        {
            _output.WriteLine("Creating Boss Enemy");
            //Assert.Equal(166.667, _sut.TotalSpecialAttackPower, 3);
            _sut.TotalSpecialAttackPower.Should().BeApproximately(166.667, .003);
        }

        

    }
}
