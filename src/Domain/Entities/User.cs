
//crio atributos
using System.Security.Cryptography;

public class User
{
    private Guid Id;
    private string email;
    private string name;
    private string password;
    public enum UserType { ADMIN, CLIENT };
    private UserType userType;
    private string status;

    //inicio o construtor para definir como deve ser tratado meu obj
    public User(string email, string name, string password, UserType userType)
    {
        ValidateEmail(email);
        ValidateName(name);
        ValidatePassword(password);
        ValidateUserType(userType);

        this.Id = Guid.NewGuid();
        this.email = email;
        this.name = name;
        this.password = password;
        this.status = "tomara que rode";
        this.userType = userType;

    }
    //defino metodos de estado
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
    //vou ver o que faço aqui 
    public void ChangeUserType(string userType)
    { }


    public void ChangeStatus(string status)
    {
        ValidateStatus(status);
        this.status = status;
    }

    //metodos de validacao

    private void ValidateEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            throw new Exception("Invalide email");
        }
    }

    public void ValidateName(string name)
    {
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
    public void ValidateUserType(UserType user)
    { }//criar regras de validacao para cada tipo de user}

    public void ValidateStatus(string status)
    {
        if (string.IsNullOrWhiteSpace(status))
        {
            throw new Exception("Invalide status");
        }
    }




}