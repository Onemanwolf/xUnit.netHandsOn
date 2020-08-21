using FluentAssertions;
using FluentAssertions.Events;
using Moq;
using System;
using System.ComponentModel;
using Xunit;

namespace GameEngine.Test
{
    [Trait("Catogory", "PlayerCharacter")]
    public class PlayerCharacterShould
    {
        private IPlayerCharacter _sut;
        private Mock<IPlayerCharacter> mock;
      
        public PlayerCharacterShould()
        {
            _sut = new PlayerCharacter();
            mock = new Mock<IPlayerCharacter>();

        }

        [Fact]
        public void BeInexperiencedWhenNew()
        {
            //Assert.True(_sut.IsNoob);
           // _sut.IsNoob.Should().BeTrue();
        }


        [Fact]
        public void CheckFullName()
        {
           
            mock.Setup(pc => pc.FirstName).Returns("Tim");
            mock.Setup(pc => pc.LastName).Returns("Oleson");
            mock.Setup(pc => pc.FullName).Returns(string.Concat(mock.Object.FirstName, " ", mock.Object.LastName));
            //_sut.FirstName = "Tim";
            //_sut.LastName = "Oleson";

            //Assert.Equal("Tim Oleson", _sut.FullName);
            mock.Object.FullName.Should().Be("Tim Oleson");
        }

        [Fact]
        public void CheckFullNameStartsWith()
        {
           // _sut.FirstName = "Anna";
           // _sut.LastName = "Oleson";
            mock.Setup(pc => pc.FirstName).Returns("Anna");
            mock.Setup(pc => pc.LastName).Returns("Oleson");
            mock.Setup(pc => pc.FullName)
                .Returns(string.Concat(mock.Object.FirstName, " ", mock.Object.LastName));
            //Assert.StartsWith("Anna", _sut.FirstName);
            mock.Object.FullName.Should().StartWith("Anna");

        }
        [Fact]
        public void CheckFullNameEndsWith()
        {
           // _sut.FirstName = "Marcela";
            //_sut.LastName = "Oleson";

            mock.Setup(pc => pc.FirstName).Returns("Anna");
            mock.Setup(pc => pc.LastName).Returns("Oleson");
            mock.Setup(pc => pc.FullName).Returns(string.Concat(mock.Object.FirstName, " ", mock.Object.LastName));

           // Assert.EndsWith("Oleson", _sut.FullName);
            mock.Object.FullName.Should().EndWith("Oleson");
        }

        [Fact]
        public void CheckLastNameEqualsNotCaseSensative()
        {
            // _sut.FirstName = "Sam";
            mock.Setup(pc => pc.LastName).Returns("Daves");
            //_sut.LastName = "Daves";

            // Assert.Equal("DAVES", _sut.LastName, ignoreCase: true);
            mock.Object.LastName.Should().BeEquivalentTo("DAVES");

        }

        [Fact]
        public void CheckFullNameContains()
        {
           // _sut.FirstName = "Timmy";
          //  _sut.LastName = "Oleson";

            mock.Setup(pc => pc.FirstName).Returns("Timmy");
            mock.Setup(pc => pc.LastName).Returns("Oleson");
            mock.Setup(pc => pc.FullName).Returns(string.Concat(mock.Object.FirstName, " ", mock.Object.LastName));

            //   Assert.Contains("mmy Ole", _sut.FullName);
            mock.Object.FullName.Should().Contain("mmy Ole");
        }
        [Fact]
        //[Fact(Skip = "Don't need to run now")]
        public void CheckFullNameMatchesTitleCase()
        {
           // _sut.FirstName = "Timmy";
           // _sut.LastName = "Oleson";

            mock.Setup(pc => pc.FirstName).Returns("Tim");
            mock.Setup(pc => pc.LastName).Returns("Oleson");
            mock.Setup(pc => pc.FullName).Returns(string.Concat(mock.Object.FirstName, " ", mock.Object.LastName));

            //Assert.Matches("[A-Z]{1}[a-z]+ [A-z]{1}[a-z]+", _sut.FullName);
            mock.Object.FullName.Should().MatchRegex("[A-Z]{1}[a-z]+ [A-z]{1}[a-z]+");
        }

