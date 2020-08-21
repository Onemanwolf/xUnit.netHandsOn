using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace GameEngine
{
    public interface IPlayerCharacter
    {
        string FirstName { get; set; }
        string FullName { get; }
        int Health { get; set; }
        bool IsNoob { get; set; }
        string LastName { get; set; }
        string Nickname { get; set; }
        List<string> Weapons { get; set; }

        event EventHandler<EventArgs> PlayerSlept;
        event PropertyChangedEventHandler PropertyChanged;

        void Sleep();
        void TakeDamage(int damage);
    }
}