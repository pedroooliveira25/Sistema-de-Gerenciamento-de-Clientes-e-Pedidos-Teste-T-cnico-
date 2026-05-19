using Domain.Entities;

public interface IUserRepository
{
    void Add(User user);
    User GetById(Guid id);
    void Update(User user);
    void Delete(User user);
    void SaveChanges();
}