using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerPlantManagement.Models;

namespace PowerPlantLoadUnitTest
{
    [TestClass]
    public class PowerPlantUnitTest
        
    {
        [TestMethod]
        public void LoadRequestShould()
        {
            var test = new LoadRequest(new InputRequestDto() { 
             Fuels = new InputFuelsDto() { }
            });
        }
    }
}
