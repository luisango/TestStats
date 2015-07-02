using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Player
{
    [System.Serializable]
	class PuppetController : MonoBehaviour
	{
        private Wrapper m_player;
        private Board.Box m_box;

        private bool m_isWaliking;
        private Vector3[] m_path;
        private int m_initialPos, m_endPos;
        public float m_t;

        public void SetPlayer(Wrapper player)
        {
            m_player = player;

			if (m_player == null) {
				Debug.Log("MIERDA");
				Debug.Break();
			} else {
				Debug.Log("NOMBRE "+ m_player.GetNickname() + " --- BOXES... " + Manager.Board.Instance.Get().Count );
			}

            // TODO: Spawn puppet, configure puppet materials (colors), etc
            int position = m_player.GetStats().GetPosition();
			Debug.Log("POSITION " + position );
            Board.Box box = Manager.Board.Instance.GetPositioned(position);

            this.SetBox(box);
            this.transform.position = box.GetWaypoint();
            m_box.AddPuppetInsideBox(this);

            if (m_isWaliking)
            {

                Vector3 pos = Vector3.Lerp(m_path[m_initialPos], m_path[m_endPos], m_t);
                
                if( m_t >= 1.0f )
                {
                    m_t = 1.0f;

                    if( m_endPos == m_path.Length )
                    {
                        m_isWaliking = false;
                        m_isWaliking = false;
                    }
                    else
                    {
                        m_t = 0.0f;
                        m_initialPos += 1;
                        m_endPos += 1;
                    }
                }
            }
        }

        public void SetBox(Board.Box box)
        {
            m_box = box;
        }

        public void StartWalking(Vector3[] positions)
        {
            m_isWaliking = true;
            m_t = .0f;
            m_initialPos = 0;
            m_endPos = 0;
        }
	}
}
