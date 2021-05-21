using Entities.Elements;
using System.Collections.Generic;

namespace Entities.Games
{
    public abstract class IGame
    {
        public int rows { get; protected set; }
        public int cols { get; protected set; }
        public GameStatus status { get; protected set; }
        public Dictionary<string, Structure> structures { get; protected set; }
        public abstract void GenerateBoard();
        public void UpdateStatus(GameStatus stat)
        {
            status = stat;
        }

        public void SetStructures(Dictionary<string, Structure> s)
        {
            if(structures==null || structures.Count==0)
                structures = s;
            else
            {
                foreach (var ss in s)
                    if(!structures.ContainsKey(ss.Key))
                        structures.Add(ss.Key, ss.Value);
            }
        }
    }
}
