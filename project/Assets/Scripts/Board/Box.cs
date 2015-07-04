using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Board
{
    [System.Serializable]
	abstract class Box : MonoBehaviour
	{
        /// <summary>
        /// Position/Order in board.
        /// </summary>
        public int m_position;

        /// <summary>
        /// Stores previous box.
        /// </summary>
        public Box m_previous;

        /// <summary>
        /// Stores next box.
        /// </summary>
        public Box m_next;

        /// <summary>
        /// Current puppets on the box.
        /// </summary>
        public List<Player.PuppetController> m_puppets;

        /// <summary>
        /// Waypoints for puppets.
        /// </summary>
        private List<Vector3> m_waypoints;

        // Make action when player stops over the box
        public bool m_idle = false;
        public Player.PuppetController m_puppetJustEntered;
        public Vector3 m_puppetJustEnteredLastPosition;
        public float m_idleWaitingTime = 0;


        void Start()
        {
            Awake();
            PrecalculateWaypoints();
        }

        /// <summary>
        /// MAY BE IMPLEMENTED ON CHILDREN! Double linking list on board boxes
        /// logic.
        /// </summary>
        protected virtual void Awake()
        {
            Manager.Board b = Manager.Board.Instance;

            m_puppets   = new List<Player.PuppetController>();
            m_waypoints = new List<Vector3>();

            // Get position in board
            // LUIS: Se hace solo por el editor
            //m_position = b.Get().Count;

            // Set last box on board as previous box
            //m_previous = b.GetLastBox();

            // If previous is null, means this is the first box added
            if (m_previous == null)
                m_previous = this;

            // Add this box to board
            b.AddBox(this);

            // Set the first box as next box
            //m_next = b.GetFirstBox();

            // Set (last box)'s next box, this box
            //b.GetLastBox().m_next = this;

            // Set (first box)'s previous box, this box
            //b.GetFirstBox().m_previous = this;
        }

        void Update()
        {
            // If there was a puppet that was entered...
            if (m_puppetJustEntered)
            {
                if (m_puppetJustEntered.transform.position == m_puppetJustEnteredLastPosition)
                    m_idle = true;
                else
                {
                    m_idle = false;
                    m_idleWaitingTime = 0;
                }

                m_puppetJustEnteredLastPosition = m_puppetJustEntered.transform.position;


                // But it just leaves the box, remove it
                if (!m_puppets.Exists(toFind => toFind == m_puppetJustEntered))
                    m_puppetJustEntered = null;
            }


            // Make action when player stops over the box
            if (m_idle && m_puppetJustEntered)
            {
                m_idleWaitingTime += Time.deltaTime;

                // If it's true 3 seconds
                if (m_idleWaitingTime > 3)
                {
                    BoxAction();
                    m_puppetJustEntered = null;
                }
            }
        }

        protected abstract void BoxAction();

        /// <summary>
        /// Precalculate waypoints for current box.
        /// </summary>
        private void PrecalculateWaypoints()
        {
            if (this.transform.name == "Box17")
            {
                int i = 0;
            }

            Transform t = this.transform.FindChild("Model").transform;

            int stepSplit = 5;
            // HINT: GetComponent<MeshRenderer>().bounds.extents.x;
            // HINT: GetComponent<MeshFilter>().mesh.bounds.extents.x;

            float height = t.GetComponent<MeshFilter>().mesh.bounds.extents.y * t.localScale.y * this.transform.localScale.y * 2;
            float width  = t.GetComponent<MeshFilter>().mesh.bounds.extents.x * t.localScale.x * this.transform.localScale.x * 2;
            float length = t.GetComponent<MeshFilter>().mesh.bounds.extents.z * t.localScale.z * this.transform.localScale.z * 2;

            // float midWidth = width / 2;
            // float midLength = length / 2;

            float stepWidth = width / stepSplit;
            float stepLength = length / stepSplit;

            // Vector3 mid  = new Vector3(midWidth, height, midLength);
            // TODO: Fix this, if needed, when pivot is fixed. Mid is zero if pivot is centered!
            Vector3 mid = new Vector3(0, height, 0);
            Vector3 step = new Vector3(stepWidth, 0, stepLength);

            // -         +  X
            ///////////////// Z
            // F    E    I // +
            //             //
            // B    A    C //
            //             //
            // H    D    G // -
            /////////////////

            // A
            m_waypoints.Add(mid + new Vector3(0 * step.x, 0, 0 * step.z));

            // B
            m_waypoints.Add(mid + new Vector3(-1 * step.x, 0, 0 * step.z));

            // C
            m_waypoints.Add(mid + new Vector3(1 * step.x, 0, 0 * step.z));

            // D
            m_waypoints.Add(mid + new Vector3(0 * step.x, 0, -1 * step.z));

            // E
            m_waypoints.Add(mid + new Vector3(0 * step.x, 0, 1 * step.z));

            // F
            m_waypoints.Add(mid + new Vector3(-1 * step.x, 0, 1 * step.z));

            // G
            m_waypoints.Add(mid + new Vector3(1 * step.x, 0, -1 * step.z));

            // H
            m_waypoints.Add(mid + new Vector3(-1 * step.x, 0, -1 * step.z));

            // I
            m_waypoints.Add(mid + new Vector3(1 * step.x, 0, 1 * step.z));
        }

        void OnTriggerEnter(Collider other)
        {
            OnTriggerAction(other);
        }

        void OnTriggerExit(Collider other)
        {
            Player.PuppetController p = other.GetComponent<Player.PuppetController>();

            if (!m_puppets.Exists(toFind => toFind == p))
                return;

            m_puppets.Remove(p);
        }

        /// <summary>
        /// MUST BE IMPLEMENTED BY CHILDREN! MUST BE CALLED FOR LOGIC CHECK! 
        /// Box action logic.
        /// </summary>
        protected virtual bool OnTriggerAction(Collider other)
        {
            Player.PuppetController p = other.GetComponent<Player.PuppetController>();

            // If object is already inside the collider / box
            if (m_puppets.Exists(toFind => toFind == p))
                return true;

            m_puppetJustEntered = other.GetComponent<Player.PuppetController>();

            // If object is not already inside the collider / box, then add it
            AddPuppetInsideBox(p);

            if (Manager.Board.Instance.IsRespawning())
                return true;
            else
                return false;
        }

        /// <summary>
        /// Adds puppet inside this box puppet list and also sets this puppet's
        /// box to this one.
        /// </summary>
        /// <param name="p">PuppetController to add</param>
        public void AddPuppetInsideBox(Player.PuppetController p)
        {
            m_puppets.Add(p);
            p.SetBox(this);
        }

        /// <summary>
        /// Get waypoint position depending on how many puppets are inside the
        /// box.
        /// </summary>
        /// <returns>Position on world (or parent) coords for a puppet</returns>
        public Vector3 GetWaypoint()
        {
            // TODO: Fix this, if needed, when pivot is fixed.
            Vector3 pos = this.transform.position;

            if (m_waypoints == null || m_puppets.Count == m_waypoints.Count || m_puppets == null)
            {
                int i = 0;
            }

            pos += m_waypoints[m_puppets.Count];

            return pos;
        }

        /// <summary>
        /// Get next box on board.
        /// </summary>
        /// <returns>Next box</returns>
        public Box GetNext()
        {
            return m_next;
        }

        /// <summary>
        /// Get previous box on board.
        /// </summary>
        /// <returns>Previous box</returns>
        public Box GetPrevious()
        {
            return m_previous;
        }

        /// <summary>
        /// Get (current box)'s GameObject
        /// </summary>
        /// <returns>Current box's GameObject</returns>
        public GameObject GetObject()
        {
            return this.gameObject;
        }

        /// <summary>
        /// Get current box position in board.
        /// </summary>
        /// <returns>Box position</returns>
        public int GetBoardPosition()
        {
            return m_position;
        }
	}
}
