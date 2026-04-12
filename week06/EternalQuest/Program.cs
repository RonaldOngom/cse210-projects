/*
CREATIVITY:
This program exceeds requirements by adding a leveling system.
The user levels up every 1000 points and receives a celebratory message,
which increases motivation and gamification beyond the base requirements.
*/

class Program
{
    static void Main()
    {
        GoalManager manager = new();
        manager.Start();
    }
}