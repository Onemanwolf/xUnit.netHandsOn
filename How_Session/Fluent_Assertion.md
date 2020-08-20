# Fluent Assertion

[Docs](https://fluentassertions.com/introduction)

## What is Fluent Assertion

A very extensive set of extension methods that allow you to more naturally specify the expected outcome of a TDD or BDD-style unit tests. Targets .NET Framework 4.5 and 4.7, as well as .NET Core 2.0, .NET Core 2.1, .NET Core 3.0, .NET Standard 1.3, 1.6 2.0 and 2.1.

## Why Use Fluent Assertion

- Intention Revealing
- Comprehensive Documentation
- Highly Extensible
- Feature Complete
- Community Support - [StackOverFlow](https://stackoverflow.com/questions/tagged/fluent-assertions?mixed=1) - [Slack](https://fluentassertionsslack.herokuapp.com/) - [Git](https://github.com/fluentassertions/fluentassertions/issues)

## Getting Started

First we need the Nuget Package.

1. Right click on the Test project and select Manage NuGet packages... then goto the Browse and paste or type in FluentAssertion.

Fluent Assertions is a set of .NET extension methods that allow you to more naturally specify the expected outcome of a TDD or BDD-style unit test. This enables a simple intuitive syntax that all starts with the following using statement:

```C#
       using FluentAssertions;
```

Now we have the power of Fluent Assertions we can do things like test multiple Items with the And Property Constraint.

```C#
string actual = "THISISASTRING";
actual.Should().StartWith("TH").And.EndWith("NG").And.Contain("AS").And.HaveLength(13);
```

We can improve our test by change or Asserts to use Fluent Assertions methods lets get started.

## Bool Asserts with Fluent Assertion

Lets updated our Bool Assert by using .Should().BeTrue().
We can also check for false Should().BeFalse() as you can see it is very natural and intuitive as you work through you see intellisense almost does the work for you.

```C#
        [Fact]
        public void BeInexperiencedWhenNew()
        {
            //Assert.True(_sut.IsNoob);
            _sut.IsNoob.Should().BeTrue();
        }
```

## Strings Asserts with Fluent Assertion

1. We can check a strings equality so lets create a test for FullName with the `.Should().Be()` method.

```C#
        [Fact]
        public void CheckFullName()
        {

            sut.FirstName = "Tim";
            sut.LastName = "Oleson";

             //Assert.Equal("Tim Oleson", _sut.FullName);
            _sut.FullName.Should().Be("Tim Oleson");
        }

```

2. We can test if a string starts with a particular string with `.Should().StartWith()`.

```C#
        [Fact]
        public void CheckFullNameStartsWith()
        {
            _sut.FirstName = "Anna";
            _sut.LastName = "Oleson";

            //Assert.StartsWith("Anna", _sut.FirstName);
            _sut.FullName.Should().StartWith("Anna");

        }

```

3. We can check if a string ends with a string by using the `.Should().EndWith()`.

```C#
        [Fact]
        public void CheckFullNameEndsWith()
        {
            _sut.FirstName = "Marcela";
            _sut.LastName = "Oleson";

           // Assert.EndsWith("Oleson", _sut.FullName);
            _sut.FullName.Should().EndWith("Oleson");
        }
```

4. We can ignore case by using the `.Should().BeEquivalentTo()`.

```C#

        [Fact]
        public void CheckLastNameEqualsNotCaseSensitive()
        {
            _sut.FirstName = "Sam";
            _sut.LastName = "Daves";

           // Assert.Equal("DAVES", _sut.LastName, ignoreCase: true);
            _sut.LastName.Should().BeEquivalentTo("DAVES");

        }

```

5. We can check if a string contains certain character by using the `.Should().Contain()`

```C#
        [Fact]
        public void CheckFullNameContains()
        {

              _sut.FirstName = "Timmy";
              _sut.LastName = "Oleson";

         //   Assert.Contains("mmy Ole", _sut.FullName);
            _sut.FullName.Should().Contain("mmy Ole");

        }
```

6. We can check in a string matches a pattern with regular expression like Title Case with the `.Should().MathRegex()`.

```C#
        [Fact]
        public void CheckFullNameMatchesTitleCase()
        {
            _sut.FirstName = "Timmy";
            _sut.LastName = "Oleson";

            //Assert.Matches("[A-Z]{1}[a-z]+ [A-z]{1}[a-z]+", _sut.FullName);
            _sut.FullName.Should().MatchRegex("[A-Z]{1}[a-z]+ [A-z]{1}[a-z]+");

        }
```

## Numeric Values Fluent Assertion

Now that we examined strings let look a numeric values and how we can test them

1. We test to see if a value is expected value with by using the `.Should().Be()`.

```C#
        [Fact]
        public void StartWithDefaultHealth()
        {
            //Assert.Equal(100, _sut.Health);
            _sut.Health.Should().Be(100);
        }
```

2. We can check to make sure a value is not zero or not a particular value with `.Should().NotBe()` in addition we can provide a because to make the test more intention revealing.

```C#
        [Fact]
        public void StartingCharacterHealthNotZero()
        {
            //Assert.NotEqual(0, _sut.Health);
            //To help understand the test when can provide optional becuase as in delow
            _sut.Health.Should().NotBe(0, because: "Starting health should be 100");
        }
```

## Floating Point and Value with Fluent Assertion

1. Right Click on the GameEngine.Tests project and select add class name the class BossEnemyShould.

2. Now we will add a test precision point on our return value.

```C#
        [Fact]
        public void HaveCorrectPower()
        {
            var sut = new BossEnemy();

            Assert.Equal(166.667, sut.TotalSpecialAttackPower, 3);
        }
```

## Behavior and values with Fluent Assertion

Lets head back over to the PlayerCharacterShould class.

1. We can check behavior by testing whether a method is producing the correct value after being called and is in within two values with `.Should().BeGreaterThan().And.BeLessThan()` we can see the use fo the And constraint in action again here.

```C#
        [Fact]
        public void IncreasedHealthAfterSleep()
        {
           _sut.Sleep();
            //Assert.True(_sut.Health >=101 && _sut.Health <= 200);
            _sut.Health.Should().BeGreaterThan(101).And.BeLessThan(201);
        }
```

2. Or you can do this using a In Range with `.Should().BeInRange()`.

```C#
        [Fact]
        public void IncreasedHealthAfterSleepUsingRange()
        {
              _sut.Sleep();
           // Assert.InRange<int>(_sut.Health, 101 , 200);
            _sut.Health.Should().BeInRange(101, 201);
        }
```

3. We can check in a value is null by using the `.Should().BeNull()`.

> Note: As you type you will see that intellisense will suggest what you should use in most cases it is dead on.

```C#
        [Fact]
        public void NotHaveNickNameByDefault()
        {

            //Assert.Null(_sut.Nickname);
            _sut.Nickname.Should().BeNull();
        }
```

> Note: As you type you will see that intellisense will suggest what you should use in most cases it is dead on.

## Collections with Fluent Assertion

1. We can check if a list contains a value with the `.Should().Contain()`.

```C#
        [Fact]
        public void HaveALongBow()
        {

             var listOfWeapons = _sut.Weapons;

            // Assert.Contains("Long Dow", _sut.Weapons);
            // you assign local variables an use them in your assert
            listOfWeapons.Should().Contain("Long Bow");
        }
```

2. We test to see if a list does not contain an Item or value with `.Should().NotContain()` which takes a string as demonstrated below.

```C#
        [Fact]
        public void NotHaveAStaffOfWonder()
        {
            //  Assert.DoesNotContain("Staff of Wonder", _sut.Weapons);
            _sut.Weapons.Should().NotContain("Staff of Wonder");
        }
```

3. We can us lambda arrow functions within `.Should().Contains()` by passing in a lambda func `x => x.Contains("string")`.

```C#
        [Fact]
        public void HaveAtLeastOneKindOfSword()
        {

            //Assert.Contains(_sut.Weapons, weapons => weapons.Contains("Sword"));
            _sut.Weapons.Should().Contain(weapons => weapons.Contains("Sword"));
        }
```

4. We can check if all items in a collection whether they are null with `.Should().NotContainNulls()`.

```C#
        [Fact]
        public void HaveNoEmptyDefaultWeapon()
        {
             //Assert.All(_sut.Weapons, weapon => Assert.False(string.IsNullOrWhiteSpace(weapon)));
            _sut.Weapons.Should().NotContainNulls();
        }
```

## Raised Events with Fluent Assertion

1. We can improve event assertion was fired or raised by using the `Should().Raise("PlayerSlept")` we will have to create a Monitor and call it monitoredSubject or you can call is subject then we take our action and check the Monitor to see if the event fired as in below example.

```C#
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

```

2. We can see if property changed event was fired with the Property Changed For Fluent assert `.Should().RaisePropertyChangeFor(p => p.Health)`. In the below example we see two approaches one is a long more opaque version and one is the shorthand version.

```C#
        [Fact]
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
```

## Object Types with Fluent Assertion

We now will look at objects creation and type checking.

1. Navigate to EnemyFactoryShould teat class.

2. Now we will test to check if the factory return the correct type with `.Should().BeOfType()`.

```C#
        [Fact]
        public void NormalEnemyCreated()
        {
             var enemy = _sut.Create("Zombie");

            //Assert.IsType<NormalEnemy>(enemy);
            enemy.Should().BeOfType(typeof(NormalEnemy));
        }
```

3. Now we can test if we can create a Boss passing in boss name and true parameter we can test if the correct type was created `.Should().BeOfType()` we can provide a because to make our test more intention revealing.

```C#
        [Fact]
        public void EnemyBossCreated()
        {
             var enemy = _sut.Create("Zombie King", true);

           // Assert.IsType<BossEnemy>(enemy);
            enemy.Should().BeOfType(typeof(BossEnemy), because: "Because the optional parameter of true was passed in");
        }
```

4. We can also cast a local var to a type and us it with the `.Should().Equals()`.

```C#
        [Fact]
        public void CreateBossEnemy_CastReturnedTypeExample()
        {
              var boss = _sut.Create("Zombie King", true);

            //Assert.Equal("Zombie King", boss.Name);
            boss.Name.Should().Equals("Zombie King");
        }
```

5. We can test to see if the object we have created is from a derived type using the `.Should().BeAssignableTo()`.

```C#
        [Fact]
        public void CreateBossEnemy_AssertAssignableType()
        {
             var enemy = _sut.Create("Zombie");

           // Assert.IsAssignableFrom<Enemy>(enemy);
            enemy.Should().BeAssignableTo(typeof(Enemy));
            enemy.Should().BeAssignableTo<Enemy>();
        }
```

6. We can test if we have separate instances of a class using the `.Should().NotBeSameAs()`.

```C#
        [Fact]
        public void CreateSeparateInstances()
        {

            var enemy1 = _sut.Create("Zombie");
            var enemy2 = _sut.Create("Zombie");

            //Assert.NotSame(enemy1, enemy2);
            enemy1.Should().NotBeSameAs(enemy2);
        }
```

## Exception with Fluent Assertion

Testing to insure exception are thrown and or handled.

1. We can test exceptions with the `.Should().Throw` we first we need create a Action delegate and then apply the Fluent Assertion method to the action.

```C#
        [Fact]
        public void NotAllowNullName()
        {

            //Assert.Throws<ArgumentNullException>(() => _sut.Create(null, false));

            Action act = () => _sut.Create(null, false);

            act.Should().Throw<ArgumentNullException>();
        }
```

2. Testing business rule custom exception are possible with the the `.Should().Throw()` again we need create a Action delegate and then apply the Fluent Assertion method to the action.

```C#
        [Fact]
        public void EnemyBossCreatedIsValidName()
        {
            //var ex =   Assert.Throws<EnemyCreationException>(() => _sut.Create("Zombie", true));

            Action act = () => _sut.Create("Zombie", true);

            act.Should().Throw<EnemyCreationException>();


        }
```
