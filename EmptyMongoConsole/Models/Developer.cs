namespace Models;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
public class Developer {
[BsonId]
[BsonRepresentation(BsonType.ObjectId)]
 public string Id { get; set; }


[BsonElement("nombre")]
 public string Name { get; set; }
[BsonElement("type")]
public DeveloperType Type { get; set; }

[BsonElement("hoursPay")]
public int HoursPay { get; set; }

[BsonElement("salaryPerHour")]
public int SalaryPerHour { get; set; }

public float Salary{ get{ return SalaryPerHour * HoursPay;}}
}

public enum DeveloperType
{
  Junior,
  Intermediate,
  Senior,
  Lead
}