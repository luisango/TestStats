using UnityEngine;
using System.Collections;


public class SelectPlayers : MonoBehaviour 
{
    /// <summary>
    /// Callback called when Player button is clicked at SelectPlayers scene.
    /// </summary>
    /// <param name="numberOfPlayers">Number of players selected (button number)</param>
    public void OnClickPlayerButton(int numberOfPlayers)
    {
        Manager.Game.Instance.SetNumberOfPlayers(numberOfPlayers);

        Manager.Scene.Instance.Load(Manager.Scene.Type.ConfigPlayers);
    }
}
