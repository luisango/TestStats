using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ConfigPlayers : MonoBehaviour 
{
    /// <summary>
    /// Stores what player identifier is being configurated.
    /// </summary>
    private int m_currentPlayersChoice;

    /// <summary>
    /// Stores current player Player.Wrapper to be added to Player Manager
    /// when configuration for this player is finished.
    /// </summary>
    private Player.Wrapper m_currentPlayerObject;

    /// <summary>
    /// Stores input key names for current player.
    /// </summary>
    private string[] m_inputKeyNames;

    /// <summary>
    /// Handle/Pointer for the nickname GUI input field.
    /// </summary>
    public InputField m_nicknameInputField;

    public void Start()
    {
        m_currentPlayersChoice = -1;
        m_currentPlayerObject  = null;
        m_inputKeyNames        = new string[3];
    }

    public void Update()
    {
        // TODO: Interpolation between configuration screens
    }

    /// <summary>
    /// Obtain current player wrapper, if it doesn't exist, it creates a new
    /// one.
    /// </summary>
    /// <returns>Current player wrapper</returns>
    private Player.Wrapper GetCurrentPlayerObject()
    {
        if (m_currentPlayerObject == null)
            m_currentPlayerObject = new Player.Wrapper();

        return m_currentPlayerObject;
    }

    /// <summary>
    /// Adds current player wrapper to the player manager and resets all
    /// current player's configuration to default values.
    /// </summary>
    private void AddCurrentPlayerObjectToPlayerManager()
    {
        // Add current player to player manager
        Manager.Player.Instance.Add(m_currentPlayerObject);

        // Reset all player configs for new player
        m_currentPlayerObject = null;
        m_inputKeyNames       = new string[3];

        // Add new player to configurate, even if there are no more players
        GetCurrentPlayerObject();
    }

    /// <summary>
    /// Callback for being called when clicked a puppet button. Stores a puppet
    /// object with an identifier at current player's wrapper.
    /// </summary>
    /// <param name="puppetIdentifier">Puppet identifier</param>
    public void OnClickPuppetButton(int puppetIdentifier)
    {
        // Create puppet
        Player.Puppet puppet = new Player.Puppet(puppetIdentifier);

        // Add puppet to current player
        GetCurrentPlayerObject().SetPuppet(puppet);
    }

    /// <summary>
    /// Callback for being called when clicked an input key button. Stores
    /// detected key into input configuration depending on the key
    /// identifier.
    /// </summary>
    /// <param name="keyIdentifier">Key descriptor identifier</param>
    public void OnClickInputKeyButton(int keyIdentifier)
    {
        // TODO: Complete with key press detection
    }

    /// <summary>
    /// Callback for being called when clicked OK button on input configuration
    /// phase. Sets new Input configuration to current player's wrapper.
    /// </summary>
    public void OnClickInputOKButton()
    {
        // Create input
        Player.Input input = new Player.Input();

        // Set input keys
        input.SetKey(Player.Input.Key.Action, m_inputKeyNames[0]);
        input.SetKey(Player.Input.Key.Left, m_inputKeyNames[1]);
        input.SetKey(Player.Input.Key.Right, m_inputKeyNames[2]);

        // Add input to current player
        GetCurrentPlayerObject().SetInput(input);
    }

    /// <summary>
    /// Callback for being called when clicked OK button at nickname
    /// configuration phase. Sets nickname from InputField for current player's 
    /// wrapper.
    /// </summary>
    public void OnClickNicknameOKButton()
    {
        // Set nickname, trimmed, to current player
        GetCurrentPlayerObject().SetNickname(m_nicknameInputField.text.Trim());
    }

    /// <summary>
    /// Callback for being called when clicked FINISH button at summary
    /// configuration phase. Adds current player to player manager, resets
    /// input field nickname and proceeds with next player configuration.
    /// </summary>
    public void OnClickFinishButton()
    {
        // Add current player to player manager
        AddCurrentPlayerObjectToPlayerManager();

        // Set current player nickname placeholder
        m_nicknameInputField.text = GetCurrentPlayerObject().GetNickname();

        // Configurate next player
        m_currentPlayersChoice++;
    }
}
