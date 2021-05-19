using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Player
{
    public enum PlayerStatus
    {
        WON, LOST, PLAYING
    }
    public class Player
    {
        public Position position;
        public PlayerStatus status { get; private set; }

        public Player()
        {
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
