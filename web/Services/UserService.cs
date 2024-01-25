using System.Text.Json;
using Microsoft.AspNetCore.Components.Forms;
using web.Models;

namespace web.Services;

public class UserService
{
    private IEnumerable<User> users { get; set; }
    public IEnumerable<User> Users
    {
        get => users;
        set
        {
            var usersString = JsonSerializer.Serialize(value);
            File.WriteAllText(storageFile, usersString);
            users = value;
        }
    }
    private static string storageFile = "users.json";

    public UserService()
    {
        if (!File.Exists(storageFile))
            Users = [];
        else
        {
            var rawUsers = File.ReadAllText(storageFile);
            Users = JsonSerializer.Deserialize<IEnumerable<User>>(rawUsers);
        }
        Console.WriteLine("loaded users");
    }

    public async Task StoreFile(string userName, IBrowserFile file)
    {
        try
        {
            var trustedFileName = Path.GetRandomFileName();
            var path = Path.Combine("wwwroot/uploads",
                file.Name);

            await using FileStream fs = new(path, FileMode.Create);
            await file.OpenReadStream().CopyToAsync(fs);


            Console.WriteLine($"file saved: {file.Name}");

            // todo: store path on user object
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error - File: {file.Name} Error: {ex.Message}");
        }
    }
}