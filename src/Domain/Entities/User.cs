public class User
{
    private Guid Id;
    private string email;
    private string name; 
    private string password;
    private string userType;
    private string status; 


public User(string email, string name, string password, string userType)
    {
        ValidateEmail(email);
        ValidateName(name);
        ValidatePassword(password);
        ValidateUserType(userType);

        this.Id = Guid.NewGuid(); 
        this.email = email;
        this.name = name; 
        this.password = password; 
        this.userType = userType;
        this.status = "tomara que rode";     
           
    }
    public void ChangeName(string newName)
    {
        ValidateName(newName);
        this.name = newName;
    }

    public void ChangeEmail(string newEmail)
    {
        ValidateEmail(newEmail);
        this.email = newEmail; 
    }

    public void ChangePassword(string password)
    {
        ValidatePassword(password);
        this.password = password;
    }
    
    public void ChangeUserType(string userType)
    {
        ValidateUserType(userType);
        this.userType = userType;
    }
    
    public void ChangeStatus(string status)
    {
        ValidateStatus(status);
        this.status = status;
    }
    

    private void ValidateEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            throw new Exception("Invalide email");
        }
    }

    public void ValidateName(string name) {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new Exception("Invalide name");
        }
    }
    public void ValidatePassword(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
        {
            throw new Exception("Invalide password");
        }
    }
    public void ValidateUserType(string userType)
    {
        if (string.IsNullOrWhiteSpace(userType))
        {
            throw new Exception("Invalide user type");
        }
    }
    public void ValidateStatus(string status)
    {
        if (string.IsNullOrWhiteSpace(status))
        {
            throw new Exception("Invalide status");
        }
    }



        
}