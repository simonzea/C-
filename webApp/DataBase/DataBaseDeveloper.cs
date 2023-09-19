namespace DataBase;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using Models;
using System.Linq;
public class DataBaseDeveloper
{
    public IMongoCollection<Developer> ConectionDB() {
        var client = new MongoClient("mongodb://localhost:27017");
        var database = client.GetDatabase("CNetTest");
        return database.GetCollection<Developer>("developers");
    }

     public  Boolean InsertInDB(IMongoCollection<Developer> developerDB, string fisrtName, string lastName, DeveloperType type, int hoursPay, int salaryPerHour, int age, string email) {
        try{
            var developer = new Developer () { FisrtName = fisrtName,LastName = lastName, Type = type, HoursPay = hoursPay, SalaryPerHour = salaryPerHour, Email= email, Age= age};
            developerDB.InsertOne(developer);
            return true;
        }
        catch (Exception e) {
            Console.WriteLine(e);
            return false;
        }
        
    }

    public List<Developer> DeveloperList(IMongoCollection<Developer> developerDB){
        return developerDB.Find(d => true).ToList();
    }

    public async Task<Developer> GetById(IMongoCollection<Developer> developerDB, string id) =>
            await developerDB.Find(a => a.Id == id).FirstOrDefaultAsync();
    public async Task<Developer> GetByEmail(IMongoCollection<Developer> developerDB, string email) =>
            await developerDB.Find(a => a.Email == email).FirstOrDefaultAsync();
    public async Task<List<Developer>> GetByFisrtName(IMongoCollection<Developer> developerDB, string firstname) =>
            await developerDB.Find(a => a.FisrtName == firstname).ToListAsync();

    public async Task<List<Developer>> GetBylastname(IMongoCollection<Developer> developerDB, string lastName) =>
            await developerDB.Find(a => a.LastName == lastName).ToListAsync();

    public async Task<List<Developer>> GetByAge(IMongoCollection<Developer> developerDB, int age) =>
            await developerDB.Find(a => a.Age == age).ToListAsync();     

    public async Task<List<Developer>> GetByHoursPay(IMongoCollection<Developer> developerDB, int hours) =>
            await developerDB.Find(a => a.HoursPay == hours).ToListAsync();         

    public async Task CreateAsync(IMongoCollection<Developer> developerDB,Developer developer) =>
            await developerDB.InsertOneAsync(developer);

    public async Task UpdateAsync(IMongoCollection<Developer> developerDB,string id,Developer developer) =>
            await developerDB.ReplaceOneAsync(a => a.Id == id, developer);

    public async Task DeletByEmail(IMongoCollection<Developer> developerDB, string email) =>
            await developerDB.DeleteOneAsync(a => a.Email == email);
}