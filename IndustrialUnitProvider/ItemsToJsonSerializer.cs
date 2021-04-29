using Newtonsoft.Json;
using System.IO;

namespace IndustrialUnitProvider
{
  internal class ItemsToJsonSerializer
  {
    internal void BuildJson<T>(T IndustrialUnits, string name)
    {
      var serializer = new JsonSerializer
      {
        Formatting = Formatting.Indented
      };

      string path = Helper.ExcelToJsonPath($"{name}UnitToDatabase.json");

      using (StreamWriter sw = new StreamWriter(path))
      {
        using (JsonWriter writer = new JsonTextWriter(sw))
        {
          serializer.Serialize(writer, IndustrialUnits);
        }
      }
    }
  }
}
