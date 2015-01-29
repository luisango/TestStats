using UnityEngine;
using System.Collections;

namespace Player
{
    /// <summary>
    /// Stats class stores all kind of stats for a player
    /// </summary>
    public class Stats
    {
        /// <summary>
        /// Store simple points
        /// </summary>
        private int m_points;


        public Stats()
        {
            m_points = 0;
        }

        /// <summary>
        /// Private constructor for add operator
        /// </summary>
        /// <param name="points">Points to set by default</param>
        private Stats(int points)
        {
            m_points = points;
        }

        /// <summary>
        /// Adds points
        /// </summary>
        /// <param name="points">Points to add</param>
        public void AddPoints(int points)
        {
            m_points += points;
        }

        /// <summary>
        /// Substracts points
        /// </summary>
        /// <param name="points">Points to substract</param>
        public void SubstractPoints(int points)
        {
            m_points -= points;
        }

        /// <summary>
        /// Sets current points to value
        /// </summary>
        /// <param name="points">Points to set </param>
        public void SetPoints(int points)
        {
            m_points = points;
        }

        /// <summary>
        /// Get points
        /// </summary>
        /// <returns>Current points</returns>
        public int GetPoints()
        {
            return m_points;
        }

        public static Stats operator +(Stats s1, Stats s2)
        {
            return new Stats(s1.m_points + s2.m_points);
        }

        public override string ToString()
        {
            return m_points.ToString();
        }
    }
}
