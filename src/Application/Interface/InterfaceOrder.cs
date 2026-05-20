
using Domain.Enums;

    public interface IOrderRepository
    {
        Task AddAsync(Order order);
        Task<Order?> GetByIdAsync(Guid id);
        void UpdateAsync(Order order);
        void DeleteAsync(Order order);
        
    }
