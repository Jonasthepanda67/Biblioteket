using Biblioteket;

namespace UnitTest_Biblioteket
{
    public class UnitTest1 (Laaner laaner1)
    {
        
        [Fact]
        public void Test1()
        {
            Mainp.Main();
            string expected = "Jonas";
            string actual = laaner1.navn;
            Assert.Equal(expected, actual);
        }
    }
}