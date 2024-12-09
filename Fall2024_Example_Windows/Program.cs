
List<string> patients = new List<string>();
bool isContinue = true;
Console.WriteLine("Select an option");
Console.WriteLine("A. Add a Patient");
Console.WriteLine("Q. Quit");
do{
string input = Console.ReadLine() ?? string.Empty;



   if(char.TryParse(input, out char choice))
   {
    switch(choice)
        {
        case 'a':
        case 'A':
            patients.Add(Console.ReadLine() ?? string.Empty);
            break;  
        case 'q':
        case 'Q':
            isContinue = false;
            break;
        default:
            Console.WriteLine("That is an invalid choice!");
            break;
        }
    }
    else 
    {
        Console.WriteLine(choice + " is not a char");
    }
}while (isContinue);
foreach(var patient in patients)
{
    Console.WriteLine($"{patient}");
}
patients.Where(x => x.Contains("John")).ToList().ForEach(Console.WriteLine);