using UnityEngine;
using System.Collections;
using System.Collections.Generic;
// TODO: Change this when Minigame class is implemented
using MinigameWrapper = Minigame.Wrapper;

namespace Manager
{
    /// <summary>
    /// Manages all minigame related actions
    /// </summary>
    public class Minigame : Utils.Singleton<Minigame>
    {
        /// <summary>
        /// List to store all active minigames
        /// </summary>
        private List<MinigameWrapper> m_minigames;


        public Minigame()
        {
            m_minigames = new List<MinigameWrapper>();
        }

        /// <summary>
        /// Get all minigames
        /// </summary>
        /// <returns>Minigames list</returns>
        public List<MinigameWrapper> Get()
        {
            return m_minigames;
        }

        /// <summary>
        /// Add minigame to the active minigame list
        /// </summary>
        /// <param name="minigame">Minigame to add</param>
        public void Add(MinigameWrapper minigame)
        {
            m_minigames.Add(minigame);
        }

        /// <summary>
        /// Removes a minigame from the active minegame list
        /// </summary>
        /// <param name="minigame">Minigame to remove</param>
        public void Remove(MinigameWrapper minigame)
        {
            m_minigames.Remove(minigame);
        }
    }
}