        [Fact]
        public void StartWithDefaultHealth()
        {
            //Assert.Equal(100, _sut.Health);
            mock.Setup(pc => pc.Health).Returns(100);
            mock.Object.Health.Should().Be(100);
        }

        [Fact]
        public void StartingCharacterHealthNotZero()
        {
            //Assert.NotEqual(0, _sut.Health);
            //To help understand the test when can provide optional becuase as in delow
            mock.Setup(pc => pc.Health).Returns(100);
            _sut.Health.Should().NotBe(0, because: "Starting health should be 100");

        }

        [Fact]
        public void IncreasedHealthAfterSleep()
        {
            _sut.Sleep();

           

            //Assert.True(_sut.Health >=101 && _sut.Health <= 200);
            _sut.Health.Should().BeGreaterThan(101).And.BeLessThan(201);
        }

        [Fact]
        public void IncreasedHealthAfterSleepUsingRange()
        {
              _sut.Sleep();

                       // Assert.InRange<int>(_sut.Health, 101 , 200);
            _sut.Health.Should().BeInRange(101, 201);
        }

        [Fact]
        public void NotHaveNickNameByDefault()
        {
            //Assert.Null(_sut.Nickname);
            _sut.Nickname.Should().BeNull();
        }

        [Fact]
        public void HaveALongBow()
        {

            var listOfWeapons = _sut.Weapons;


            // Assert.Contains("Long Dow", _sut.Weapons);
            // you assign local variables an use them in your assert
            listOfWeapons.Should().Contain("Long Bow");
        }

        [Fact]
        public void NotHaveAStaffOfWonder()
        {
            //  Assert.DoesNotContain("Staff of Wonder", _sut.Weapons);
            _sut.Weapons.Should().NotContain("Staff of Wonder");
        }

        [Fact]
        public void HaveAtLeastOneKindOfSword()
        {
            //Assert.Contains(_sut.Weapons, weapons => weapons.Contains("Sword"));
            _sut.Weapons.Should().Contain(weapons => weapons.Contains("Sword"));

        }

        [Fact]
        public void HaveNoEmptyDefaultWeapon()
        {
            //Assert.All(_sut.Weapons, weapon => Assert.False(string.IsNullOrWhiteSpace(weapon)));
            _sut.Weapons.Should().NotContainNulls();


        }

        [Fact]
        public void RaiseSleptEvent()
        {
            //Assert.Raises<EventArgs>(
            //    handler => _sut.PlayerSlept += handler,
            //    handler => _sut.PlayerSlept -= handler, 
            //    () => _sut.Sleep());

            // Fluent Assertions use a Monitor to check Events
            using (var monitoredSubject = _sut.Monitor())
            {
                _sut.Sleep();
                monitoredSubject.Should().Raise("PlayerSlept");
            }

        }

        [Fact]
        public void ExameString()
        {
            string actual = "THISISASTRING";
            actual.Should().StartWith("TH").And.EndWith("NG").And.Contain("AS").And.HaveLength(13);
        }


        [Fact]
        [Trait("Catogory", "HealthTest")]
        public void RaisePropertyChangedEvent()
        {
            // Assert.PropertyChanged(_sut, "Health", () => _sut.TakeDamage(10));

            using (var monitoredSubject = _sut.Monitor())
            {
                _sut.TakeDamage(10);

                monitoredSubject.Should().RaisePropertyChangeFor(p => p.Health);
                //long form 
                //monitoredSubject.Should().Raise("PropertyChanged").WithSender(_sut).WithArgs<PropertyChangedEventArgs>(args => args.PropertyName == "Health");
            }

        }

        [Theory]
        [InlineData(0, 100)] //Test Case Data
        [InlineData(20, 80)]
        [InlineData(50, 50)]
        [InlineData(101, 1)]

        [Trait("Catogory", "HealthTest")]
        public void TakeDamage(int damage, int expectedHealth)
        {
            _sut.TakeDamage(damage);
            //Assert.Equal(expectedHealth, _sut.Health);
            _sut.Health.Should().Equals(expectedHealth);
        }



    }
}

