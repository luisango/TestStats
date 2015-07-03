using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class GUIController : MonoBehaviour {

    public Text m_text;

	// Update is called once per frame
	void Update () 
    {
        m_text.text = "Score: (" + Manager.Board.Instance.m_scoreToWin + " to win!)\n\n";
        
        foreach (Player.Wrapper p in Manager.Player.Instance.Get())
        {
            m_text.text += p.GetNickname() + ": " + p.GetStats().GetPoints();
        }
	}
}
