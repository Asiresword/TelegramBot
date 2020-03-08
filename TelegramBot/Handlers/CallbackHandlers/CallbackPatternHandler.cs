using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml;

namespace TelegramBot.Handlers.CallbackHandlers
{
    public static class CallbackPatternHandler
    {
        public static async Task<string> GetPattern(string Name)
        {
            try
            {
                XmlDocument Patterns = new XmlDocument();
                string PatternString;
                Patterns.Load("../../../XmlFiles/patterns.xml");

                XmlNode XmlPattern = Patterns.SelectSingleNode($"/patterns/pattern[@name='{Name}']");

                PatternString = $"{Name}: {XmlPattern.SelectSingleNode("description").InnerText}\n";
                PatternString += $"\tDifficulty: {XmlPattern.SelectSingleNode("difficulty").InnerText}\n";
                PatternString += $"\tPopularity: {XmlPattern.SelectSingleNode("popularity").InnerText}\n";
                PatternString += $"\tWhen to use:\n";
                foreach (XmlNode node in XmlPattern.SelectSingleNode("usability").ChildNodes)
                {
                    PatternString += $"\t{node.InnerText}\n";
                }

                return PatternString;
            }
            catch
            {
                return "An error has occured, try again later.";
            }
        }
    }
}
