using System.Text;
using System.Linq;
using System.Diagnostics;

namespace PointsBet_Backend_Online_Code_Test
{

    /*
    Improve a block of code as you see fit in C#.
    You may make any improvements you see fit, for example:
      - Cleaning up code
      - Removing redundancy
      - Refactoring / simplifying
      - Fixing typos
      - Any other light-weight optimisation
    */
    public class StringFormatter
    {
        public static void formatString()
        {
            //string[] stringArray = { "Apple", "Banana", "Peach", "Apricot", "Grapes", "Cherry", "Mango", "Blueberry", "Strawberry", "Dragonfruit", "Tomatto"};
            string[] stringArray = { "The", "Sydney", "Opera", "House", "is", "a", "globally", "recognized", "masterpiece", "of", "modern", "architecture", "featuring", "its", "signature", "saillike", "shell", "structures", "Located", "on", "Sydney", "Harbour", "it", "was", "designed", "by", "Jørn", "Utzon", "and", "opened", "in", "1973", "This", "performing", "arts", "center", "houses", "multiple", "venues", "including", "concert", "halls", "and", "theaters", "Its", "design", "is", "based", "on", "spherical", "geometry", "and", "the", "white", "tiled", "roofs", "dramatically", "contrast", "with", "the", "blue", "harbor", "water", "The", "building", "is", "a", "UNESCO", "World", "Heritage", "site", "and", "serves", "as", "Australia's", "premier", "cultural", "icon", "attracting", "millions", "of", "visitors", "annually", "The", "Sydney", "Opera", "House", "is", "a", "globally", "recognized", "masterpiece", "of", "modern", "architecture", "featuring", "its", "signature", "saillike", "shell", "structures", "Located", "on", "Sydney", "Harbour", "it", "was", "designed", "by", "Jørn", "Utzon", "and", "opened", "in", "1973", "This", "performing", "arts", "center", "houses", "multiple", "venues", "including", "concert", "halls", "and", "theaters", "Its", "design", "is", "based", "on", "spherical", "geometry", "and", "the", "white", "tiled", "roofs", "dramatically", "contrast", "with", "the", "blue", "harbor", "water", "The", "building", "is", "a", "UNESCO", "World", "Heritage", "site", "and", "serves", "as", "Australia's", "premier", "cultural", "icon", "attracting", "millions", "of", "visitors", "annually" };
            //string[] stringArray = { "The" };

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            string css = ToCommaSeparatedString(stringArray, "'");
            Console.WriteLine(css);
            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;
            Console.WriteLine($"Time elapsed: {ts.TotalMilliseconds:F2} ms");

            stopwatch.Restart();

            string cssLinq = ToCommaSeparatedStringLinq(stringArray, "'");
            Console.WriteLine(cssLinq);
            stopwatch.Stop();
            ts = stopwatch.Elapsed;
            Console.WriteLine($"Time elapsed: {ts.TotalMilliseconds:F2} ms");

            stopwatch.Restart();

            string cssLinq = ToCommaSeparatedStringStringBuilder(stringArray, "'");
            Console.WriteLine(cssLinq);
            stopwatch.Stop();
            ts = stopwatch.Elapsed;
            Console.WriteLine($"Time elapsed: {ts.TotalMilliseconds:F2} ms");
            
        }

        // More efficient but little complicated
        public static string ToCommaSeparatedString(string[] items, string quote = "\"")
        {
            if (items.Length <= 1) return $"{quote}{items[0]}{quote}";
            if (items.Length <= 2) return $"{quote}{items[0]}{quote}, {quote}{items[1]}{quote}";
            return ToCommaSeparatedString(items[0..((items.Length + 1) / 2)], quote) + ", " + ToCommaSeparatedString(items[((items.Length + 1) / 2)..(items.Length)], quote);
        }
        
        // Clean and easy to follow 
        public static string ToCommaSeparatedStringLinq(string[] items, string quote="\"")
        {
            return string.Join(",", items.Select(item=> $"{quote}{item}{quote}"));
        }

        // very fast
        public static string ToCommaSeparatedStringStringBuilder(string[] items, string quote="\"")
        {
            StringBuilder sb = new StringBuilder(items[0] ?? "");
            for (int i = 1; i < items.Length; i++)
            {
                // sb.Append($"{quote}{items[i]}{quote},");
                sb.Append(quote);
                sb.Append(items[i]);
                sb.Append(quote);
                sb.Append(",");
            }
            return sb.ToString();
        }
    }
}
