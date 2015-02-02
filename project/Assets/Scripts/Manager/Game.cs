using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace Manager
{
    /// <summary>
    /// Global Game Manager.
    /// </summary>
    public class Game : Utils.Singleton<Game>
    {
        /// <summary>
        /// Number of players for current game sesion.
        /// </summary>
        private int m_numberOfPlayers;


        public Game()
        {
            m_numberOfPlayers = -1;
        }

        /// <summary>
        /// Sets the number of players for party configuration purposes.
        /// </summary>
        /// <param name="numberOfPlayers">Number of players</param>
        public void SetNumberOfPlayers(int numberOfPlayers)
        {
            m_numberOfPlayers = numberOfPlayers;
        }

        /// <summary>
        /// Gets the number of players selected.
        /// </summary>
        /// <returns>Number of players selected, 0 if not set</returns>
        public int GetNumberOfPlayers()
        {
            return m_numberOfPlayers;
        }
    }
}
