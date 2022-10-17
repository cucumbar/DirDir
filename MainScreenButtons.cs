using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScreenButtons : MonoBehaviour
{
    public MainScreenButtons MSB;
    public Button play;
    public Button exit;
    public GameObject player;

    void Start()
    {
        MSB.play.onClick.AddListener(CloserPlayDialogue);
        MSB.exit.onClick.AddListener(CloserExitDialogue);
    }

    void CloserPlayDialogue()
    {
        player.SetActive(true);
        MSB.gameObject.SetActive(false);
    }

    void CloserExitDialogue()
    {
        MSB.gameObject.SetActive(false);
        Application.Quit();
    }
}
