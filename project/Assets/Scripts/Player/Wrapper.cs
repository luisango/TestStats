using UnityEngine;
using System.Collections;

namespace Player
{
    /// <summary>
    /// Player Wrapper class stores all information related to a player.
    /// </summary>
    [System.Serializable]
    public class Wrapper
    {
        /// <summary>
        /// Input mapping for this player.
        /// </summary>
        private Input m_input;

        /// <summary>
        /// Stats for this player.
        /// </summary>
        private Stats m_stats;

        /// <summary>
        /// Puppet for this player.
        /// </summary>
        private Puppet m_puppet;

        /// <summary>
        /// Nickname for this player.
        /// </summary>
        public string m_nickname;


        public Wrapper()
        {
            m_input    = null;
            m_stats    = new Stats();
            m_puppet   = null;

            // Automated player name by counting current players
            m_nickname = "Random player " + (Manager.Player.Instance.Get().Count + 1);
        }

        /// <summary>
        /// Set player's input.
        /// </summary>
        /// <param name="input">Input</param>
        public void SetInput(Input input)
        {
            m_input = input;
        }

        /// <summary>
        /// Get player's input.
        /// </summary>
        /// <returns>Player's input</returns>
        public Input GetInput()
        {
            return m_input;
        }

        /// <summary>
        /// Set player's stats.
        /// </summary>
        /// <param name="stats">Stats</param>
        public void SetStats(Stats stats)
        {
            m_stats = stats;
        }

        /// <summary>
        /// Get player's stats.
        /// </summary>
        /// <returns>Player's stats</returns>
        public Stats GetStats()
        {
            return m_stats;
        }

        /// <summary>
        /// Set player's puppet.
        /// </summary>
        /// <param name="puppet">Puppet</param>
        public void SetPuppet(Puppet puppet)
        {
            m_puppet = puppet;
        }

        /// <summary>
        /// Get player's puppet.
        /// </summary>
        /// <returns>Player's puppet</returns>
        public Puppet GetPuppet()
        {
            return m_puppet;
        }

        /// <summary>
        /// Set player's nickname.
        /// </summary>
        /// <param name="nickname">Nickname</param>
        public void SetNickname(string nickname)
        {
            m_nickname = nickname;
        }

        /// <summary>
        /// Get player's nickname.
        /// </summary>
        /// <returns>Player's nickname</returns>
        public string GetNickname()
        {
            return m_nickname;
        }

        public override bool Equals(System.Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            Wrapper p = obj as Wrapper;
            if ((System.Object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return m_nickname == p.m_nickname;
        }

        public bool Equals(Wrapper p)
        {
            // If parameter is null return false:
            if ((object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return m_nickname == p.m_nickname;
        }

        public override int GetHashCode()
        {
            int hash = 0;
            int factor = 1;
            foreach (char c in m_nickname)
            {
                hash += (((int) c) + factor) * factor;

                factor++;
            }

            return hash;
        }
    }
}
