using System;
using Xunit;

namespace GameEngine.Test
{
    [Trait("Catogory", "PlayerCharacter")]
    public class PlayerCharacterShould
    {
        private PlayerCharacter _sut;

        public PlayerCharacterShould()
        {
            _sut = new PlayerCharacter();

        }

        [Fact]
        public void BeInexperiencedWhenNew()
        {


            Assert.True(_sut.IsNoob);
        }
        [Fact]
        public void CheckFullName()
        {

            _sut.FirstName = "Tim";
            _sut.LastName = "Oleson";

            Assert.Equal("Tim Oleson", _sut.FullName);
        }

        [Fact]
        public void CheckFullNameStartsWith()
        {
            _sut.FirstName = "Anna";
            _sut.LastName = "Oleson";

            Assert.StartsWith("Anna", _sut.FirstName);

        }
        [Fact]
        public void CheckFullNameEndsWith()
        {
            _sut.FirstName = "Marcela";
            _sut.LastName = "Oleson";
            Assert.EndsWith("Oleson", _sut.FullName);
        }

        [Fact]
        public void CheckLastNameEqualsNotCaseSensative()
        {
            _sut.FirstName = "Sam";
            _sut.LastName = "Daves";
            Assert.Equal("DAVES", _sut.LastName, ignoreCase: true);

        }

        [Fact]
        public void CheckFullNameContains()
        {
            _sut.FirstName = "Sam";
            _sut.LastName = "Daves";
            Assert.Contains("am Da", _sut.FullName);

        }
        [Fact(Skip = "Don't need to run now")]
        public void CheckFullNameMatchesTitleCase()
        {
            _sut.FirstName = "Sam";
            _sut.LastName = "Daves";
            Assert.Matches("[A-Z]{1}[a-z]+ [A-z]{1}[a-z]+", _sut.FullName);

        }

        [Fact]
        public void StartWithDefaultHealth()
        {
            Assert.Equal(100, _sut.Health);
        }

        [Fact]
        public void StartingCharacterHealthNotZero()
        {
            Assert.NotEqual(0, _sut.Health);
        }

        [Fact]
        public void IncreasedHealthAfterSleep()
        {
            _sut.Sleep();
            Assert.True(_sut.Health >=101 && _sut.Health <= 200);
        }

        [Fact]
        public void IncreasedHealthAfterSleepUsingRange()
        {
            _sut.Sleep();
            Assert.InRange<int>(_sut.Health, 101 , 200);
        }

        [Fact]
        public void NotHaveNickNameByDefault()
        {
            Assert.Null(_sut.Nickname);
        }

        [Fact]
        public void HaveALongBow()
        {
            Assert.Contains("Long Bow", _sut.Weapons);
        }

        [Fact]
        public void NotHaveAStaffOfWonder()
        {
            Assert.DoesNotContain("Staff of Wonder", _sut.Weapons);
        }

        [Fact]
        public void HaveAtLeastOneKindOfSword()
        {
            Assert.Contains(_sut.Weapons, weapons => weapons.Contains("Sword"));
        }

        [Fact]
        public void HaveNoEmptyDefaultWeapon()
        {
            Assert.All(_sut.Weapons, weapon => Assert.False(string.IsNullOrWhiteSpace(weapon)));
        }

        [Fact]
        public void RaiseSleptEvent()
        {
            Assert.Raises<EventArgs>(
                handler => _sut.PlayerSlept += handler,
                handler => _sut.PlayerSlept -= handler, 
                () => _sut.Sleep());
        }

        [Fact]
        [Trait("Catogory", "HealthTest")]
        public void RaisePropertyChangedEvent()
        {
            Assert.PropertyChanged(_sut, "Health", () => _sut.TakeDamage(10));
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
            Assert.Equal(expectedHealth, _sut.Health);
        }



    }
}

