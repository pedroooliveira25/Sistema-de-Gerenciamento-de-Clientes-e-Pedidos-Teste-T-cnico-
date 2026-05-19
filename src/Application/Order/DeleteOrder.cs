namespace Application.Orders
{
    public class DeleteOrder
    {
        private readonly IOrderRepository _repository;

        public DeleteOrder(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task Execute(Guid id)
        {
            var order = await _repository.GetByIdAsync(id);

            if (order == null)
                throw new Exception("Order não encontrado");

            await _repository.DeleteAsync(order);
            await _repository.SaveChangesAsync();
        }
    }
}