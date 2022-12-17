using StackExchange.Redis;
using System.Collections.Generic;
using System.Linq;

namespace Services.Basket.Services
{
    public class RedisService
    {
        private readonly string _host;
        private readonly int _port;
        private ConnectionMultiplexer _connectionMultiplexer;

        public RedisService(string host, int port)
        {
            _host = host;
            _port = port;
        }

        public void Connect() => _connectionMultiplexer = ConnectionMultiplexer.Connect($"{_host}:{_port}");
        public IDatabase GetDatabase(int db = 1) => _connectionMultiplexer.GetDatabase(db);
        public List<RedisKey> GetKeys() => _connectionMultiplexer.GetServer($"{_host}:{_port}").Keys(1).ToList();
    }
}