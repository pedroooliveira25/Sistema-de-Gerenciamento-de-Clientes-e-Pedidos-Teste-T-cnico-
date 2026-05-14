using System.Data.Common;

public class Customer
{
    private Guid id; 

    public string address {get; private set;} 
    public string name {get; private set;} 
    public string email {get; private set;}
    public string cep {get; private set;} 

    public enum Stage {Active, Inactive, Blocked};

    private Stage stage; 
//iniciando construtor
    public Customer(Guid userId, string name, string email, string cep, string address)
    {
       
        this.id = (userId);

        this.name = (name);
        this.email = (email);
        this.cep = (cep);
        this.address = (address);

        this.stage = Stage.Active;
    }

//definindo metodos de estado
public void Activate()
    { this.stage = Stage.Active; }

public void Block()
    { this.stage = Stage.Blocked; }

public void Inactive()
    { this.stage = Stage.Inactive; }

//definindo regras invariantes



}





