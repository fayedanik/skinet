using MongoDB.Bson.Serialization.Attributes;

namespace Core;

[BsonIgnoreExtraElements(Inherited = true)]
public class EntityBase
{
    [BsonId]
    public string ItemId { get; set; }
    public virtual string CreatedBy { get; set; }
    public virtual DateTime CreateDate { get; set; }
    public string[] Tags { get; set; }
    public string Language { get; set; }
    public DateTime LastUpdateDate { get; set; } 
    public string LastUpdatedBy { get; set; }

}
