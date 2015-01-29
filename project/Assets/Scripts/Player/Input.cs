using UnityEngine;
using System.Collections;

namespace Player 
{
    /// <summary>
    /// Input class is an abstraction for multiple input keys
    /// </summary>
    public class Input
    {
        /// <summary>
        /// Key descriptors
        /// </summary>
        public enum Key
        {
            Left,
            Right,
            Action,
            Length
        };

        /// <summary>
        /// String array to store each key
        /// </summary>
        private string[] m_keys;


        Input()
        {
            m_keys = new string[3];
        }

        /// <summary>
        /// Sets all input keys at once
        /// </summary>
        /// <param name="actionKey">Action key</param>
        /// <param name="leftKey">Left key</param>
        /// <param name="rightKey">Right key</param>
        public void SetKeys(string actionKey, string leftKey, string rightKey)
        {
            m_keys[(int) Key.Left] = actionKey;
            m_keys[(int) Key.Right] = leftKey;
            m_keys[(int) Key.Action] = rightKey;
        }

        /// <summary>
        /// Set a specific key
        /// </summary>
        /// <param name="key">Key descriptor</param>
        /// <param name="value">Key name</param>
        public void SetKey(Key key, string value)
        {
            m_keys[(int) key] = value;
        }

        /// <summary>
        /// Get a specific key
        /// </summary>
        /// <param name="key">Key descriptor</param>
        /// <returns>Key name related to key descriptor</returns>
        public string GetKey(Key key)
        {
            return m_keys[(int) key];
        }

        /// <summary>
        /// Detects if key is held down
        /// </summary>
        /// <param name="key">Key descriptor</param>
        /// <returns>If the key is held down or not</returns>
        public bool IsKeyPressed(Key key)
        {
            return UnityEngine.Input.GetKey(m_keys[(int) key]);
        }

        /// <summary>
        /// Detects if key has just changed to up state
        /// </summary>
        /// <param name="key">Key descriptor</param>
        /// <returns>If key is just up or not</returns>
        public bool IsKeyUp(Key key)
        {
            return UnityEngine.Input.GetKeyUp(m_keys[(int) key]);
        }

        /// <summary>
        /// Detects if key has just pressed
        /// </summary>
        /// <param name="key">Key descriptor</param>
        /// <returns>If key is just pressed or not</returns>
        public bool IsKeyDown(Key key)
        {
            return UnityEngine.Input.GetKeyDown(m_keys[(int) key]);
        }

        public override string ToString()
        {
            return m_keys[(int) Key.Left] + " " + m_keys[(int) Key.Action] + " " + m_keys[(int) Key.Right];
        }
    }
}
