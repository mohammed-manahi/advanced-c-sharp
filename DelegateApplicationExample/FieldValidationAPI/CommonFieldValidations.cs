using System.Text.RegularExpressions;

namespace FieldValidationAPI;


    // Define validation delegates at namespace scope level
   public delegate bool RequiredFieldValidationDel(string field);

   public delegate bool StringLengthValidationDel(string field, int min, int max);

   public delegate bool DateValidationDel(string dateField, out DateTime validDateTime);

   public delegate bool PatternMatchDel(string field, string pattern);

   public delegate bool CompareFieldsValidationDel(string field1, string field2);
   
public class CommonFieldValidations
{
    // Private static member variables for delegates
    private static RequiredFieldValidationDel _requiredFieldValidationDel = null;
    private static StringLengthValidationDel _stringLengthValidationDel = null;
    private static DateValidationDel _dateValidationDel = null;
    private static PatternMatchDel _patternMatchDel = null;
    private static CompareFieldsValidationDel _compareFieldsValidationDel = null;
    
    // Properties for delegate
    public RequiredFieldValidationDel RequiredFieldValidationProp
    {
        get
        {
            if (_requiredFieldValidationDel != null)
            {
                // Create a object from the delegate and pass the method in the property get 
                _requiredFieldValidationDel = new RequiredFieldValidationDel(RequiredFieldValidation);
            }
            
            return _requiredFieldValidationDel;
        }
    }
    
    public StringLengthValidationDel StringLengthValidationProp
    {
        get
        {
            if (_stringLengthValidationDel != null)
            {
                _stringLengthValidationDel = new StringLengthValidationDel(StringLengthValidation);
            }
            
            return _stringLengthValidationDel;
        }
    }
    
    public DateValidationDel DateValidationProp
    {
        get
        {
            if (_dateValidationDel != null)
            {
                _dateValidationDel = new DateValidationDel(DateValidation);
            }
            
            return _dateValidationDel;
        }
    }
    
    public PatternMatchDel PatternMatchProp
    {
        get
        {
            if (_patternMatchDel != null)
            {
                _patternMatchDel = new PatternMatchDel(PatternMatch);
            }
            
            return _patternMatchDel;
        }
    }
    
    
    public CompareFieldsValidationDel CompareFieldsValidationProp
    {
        get
        {
            if (_compareFieldsValidationDel != null)
            {
                _compareFieldsValidationDel = new CompareFieldsValidationDel(CompareFieldsValidation);
            }
            
            return _compareFieldsValidationDel;
        }
    }


    // Method implementations for delegates
    
    public static bool RequiredFieldValidation(string field)
    {
        if (!string.IsNullOrEmpty(field))
        {
            return true;
        }

        return false;
    }

    public static bool StringLengthValidation(string field, int min, int max)
    {
        if (field.Length >= min && field.Length <= max)
        {
            return true;
        }

        return false;
    }

    public static bool DateValidation(string date, out DateTime validDateTime)
    {
        if (DateTime.TryParse(date, out validDateTime))
        {
            return true;
        }

        return false;
    }

    public static bool PatternMatch(string field, string pattern)
    {
        Regex regex = new Regex(pattern);
        if (regex.IsMatch(field))
        {
            return true;
        }

        return false;
    }

    public static bool CompareFieldsValidation(string field1, string field2)
    {
        if (field1.Equals(field2))
        {
            return true;
        }

        return false;
    }

}