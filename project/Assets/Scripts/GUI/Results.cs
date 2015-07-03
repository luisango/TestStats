using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Results : MonoBehaviour
{
    public Text m_winner1;
    public Text m_winner2;
    public Text m_winner3;


    void Start()
    {
        // TODO: Shitty way to discover the winner... fix this shit!

        Player.Wrapper winner1 = null;
        Player.Wrapper winner2 = null;
        Player.Wrapper winner3 = null;
        int maxScore1 = 0;
        int maxScore2 = 0;
        int maxScore3 = 0;

        foreach (Player.Wrapper player in Manager.Player.Instance.Get())
        {
            int thisPlayerScore = Manager.Minigame.Instance.GetLocalScoreForPlayer(player);

            if (maxScore1 < thisPlayerScore)
            {
                maxScore3 = maxScore2;
                maxScore2 = maxScore1;
                maxScore1 = thisPlayerScore;
                winner3 = winner2;
                winner2 = winner1;
                winner1 = player;
            }
            else if (maxScore2 < thisPlayerScore)
            {
                maxScore3 = maxScore2;
                maxScore2 = thisPlayerScore;
                winner3 = winner2;
                winner2 = player;
            }
            else if (maxScore3 < thisPlayerScore)
            {
                maxScore3 = thisPlayerScore;
                winner3 = player;
            }
        }

        m_winner1.text = winner1.GetNickname() + ": " + maxScore1;
        winner1.GetStats().AddPoints( Manager.Minigame.Instance.NormalizeScore( maxScore1 ) );

        if ( Manager.Player.Instance.Get().Count > 1 )
        {
            m_winner2.text = winner2.GetNickname() + ": " + maxScore2;
            winner2.GetStats().AddPoints( Manager.Minigame.Instance.NormalizeScore( maxScore2 ) );
        }
        if ( Manager.Player.Instance.Get().Count > 2 )
        {
            m_winner3.text = winner3.GetNickname() + ": " + maxScore3;
            winner3.GetStats().AddPoints( Manager.Minigame.Instance.NormalizeScore( maxScore3 ) );
        }
        
    }

    void Update()
    {
        foreach (Player.Wrapper player in Manager.Player.Instance.Get())
        {
            if (player.GetInput().IsKeyDown(Player.Input.Key.Action))
            {
                Manager.Scene.Instance.Load(Manager.Scene.Type.Board);
            }
        }
    }
}