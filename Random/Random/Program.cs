// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

   List<int> list = new List<int>();

    var rand = new Random();
    int random;

    for (int ctr = 0; ctr <= 1001; ctr++)
    {
       random = rand.Next(101);
       list.Add(random);
       //Console.WriteLine(random);
    }
    
    
    double average = list.Average();
    Console.WriteLine(average);
    
    IEnumerable<int> kleinerAverage = list.Where (x => x < average);

    Console.WriteLine(kleinerAverage.Count());


//Studenten-Aufgabe

string SearchStudent(Dictionary<string, string[]> studentInClass, string student)
{
    return studentInClass.FirstOrDefault(kvp => kvp.Value.Contains(student)).Key;
}
   
Dictionary<string, string[]> studentInClassUebergabe = new Dictionary<string, string[]>();

string room1 = "Wohnzimmer";
string room2 = "Schlafzimmer";

string student1 = "Student1";
string student2 = "Student2";
string student3 = "Student3";

string[] schlafzimmerstds = new string[5];
string[] wohnzimmerstds = new string[4];

schlafzimmerstds[0] = student1;
schlafzimmerstds[1] = student2;
wohnzimmerstds[0] = student3;

studentInClassUebergabe.Add(room1, wohnzimmerstds);
studentInClassUebergabe.Add(room2, schlafzimmerstds);

Console.WriteLine(SearchStudent(studentInClassUebergabe, student3));