

using System.Collections;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public class Exercise1
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    private List<int> _arrayInt;
    public Exercise1(string name, int age, string email)
    {
        this.Name = name;
        this.Age = age;
        this.Email = email;
        this._arrayInt  = new List<int>();
    }
    
 
 public void PrintAtributes() {
        Console.WriteLine("Name: {0} ", Name);
        Console.WriteLine("Age: {0} ", Age);
        Console.WriteLine("Email: {0} ", Email);
 }


/*------------------------------------------------------------------------------------------------------*/
 public void Sum() {
        GetNNumbers();
        Console.WriteLine(SetIteral(_arrayInt));
 }
private string SetIteral(List<int> arrayList) {
    int sum = 0;
    string sumInString = string.Empty;
    for (int i = 0; i < arrayList.Count; i++)
        {
            sum += arrayList[i];

            if (i==0){
            sumInString = arrayList[i].ToString();
            } else {
            sumInString +=  " + "+ arrayList[i].ToString();
            }
        }
    
    return sumInString + " = " + sum.ToString();
 
 }
 private void GetNNumbers() {
    bool isInt = true;
    Console.WriteLine("Enter the numbers: (it cancels if is not a number)");

    do
    {
        string input = Console.ReadLine();

        if (int.TryParse(input, out int inputInt))
        {
            _arrayInt.Add(inputInt);
        }
        else
        {
            isInt = false;
        }

    } while (isInt);
 }

 public string Sum2(params int[] list){
    int aux = 0;
    var stringToShow = string.Empty;

    foreach(int i in list){
        aux += i;
        stringToShow += " + "+ i.ToString();
    }

    return stringToShow += " = "+ aux;
 }

 /*------------------------------------------------------------------------------------------------------*/

private string CurrencyToWord(int number, string word)
{
    if (number / 1_000_000 != 0)
    {
        word = string.Concat(CurrencyToWord(number / 1_000_000, word), " million ");
        number %= 1_000_000;
    }

    if (number / 1_000 != 0)
    {
        word = string.Concat(CurrencyToWord(number / 1_000, word), " thousand ");
        number %= 1_000;
    }

    if (number / 100 != 0)
    {
        word = string.Concat(CurrencyToWord(number / 100, word), " hundred ");
        number %= 100;
    }

    word = NumberToWord(number, word);

    return word;
}

 private string NumberToWord(int number, string words)
{
    if (words != "") words += " ";
    var unitValues = new[]
    {
        "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve",
        "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"
    };
    var tensValues = new[]
        { "", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

    if (number >= 20)
    {
        words += tensValues[number / 10];
        if (number % 10 > 0) words += "-" + unitValues[number % 10];
    }
    else
        words += unitValues[number];

    return words;
}

public string CurrencyToWordGraterThan() {
    int minValue = 50000;
    int salary = Salary();

    if (minValue < salary){
        return CurrencyToWord(salary, string.Empty);
    } else {
        return "false";
    } 
}

private int Salary(){
    bool isInt = true;
    int inputInt;
    Console.WriteLine("Enter the salary of a developer: ");
    do
    {
        string input = Console.ReadLine();

        if (int.TryParse(input, out inputInt))
        {
            
            isInt = false;
        }
        else
        {
            Console.WriteLine("The value is no a number");
        }

    } while (isInt);
    return inputInt;
}
}
 /*------------------------------------------------------------------------------------------------------*/

public class Exercise2
{
    //generic
     public dynamic SalaryPerHour(dynamic salary, int hours) {
    return salary * hours;
 }

/* public T SalaryPerHour2<T> (ref T salary, int hours) {
    return salary * hours;
 }
*/
}

 /*------------------------------------------------------------------------------------------------------*/

