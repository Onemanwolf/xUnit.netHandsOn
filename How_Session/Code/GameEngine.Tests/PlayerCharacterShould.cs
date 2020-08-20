using System;
using System.Collections.Generic;
using System.Text;
using Xunit;


namespace GameEngine.Tests
{

    [Trait("Category", "PlayerCharacter")]
    public class PlayerCharacterShould
    {
        private PlayerCharacter _sut;


        public PlayerCharacterShould()
        {
            _sut = new PlayerCharacter();
        }


        [Fact]
        public void BeInExperiencedWhenNew()
        {
            //Arrange
            

            //Act
            //Testing defaults

            //Assert
            Assert.True(_sut.IsNoob);
        }


        [Fact]
        public void CheckFullName()
        {
            //Arrange
           
            //Act
            _sut.FirstName = "Tim";
            _sut.LastName = "Oleson";
            //Assert
            Assert.Equal("Tim Oleson", _sut.FullName);
        }

        [Fact]
        public void CheckFullNameStartsWith()
        {
            //Arrange
            
            //Act
            _sut.FirstName = "Anna";
            _sut.LastName = "Oleson";
            //Assert
            Assert.StartsWith("Anna", _sut.FullName);

        }

        [Fact]
        public void CheckFullNameEndsWith()
        {
            //Arrange
           
            //Act
            _sut.FirstName = "Marcela";
            _sut.LastName = "Oleson";
            //Assert
            Assert.EndsWith("Oleson", _sut.FullName);
        }

        [Fact]
        public void CheckLastNameEqualsNotCaseSensitive()
        {
            //Arrange
           
            //Act
            _sut.FirstName = "Sam";
            _sut.LastName = "Daves";
            //Assert
            Assert.Equal("DAVES", _sut.LastName, ignoreCase: true);

        }

        [Fact]
        public void CheckFullNameContains()
        {

            //Arrange
           
            //Act
            _sut.FirstName = "Sam";
            _sut.LastName = "Daves";
            //Assert

            Assert.Contains("am Da", _sut.FullName);

        }

        [Fact]
        public void CheckFullNameMatchesTitleCase()
        {
            //Arrange
           
            //Act
            _sut.FirstName = "Sam";
            _sut.LastName = "Daves";
            //Assert
            Assert.Matches("[A-Z]{1}[a-z]+ [A-z]{1}[a-z]+", _sut.FullName);

        }


        [Fact]
        public void StartWithDefaultHealth()
        {
            //Arrange
            
            //Act Testing Default values

            //Assert
            Assert.Equal(100, _sut.Health);
        }

        [Fact]
        public void StartingCharacterHealthNotZero()
        {
            //Arrange
            
            //Act Testing Default values

            Assert.NotEqual(0, _sut.Health);

        }

       
        [Trait("Category", "Health")]
        [Fact(Skip = "Don't need to run now")]
        public void IncreasedHealthAfterSleep()
        {
            //Arrange
            
            //Act
            _sut.Sleep();
            //Assert
            Assert.True(_sut.Health >= 101 && _sut.Health <= 200);
        }

        [Fact]
        [Trait("Category", "Health")]
        public void IncreasedHealthAfterSleepUsingRange()
        {
            //Arrange
          
            //Act
            _sut.Sleep();
            Assert.InRange<int>(_sut.Health, 101, 200);
        }

        [Fact]
        public void NotHaveNickNameByDefault()
        {
            //Arrange
         
            //Act Checking null Default value

            Assert.Null(_sut.Nickname);
        }


        [Fact]
        public void HaveALongBow()
        {

            //Arrange
           
            //Act Default Values

            //Assert
            Assert.Contains("Short Bow", _sut.Weapons);
        }


        [Fact]
        public void NotHaveAStaffOfWonder()
        {
            //Arrange
           
            //Act Default Values
            Assert.DoesNotContain("Staff of Wonder", _sut.Weapons);
        }


        [Fact]
        public void HaveAtLeastOneKindOfSword()
        {
            //Arrange
            
            //Act Default Values

            //Assert
            Assert.Contains(_sut.Weapons, weapons => weapons.Contains("Sword"));
        }

        [Fact]
        public void HaveNoEmptyDefaultWeapon()
        {

            //Arrange
          
            //Act Default Values

            //Assert
            Assert.All(_sut.Weapons, weapon => Assert.False(string.IsNullOrWhiteSpace(weapon)));
        }

        [Fact]
        public void RaiseSleptEvent()
        {
            //Arrange
            
            //Act lambda

            //Assert
            Assert.Raises<EventArgs>(
                handler => _sut.PlayerSlept += handler,
                handler => _sut.PlayerSlept -= handler,
                () => _sut.Sleep());

           
            
        }


        [Fact]
        public void RaisePropertyChangedEvent()
        {
            //Arrange
          
            //Act lambda

            Assert.PropertyChanged(_sut, "Health", () => _sut.TakeDamage(10));
        }




    }
}
