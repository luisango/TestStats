using UnityEngine;
using System.Collections;

namespace Minigame
{
    /// <summary>
    /// Minigame Wrapper class stores all information related to a minigame
    /// </summary>
    public class Wrapper : Utils.IListener
    {
        private bool m_isGameOver;

        public Wrapper()
        {
            m_isGameOver = false;
        }

        protected bool IsGameOver()
        {
            return m_isGameOver;
        }

        public override bool OnEvent(int evt)
        {
            return true;
        }
    }
}
