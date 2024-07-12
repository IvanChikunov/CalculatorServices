using calculator_back.Consts;
using calculator_back.Services.Interfaces;

namespace calculator_back.Services
{
    public class CalculatorsFactory : ICalculatorsFactory
    {
        public IEnumerable<ICalculationService> calculationServices { get; }

        public CalculatorsFactory(IEnumerable<ICalculationService> calculationServices)
        {
            this.calculationServices = calculationServices;
        }

        public ICalculationService GetServiceByType(CalculationServicesEnum Type)
        {
            return calculationServices.Single(service => service.CalculationServiceType == Type);
        }
    }
}
