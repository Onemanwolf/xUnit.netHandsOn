using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests
{
    
        public class GameStateShould
        {
            private readonly GameState _sut;
            private readonly ITestOutputHelper _output;


            public GameStateShould(ITestOutputHelper output)
            {
                _sut = new GameState();

                _output = output;
            }

            [Fact]
            public void DamageAllPlayersWhenEarthquake()
            {
                _output.WriteLine($"GameState ID={_sut.Id}");

                var player1 = new PlayerCharacter();
                var player2 = new PlayerCharacter();

                _sut.Players.Add(player1);
                _sut.Players.Add(player2);

                var expectedHealthAfterEarthquake = player1.Health - GameState.EarthquakeDamage;

                _sut.Earthquake();

                Assert.Equal(expectedHealthAfterEarthquake, player1.Health);
                Assert.Equal(expectedHealthAfterEarthquake, player2.Health);
            }

            [Fact]
            public void DateChecker()
            {
            
           

            }

            [Fact]
            public void Reset()
            {


                var player1 = new PlayerCharacter();
                var player2 = new PlayerCharacter();

                _sut.Players.Add(player1);
                _sut.Players.Add(player2);

                _sut.Reset();

                Assert.Empty(_sut.Players);
            }
        }

    }

