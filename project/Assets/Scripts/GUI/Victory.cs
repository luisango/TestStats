﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Victory : MonoBehaviour
{
    public Text m_winner;


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
//<<<<<<< HEAD

        m_winner.text = winner.GetNickname() + " : " + maxScore;
//=======
        m_winner.text = winner.GetNickname();
//>>>>>>> 92319fa9a7e48dbd64724b77c0fe1c880498d55f
    }

    void Update()
    {
        foreach (Player.Wrapper player in Manager.Player.Instance.Get())
        {
            if (player.GetInput().IsKeyDown(Player.Input.Key.Action))
            {
                Manager.Scene.Instance.Load(Manager.Scene.Type.Credits);
            }
        }
    }
}
