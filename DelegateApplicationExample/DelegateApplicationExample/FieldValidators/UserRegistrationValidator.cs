using DelegateApplicationExample.Data;
using FieldValidationAPI;

namespace DelegateApplicationExample.FieldValidators;

public class UserRegistrationValidator : IFieldValidator
{
    const int FirstNameMinLength = 2;
    const int FirstNameMaxLength = 100;
    const int LastNameMinLength = 2;
    const int LastNameMaxLength = 100;

    // Define a delegate to check if email address already exists in the system
    delegate bool EmailAddressExistsDel(string emailAddress);

    // Create private member of field validator delegate from the interface
    private FieldValidatorDel _fieldValidatorDel = null;

    // Create private members of API delegates
    RequiredFieldValidationDel _requiredFieldValidationDel = null;
    StringLengthValidationDel _stringLengthValidationDel = null;
    DateValidationDel _dateValidationDel = null;
    PatternMatchDel _patternMatchDel = null;
    CompareFieldsValidationDel _compareFieldsValidationDel = null;

    // Create private member of email address delegate defined above
    private EmailAddressExistsDel _emailAddressExistsDel = null;

    private IRegister _register = null;

    // Define the field array
    private string[] _fieldArray = null;


    // Define the field array property
    public string[] FieldArray
    {
        get
        {
            if (_fieldArray == null)
            {
                // Define array size according to values in user registration field enum
                _fieldArray = new string[Enum.GetValues(typeof(FieldConstants.UserRegistrationField)).Length];
            }

            return _fieldArray;
        }
    }


    public FieldValidatorDel FieldValidatorProp
    {
        get
        {
            // Gets the private member of field validator delegate 
            return _fieldValidatorDel;
        }
    }

    public UserRegistrationValidator(IRegister register)
    {
        _register = register;
    }

    public void InitializeValidationDelegates()
    {
        // Call the private field validator in the initializer which reference the field validate delegate
        _fieldValidatorDel = new FieldValidatorDel(FieldValidator);

        // Reference the email exists method to its delegate
        _emailAddressExistsDel = new EmailAddressExistsDel(_register.EmailExists);
        
        // Reference the delegates to their proper methods
        _requiredFieldValidationDel = new RequiredFieldValidationDel(CommonFieldValidations.RequiredFieldValidation);
        _stringLengthValidationDel = new StringLengthValidationDel(CommonFieldValidations.StringLengthValidation);
        _dateValidationDel = new DateValidationDel(CommonFieldValidations.DateValidation);
        _patternMatchDel = new PatternMatchDel(CommonFieldValidations.PatternMatch);
        _compareFieldsValidationDel = new CompareFieldsValidationDel(CommonFieldValidations.CompareFieldsValidation);
    }

