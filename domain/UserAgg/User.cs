namespace domain.UserAgg;

public class User : BaseClass<long>
{
    public User()
    {
        Role = new Role();
    }
    public string Name { get; set; }
    public string FullName { get; set; }
    public Role Role { get; set; }
    public long RoleId { get; set; }
  
}