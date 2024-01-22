using GenericBubbleSort;

object[] numbersArray = new object[] { 1, 4, 7, 3, 9, 5, 0 };
string[] stringsArray = new string[] { "Mahmoud", "Ali", "Ahmed", "Mohammed", "Hasan"};
SortArray sortArray = new SortArray();
sortArray.BubbleSort(numbersArray);
sortArray.BubbleSort(stringsArray);

GenericSortArray<string> genericSortArray = new GenericSortArray<string>();
genericSortArray.BubbleSort(stringsArray);