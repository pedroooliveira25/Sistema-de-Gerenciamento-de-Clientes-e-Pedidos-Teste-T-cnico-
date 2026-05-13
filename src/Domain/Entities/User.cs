public class User
{
    public int Id {get; private set;}
    public string name {get; private set;}
    public string email {get; private set;}
    public string password {get; private set;}
    public string userType {get; private set;}



//metado para criar user
public User(string email, string name, string password, string userType)
    {
        if (string.IsNullOrWhiteSpace(email))
        throw new Exception("Invalid e-mail");

        if (string.IsNullOrWhiteSpace(name)){
            throw new Exception("Invalid name");
        }

        this.email = email; 
        this.name = name;
        this.password = password; 
        this.userType = userType;

    }


        
}