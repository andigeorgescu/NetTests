using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rps
{
    public class Game
    {
        private Dictionary<Tool, List<Tool>> whoBeats;

        public Game()
        {
            whoBeats = new Dictionary<Tool, List<Tool>>();
            whoBeats.Add(Tool.Scissors, new List<Tool> {Tool.Rock});
            whoBeats.Add(Tool.Paper, new List<Tool>{Tool.Ac,Tool.Scissors});
            whoBeats.Add(Tool.Rock, new List<Tool> { Tool.Paper });
            whoBeats.Add(Tool.Ac, new List<Tool> { Tool.Rock });
        }

        public ResultType Challange(Tool playerOneTool, Tool playerTwoTool)
        {
            if (playerOneTool == playerTwoTool)
                return ResultType.Draw;


            if(SecondToolBeatsFirstTool(playerOneTool, playerTwoTool))
                return ResultType.PlayerTwo;
         
            if(SecondToolBeatsFirstTool(playerTwoTool, playerOneTool))
                return ResultType.PlayerOne;


            throw new NotImplementedException();
        }

        private bool SecondToolBeatsFirstTool(Tool playerTool1, Tool playerTool2)
        {
            var whoBeatsPlayerOne = whoBeats[playerTool1];

            return whoBeatsPlayerOne.Contains(playerTool2);
        }

        public Tool Tools { get; set; }
    }
}
