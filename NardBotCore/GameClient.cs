using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NardBotCore
{
    public class GameClient
    {
        public GameClient(Identity identity)
        {
            this.ClientIdentity = identity;
        }
        private Game game;

        public virtual void MoveStarted(object sender, MoveEventArgs e) => ClientMoveStarted?.Invoke(this, e);
        
        public event EventHandler<MoveEventArgs> ClientMoveStarted;

        public Identity ClientIdentity { get; private set; }

    }
}
