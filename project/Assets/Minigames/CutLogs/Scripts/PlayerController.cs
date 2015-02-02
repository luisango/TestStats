using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
    private Player.Wrapper m_playerWrapper;
    private int m_score;
    

    public PlayerController(Player.Wrapper playerWrapper)
    {
        m_playerWrapper = playerWrapper;
        m_score = 0;
    }

	void Start() 
    {
	
	}
	
	void Update()
    {
        if (m_playerWrapper.GetInput().IsKeyDown(Player.Input.Key.Action)) {
            Debug.Log("Action!!");
        }
	}
}
