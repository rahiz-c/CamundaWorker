
using Camunda.Worker;
using Camunda.Worker.Variables;
using CamundaWorker.DataAccess.SQL.Repository;

namespace CamundaWorker.Worker
{
    [HandlerTopics("charge-card")]
    public class PaymentHandler : IExternalTaskHandler
    {
        public readonly RechargeRepository _rechargeRepository;

        public PaymentHandler(RechargeRepository rechargeRepository)
        {
            _rechargeRepository = rechargeRepository;
        }


        public async Task<IExecutionResult> HandleAsync(ExternalTask externalTask, CancellationToken cancellationToken)
        {
            bool hasAmount = externalTask.TryGetVariable<IntegerVariable>("amount", out var amount);
            bool hasItem = externalTask.TryGetVariable<StringVariable>("Item", out var item);

            if(hasAmount && hasItem) {
                await _rechargeRepository.InsertItem(item.Value, amount.Value);
            }

            await Task.Delay(1000, cancellationToken);

            return new CompleteResult();
        }
    }
}
