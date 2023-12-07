namespace DelegateApplicationExample.FieldValidators;

// Define a delegate that can validate field of any form 
// The fieldIndex is used to index in the field array
// The out keyword allow the value to be output to the calling code
public delegate bool FieldValidatorDel(int fieldIndex, string fieldValue, string[] fieldArray, out string fieldInvalidMessage);

public interface IFieldValidator
{
    void InitializeValidationDelegates();
    string[] FieldArray { get; }
    FieldValidatorDel FieldValidatorProp { get; }
}