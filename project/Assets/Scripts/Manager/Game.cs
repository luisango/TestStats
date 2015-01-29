using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Manager
{
    /// <summary>
    /// Global Game Manager
    /// </summary>
    public class Game : Utils.Singleton
    {
        Game()
        {
            Manager.Player.Instance();
            Manager.Minigame.Instance();
        }
    }
}
