namespace GenericBubbleSort;

public class SortArray
{
    public void BubbleSort(object[] array)
    {
        int n = array.Length;
        // The out loop loops through the collection where it limit is n - 1 because the array index starts at 0
        for (int i = 0; i < n - 1; i++)
        {
            // The inner loop part compares each item with its neighbor 
            for (int j = 0; j < n - i - 1; j++)
            {
                // Cast to IComparable because type object can not be compared
                // Compare to method return greater than zero if the value (j) is larger than the value that is compared to (j+1)
                if (((IComparable)array[j]).CompareTo(array[j + 1]) > 0)
                {
                    Swap(array, j);
                }
            }
        }
        Console.WriteLine(string.Join("," , array));
    }

    private void Swap(object[] array, int j)
    {
        object temp = array[j];
        array[j] = array[j + 1];
        array[j + 1] = temp;
    }
}