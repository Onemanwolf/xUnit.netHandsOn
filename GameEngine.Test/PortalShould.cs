using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Xunit;

namespace GameEngine.Test
{
    [Trait("Catogory", "PortalShould")]
    public class PortalShould
    {           

        [Fact]
        public void TransportPlayer()
        {
            var player = new Mock<PlayerCharacter>();
            
            var _sut = new Portal("string", "string", player.Object);

            _sut.Transport();
            _sut.DestinationReached.Should().BeTrue();
                



        }
    }
}
