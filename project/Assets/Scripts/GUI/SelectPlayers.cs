using UnityEngine;
using System.Collections;

public class SelectPlayers : MonoBehaviour 
{
    public void OnClickPlayerButton(int numberOfPlayers)
    {
        Debug.Log(numberOfPlayers +" players selected!!");

        Manager.Game.Instance.SetNumberOfPlayers(numberOfPlayers);
    }
}
