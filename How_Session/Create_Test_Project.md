# Getting Started

[Docs](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-dotnet-test)

1. Create folder Open Command Prompt and make dir xUnit.

```console
C:\Users\tioleson>md xUnit

```

2. Clone the repo from [xUnit.netHandsOn](https://github.com/Onemanwolf/xUnit.netHandsOn)
   .

3. Once the repo is cloned in the How_Session folder open the Code folder and open the GameEngine.sln with Visual Studio.

4. Now that the solution is open we will add a xUnit Test project by right clicking the GameEngine Solution and select add New Project.

![alt text](https://github.com/Onemanwolf/xUnit.netHandsOn/blob/master/How_Session/images/Add_Test_Project.png?raw=true 'Request Pipeline')

4. In the Add a new project window type xunit in the top search window
   and then select xUnit Test Project .Net Core click Next button.

![alt text](https://github.com/Onemanwolf/xUnit.netHandsOn/blob/master/How_Session/images/Name_Test_Project.png?raw=true 'Request Pipeline')

5. In the configure your new project window type GameEngine.Tests in the Project name field.

## Add First Test Class

1. Right Click the Test Project and select add Class and name it PlayerCharacterShould.cs

2. Add a Test Method to the class

```C#
[Fact]
 public void BeInExperiencedWhenNew()
        {
          //Arrange
            var sut = new PlayerCharacter();

            //Act
              //Testing defaults

            //Assert
            Assert.True(sut.IsNoob);
        }

```

## Test Explore

1. Open the Class UnitTest1 you will see test method stub.

2. Let use this test for now just to examine the Test Explore you can open it by clicking on Test in the menu bar at the top of Visual Studio.

3. The will focus on the Group By
   we can Group By things like:

   - Namespace
   - Class
   - Project
   - Traits

4. When right click test and run them or debug test from here

## Run Test from Console

1. Open Console Navigate to Test Project folder and change directory to the test project folder where the test project is located testprojectname.

   ![alt text](https://github.com/Onemanwolf/xUnit.netHandsOn/blob/master/How_Session/images/Console_Command_Dotnet_Test_Cd.png?raw=true 'Request Pipeline')

2. Test and type `dotnet test`

> Example:

```console
C:\Users\tioleson\source\repos\XUnitDotNetHandsOn\xUnit.netHandsOn\GameEngine.Test>dotnet test
```

## Asserts

How many asserts per test? Should always be just one Assert if you need more look at your code and make sure it is following SOLID principles or right a seperate test for the additoinal Assert.

We will explore the xUnit Assert for dealing common uses cases:

- Booleans
- Strings
- Numeric values
- Nulls
- Collections
- Object types and object instances
- Thrown exceptions
- Raised events

### Assert Defined

Evaluate and verify the outcomes of a test, based on a returned results, final object state, or the occurrence of events observed during execution. An assert can either pass or fails the test fails

### Boolean values

- True/false

### String values

- Equality, inequality
- Empty,
- Starts with / ends with
- Contains substring
- Matches regular expression

### Numeric values

- Equality, inequality
- In a given range
- Floating point precision

### Collection contents

- Equality with another collection
- Contains / does not contain
- Contains item satisfying predicate
- All items satisfy an assert

### Raised events

- Custom events
- Framework events

### Object type

Is / not exact specified type
Is / not type or derived type

One Assert per test

```C#
Aasert.True(_sut.IsNoob)
Assert.StartsWith("Smith", _sut.FullName)
Assert.InRange(_sut.Health, 101, 200)
Assert.Null(_sut.NickName)
Assert.Contains("Long Bow", _sut.Weapons)
Assert.IsType<BossEnemy>(enemy);
Assert.NotSame(enemy1, enemy2)
Assert.Throws<ArgruementNullException>(() => _sut.Create(null));
Assert.Raises<EventArgs>(…)
```

## Strings Asserts

We have created a Boolean in our first example now lets explore the rest we start with Strings.

1. We can check a strings equality so lets create a test for FullName

```C#
        [Fact]
        public void CheckFullName()
        {
            //Arrange
            var sut = new PlayerCharacter();
            //Act
            sut.FirstName = "Tim";
            sut.LastName = "Oleson";
            //Assert
            Assert.Equal("Tim Oleson", sut.FullName);
        }

```

2. We can test if a string starts with a particular string.

```C#
        [Fact]
        public void CheckFullNameStartsWith()
        {
            //Arrange
            var sut = new PlayerCharacter();
            //Act
            sut.FirstName = "Anna";
            sut.LastName = "Oleson";
            //Assert
            Assert.StartsWith("Anna", sut.FirstName);

        }

```

3. We can check if a string ends with a string.

```C#
        [Fact]
        public void CheckFullNameEndsWith()
        {
            //Arrange
            var sut = new PlayerCharacter();
            //Act
            sut.FirstName = "Marcela";
            sut.LastName = "Oleson";
            //Assert
            Assert.EndsWith("Oleson", sut.FullName);
        }
```

4. We can ignore case if we need to by passing in the overload of ignoreCase to true

```C#

        [Fact]
        public void CheckLastNameEqualsNotCaseSensative()
        {
            //Arrange
            var sut = new PlayerCharacter();
            //Act
            sut.FirstName = "Sam";
            sut.LastName = "Daves";
            //Assert
            Assert.Equal("DAVES", sut.LastName, ignoreCase: true);

        }

```

5. We can check if a string contains certian character by using contains assert

```C#
        [Fact]
        public void CheckFullNameContains()
        {

            //Arrange
            var sut = new PlayerCharacter();
            //Act
            sut.FirstName = "Sam";
            sut.LastName = "Daves";
            //Assert

            Assert.Contains("am Da", sut.FullName);

        }
```

6. We can check in a string matches a pattern with regular expression like Title Case

```C#
        [Fact]
        public void CheckFullNameMatchesTitleCase()
        {
            //Arrange
            var sut = new PlayerCharacter();
            //Act
            sut.FirstName = "Sam";
            sut.LastName = "Daves";
            //Assert
            Assert.Matches("[A-Z]{1}[a-z]+ [A-z]{1}[a-z]+", sut.FullName);

        }
```

## Numeric Values

Now that we examined strings let look a numeric values and how we can test them

1. We test to see if a value is expected value with equal assert.

```C#
        [Fact]
        public void StartWithDefaultHealth()
        {
            //Arrange
            var sut = new PlayerCharacter();
            //Act Testing Default values

            //Assert
            Assert.Equal(100, sut.Health);
        }
```

2. We can check to make sure a value is not zero or not a particalur value with Not Equal Assert

```C#
        [Fact]
        public void StartingCharacterHealthNotZero()
        {
            //Arrange
            var sut = new PlayerCharacter();
            //Act Testing Default values

            Assert.NotEqual(0, _sut.Health);
        }
```

## Floating Point and Value

1. Right Click on the GameEnging.Tests project and select add class name the class BossEnemyShould.

2. Now we will add a test precision point on our return value.

```C#
        [Fact]
        public void HaveCorrectPower()
        {
            var sut = new BossEnemy();

            Assert.Equal(166.667, sut.TotalSpecialAttackPower, 3);
        }
```

## Behavior and values

Lets head back over to the PlayerCharacterShould class.

1. We can check behavior by testing whether a method is producing the correct value after being called and is in within two values.

```C#
        [Fact]
        public void IncreasedHealthAfterSleep()
        {
            //Arrange
            var sut = new PlayerCharacter();
            //Act
            sut.Sleep();
            //Assert
            Assert.True(sut.Health >=101 && sut.Health <= 200);
        }
```

2. Or you can do this using a In Range Assert.

```C#
        [Fact]
        public void IncreasedHealthAfterSleepUsingRange()
        {
            //Arrange
            var sut = new PlayerCharacter();
            //Act
            sut.Sleep();
            Assert.InRange<int>(sut.Health, 101 , 200);
        }
```

3. We can check in a value is null by using the Null assert.

```C#
        [Fact]
        public void NotHaveNickNameByDefault()
        {
            //Arrange
            var sut = new PlayerCharacter();
            //Act Checking null Default value

            Assert.Null(_sut.Nickname);
        }
```

1. We can check if a list contains a value with the Contains assert.

```C#
        [Fact]
        public void HaveALongBow()
        {

            //Arrange
            var sut = new PlayerCharacter();
            //Act Defaualt Values

            //Assert
            Assert.Contains("Long Bow", sut.Weapons);
        }
```

2. We test to see if a list does not contain an Item or value with Does Not Contain assert.

```C#
        [Fact]
        public void NotHaveAStaffOfWonder()
        {
            //Arrange
            var sut = new PlayerCharacter();
            //Act Defaualt Values
            Assert.DoesNotContain("Staff of Wonder", sut.Weapons);
        }
```

3. We can us lambda arrow functions within Contains assert.

```C#
        [Fact]
        public void HaveAtLeastOneKindOfSword()
        {
            //Arrange
            var sut = new PlayerCharacter();
            //Act Defaualt Values

            //Assert
            Assert.Contains(_sut.Weapons, weapons => weapons.Contains("Sword"));
        }
```

4. We can check if all items in a collection whether the are null or whitespace with lambda and All assert.

```C#
        [Fact]
        public void HaveNoEmptyDefaultWeapon()
        {

            //Arrange
            var sut = new PlayerCharacter();
            //Act Defaualt Values

            //Assert
            Assert.All(_sut.Weapons, weapon => Assert.False(string.IsNullOrWhiteSpace(weapon)));
        }
```

## Rasied Events

1. We can check and determine if an event was fired or raised by using th Raises assert.

```C#
        [Fact]
        public void RaiseSleptEvent()
        {
            //Arrange
            var sut = new PlayerCharacter();
            //Act lambda

            //Assert
            Assert.Raises<EventArgs>(
                handler => sut.PlayerSlept += handler,
                handler => sut.PlayerSlept -= handler,
                () => sut.Sleep());
        }

```

2. We can see if porterty changed event was fired with the Property Changed assert.

```C#
        [Fact]
        public void RaisePropertyChangedEvent()
        {
            //Arrange
            var sut = new PlayerCharacter();
            //Act lambda

            Assert.PropertyChanged(_sut, "Health", () => _sut.TakeDamage(10));
        }
```

## Object Types

We now will look a objects creation and type checking.

1. Right Click on the GameEngine.Tests project and select add class and name it EnemyFactoryShould.

2. Now will create a test method to check if the factory return the correct type.

```C#
        [Fact]
        public void NormalEnemyCreated()
        {
            var sut = new EnemyFactory();

            var enemy = sut.Create("Zombie");

            Assert.IsType<NormalEnemy>(enemy);
        }
```

3. Now we can test if we can create a Boss passing in boss name and true parameter.

```C#
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
```

4. We can also cast a local var to a type using an assert and then test if the Name property is correct.

```C#
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
```

5. We can test to see if the object we created is from a derived type using the IsAssignableFrom assert.

```C#
        [Fact]
        public void CreateBossEnemy_AssertAssignableType()
        {
            //Arrange
            var sut = new EnemyFactory();

            //Act
            var enemy = sut.Create("Zombie");

            Assert.IsAssignableFrom<Enemy>(enemy);
        }
```

6. We can test if we have seperate instances of a class using the NotSame assert.

```C#
        [Fact]
        public void CreateSeperateInstances()
        {

            //Arrange
            var sut = new EnemyFactory();

            //Act
            var enemy1 = sut.Create("Zombie");
            var enemy2 = sut.Create("Zombie");

            Assert.NotSame(enemy1, enemy2);
        }
```

## Exception

Testing to insure exeception are thrown and or handled.

1. We can test exceptions with Throws assert.

```C#
        [Fact]
        public void NotAllowNullName()
        {

            //Arrange
            var sut = new EnemyFactory();

            //Act lambda

            //Assert
            Assert.Throws<ArgumentNullException>(() => sut.Create(null, false));
        }
```

2. Testing buisness rule exception are possible with the Throws assert for example we have correct name for Bosses.

```C#
        [Fact]
        public void EnemyBossCreatedIsValidName()
        {
            //Arrange
            var sut = new EnemyFactory();

            //Act lambda

            //Assert

          var ex =   Assert.Throws<EnemyCreationException>(() => sut.Create("Zombie", true));


        }

```

## Refactor Test

We can see that we are breaking the don't repeat yourself principle which can to lead to maintance nighmares so let refactor all the test we have created to be easier to maintain.

1. Lets start with the PlayerCharacterShould class add a property.

```C#
      private PlayerCharacter _sut;
```

2. Create a constructor for the test class, at the top of the class type ctor and double tap tab key. We are creating a constructor and going to initialize the systme under test `sut`.

```C#
        public PlayerCharacterShould()
        {
            _sut = new PlayerCharacter();

        }
```

2. Now lets lose all of the newing up of the sut in each test.

Form this:

```C#
        [Fact]
        public void CheckFullName()
        {
            //Arrange
            var sut = new PlayerCharacter();
            //Act
            sut.FirstName = "Tim";
            sut.LastName = "Oleson";
            //Assert
            Assert.Equal("Tim Oleson", sut.FullName);
        }
```

To this:

```C#
        [Fact]
        public void CheckFullName()
        {

            _sut.FirstName = "Tim";
            _sut.LastName = "Oleson";

            Assert.Equal("Tim Oleson", _sut.FullName);
        }
```

3. Now refactor on the rest of the test methods and class we havd created so far and moving forward do this or the rest of the test methods and class we create.

> Note
> You can use Control+. to refactor.

![alt text](https://github.com/Onemanwolf/.Net_Core_Api_Getting_Started/blob/master/Labs/images/CreateANewASPDotNetCoreWebApp.png?raw=true 'Request Pipeline')


## Return values

[EF Core Docs](https://docs.microsoft.com/en-us/aspnet/core/data/ef-rp/intro?view=aspnetcore-3.1&tabs=visual-studio)
