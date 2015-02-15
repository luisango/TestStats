using UnityEngine;
using System.Collections;

namespace Board
{
    public class Respawner : MonoBehaviour
    {
        private bool m_isSpawned = false;
        public GameObject m_puppetPrefab;

        void Update()
        {
            // TODO: REMOVE THIS CREEPY HACK!
            if (Time.time > 30 && !m_isSpawned)
            {
                m_isSpawned = true;
                Manager.Board.Instance.Respawn();
            }
        }

        public void RespawnPlayers()
        {
            foreach (Player.Wrapper p in Manager.Player.Instance.Get())
            {
                GameObject puppet = (GameObject)Instantiate(m_puppetPrefab);

                puppet.GetComponent<Player.PuppetController>().SetPlayer(p);
            }
        }
    }
}
