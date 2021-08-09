using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NardBotCore
{
    public class GameClient
    {
        public GameClient(Game game, Identity identity)
        {
            this.game = game;
            if (identity == Identity.White)
                this.game.WhiteMove += MoveStarted;
            else
                this.game.BlackMove += MoveStarted;

            this.ClientIdentity = identity;
        }
        private Game game;
        protected virtual void MoveStarted(object sender, MoveEventArgs e) => ClientMoveStarted?.Invoke(this, e);
        
        public event EventHandler<MoveEventArgs> ClientMoveStarted;

        public Identity ClientIdentity { get; private set; }

    }
}
