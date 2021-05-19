using Entities.Player;

namespace Snake_Ladder
{
    public abstract class Machine
    {
        public abstract void Actions(int numberOfSteps, Player player);
        public abstract void MoveThePawn(int numberOfSteps, Player player);
        public abstract void UpdateStatus(Player player);
        public abstract void MoveAlongTheStructure(Player player);
    }
}
