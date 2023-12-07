using DelegateApplicationExample.Models;

namespace DelegateApplicationExample.Data;

public interface ILogin
{
    User Login(string emailAddress, string password);
}