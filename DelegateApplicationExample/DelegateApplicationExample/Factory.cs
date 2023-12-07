using DelegateApplicationExample.Data;
using DelegateApplicationExample.FieldValidators;
using DelegateApplicationExample.Views;

namespace DelegateApplicationExample;

public static class Factory
{
    public static IView GetMainViewObject()
    {
        // Abstracts the application views in a factory class
        ILogin login = new LoginUser();
        IRegister register = new RegisterUser();
        IFieldValidator userRegistrationValidator = new UserRegistrationValidator(register);
        userRegistrationValidator.InitializeValidationDelegates();

        IView registerView = new UserRegistrationView(register, userRegistrationValidator);
        IView loginView = new UserLoginView(login);
        IView mainView = new MainView(registerView, loginView);

        return mainView;
    }
}