using System.Collections.Generic;
using System.IO;
using Interview.Infrastructure.Contracts;
using Newtonsoft.Json;

namespace Interview.Infrastructure.Services
{
    public class JsonOperationService : IJsonOperationService
    {
        private readonly Configuration _configuration;
        public JsonOperationService()
        {
            _configuration = new Configuration();
        }
        public IEnumerable<T> LoadJsonFile<T>()
        {
            using (var streamReader = new StreamReader(_configuration.Path))
            {
                var jsonString = streamReader.ReadToEnd();
                return JsonConvert.DeserializeObject<IEnumerable<T>>(jsonString);
            }
        }

        public void UpdateJsonFile<T>(List<T> items)
        {
            var jsonObjects = JsonConvert.SerializeObject(items);
            SaveToJson(jsonObjects);
        }

        private void SaveToJson(string json)
        {
            using (var streamWriter = new StreamWriter(_configuration.Path))
            {
                streamWriter.Write(json);
            }
        }
    }
}