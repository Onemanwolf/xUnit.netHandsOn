using Xunit;

namespace GameEngine.Test
{

    [Trait("Catogory", "NonPlayerCharacter")]
    public class NonPlayerCharacterShould
    {
        [Theory]
        //[MemberData("TestData", MemberType = typeof(InternalHealthDamageTestData))]
        [MemberData(nameof(InternalHealthDamageTestData.TestData), MemberType = typeof(InternalHealthDamageTestData))]
        public void InteralTakeDamage(int damage, int expectedHealth)
        {
            NonPlayerCharacter sut = new NonPlayerCharacter();

            sut.TakeDamage(damage);

            Assert.Equal(expectedHealth, sut.Health);
        }

        [Theory]
        //[MemberData("TestData", MemberType = typeof(InternalHealthDamageTestData))]
        [MemberData(nameof(ExternalHealthDamageTestData.TestData), MemberType = typeof(ExternalHealthDamageTestData))]
        public void ExternalDataSourceTakeDamage(int damage, int expectedHealth)
        {
            NonPlayerCharacter sut = new NonPlayerCharacter();

            sut.TakeDamage(damage);

            Assert.Equal(expectedHealth, sut.Health);
        }


        [Theory]
        [HealthDamageData]
        public void DataAttributeDataSourceTakeDamage(int damage, int expectedHealth)
        {
            NonPlayerCharacter sut = new NonPlayerCharacter();

            sut.TakeDamage(damage);

            Assert.Equal(expectedHealth, sut.Health);
        }


        [Theory]
        [HealthDamageFromCSV]
        public void DataAttributeDataCSVSourceTakeDamage(int damage, int expectedHealth)
        {
            NonPlayerCharacter sut = new NonPlayerCharacter();

            sut.TakeDamage(damage);

            Assert.Equal(expectedHealth, sut.Health);
        }




    }
}
