using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GameEngine.Tests
{
    public class EnemyFactoryShould
    {





        [Fact]
        public void NormalEnemyCreated()
        {
            var sut = new EnemyFactory();

            var enemy = sut.Create("Zombie");

            Assert.IsType<NormalEnemy>(enemy);

        }

        [Fact]
        public void EnemyBossCreated()
        {
            //Arrange
            var sut = new EnemyFactory();

            //Act
            var enemy = sut.Create("Zombie King", true);

            //Assert
            Assert.IsType<BossEnemy>(enemy);
        }

        [Fact]
        public void CreateBossEnemy_CastReturnedTypeExample()
        {
            //Arrange
            var sut = new EnemyFactory();

            //Act
            var enemy = sut.Create("Zombie King", true);
            var boss = Assert.IsType<BossEnemy>(enemy);

            //Assert
            Assert.Equal("Zombie King", boss.Name);
        }

        [Fact]
        public void CreateBossEnemy_AssertAssignableType()
        {
            //Arrange
            var sut = new EnemyFactory();

            //Act
            var enemy = sut.Create("Zombie");

            Assert.IsAssignableFrom<Enemy>(enemy);
        }

        [Fact]
        public void CreateSeparateInstances()
        {

            //Arrange
            var sut = new EnemyFactory();

            //Act
            var enemy1 = sut.Create("Zombie");
            var enemy2 = sut.Create("Zombie");

            Assert.NotSame(enemy1, enemy2);
        }

        [Fact]
        public void NotAllowNullName()
        {

            //Arrange
            var sut = new EnemyFactory();

            //Act lambda

            //Assert
            Assert.Throws<ArgumentNullException>(() => sut.Create(null, false));
        }

        [Fact]
        public void EnemyBossCreatedIsValidName()
        {
            //Arrange
            var sut = new EnemyFactory();

            //Act lambda

            //Assert

            var ex = Assert.Throws<EnemyCreationException>(() => sut.Create("Zombie", true));


        }
    }
}