public class Exercise3
{
public string StringLiterals (string v1, string v2, string v3, string v4) {
    return "Hello "+ v1+ " "+ v2+ " "+ v3+ " "+ v4;
}

public string StringInterpolation (string v1, string v2, string v3, string v4) {
    return $"Hello {v1} {v2} {v3} {v4}";
}

public string StringStringBuilder (string v1, string v2, string v3, string v4) {
    var sb = new System.Text.StringBuilder();

    sb.Append("Hello ");
    sb.Append(v1);
    sb.Append(" ");
    sb.Append(v2);
    sb.Append(" ");
    sb.Append(v3);
    sb.Append(" ");
    sb.Append(v4);

    return sb.ToString();
}

public string StringJoin (string v1, string v2, string v3, string v4) {
string[] words = { "Hello", v1,v2,v3,v4 };
return string.Join(" ", words);
}

public string StringAgregate (string v1, string v2, string v3, string v4) {
    string[] words = { "Hello", v1,v2,v3,v4 };
    return words.Aggregate((partialPhrase, word) =>$"{partialPhrase} {word}");

}


[Benchmark]
public string StringLiterals() => StringLiterals("Simon", "Pedro", "Lucas", "Juan");

[Benchmark]
public string StringInterpolation() => StringInterpolation("Simon", "Pedro", "Lucas", "Juan");

[Benchmark]
public string StringStringBuilder() => StringStringBuilder("Simon", "Pedro", "Lucas", "Juan");

[Benchmark]
public string StringJoin() => StringJoin("Simon", "Pedro", "Lucas", "Juan");

[Benchmark]
public string StringAgregate() => StringAgregate("Simon", "Pedro", "Lucas", "Juan");

}

 /*------------------------------------------------------------------------------------------------------*/

public class Exercise4
{

private Queue<string> _listOfNames = new Queue<string>();
private Stack<string> _stackOfNames = new Stack<string>();
private void GetNames() {
    bool isInt = true;
    Console.WriteLine("Enter the names: (it cancels if you type 'e')");

    do
    {
            string input = Console.ReadLine();
            if (input != "e")
            {
                this._listOfNames.Enqueue(input);
                this._stackOfNames.Push(input);
            }
            else
            {
                isInt = false;
            }

    } while (isInt);
 }

private void ShowNextName(Queue<string> _listOfNames){

while (_listOfNames.Count > 0)
        {
        var val = _listOfNames.Dequeue();
        Console.WriteLine(val);
        };
}

private void ShowRevertName(Stack<string> _listOfNames){

while (_listOfNames.Count > 0)
        {
        string val = _listOfNames.Pop();
        Console.WriteLine(val);
        };
}

public void RemoveNames(){
    GetNames();
    ShowNextName(_listOfNames);
    ShowRevertName(_stackOfNames);
    RemoveList();
}

public void RemoveList(){
    _listOfNames.Clear();
    _stackOfNames.Clear();
}


}

public class Exercise5
{

}

class Program
{
    static void Main()
    {
        //exercise 1
        Exercise1 exercise1 = new Exercise1("Leopold", 6, "test@test.com");
       // exercise1.PrintAtributes();
         //exercise1.sum();
        // 2,4,5,8,10
        //Console.WriteLine(exercise1.sum2());
        //Console.WriteLine(exercise1.CurrencyToWordGraterThan());



        // exercise 2
       // Exercise2 exercise2 = new Exercise2();
       // Console.WriteLine(exercise2.salaryPerHour((decimal) 34.56, 2).ToString());
        //Console.WriteLine(exercise2.salaryPerHour("45", 22).ToString());
        //Console.WriteLine(exercise2.salaryPerHour((float)2234234234, 2).ToString());
        //Console.WriteLine(exercise2.salaryPerHour((double)234234.56435, 2).ToString());



        // exercise 3
        Exercise3 exercise3 = new Exercise3();

       // var summary = BenchmarkRunner.Run(typeof(Program).Assembly);

        //dotnet run --configuration Release -- --help



        // exercise 4
        Exercise4 exercise4 = new Exercise4();
        exercise4.RemoveNames();



        // exercise 5
        Exercise5 exercise5 = new Exercise5();
    }
}
