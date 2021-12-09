using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NardBotCore
{
    public class GameClient
    {
        public GameClient(Identity identity, Game game)
        {
            this.ClientIdentity = identity;
            this.game = game;   
        }
        protected Game game { get; }
        public Cell StartCell { get; set; }  
        public virtual void MoveStarted(object sender, MoveEventArgs e) => ClientMoveStarted?.Invoke(this, e);
        
        public event EventHandler<MoveEventArgs> ClientMoveStarted;

        public Identity ClientIdentity { get; private set; }
        public bool IsHuman { get; set; }

    }
}
