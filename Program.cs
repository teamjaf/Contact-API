using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// app.UseStaticFiles();

app.MapGet("/", () => "Hello World!");
app.MapGet("/contacts",() =>{

    var contacts = JsonSerializer
        .Deserialize<IEnumerable<Contact>>(
            File.OpenRead("wwwroot/contacts.json")
         
        );
        return Results.Ok(contacts);

});

app.Run();


public class Contact{
    public string Name { get; set; }
    public string City { get; set; }
}