namespace BusinessModel.Users;

public abstract class User
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }

    public User (string name, string surname, string email)
    {
        this.Name = name;
        this.Surname = surname;
        this.Email = email;
    }
}
