using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;

namespace DAL.Repository
{
    class RedisRepository
    {
        ServiceStack.Redis.RedisClient client;
        public RedisRepository()
        {
            client = new RedisClient("localhost", 6379);
        }
        public List<string> GetFollowing(string key)
        {
            List<string> following = Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(client.Get<string>(key));
            return following;
        }

        public bool SetFollowing(string key, List<string> following, int ttl)
        {
            string foll = Newtonsoft.Json.JsonConvert.SerializeObject(following);
            return client.Add<string>(key, foll);
        }
        public bool IsInDataBase(string key)
        {
            return client.Exists(key) != 0 ? true : false;
        }
    }
}
