namespace Models;

using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
public class Developer {
[BsonId]
[BsonRepresentation(BsonType.ObjectId)]
 public string Id { get; set; }


[BsonElement("fisrtName")]
[MaxLength(20,ErrorMessage="FisrtName cannot be greater than 20"), MinLength(3,ErrorMessage="FisrtName cannot be less than 3")]
 public string FisrtName { get; set; }


[BsonElement("lastName")]
[MaxLength(30,ErrorMessage="LastName cannot be greater than 20"), MinLength(3,ErrorMessage="LastName cannot be less than 3")]
 public string LastName { get; set; }

[BsonElement("fullName")]
 public string FullName{ get{ return FisrtName +' '+ LastName;}}


[BsonElement("type")]  // JSON.Net
[BsonRepresentation(BsonType.String)] 
public DeveloperType Type { get; set; }


[BsonElement("hoursPay")]
[Range(13, int.MaxValue, ErrorMessage = "Please enter a value bigger than {13}")]
public int HoursPay { get; set; }


[BsonElement("salaryPerHour")]
[Range(30, 50, ErrorMessage = "Please enter a value between {30} and {50}")]
public int SalaryPerHour { get; set; }

public float Salary{ get{ return SalaryPerHour * HoursPay;}}


[BsonElement("email")]
public string Email { get; set; }


[BsonElement("age")]
[Range(10, int.MaxValue, ErrorMessage = "Please enter a value bigger than {10}")]
public int Age { get; set; }
}

public enum DeveloperType
{
  [BsonRepresentation(BsonType.String)]
  Junior,
  [BsonRepresentation(BsonType.String)]
  Intermediate,
  [BsonRepresentation(BsonType.String)]
  Senior,
  [BsonRepresentation(BsonType.String)]
  Lead
}