using System.ComponentModel.DataAnnotations;
using DataBase;
using Models;
var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var conectionDB = new DataBaseDeveloper();
var developerDB = conectionDB.ConectionDB();

app.MapGet("/api/developers", () =>
{   
    return Results.Ok(conectionDB.DeveloperList(developerDB));
});

app.MapPost("/api/developers", (Developer developer) =>
{   
    var result = conectionDB.InsertInDB(developerDB, developer.FisrtName, developer.LastName, developer.Type, developer.HoursPay, developer.SalaryPerHour, developer.Age, developer.Email);
    if(result){
        return Results.Ok(result);
    }
    return Results.Problem();
});

app.MapGet("/api/developers/email/{email}",  async(string email) => {
        {
            var category = await conectionDB.GetByEmail(developerDB,email);
            if (category == null)
            {
                return Results.Ok(null);
            }
            return Results.Ok(category);
        }
});

app.MapGet("/api/developers/fistname/{fistname}",  async (string fistname)=> {
        {
            var category = await conectionDB.GetByFisrtName(developerDB,fistname);
            if (category == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(category);
        }
});

app.MapGet("/api/developers/lastname/{lastname}",async (string lastname)=> {
        {
            var category = await conectionDB.GetBylastname(developerDB,lastname);
            if (category == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(category);
        }
});

app.MapGet("/api/developers/age/{age}", async (int age)=> {
        {
            var category = await conectionDB.GetByAge(developerDB, age);
            if (category == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(category);
        }
});

app.MapGet("/api/developers/hoursPay/{hoursPay}", async (int  hoursPay)=> {
        {
            var category = await conectionDB.GetByHoursPay(developerDB,hoursPay);
            if (category == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(category);
        }
});


app.MapPut("/api/developers/{id}",async (string id, Developer developer)=> {
        {
            var category = await conectionDB.GetById(developerDB,id);
            if (category == null)
                return Results.NotFound();
            developer.Id = id;
            await conectionDB.UpdateAsync(developerDB,id,developer);
            return Results.Ok("done");
        }
});

app.MapDelete("/api/developers/{email}", async (string email)=> {
        {
            var category = await conectionDB.GetByEmail(developerDB,email);
            if (category == null)
                return Results.NotFound();
            await conectionDB.DeletByEmail(developerDB,email);
            return Results.Ok("deleted successfully");
        }
});

app.Run();

