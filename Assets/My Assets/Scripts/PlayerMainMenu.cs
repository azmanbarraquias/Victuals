using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMainMenu : MonoBehaviour
{
    [Header("Player")]
    private Player player;

    [Space]
    [Header("Create Player")]
    public TMP_InputField inputProfileField;

    public GameObject newPlayerUI;

    public GameObject mainMenu;

    private int profileID = 0;

    private bool profileGender = true;

    [Header("Profile")]
    public TextMeshProUGUI profileNameTMP;

    public Image profileImage;

    public Image avatarSelection;


    public Image profileGenderImage;

    public Sprite[] profileImageSprites;

    public Sprite[] profileGenderImageSprites;


    [Header("Reset Player")]
    public bool reset = false;

    private void Start()
    {
        player = FindObjectOfType<Player>();

        if (reset)
        {
            SaveSystem.DeletePlayerData();
        }
        LoadPlayer();
    }



    public void SavePlayer()
    {
        if (player.players.Count == 0)
        {
            // New Player
            PlayerPrefs.SetInt("currentPlayerID", 0);

            var newPlayer = new PlayerData
            {
                profileID = profileID,
                playerName = inputProfileField.text,
                gender = profileGender
            };

            player.players.Add(newPlayer);
        }
        else
        {
            //UpdateCurrentPlayer
        }

        SaveSystem.SavePlayer(player.players);

        LoadPlayer();
    }

    public void LoadPlayer()
    {
        player.players = (SaveSystem.LoadPlayer() == null) ? new() : SaveSystem.LoadPlayer();

        if (player.players.Count == 0)
        {
            newPlayerUI.SetActive(true);
        }
        else
        {
            int currentPlayerID = PlayerPrefs.GetInt("currentPlayerID");

            player.currentPlayer = player.players[currentPlayerID];

            profileNameTMP.text = player.currentPlayer.playerName;

            profileImage.sprite = profileImageSprites[player.currentPlayer.profileID];

            profileGenderImage.sprite = player.currentPlayer.gender ? profileGenderImageSprites[0] : profileGenderImageSprites[1];
            Debug.Log(player.currentPlayer.gender);

            mainMenu.SetActive(true);
        }
    }

    public void SelectUserProfileID(int id)
    {
        profileID = id;
        avatarSelection.sprite = profileImageSprites[id];
    }

    public void SelectUserGender(bool gender)
    {
        profileGender = gender;
    }
}
