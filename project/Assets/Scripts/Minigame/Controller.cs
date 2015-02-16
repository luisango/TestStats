using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace Minigame
{
    /// <summary>
    /// Minigame Wrapper class stores all information related to a minigame.
    /// </summary>
    public abstract class Controller : MonoBehaviour, Utils.IListener
    {
        /// <summary>
        /// Predefined events. Reserved until 99.
        /// </summary>
        public enum Events
        {
            GameOver,
            TimesUp
        };

        /// <summary>
        /// Indicates if game is over or not.
        /// </summary>
        private bool m_isGameOver;

        /// <summary>
        /// EDITOR VAR! Stores a prefab to instantiate when 
        /// IntantiatePlayers().
        /// </summary>
        public GameObject m_playerPrefab;

        /// <summary>
        /// Player instances.
        /// </summary>
        private List<GameObject> m_playerInstances;


        public Controller()
        {
            m_playerInstances = new List<GameObject>();
            m_isGameOver = false;
        }

        /// <summary>
        /// MonoBehaviour Start(). Call custom OnStart and instantiate players.
        /// </summary>
        void Start()
        {
            OnStart();
            InstantiatePlayers();
        }

        /// <summary>
        /// MonoBehaviour Update(). Check if is game over and call custom 
        /// OnUpdate().
        /// </summary>
        void Update()
        {
            if (IsGameOver()) {
                foreach (GameObject o in m_playerInstances)
                {
                    Player.Controller c = o.GetComponent<Player.Controller>();
                    Manager.Minigame.Instance.SetMinigameLocalScoreForPlayer(c.GetPlayer(), c.GetScore());
                }

                Manager.Scene.Instance.Load(Manager.Scene.Type.Results);
            }

            OnUpdate();
        }

        /// <summary>
        /// Checks or sets if game is over.
        /// </summary>
        /// <param name="set">If true, sets game over</param>
        /// <returns>If is game over or not</returns>
        protected bool IsGameOver(bool set = false)
        {
            if (set)
                return m_isGameOver = true;
            else
                return m_isGameOver;
        }

        /// <summary>
        /// Custom OnStart().
        /// </summary>
        public virtual void OnStart()
        {

        }

        /// <summary>
        /// Custom OnUpdate().
        /// </summary>
        public virtual void OnUpdate()
        {

        }

        /// <summary>
        /// Default event handling.
        /// </summary>
        /// <param name="evt">Event identificator</param>
        /// <returns>If must continue with event chain or not</returns>
        public virtual bool OnEvent(int evt)
        {
            switch (evt)
            {
                case (int) Events.GameOver:
                    IsGameOver(true);
                    break;

                default:
                    break;
            }

            return true;
        }

        /// <summary>
        /// Instantiates player prefab.
        /// </summary>
        /// <returns>GameObject corresponding to the instantiated prefab</returns>
        protected GameObject InstantiatePlayer()
        {
            GameObject o = (GameObject)Instantiate(m_playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            m_playerInstances.Add(o);

            return o;
        }

        /// <summary>
        /// MUST DEFINE BY USER! Must instantiate and set user prefabs stuff.
        /// </summary>
        protected abstract void InstantiatePlayers();

        /// <summary>
        /// MUST DEFINE BY USER! This function will be called to convert local
        /// score into global game score.
        /// </summary>
        /// <param name="score">Local score to convert</param>
        /// <returns>Global score corresponding to input</returns>
        public abstract int NormalizeScore(int score);
    }
}
