using UnityEngine;
using System.Collections;


namespace Player
{
    /// <summary>
    /// Puppet class stores all information related to a player puppet.
    /// </summary>
    public class Puppet
    {
        /// <summary>
        /// Store a puppet identifier.
        /// </summary>
        private int m_identifier;

        /// <summary>
        /// Main color for puppet.
        /// </summary>
        private Color m_mainColor;


        /// <summary>
        /// Puppet constructor.
        /// </summary>
        /// <param name="identifier">Puppet identifier</param>
        public Puppet(int identifier)
        {
            m_identifier = identifier;
            m_mainColor = new Color(
                Random.Range(0f, 1f),
                Random.Range(0f, 1f),
                Random.Range(0f, 1f)
                );
        }

        /// <summary>
        /// Get puppet identifier.
        /// </summary>
        /// <returns>Puppet identifier</returns>
        public int GetIdentifier()
        {
            return m_identifier;
        }

        /// <summary>
        /// Get puppet primary color.
        /// </summary>
        /// <returns>Primary color</returns>
        public Color GetColor()
        {
            return m_mainColor;
        }
    }
}
