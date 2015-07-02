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

        private bool m_isWalking;
        private List<Board.Box> m_path;
        private int m_initialPos, m_endPos;
        public float m_t;
        private bool m_haveRolled;

        public void SetPlayer(Wrapper player)
        {
            m_player = player;
            m_isWalking = false;
            m_haveRolled = false;

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
        }

        public void SetBox(Board.Box box)
        {
            m_box = box;
        }

        public void StartWalking(List<Board.Box> path)
        {
            m_isWalking = true;
            m_t = .0f;
            m_initialPos = 0;
            m_endPos = 1;
            m_path = path;

            m_player.GetStats().SetPosition(path[path.Count - 1].GetBoardPosition());

            Debug.Log("Tamano del vectoru del path: " + m_path.Count);
        }

        public void Update()
        {
            Manager.Board b = Manager.Board.Instance;

            if (b.GetCurrentTurnPlayer() == m_player)
            {
                Board.Roulette r = GameObject.Find("Roulette").GetComponent<Board.Roulette>();

                if (m_player.GetInput().IsKeyDown(Player.Input.Key.Action))
                {
                    m_haveRolled = true;
                    r.TurnRoulette(100);
                }

                int steps = 0;
                if (r.GetSteps(out steps) && m_haveRolled)
                {
                    Debug.Log("Y ha salidoru.... " + steps);
                    m_haveRolled = false;
                    StartWalking(b.GetPath(m_box, steps));
                }
            }
            else
            {
                m_haveRolled = false;
            }

            if (m_isWalking)
            {
                Vector3 initialPos = m_path[m_initialPos].GetWaypoint();
                Vector3 endPos = m_path[m_endPos].GetWaypoint();

                Vector3 pos = Vector3.Lerp(m_path[m_initialPos].GetWaypoint(), m_path[m_endPos].GetWaypoint(), Mathf.Clamp( m_t, 0.0f, 1.1f )  );

                if (m_t >= 1.0f)
                {
                    m_t = 1.0f;

                    if (m_endPos == m_path.Count - 1)
                    {
                        m_isWalking = false;
                    }
                    else
                    {
                        m_t = 0.0f;
                        m_initialPos += 1;
                        m_endPos += 1;
                    }
                }

                m_t += Time.deltaTime;
                this.transform.position = pos;
            }
        }
	}
}
