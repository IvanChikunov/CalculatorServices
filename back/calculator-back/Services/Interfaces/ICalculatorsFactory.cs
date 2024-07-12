using calculator_back.Consts;

namespace calculator_back.Services.Interfaces
{
    public interface ICalculatorsFactory
    {
        IEnumerable<ICalculationService> calculationServices { get; }

        public ICalculationService GetServiceByType(CalculationServicesEnum Type);
    }
}
