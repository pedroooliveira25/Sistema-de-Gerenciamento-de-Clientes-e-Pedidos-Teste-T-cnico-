using System.Data.Common;

public class Customer
{
    private Guid id; 
    private string name; 
    private string email;
    private string cep; 

    public enum Stage {Active, Inactive, Blocked};

    private Stage stage; 
//iniciando construtor
    public Customer(Guid id, string name, string email, string cep)
    {
        this.id = (id);
        this.name = (name);
        this.email = (email);
        this.cep = (cep);

        this.stage = Stage.Active;
    }

//definindo metodos de estado
public void Active(Stage stage)
    { this.stage = Stage.Active; }

public void Blocked(Stage stage)
    { this.stage = Stage.Blocked; }

public void Inactive(Stage stage)
    { this.stage = Stage.Inactive; }
}

