using System.Text.Json;
using web.Models;

namespace web.Services;

public class UserService
{
    private IEnumerable<User> users { get; set; }
    public IEnumerable<User> Users {
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
}