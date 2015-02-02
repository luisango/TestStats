using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PlayerWrapper = Player.Wrapper;
using MinigameDefinition = Minigame.Definition;

namespace Manager
{
    /// <summary>
    /// Manages all minigame related actions.
    /// </summary>
    public class Minigame : Utils.Singleton<Minigame>
    {
        /// <summary>
        /// List to store all active minigames.
        /// </summary>
        private List<MinigameDefinition> m_minigames;

        private int m_currentPlayerWrapperCount;

        private List<int> m_currentPlayerIndexShuffle;


        public Minigame()
        {
            m_minigames = new List<MinigameDefinition>();
        }

        /// <summary>
        /// Get all minigames.
        /// </summary>
        /// <returns>Minigames list</returns>
        public List<MinigameDefinition> Get()
        {
            return m_minigames;
        }

        /// <summary>
        /// Add minigame to the active minigame list.
        /// </summary>
        /// <param name="minigame">Minigame to add</param>
        public void Add(MinigameDefinition minigame)
        {
            m_minigames.Add(minigame);
        }

        /// <summary>
        /// Removes a minigame from the active minegame list.
        /// </summary>
        /// <param name="minigame">Minigame to remove</param>
        public void Remove(MinigameDefinition minigame)
        {
            m_minigames.Remove(minigame);
        }

        public void Load(MinigameDefinition minigame)
        {
            ResetMinigameImplicitVars();
            Manager.Scene.Instance.Load(minigame.GetAlias());
        }

        private void ResetMinigameImplicitVars()
        {
            m_currentPlayerIndexShuffle = new List<int>();

            for (int i = 0; i < Manager.Game.Instance.GetNumberOfPlayers(); i++)
                m_currentPlayerIndexShuffle.Add(i);

            Utils.List.Shuffle<int>(m_currentPlayerIndexShuffle);

            m_currentPlayerWrapperCount = 0;
        }

        private PlayerWrapper GetPlayer(int playerIndex)
        {
            m_currentPlayerWrapperCount++;

            return Manager.Player.Instance.GetOne(playerIndex);
        }

        public PlayerWrapper GetPlayer()
        {
            return GetPlayer(m_currentPlayerWrapperCount);
        }

        public PlayerWrapper GetRandomPlayer()
        {

        }
    }
}
