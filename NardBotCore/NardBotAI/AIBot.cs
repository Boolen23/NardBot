using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NardBotCore.NardBotAI
{
    public class AIBot : GameClient
    {
        public AIBot(Identity identity, Game game) : base(identity, game)
        {
            Mission = BotMission.FillHome;
        }
        public BotMission Mission; //TODO: close after debug
        public override void MoveStarted(object sender, MoveEventArgs e)
        {
            while (!e.move.IsEnd)
            {
                game.ExecuteCommand(new Command() { SourceFourth = StartCell.FourthNumber, SourceCellNumber = StartCell.CellNumber, MoveCount = e.move.Moves[0] });
            }
            //base.MoveStarted(sender, e);
        }
    }
}
