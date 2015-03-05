using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PlayerWrapper = Player.Wrapper;
using MinigameDefinition = Minigame.Definition;
using MinigameController = Minigame.Controller;


namespace Manager
{
    /// <summary>
    /// Manages all minigame related actions.
    /// </summary>
    public class Minigame : Utils.Singleton<Minigame>
    {
        public enum Type
        {
            NONE,
            SweetRain,
            CutLogs,
            Jellyasticity,
            ContarObjetos
        };

        /// <summary>
        /// List to store all active minigames.
        /// </summary>
        private List<MinigameDefinition> m_minigames;

        /// <summary>
        /// Count for Player.Wrapper dispatching.
        /// </summary>
        private int m_currentPlayerWrapperCount;

        /// <summary>
        /// Ordering for Player.Wrapper dispatching.
        /// </summary>
        private List<int> m_currentPlayerIndexShuffle;

        private MinigameController m_currentMinigameController;

        private int[] m_currentMinigameLocalScore;


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

        /// <summary>
        /// Load minigame by Minigame.Definition.
        /// </summary>
        /// <param name="minigame">Minigame definition</param>
        public void Load(MinigameDefinition minigame)
        {
            ResetMinigameImplicitVars();
            Manager.Scene.Instance.Load(minigame.GetAlias());
        }

        /// <summary>
        /// Reset minigame implicit vars.
        /// </summary>
        private void ResetMinigameImplicitVars()
        {
            int playerCount = Manager.Player.Instance.Get().Count;

            m_currentPlayerIndexShuffle = new List<int>();
            m_currentMinigameLocalScore = new int[playerCount];

            for (int i = 0; i < playerCount; i++)
                m_currentPlayerIndexShuffle.Add(i);

            Utils.List.Shuffle<int>(m_currentPlayerIndexShuffle);

            m_currentPlayerWrapperCount = 0;
            m_currentMinigameController = null;
        }

        /// <summary>
        /// Get Player.Wrapper at index.
        /// </summary>
        /// <param name="playerIndex">Index</param>
        /// <returns>Player.Wrapper at indicated index</returns>
        private PlayerWrapper GetPlayer(int playerIndex)
        {
            m_currentPlayerWrapperCount++;

            return Manager.Player.Instance.GetOne(playerIndex);
        }

        /// <summary>
        /// Get a Player.Wrapper by default ordering.
        /// </summary>
        /// <returns>A Player.Wrapper</returns>
        public PlayerWrapper GetPlayer()
        {
            return GetPlayer(m_currentPlayerWrapperCount);
        }

        /// <summary>
        /// Get a Player.Wrapper by random ordering.
        /// </summary>
        /// <returns>A Player.Wrapper</returns>
        public PlayerWrapper GetRandomPlayer()
        {
            return GetPlayer(m_currentPlayerIndexShuffle[m_currentPlayerWrapperCount]);
        }

        public void SetMinigameController(MinigameController controller)
        {
            m_currentMinigameController = controller;
        }

        public MinigameController GetMinigameController()
        {
            return m_currentMinigameController;
        }

        public void SetMinigameLocalScoreForPlayer(PlayerWrapper player, int score)
        {
            m_currentMinigameLocalScore[Player.Instance.Get().IndexOf(player)] = score;
        }

        public int GetLocalScoreForPlayer(PlayerWrapper player)
        {
            return m_currentMinigameLocalScore[Player.Instance.Get().IndexOf(player)];
        }

        public int NormalizeScore(int score)
        {
            return m_currentMinigameController.NormalizeScore(score);
        }
    }
}
