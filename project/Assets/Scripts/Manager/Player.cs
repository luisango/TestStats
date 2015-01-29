using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PlayerWrapper = Player.Wrapper;

namespace Manager
{
    /// <summary>
    /// Player Manager class stores all information related to all players
    /// </summary>
	public class Player : Utils.Singleton
	{
        /// <summary>
        /// List to store all players
        /// </summary>
		private List<PlayerWrapper> m_players;

		protected Player()
		{
            m_players = new List<PlayerWrapper>();
		}

        /// <summary>
        /// Get player list
        /// </summary>
        /// <returns>List with all current players</returns>
        public List<PlayerWrapper> Get()
		{
			return m_players;
		}

        /// <summary>
        /// Add a player to current players
        /// </summary>
        /// <param name="player">Player to add</param>
        public void Add(PlayerWrapper player)
		{
            m_players.Add(player);
		}

        /// <summary>
        /// Remove a player from current players
        /// </summary>
        /// <param name="player">Player to remove</param>
        public void Remove(PlayerWrapper player)
		{
            m_players.Remove(player);
		}
	}
}