    private bool FieldValidator(int fieldIndex, string fieldValue, string[] fieldArray, out string fieldInvalidMessage)
    {
        // Create private method for field validator delegate
        fieldInvalidMessage = "";
        // Convert enum values to field index values to use in field array 
        FieldConstants.UserRegistrationField userRegistrationField = (FieldConstants.UserRegistrationField)fieldIndex;
        switch (userRegistrationField)
        {
            case FieldConstants.UserRegistrationField.EmailAddress:
                fieldInvalidMessage = (!_requiredFieldValidationDel(fieldValue))
                    // Get the enum value using the type and value based on the switch case
                    ? ($"You must enter a value for {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine}")
                    : fieldInvalidMessage;
                // The check is first if the message is still empty meaning that the required validation passed then compare the pattern match using regex
                fieldInvalidMessage = (fieldInvalidMessage == string.Empty && !_patternMatchDel(fieldValue,
                    CommonRegularExpressionValidations.Email_Address_RegEx_Pattern))
                    ? "You must enter a valid email address"
                    : fieldInvalidMessage;
                fieldInvalidMessage = (fieldInvalidMessage == string.Empty && _emailAddressExistsDel(fieldValue))
                    ? $"This email address already exists. Please try again{Environment.NewLine}"
                    : fieldInvalidMessage;
                break;
            case FieldConstants.UserRegistrationField.FirstName:
                fieldInvalidMessage = (!_requiredFieldValidationDel(fieldValue))
                    ? ($"You must enter a value for {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine}")
                    : fieldInvalidMessage;
                // Check for first name length range using defined constant members in this class 
                fieldInvalidMessage = (fieldInvalidMessage == string.Empty && !_stringLengthValidationDel(fieldValue, FirstNameMinLength, FirstNameMaxLength))
                    ? $"The length for field: {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)} must be between {FirstNameMinLength} and {FirstNameMaxLength}{Environment.NewLine}"
                    : fieldInvalidMessage;
                break;
            case FieldConstants.UserRegistrationField.LastName:
                fieldInvalidMessage = (!_requiredFieldValidationDel(fieldValue))
                    ? ($"You must enter a value for {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine}")
                    : fieldInvalidMessage;
                fieldInvalidMessage = (fieldInvalidMessage == string.Empty && !_stringLengthValidationDel(fieldValue, LastNameMinLength, LastNameMaxLength))
                    ? $"The length for field: {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)} must be between {LastNameMinLength} and {LastNameMaxLength}{Environment.NewLine}"
                    : fieldInvalidMessage;
                break;
            case FieldConstants.UserRegistrationField.Password:
                fieldInvalidMessage = (!_requiredFieldValidationDel(fieldValue))
                    ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine}"
                    : fieldInvalidMessage;
                fieldInvalidMessage = (fieldInvalidMessage == "" && _patternMatchDel(fieldValue, CommonRegularExpressionValidations.Strong_Password_RegEx_Pattern))
                        ? $"Your password must contain at least 1 small-case letter, 1 capital letter, 1 special character and the length should be between 6 - 10 characters{Environment.NewLine}"
                        : fieldInvalidMessage;
                break;
            case FieldConstants.UserRegistrationField.PasswordCompare:
                fieldInvalidMessage = (!_requiredFieldValidationDel(fieldValue))
                    ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine}"
                    : fieldInvalidMessage;
                // Get the value of the password in field array to comapre it with password compare field
                fieldInvalidMessage = (fieldInvalidMessage == "" && !_compareFieldsValidationDel(fieldValue, fieldArray[(int)FieldConstants.UserRegistrationField.Password]))
                        ? $"Your entry did not match your password{Environment.NewLine}"
                        : fieldInvalidMessage;
                break;
            case FieldConstants.UserRegistrationField.DateOfBirth:
                fieldInvalidMessage = (!_requiredFieldValidationDel(fieldValue))
                    ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine}"
                    : "";
                fieldInvalidMessage = (fieldInvalidMessage == "" && !_dateValidationDel(fieldValue, out DateTime validDateTime))
                        ? $"You did not enter a valid date"
                        : fieldInvalidMessage;
                break;
            case FieldConstants.UserRegistrationField.PhoneNumber:
                fieldInvalidMessage = (!_requiredFieldValidationDel(fieldValue))
                    ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine}"
                    : "";
                fieldInvalidMessage = (fieldInvalidMessage == "" && !_patternMatchDel(fieldValue,
                        CommonRegularExpressionValidations.Uk_PhoneNumber_RegEx_Pattern))
                        ? $"You did not enter a valid UK phone number{Environment.NewLine}"
                        : fieldInvalidMessage;
                break;
            case FieldConstants.UserRegistrationField.AddressFirstLine:
                fieldInvalidMessage = (!_requiredFieldValidationDel(fieldValue))
                    ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine}"
                    : "";
                break;
            case FieldConstants.UserRegistrationField.AddressSecondLine:
                fieldInvalidMessage = (!_requiredFieldValidationDel(fieldValue))
                    ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine}"
                    : "";
                break;
            case FieldConstants.UserRegistrationField.AddressCity:
                fieldInvalidMessage = (!_requiredFieldValidationDel(fieldValue))
                    ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine}"
                    : "";
                break;
            case FieldConstants.UserRegistrationField.PostCode:
                fieldInvalidMessage = (!_requiredFieldValidationDel(fieldValue))
                    ? $"You must enter a value for field:{Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine}"
                    : "";
                fieldInvalidMessage =
                    (fieldInvalidMessage == "" && !_patternMatchDel(fieldValue,
                        CommonRegularExpressionValidations.Uk_Post_Code_RegEx_Pattern))
                        ? $"You did not enter a valid UK post code{Environment.NewLine}"
                        : fieldInvalidMessage;
                break;
            default:
                throw new ArgumentException("This field does not exists");
        }

        return (fieldInvalidMessage == "");
    }
}