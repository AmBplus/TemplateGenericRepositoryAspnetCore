namespace Models;

public class Resevation
{
    public User MadyBy { get; set; }

    public bool CanBeCancelledBy(User user)
    {
        if (user.IsAdmin) return true;
        if (user == MadyBy) return true;
        return false;
    }
}