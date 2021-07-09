using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NardBotCore.NardBotAI
{
    public class AIBot
    {
        public AIBot(Game game, Identity identity)
        {
            _game = game;
            _identity = identity;
            Mission = BotMission.FillHome;

            if(_identity == Identity.White)
                _game.WhiteMove += game_AIMove;
            else
                _game.BlackMove += game_AIMove;
        }

        private void game_AIMove(object sender, MoveEventArgs e)
        {

        }

        private Game _game;
        public Identity _identity; //close after debug
        public BotMission Mission; //close after debug
    }
}
