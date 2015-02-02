using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Results : MonoBehaviour
{
    public Text m_winner;


	void Start()
    {
        // TODO: Shitty way to discover the winner... fix this shit!

        Player.Wrapper winnerPlayer = null;
        int maxScore = 0;

        foreach (Player.Wrapper player in Manager.Player.Instance.Get())
        {
            int thisPlayerScore = Manager.Minigame.Instance.GetLocalScoreForPlayer(player);
            if (maxScore < thisPlayerScore) {
                maxScore = thisPlayerScore;
                winnerPlayer = player;
            }
        }

        m_winner.text = winnerPlayer.GetNickname();
    }
}
