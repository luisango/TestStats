using UnityEngine;
using System.Collections;


namespace Minigame
{
    /// <summary>
    /// This class is used for minigame properties definition.
    /// </summary>
    public class Definition
    {
        /// <summary>
        /// Stores the minigame name.
        /// </summary>
        private string m_name;

        /// <summary>
        /// Stores the minigame alias.
        /// </summary>
        private string m_alias;

        /// <summary>
        /// Stores the minigame maximum players.
        /// </summary>
        private int m_maxPlayers;


        public Definition()
        {
            m_name = "Unknown Game";
            m_alias = "UnknownGame";
            m_maxPlayers = 0;
        }

        /// <summary>
        /// Set all properties at once.
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="alias">Alias</param>
        /// <param name="maxPlayers">Maximum players</param>
        protected void SetInfo(string name, string alias, int maxPlayers)
        {
            m_name = name;
            m_alias = alias;
            m_maxPlayers = maxPlayers;
        }

        public string GetName()
        {
            return m_name;
        }

        public string GetAlias()
        {
            return m_alias;
        }

        public int GetMaxPlayers()
        {
            return m_maxPlayers;
        }
    }
}