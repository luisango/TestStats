using UnityEngine;
using System.Collections;


namespace Player
{
    /// <summary>
    /// Stats class stores all kind of stats for a player.
    /// </summary>
    public class Stats
    {
        /// <summary>
        /// Store simple points.
        /// </summary>
        private int m_points;

        /// <summary>
        /// Store in which box the player is.
        /// </summary>
        private int m_position;


        public Stats()
        {
            m_points   = 0;
            m_position = 0;
        }

        /// <summary>
        /// Private constructor for add operator.
        /// </summary>
        /// <param name="points">Points to set by default</param>
        /// <param name="position">Position to set by default</param>
        private Stats(int points, int position)
        {
            m_points   = points;
            m_position = position;
        }

        private void SetPosition(int position)
        {
            m_position = position;
        }

        public int GetPosition()
        {
            return m_position;
        }

        /// <summary>
        /// Adds points.
        /// </summary>
        /// <param name="points">Points to add</param>
        public void AddPoints(int points)
        {
            m_points += points;
        }

        /// <summary>
        /// Substracts points.
        /// </summary>
        /// <param name="points">Points to substract</param>
        public void SubstractPoints(int points)
        {
            m_points -= points;
        }

        /// <summary>
        /// Sets current points to value.
        /// </summary>
        /// <param name="points">Points to set </param>
        public void SetPoints(int points)
        {
            m_points = points;
        }

        /// <summary>
        /// Get points.
        /// </summary>
        /// <returns>Current points</returns>
        public int GetPoints()
        {
            return m_points;
        }

        public static Stats operator +(Stats s1, Stats s2)
        {
            return new Stats(s1.m_points + s2.m_points, s1.m_position + s2.m_position);
        }

        public override string ToString()
        {
            return m_points.ToString();
        }
    }
}
