using Core;

namespace Infrastructure;

public class MongoDbSettings : IMongoDbSettings
{
    public string DatabaseName { get; set; } = String.Empty;
    public string ConnectionString { get; set; } = String.Empty;
}
