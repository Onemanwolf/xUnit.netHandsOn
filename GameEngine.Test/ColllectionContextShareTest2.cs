﻿using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Test
{
    [Collection("GameState collection")]
    [Trait("Catogory", "Context Sharing")]
    public class ColllectionContextShareTest2
    {
        private readonly GameStateFixture _gameStateFixture;
        private readonly ITestOutputHelper _output;

        public ColllectionContextShareTest2(GameStateFixture gameStateFixture, ITestOutputHelper output)
        {
            _gameStateFixture = gameStateFixture;
            _output = output;
        }

        [Fact]
        public void Test1()
        {
            _output.WriteLine($"GameState ID= {_gameStateFixture.State.Id}");
        }

        [Fact]
        public void Test2()
        {
            _output.WriteLine($"GameState ID= {_gameStateFixture.State.Id}");
        }

    }
}
