using UnityEngine;
using System.Collections;

public class SelectPlayers : MonoBehaviour 
{
    public void OnClickPlayerButton(int numberOfPlayers)
    {
        Manager.Game.Instance.SetNumberOfPlayers(numberOfPlayers);

        Manager.Scene.Instance.Load(Manager.Scene.Type.ConfigPlayers);
    }
}
