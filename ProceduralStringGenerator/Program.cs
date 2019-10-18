using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unleash_the_giraffe
{
    class Program
    {
        static void Main(string[] args)
        {

            //Here's an example of a small story:
            var psg = new ProceduralStringGenerator(" ");

            //Name generation example
            psg.AddPart("_NAME_", "_NAMEPART1__NAMEPART2_");
            psg.AddPart("_NAMEPART1_", "an", "go", "mo", "fi", "_NAMEPART2_");
            psg.AddPart("_NAMEPART2_", "na", "ona", "hu", "blop", "rgh");

            //Sentence generation example
            psg.AddPart("_ACTION_", "walked", "strode", "flew", "fell");
            psg.AddPart("_PLACE_", "the _COLOR_ store", "a _COLOR_ dungeon", "some place", "the stairs");

            //Reference item
            psg.AddPart("_COLOR_", "yellow", "white", "black", "red", "green", "blue");

            //Randomize whatever story or name we want to make.
            //This generator will generate two sentence, both randomizing with the content set on each line.
            psg.SetStructure("_NAME_ the hero.", "_NAME_ the _COLOR_.", "_NAME_ _ACTION_ towards the _PLACE_.");
            psg.SetStructure("They like _COLOR_.", "Once, they visited _PLACE_.", "");

            //You can / should refer to a json to your load data instead of doing it manually, like this:
            //var psg = Json.LoadExternal<ProceduralStringGenerator>("data.json");

            for (int i = 0; i < 25; i++)
            {
                Console.WriteLine(psg.Get());
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
