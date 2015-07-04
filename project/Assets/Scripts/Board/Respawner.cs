using UnityEngine;
using System.Collections;

namespace Board
{
    public class Respawner : MonoBehaviour
    {
        private bool m_isSpawned = false;
        public GameObject m_puppetPrefab;

        public GameObject[] m_puppetPrefabs;

        void Update()
        {
            // TODO: REMOVE THIS CREEPY HACK!
            if (Time.timeSinceLevelLoad > 0.5f && !m_isSpawned)
            {
                m_isSpawned = true;
                Manager.Board.Instance.Respawn();
                
            }
        }

        public void RespawnPlayers()
        {
            foreach (Player.Wrapper p in Manager.Player.Instance.Get())
            {
                int id = p.GetPuppet().GetIdentifier();
                GameObject puppet = (GameObject)Instantiate(m_puppetPrefabs[id]);

                puppet.AddComponent<Player.PuppetController>();
                puppet.GetComponent<Player.PuppetController>().SetPlayer(p);
            }
        }
    }
}
