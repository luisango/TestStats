using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Board;
using PlayerWrapper = Player.Wrapper;
using Utils;

namespace Manager
{
    class Board : Utils.Singleton<Board>
	{
        /// <summary>
        /// Array that stores all the boxes of the board.
        /// </summary>
        private List<Box> m_boxes;

        /// <summary>
        /// Stores turn order for board.
        /// </summary>
        private List<PlayerWrapper> m_turn;

        /// <summary>
        /// Stores current turn.
        /// </summary>
        private int m_currentTurn;

        /// <summary>
        /// Used for respawning logic.
        /// </summary>
        private bool m_isRespawning;

        public Board()
        {
            m_boxes = new List<Box>();
            m_turn = new List<PlayerWrapper>();

            // Get players
            m_turn = Manager.Player.Instance.Get();

            // Shuffle players to order turns
            m_turn.Shuffle();

            m_currentTurn = 0;
        }

        /// <summary>
        /// Called when respawning the board.
        /// </summary>
        public void Respawn()
        {
            Debug.Log("RESPAWNING!!!!!!!!!!!!");
            m_isRespawning = true;

            GameObject board = GameObject.Find("Board");

            board.GetComponent<Respawner>().RespawnPlayers();

            m_isRespawning = false;
        }

        /// <summary>
        /// Get the very first box added to the board.
        /// </summary>
        /// <returns>First box added</returns>
        public Box GetFirstBox()
        {
            if (m_boxes.Count == 0)
                return null;
            else
                return m_boxes[0];
        }

        /// <summary>
        /// Get the lastest box added to the board.
        /// </summary>
        /// <returns>Last box added</returns>
        public Box GetLastBox()
        {
            if (m_boxes.Count == 0)
                return null;
            else
                return m_boxes[m_boxes.Count - 1];
        }

        /// <summary>
        /// Add box to current list of boxes.
        /// </summary>
        /// <param name="box">Box component to add</param>
        /// <param name="index">Index where the box must be in</param>
        public void AddBox(Box box, int index = -1)
        {
            if (index < 0)
            {
                Debug.Log("PREADD");
                m_boxes.Add(box);
                Debug.Log("1 ADDED BOX: " + box.gameObject.name);
            }
            else
            {
                Debug.Log("PREADD");
                m_boxes.Insert(index, box);
                Debug.Log("2 ADDED BOX: " + box.gameObject.name);
            }

            Debug.Log("TOTAL BOXES = " + m_boxes.Count);
        }

        /// <summary>
        /// Get the path of what boxes must the player follow. Remember to use
        /// Box.GetWaypoint() to get box position as Vector3!
        /// </summary>
        /// <param name="from">Box where the player is</param>
        /// <param name="to">How many boxes to go through (MAY BE NEGATIVE!)</param>
        /// <returns>The path to follow (by boxes), WITHOUT THE CURRENT BOX!</returns>
        public List<Box> GetPath(Box from, int to)
        {
            List<Box> path = new List<Box>();
            Box currentBox = from;
            int steps = Math.Abs(to);

            for (int i = 0; i < steps; i++)
            {
                currentBox = (to < 0) ? currentBox.GetPrevious() : currentBox.GetNext();

                path.Add(currentBox);
            }

            // HINT: This returns a list of Box instead of Vec3 because it may be needed in the future
            return path;
        }

        /// <summary>
        /// Return all board boxes.
        /// </summary>
        /// <returns>A list of board boxes</returns>
        public List<Box> Get()
        {
            return m_boxes;
        }

        public bool IsRespawning()
        {
            return m_isRespawning;
        }

        public PlayerWrapper GetCurrentTurnPlayer()
        {
            return m_turn[m_currentTurn];
        }

        public void NextTurn()
        {
            m_currentTurn += 1;

            if (m_currentTurn > m_turn.Count - 1)
                m_currentTurn = 0;
        }

        public void MoveCurrentPlayer(int boxes)
        {

        }
	}
}
