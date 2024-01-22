using System.Collections;
using GenericsBasicExample;

Salaries salaries = new Salaries();

List<float> salariesList = salaries.GetSalaries();

float salary = (float)salariesList[1];

salary += salary * 0.02f;

Console.WriteLine(salary);