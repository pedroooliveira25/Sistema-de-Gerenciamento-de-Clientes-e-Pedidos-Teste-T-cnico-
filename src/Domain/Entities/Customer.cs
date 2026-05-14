using System.Data.Common;
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
//iniciando construtor
    public Customer(Guid userId, string name, string email, string cep, string address)
    {
    //falta definir como inicia o construtor

    if (string.IsNullOrEmpty(address))
    throw new Exception ("Endereço invalido");
    
    if (string.IsNullOrWhiteSpace(cep))
    throw new Exception("CEP invalido");

    if(string.IsNullOrEmpty(name))
    throw new Exception ("Nome invalido");

    if (userId != idUser)
        throw new Exception("User invalidate");


    //name tem que ser o mesmo cadastrado no usuario 
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





