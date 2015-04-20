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
    /// Stores UI buttons to set input keys.
    /// </summary>
    public Text[] m_inputKeyButtons;

    /// <summary>
    /// Stores if input is being configurated or not.
    /// </summary>
    private bool m_isInputBeingConfigurated;

    /// <summary>
    /// Stores what key is being configurated.
    /// </summary>
    private int m_inputKeyIsBeingConfigurated;

    /// <summary>
    /// Handle/Pointer for the nickname GUI input field.
    /// </summary>
    public InputField m_nicknameInputField;

    /// <summary>
    /// Handle/Pointer for the phase title GUI text.
    /// </summary>
    public Text m_phaseTitleText;




    public GameObject NicknamePhase;
    public GameObject CharacterPhase;
    public GameObject InputPhase;
    



    public void Start()
    {
        m_currentPlayersChoice        = Manager.Player.Instance.Get().Count;
        m_currentPlayerObject         = null;
        m_inputKeyIsBeingConfigurated = -1;

        CharacterPhase.SetActive(false);
        InputPhase.SetActive(false);
    }

    public void Update()
    {
        // TODO: Interpolation between configuration screens

        if (m_isInputBeingConfigurated) {
            foreach (char c in Input.inputString)
            {
                if (c != "\b"[0] && c != "\n"[0] && c != "\r"[0] && m_inputKeyIsBeingConfigurated > -1) {
                    m_inputKeyButtons[m_inputKeyIsBeingConfigurated].text = c.ToString();
                }

                m_inputKeyIsBeingConfigurated = -1;
                m_isInputBeingConfigurated = false;
                break;
            }
        }
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

        CharacterPhase.SetActive(false);
        InputPhase.SetActive(true);
    }

    /// <summary>
    /// Callback for being called when clicked an input key button. Stores
    /// detected key into input configuration depending on the key
    /// identifier.
    /// </summary>
    /// <param name="keyIdentifier">Key descriptor identifier</param>
    public void OnClickInputKeyButton(int keyIdentifier)
    {
        m_inputKeyIsBeingConfigurated = keyIdentifier;
        m_isInputBeingConfigurated = true;
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
        input.SetKey(Player.Input.Key.Left, m_inputKeyButtons[0].text);
        input.SetKey(Player.Input.Key.Right, m_inputKeyButtons[1].text);
        input.SetKey(Player.Input.Key.Action, m_inputKeyButtons[2].text);

        // Add input to current player
        GetCurrentPlayerObject().SetInput(input);

        InputPhase.SetActive(false);
        Finish();
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
        NicknamePhase.SetActive(false);
        CharacterPhase.SetActive(true);
    }

    /// <summary>
    /// Callback for being called when clicked FINISH button at summary
    /// configuration phase. Adds current player to player manager, resets
    /// input field nickname and proceeds with next player configuration.
    /// </summary>
    public void Finish()
    {
        // Set current player nickname placeholder
        m_nicknameInputField.text = "";

        // Add current player to player manager
        AddCurrentPlayerObjectToPlayerManager();

        // Configurate next player
        if (m_currentPlayersChoice >= Manager.Game.Instance.GetNumberOfPlayers()) {


            /////////////////////////

            //SweetRain.MinigameDefinition sweetRain = new SweetRain.MinigameDefinition();
            //
            //Manager.Minigame.Instance.Add(sweetRain);
            //Manager.Minigame.Instance.Load(sweetRain);

            /////////////////////////

            Manager.Scene.Instance.Load(Manager.Scene.Type.Board);
        } else {
            m_currentPlayersChoice++;

            NicknamePhase.SetActive(true);
            m_phaseTitleText.text = "Select Character P" + (m_currentPlayersChoice + 1);
        }
    }
}
