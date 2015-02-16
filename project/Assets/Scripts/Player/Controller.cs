using UnityEngine;
using System.Collections;


namespace Player
{
    /// <summary>
    /// Player base controller class make some player controller functionality.
    /// </summary>
    public abstract class Controller : MonoBehaviour
    {
        /// <summary>
        /// Event handler to comunicate with Minigame.Controller.
        /// </summary>
        private Utils.Observable m_eventHandler;

        /// <summary>
        /// Handle to current player wrapper.
        /// </summary>
        private Wrapper m_player;

        /// <summary>
        /// Local (minigame) score.
        /// </summary>
        private int m_score;


        /// <summary>
        /// MonoBehaviour Start()
        /// </summary>
        void Start()
        {
            // Set player wrapper
            m_player = SetPlayer();

            // Initialize score
            m_score = 0;

            // Custom OnStart() method
            OnStart();
        }

        /// <summary>
        /// Custom Start method. It triggers at the end of 
        /// Player.Controller.Start() method.
        /// </summary>
        protected virtual void OnStart()
        {

        }

        /// <summary>
        /// MonoBehaviour Update()
        /// </summary>
        void Update()
        {
            // If the game is over, then notify GameOver to Minigame.Controller
            if (GameOverCheck())
                SendEvent((int)Minigame.Controller.Events.GameOver);

            // Process input commands
            ProcessInput();

            // Custom OnUpdate() method
            OnUpdate();
        }

        /// <summary>
        /// Send an event to minigame controller
        /// </summary>
        /// <param name="evt">Event</param>
        protected void SendEvent(int evt)
        {
            m_eventHandler.Notify(evt);
        }

        /// <summary>
        /// Custom OnUpdate() method. It triggers at the end of 
        /// Player.Controller.Update() method.
        /// </summary>
        protected virtual void OnUpdate()
        {

        }

        /// <summary>
        /// Adds score to local score.
        /// </summary>
        /// <param name="score">Score to add</param>
        protected void AddScore(int score)
        {
            m_score += score;
        }

        /// <summary>
        /// Substract score to local score.
        /// </summary>
        /// <param name="score">Score to substract</param>
        protected void SubstractScore(int score)
        {
            m_score -= score;
        }

        /// <summary>
        /// Get the current local score.
        /// </summary>
        /// <returns>Current local score</returns>
        public int GetScore()
        {
            return m_score;
        }

        /// <summary>
        /// Subscribes a Minigame.Controller to this controller event handler.
        /// </summary>
        /// <param name="controller">Minigame.Controller which is subscribing</param>
        public void Subscribe(Minigame.Controller controller)
        {
            // Create event handler if not created yet
            if (m_eventHandler == null)
                m_eventHandler = new Utils.Observable();

            m_eventHandler.Subscribe(controller);
        }

        /// <summary>
        /// MUST DEFINE BY USER! Determines what Player.Wrapper will this class 
        /// controls.
        /// </summary>
        /// <returns>Player.Wrapper for this controller</returns>
        protected abstract Wrapper SetPlayer();

        /// <summary>
        /// Get current Player.Wrapper.
        /// </summary>
        /// <returns>Current Player.Wrapper</returns>
        public Wrapper GetPlayer()
        {
            return m_player;
        }

        /// <summary>
        /// MUST DEFINE BY USER! This function must encapsulate input 
        /// functionality and calls.
        /// </summary>
        protected abstract void ProcessInput();

        /// <summary>
        /// MUST DEFINE BY USER! This function checks if the game is over.
        /// </summary>
        /// <returns>If game is over or not</returns>
        protected abstract bool GameOverCheck();
    }
}