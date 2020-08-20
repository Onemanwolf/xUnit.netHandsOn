using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace GameEngine
{
    public partial class Portal : IPortal
    {
      
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public bool IsActive { get; set; }
        public bool DestinationReached { get; set; }

        public PlayerCharacter _player;

        public Portal(string from, string to, PlayerCharacter player)
        {
            ToLocation =  to;
            FromLocation = from;
            _player = player;
        }

        public void Transport()
        {
                IsActive = true;
                
                

                //code to Update world Instance moving player to new world instance

             
             
            this.DestinationReached = true;

           
            
                
        }


    }
}
