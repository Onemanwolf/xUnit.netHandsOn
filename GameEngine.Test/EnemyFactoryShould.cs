using System;
using System.Runtime.InteropServices;
using Xunit;

namespace GameEngine.Test
{
    [Trait("Catogory", "Enemy")]
    public class EnemyFactoryShould
    {

        private EnemyFactory _sut;
        public EnemyFactoryShould()
        {
            _sut = new EnemyFactory();
        }

        [Fact]
       
        public void NormalEnemyCreated()
        {
            var enemy = _sut.Create("Zombie");

            Assert.IsType<NormalEnemy>(enemy);
        }

        [Fact]
        public void EnemyBossCreated()
        {
            var enemy = _sut.Create("Zombie King", true);

            Assert.IsType<BossEnemy>(enemy);
        }

        [Fact]
        public void CreateBossEnemy_CastReturnedTypeExample()
        {
            var enemy = _sut.Create("Zombie King", true);
            var boss = Assert.IsType<BossEnemy>(enemy);
            //Assert.Equal("Zombie King", boss.Name);
        }

        [Fact]
        public void CreateBossEnemy_AssertAssignableType()
        {
            var enemy = _sut.Create("Zombie");

            Assert.IsAssignableFrom<Enemy>(enemy);
        }

        [Fact]
        public void CreateSeperateInstances()
        {
            var enemy1 = _sut.Create("Zombie");
            var enemy2 = _sut.Create("Zombie");

            Assert.NotSame(enemy1, enemy2);
        }


        [Fact]
        public void NotAllowNullName()
        {
            
            Assert.Throws<ArgumentNullException>(() => _sut.Create(null, false));
        }

        [Fact]
        public void EnemyBossCreatedIsValidName()
        {
          var ex =   Assert.Throws<EnemyCreationException>(() => _sut.Create("Zombie", true));


        }

        
    }
}
