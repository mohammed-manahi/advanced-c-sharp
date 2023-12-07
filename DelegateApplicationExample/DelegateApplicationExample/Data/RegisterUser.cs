using DelegateApplicationExample.Models;
using Microsoft.EntityFrameworkCore;

namespace DelegateApplicationExample.Data;
using FieldValidators;
public class RegisterUser : IRegister
{
    public bool Register(string[] fields)
    {
        using (var dbContext = new ApplicationDbContext())
        {
            User user = new User()
            {
                // Ensure to cast enum values to int values
                EmailAddress = fields[(int)FieldConstants.UserRegistrationField.EmailAddress],
                FirstName = fields[(int)FieldConstants.UserRegistrationField.FirstName],
                LastName = fields[(int)FieldConstants.UserRegistrationField.LastName],
                Password = fields[(int)FieldConstants.UserRegistrationField.Password],
                DateOfBirth = DateTime.Parse(fields[(int)FieldConstants.UserRegistrationField.DateOfBirth]),
                PhoneNumber = fields[(int)FieldConstants.UserRegistrationField.PhoneNumber],
                AddressFirstLine = fields[(int)FieldConstants.UserRegistrationField.AddressFirstLine],
                AddressSecondLine = fields[(int)FieldConstants.UserRegistrationField.AddressSecondLine],
                AddressCity = fields[(int)FieldConstants.UserRegistrationField.AddressCity],
                PostCode = fields[(int)FieldConstants.UserRegistrationField.PostCode],
            };
            // Adds the object to the users table in database and save the changes
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
        }

        return true;
    }

    public bool EmailExists(string emailAddress)
    {
        bool emailExists = false;
        using (var dbContext = new ApplicationDbContext())
        {
           emailExists = dbContext.Users.Any(user => user.EmailAddress.Trim().ToLower() == emailAddress.Trim().ToLower());
        }
        return emailExists;
    }
}
