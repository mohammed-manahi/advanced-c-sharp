using System.Collections;

namespace GenericsBasicExample;

public class Salaries
{
    // ArrayList is not a generic collection while List is a generic collection
    // ArrayList typically stores an object data type while List stores user-specified data type for T 
    // Generic collections such as list solves the problem of boxing and unboxing of object type in non-generic collections such as ArrayList
    
    private List<float> _salariesList = new List<float>();

    public Salaries()
    {
        _salariesList.Add(5000.53f);
        _salariesList.Add(4000.62f);
        _salariesList.Add(6000.13f);
    }

    public List<float> GetSalaries()
    {
        return _salariesList;
    }
}