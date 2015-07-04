using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Victory : MonoBehaviour
{
    public Text m_winner;

    public int m_timer = 0;


    void Start()
    {
        // TODO: Shitty way to discover the winner... fix this shit!

        Player.Wrapper winner = null;
        int maxScore = 0;

        foreach (Player.Wrapper player in Manager.Player.Instance.Get())
        {
            int thisPlayerScore = player.GetStats().GetPoints();

            if (maxScore < thisPlayerScore || winner == null)
            {
                maxScore = thisPlayerScore;
                winner = player;
            }
        }

        m_winner.text = winner.GetNickname();
    }

    void Update()
    {
        m_timer++;

        foreach (Player.Wrapper player in Manager.Player.Instance.Get())
        {
            if (m_timer > 5000 && player.GetInput().IsKeyDown(Player.Input.Key.Action))
            {
                Manager.Scene.Instance.Load(Manager.Scene.Type.Credits);
            }
        }
    }
}