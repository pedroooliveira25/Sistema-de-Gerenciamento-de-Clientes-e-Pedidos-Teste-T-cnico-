namespace Domain.Entities;


    public class DeleteOrder
    {
        private readonly IOrderRepository _orderRepository;

        public DeleteOrder(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task Execute(Guid id)
        {
            var order = await _orderRepository.GetByIdAsync(id);

            if (order == null)
                throw new Exception("Order not found");

            await _orderRepository.DeleteAsync(order);
            await _orderRepository.SaveChangesAsync();
        }
    }
