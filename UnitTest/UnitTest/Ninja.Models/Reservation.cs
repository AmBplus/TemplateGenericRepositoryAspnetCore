namespace Ninja.Models;

public class Reservation
{
    public User MadyBy { get; set; }

    public bool CanBeCancelledBy(User user)
    {
        return (user.IsAdmin || user == MadyBy);
        //if (user.IsAdmin) return true;
        //if (user == MadyBy) return true;
        //return false;
    }
}