using UnityEngine;
using System.Collections;

namespace Player
{
    /// <summary>
    /// Player Wrapper class stores all information related to a player
    /// </summary>
    public class Wrapper
    {
        /// <summary>
        /// Input mapping for this player
        /// </summary>
        private Input m_input;

        /// <summary>
        /// Stats for this player
        /// </summary>
        private Stats m_stats;


        public Wrapper()
        {
            m_input = null;
            m_stats = null;
        }

        /// <summary>
        /// Set player's input
        /// </summary>
        /// <param name="input">Input</param>
        public void SetInput(Input input)
        {
            m_input = input;
        }

        /// <summary>
        /// Get player's input 
        /// </summary>
        /// <returns>Player's input</returns>
        public Input GetInput()
        {
            return m_input;
        }

        /// <summary>
        /// Set player's stats
        /// </summary>
        /// <param name="stats">Stats</param>
        public void SetStats(Stats stats)
        {
            m_stats = stats;
        }

        /// <summary>
        /// Get player's stats
        /// </summary>
        /// <returns>Player's stats</returns>
        public Stats GetStats()
        {
            return m_stats;
        }
    }
}
