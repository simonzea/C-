using MongoDB.Driver;
using System;
using System.Collections.Generic;
using Models;
using System.Linq;

namespace MongoDb.Models;

class Program
{
    static void Main()
    {

    IMongoCollection<Developer> ConectionDB() {
        var client = new MongoClient("mongodb://localhost:27017");
        var database = client.GetDatabase("CNetTest");
        return database.GetCollection<Developer>("developers");
    }

    void InsertInDB(IMongoCollection<Developer> developerDB, string name, string type, int hoursPay, int salaryPerHour) {
        var developer = new Developer () { Name = name, Type = type, HoursPay = hoursPay, SalaryPerHour = salaryPerHour};
        developerDB.InsertOne(developer);
    }

    void PrintAtributes(Developer developer) {
        Console.WriteLine("Dev Name: {0} ", developer.Name);
        Console.WriteLine("Dev Type: {0} ", developer.Type);
        Console.WriteLine("Worked Hours: {0} ", developer.HoursPay);
        Console.WriteLine("SalaryByHour: {0} USD\n", developer.SalaryPerHour);
    }

    void PrintResume(float totalSalary, int totalhours, int totalDevs) {
        Console.WriteLine("Resume:\nTotal Salary: {0} USD", totalSalary);
        Console.WriteLine("Total Hours: {0} ", totalhours);
        Console.WriteLine("Total Devs: {0}\n", totalDevs);
    }

    float SalaryRule(DeveloperType type) {
         switch (type) {
        case DeveloperType.Intermediate:
            return (float)1.12;
        case DeveloperType.Senior:
            return (float)1.25;
        case DeveloperType.Lead:
            return (float)1.5;
        default:
            return (float)1;
    };
    }

    void ShowResume(List<Developer> developerList) {
        float totalSalary = 0;
        int totalhours = 0;
        int totalDevs = 0;

        developerList.ForEach( developer => {
            totalDevs += 1;
            totalhours += developer.HoursPay;
            totalSalary += (developer.SalaryPerHour * developer.HoursPay) * SalaryRule(developer.Type);
            PrintAtributes(developer);
        });
        
        PrintResume(totalSalary, totalhours, totalDevs);
    }

     var developerDB = ConectionDB();
   // InsertInDB(developerDB, "Andres", "Junior", 10, 100);
   // InsertInDB(developerDB, "Simon", "Senior", 10, 140);
   // InsertInDB(developerDB, "Alejandra", "Intermediate", 10, 120);
   // InsertInDB(developerDB, "Melissa", "Lead", 10, 160);
    List<Developer> developerList = developerDB.Find(d => true).ToList();
    ShowResume(developerList);

    }
}