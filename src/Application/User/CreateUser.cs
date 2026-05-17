using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using Microsoft.VisualBasic;

namespace  Application.User;
using Domain.Entities;


public class CreateUser 
{    
        public User Execute(string email, string name, string password, UserType userType)
    {
          var user = new User(email, name, password, userType);
        return user;
    }



public void EditProduct(User user)
{
    if (user.UserType != UserType.ADMIN)
        throw new Exception("Access denied");

    //colocar logica de edicao do produto aqui;;
}

    
}


