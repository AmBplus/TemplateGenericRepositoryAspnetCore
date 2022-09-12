namespace domain.UserAgg;

public class Role : BaseClass<long>
{
    public Role()
    {
        Users = new List<User>();
    }
    public string Name { get; set; }
    public IList<User> Users { get; set; }
}