using UnityEngine;
using System.Collections;

namespace Minigame
{
    /// <summary>
    /// Minigame Wrapper class stores all information related to a minigame
    /// </summary>
    public abstract class Controller : MonoBehaviour, Utils.IListener
    {
        private bool m_isGameOver;

        public Controller()
        {
            m_isGameOver = false;
        }

        void Start()
        {
            OnStart();
        }

        void Update()
        {
            OnUpdate();
        }

        protected bool IsGameOver()
        {
            return m_isGameOver;
        }

        public void OnStart()
        {

        }

        public void OnUpdate()
        {

        }

        public bool OnEvent(int evt)
        {
            return true;
        }
    }
}
