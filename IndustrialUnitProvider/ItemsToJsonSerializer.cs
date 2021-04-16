using Newtonsoft.Json;
using System.IO;

namespace IndustrialUnitProvider
{
  internal class ItemsToJsonSerializer
  {
    internal void BuildJson(Items IndustrialUnits)
    {
      var serializer = new JsonSerializer
      {
        Formatting = Formatting.Indented
      };

      using (StreamWriter sw = new StreamWriter(Helper.ProjectPath(@"IndustrialUnitJsonToDatabase.json")))
      {
        using (JsonWriter writer = new JsonTextWriter(sw))
        {
          serializer.Serialize(writer, IndustrialUnits);
        }
      }
    }
  }
}
