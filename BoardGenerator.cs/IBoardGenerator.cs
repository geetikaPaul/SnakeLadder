using Entities.Games;

namespace BoardGenerator
{
    public interface IBoardGenerator
    {
        IGame generateBoard();
    }
}
