using Application.User;
using Domain.Entities;

var createUser = new CreateUser();

var user = createUser.Execute(
    "pedro@gmail.com",
    "Pedro",
    "123456",
    UserType.CLIENT
);

System.Console.WriteLine(user);