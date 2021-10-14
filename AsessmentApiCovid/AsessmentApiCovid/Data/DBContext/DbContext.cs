using AsessmentApiCovid.Data.DBSet;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsessmentApiCovid.Data.DBContext
{
    public class DbContext
    {

        
        public  DBSet<TEntity> Set<TEntity>(string JsonPath) where TEntity : class{

            var read = Read<TEntity>(JsonPath).Result;

            return read;
        }

        private async Task<DBSet<TEntity>> Read<TEntity>(string JsonPath)
        {
            

            var json = await ReadJson(JsonPath);

            var result = JsonConvert.DeserializeObject<DBSet<TEntity>>(json);

            return result;

        }

        private async Task<string> ReadJson(string path)
        {
            string json = await System.IO.File.ReadAllTextAsync(AppContext.BaseDirectory + "/Data/JsonData/" + path);

            return json;
        }
    }
}
