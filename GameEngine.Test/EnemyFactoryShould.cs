using FluentAssertions;
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

            //Assert.IsType<NormalEnemy>(enemy);
            enemy.Should().BeOfType(typeof(NormalEnemy));
        }

        [Fact]
        public void EnemyBossCreated()
        {
            var enemy = _sut.Create("Zombie King", true);

           // Assert.IsType<BossEnemy>(enemy);
            enemy.Should().BeOfType(typeof(BossEnemy), because: "Because the optional parameter of true was passed in");
        }

        [Fact]
        public void CreateBossEnemy_CastReturnedTypeExample()
        {
            var boss = _sut.Create("Zombie King", true);

            //Assert.Equal("Zombie King", boss.Name);
            boss.Name.Should().Equals("Zombie King");
        }

        [Fact]
        public void CreateBossEnemy_AssertAssignableType()
        {
            var enemy = _sut.Create("Zombie");

           // Assert.IsAssignableFrom<Enemy>(enemy);
            enemy.Should().BeAssignableTo(typeof(Enemy));
            enemy.Should().BeAssignableTo<Enemy>();
        }

        [Fact]
        public void CreateSeperateInstances()
        {
            var enemy1 = _sut.Create("Zombie");
            var enemy2 = _sut.Create("Zombie");

            //Assert.NotSame(enemy1, enemy2);
            enemy1.Should().NotBeSameAs(enemy2);
        }


        [Fact]
        public void NotAllowNullName()
        {
            
            //Assert.Throws<ArgumentNullException>(() => _sut.Create(null, false));

            Action act = () => _sut.Create(null, false);

            act.Should().Throw<ArgumentNullException>();


        }

        [Fact]
        public void EnemyBossCreatedIsValidName()
        {
            //var ex =   Assert.Throws<EnemyCreationException>(() => _sut.Create("Zombie", true));

            Action act = () => _sut.Create("Zombie", true);

            act.Should().Throw<EnemyCreationException>();

        }

        
    }
}
