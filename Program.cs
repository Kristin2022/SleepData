// See https://aka.ms/new-console-template for more information
// See https://aka.ms/new-console-template for more information
// ask for input
using Microsoft.VisualBasic.FileIO;

internal class Program
{
    private static void Main(string[] args)
    {
        const string path = "data.txt";
        Console.WriteLine("Enter 1 to create data file.");
        Console.WriteLine("Enter 2 to parse data.");
        Console.WriteLine("Enter anything else to quit.");
        // input response
        string resp = Console.ReadLine();

        if (resp == "1")
        {
            // create data file

            // ask a question
            Console.WriteLine("How many weeks of data is needed?");
            // input the response (convert to int)
            int weeks = int.Parse(Console.ReadLine());
            // determine start and end date
            DateTime today = DateTime.Now;
            // we want full weeks sunday - saturday
            DateTime dataEndDate = today.AddDays(-(int)today.DayOfWeek);
            // subtract # of weeks from endDate to get startDate
            DateTime dataDate = dataEndDate.AddDays(-(weeks * 7));
            // random number generator
            Random rnd = new Random();
            // create file
            StreamWriter sw = new StreamWriter(path);

            // loop for the desired # of weeks
            while (dataDate < dataEndDate)
            {
                // 7 days in a week
                int[] hours = new int[7];
                for (int i = 0; i < hours.Length; i++)
                {
                    // generate random number of hours slept between 4-12 (inclusive)
                    hours[i] = rnd.Next(4, 13);
                }
                //M/d/yyyy,#|#|#|#|#|#|#
                Console.WriteLine($"{dataDate:M/d/yy},{string.Join("|", hours)}");
                sw.WriteLine($"{dataDate:M/d/yyyy},{string.Join("|", hours)}");
                // add 1 week to date


                // TODO: parse data file
                //Console.WriteLine("Weekly Report");
                // sw.WriteLine($"Week of {dataDate:MMM,dd,yyy},\n {dataDate:dd}, \n{string.Format("--")}");
                // sw.WriteLine($"{dataDate:d}");
                dataDate = dataDate.AddDays(7);
            }
            sw.Close();
        }
        else if (resp == "2")
        { 
            StreamReader streamReader = new StreamReader(path);
            while(!streamReader.EndOfStream){
                string line = streamReader.ReadLine();
                string[] arr = line.Split(',');
                DateTime d = DateTime.Parse(arr[0]);
                Console.WriteLine($"Week of {d:MMM, dd, yyyy}");
                Console.WriteLine("{0,3}{1,3}{2,3}{3,3}{4,3}{5,3}{6,3}", "Su", "Mo", "Tu", "We", "Th", "Fr", "Sa");
                Console.WriteLine("{0,3}{1,3}{2,3}{3,3}{4,3}{5,3}{6,3}", "--", "--", "--", "--", "--", "--", "--");
                string[] data = arr[1].Split('|');
                Console.WriteLine("{0,3}{1,3}{2,3}{3,3}{4,3}{5,3}{6,3}", data[0], data[1], data[2], data[3], data[4], data[5], data[6]);
                Console.WriteLine();
            }
        }
    }
}
/*const string path = "TextFile//data.txt";
StreamReader streamReader = new StreamReader(path);
string line = streamReader.ReadLine();
while (line != null)
{
  // Split the line into date and hours
  string[] parts = line.Split(',');
  string date = parts[0];
  string[] hours = parts[1].Split('|');

  // Calculate total and average hours
  int totalHours = 0;
  foreach (string hour in hours)
  {
      totalHours += int.Parse(hour);
  }
  double avgHours = (double)totalHours / hours.Length;

  // Display weekly report
  Console.WriteLine($"Week of {date}");
  Console.WriteLine(" Su Mo Tu We Th Fr Sa Tot Avg");
  Console.WriteLine(" -- -- -- -- -- -- -- --- ---");
  Console.WriteLine($" {string.Join(" ", hours)} {totalHours} {avgHours:F1}");

  line = streamReader.ReadLine();
}*/




/*const string path = "TextFile//data.txt";

StreamReader streamReader= new StreamReader(path);

string line = streamReader.ReadLine();

while (line != null){
    Console.WriteLine($"Week of {0:MMMM} {0:dd} {0:yyyy}");
    line = streamReader.ReadLine();
    Console.WriteLine(line);
    line = streamReader.ReadLine();

} 
*/


/*if(File.Exists(" ")){
    // StreamReader sr = new StreamReader(File.txt(" "));
    // while(sr.Read() != 0){
    //     string line = sr.ReadLine();
    //     string DayOfWeek = new string((""));
    //     Console.WriteLine($"Week of {0:MMMM} {0:dd} {0:yyyy}");
    //     Console.WriteLine(line);
    //     Console.WriteLine($"=, =25:d)={line,10}");
    //     Console.WriteLine($"[{DateTime.FromFileTime, -20:d}]");
    //     Console.WriteLine($"[{0:d}]");
    //     Console.WriteLine($"");
    // }*/



