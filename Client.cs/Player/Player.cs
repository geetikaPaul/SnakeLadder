using System;

namespace Entities.Player
{
    public enum PlayerStatus
    {
        WON, LOST, PLAYING
    }
    public class Player
    {
        public string Id { get; private set; }
        public Position position;
        public PlayerStatus status { get; private set; }

        public Player()
        {
            Id = Guid.NewGuid().ToString();
            position = new Position(0, 0);
            status = PlayerStatus.PLAYING;
        }

        public Player(int x, int y)
        {
            position = new Position(x, y);
            status = PlayerStatus.PLAYING;
        }

        public void UpdateStatus(PlayerStatus stat)
        {
            status = stat;
        }

    }
}
