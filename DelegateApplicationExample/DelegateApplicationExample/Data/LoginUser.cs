using DelegateApplicationExample.Models;

namespace DelegateApplicationExample.Data;

public class LoginUser : ILogin
{
    
    public User Login(string emailAddress, string password)
    {
        User user = null;

        using (var dbContext = new ApplicationDbContext())
        {
            user = dbContext.Users.FirstOrDefault(u => u.EmailAddress.Trim().ToLower() == emailAddress.Trim().ToLower() && u.Password.Equals(password));
        }
        return user;
    }
}