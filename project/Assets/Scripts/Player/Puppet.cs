using UnityEngine;
using System.Collections;

namespace Player
{
    /// <summary>
    /// Puppet class stores all information related to a player puppet
    /// </summary>
    public class Puppet
    {
        /// <summary>
        /// Store a puppet identifier
        /// </summary>
        private int m_identifier;

        /// <summary>
        /// Puppet constructor
        /// </summary>
        /// <param name="identifier">Puppet identifier</param>
        public Puppet(int identifier)
        {
            m_identifier = identifier;
        }

        /// <summary>
        /// Get puppet identifier
        /// </summary>
        /// <returns>Puppet identifier</returns>
        public int GetIdentifier()
        {
            return m_identifier;
        }
    }
}
