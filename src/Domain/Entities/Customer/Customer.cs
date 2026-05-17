using System.Data.Common;
using System.Runtime.CompilerServices;
public enum Stage {Active, Inactive, Blocked};

public class Customer
{
    private Guid id; 
    public Guid idUser {get; private set;}
    public string address {get; private set;} 
    public string name {get; private set;} 
    public string email {get; private set;}
    public string cep {get; private set;} 

    private Stage stage; 

    public Customer(Guid userId, string name, string email, string cep, string address)
    {

    if (string.IsNullOrEmpty(address))
    throw new Exception ("Endereço invalido");
    
    if (string.IsNullOrWhiteSpace(cep))
    throw new Exception("CEP invalido");

    if(string.IsNullOrEmpty(name))
    throw new Exception ("Nome invalido");


        this.idUser = (userId);
        this.id = Guid.NewGuid();
        this.name = (name);
        this.email = (email);
        this.cep = (cep);
        this.address = (address);
        this.stage = Stage.Active;


    }

    public void Activate()
    {
        if (stage == Stage.Blocked)
            throw new Exception ("User is blocked");
        
        stage = Stage.Active; 
    }
    public void Inactive()
    {
        if (stage == Stage.Blocked)
            throw new Exception ("User is blocked");

        stage = Stage.Inactive; 
    }
    public void Blocked()
    {
        if (stage == Stage.Blocked)
            throw new Exception ("User already blocked"); 
        stage = Stage.Blocked; 

    }



}





