using DelegateApplicationExample.FieldValidators;

namespace DelegateApplicationExample.Views;

public interface IView
{
    void RunView();
    IFieldValidator FieldValidator { get; }
}