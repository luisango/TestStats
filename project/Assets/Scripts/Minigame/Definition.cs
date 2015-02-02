using UnityEngine;
using System.Collections;

namespace Minigame
{
    public class Definition
    {
        private string m_name;
        private string m_alias;
        private int m_maxPlayers;

        public Definition()
        {
            m_name = "Unknown Game";
            m_alias = "UnknownGame";
            m_maxPlayers = 0;
        }

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