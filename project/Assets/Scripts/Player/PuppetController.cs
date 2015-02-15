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
            Board.Box box = Manager.Board.Instance.Get()[position];

            this.transform.position = box.GetWaypoint();
        }

        public void SetBox(Board.Box box)
        {
            m_box = box;
        }
	}
}
