using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using Domain.Entities;


public class User : Base
{

    
    public User(string name)
    {
        this.Name = name; 
        this.productId = Guid.NewGuid(); 
    }
}