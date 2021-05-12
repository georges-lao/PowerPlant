using NUnit.Framework;
using PowerPlantManagement.Models;
using System.Collections.Generic;

namespace PowerPlantLoadUnitTest
{
    [TestFixture]
    public class PowerPlantUnitTest        
    {
        [Test]
        public void LoadRequestShould()
        {
            var intput = new InputPowerPlantDto() { Name = "TestInput"
                                                   , Efficiency = 100
                                                   , Pmax = 200
                                                   , Pmin = 100
                                                   , Type = "gasfired"
            };
            var list = new List<InputPowerPlantDto>();
            list.Add(intput);
            var test = new LoadRequest(new InputRequestDto() { 
             Fuels = new InputFuelsDto() { 
                                            Co2EuroTon = 100,
                                            gazEeuroMWh = 100,
                                            KerosineEuroMwh = 100,
                                            WindIndex = 1
                                            }
             , load = 200
             , InputPowerPlantDtos = list
             });

            Assert.That(test.GetLoadPlan().Count, Is.EqualTo(1));
        }

        [Test]
        public void TurboJetPowerPlantShould ()
        {
            var PowerPlant = new TurbojetPowerPlant("TurbojetTest",50,10,1,100);
            Assert.That(PowerPlant.Profitability, Is.EqualTo(10));
        }

        [Test]
        public void GasfiredPowerPlantShould()
        {
            var PowerPlant = new GasfiredPowerPlant("GazfiredTest", 50, 10, 1, 100);
            Assert.That(PowerPlant.Profitability, Is.EqualTo(10));
        }

        [Test]
        public void WindturbinePowerPlantShould()
        {
            var PowerPlant = new WindturbinePowerPlant("WindturbineTest", 100, 10, 1, 100);
            Assert.That(PowerPlant.Profitability, Is.EqualTo(100));
        }
    }
}
