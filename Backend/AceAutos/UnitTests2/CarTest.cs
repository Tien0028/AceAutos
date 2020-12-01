using AceAutos.Core.DomainService;
using Moq;
using Xunit;

namespace UnitTests2
{
    public class CarTest
    {
        [Fact]
        public void ReadById()
        {
            //Validate Data
            Mock<ICarRepository> carRepo = new Mock<ICarRepository>();
            Assert.Equal(true, false);
        }
    }
}
