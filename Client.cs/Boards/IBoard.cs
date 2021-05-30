using Entities.Elements;
using System.Collections.Generic;

namespace Entities.Boards
{
    public abstract class IBoard
    {
        public int rows { get; protected set; }
        public int cols { get; protected set; }

        //ideally structures should be property of the BasicBoard since it's decoration for a board
        public Dictionary<string, Structure> structures { get; protected set; }
        public abstract void GenerateBoard();

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
