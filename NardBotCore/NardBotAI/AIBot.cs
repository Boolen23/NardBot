using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NardBotCore.NardBotAI
{
    public class AIBot : GameClient
    {
        public AIBot(Game game, Identity identity) : base(game, identity)
        {
            Mission = BotMission.FillHome;
        }
        public BotMission Mission; //close after debug
        protected override void MoveStarted(object sender, MoveEventArgs e)
        {
            //base.MoveStarted(sender, e);
        }
    }
}
