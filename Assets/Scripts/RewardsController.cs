using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardsController : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button reward1Button;
    [SerializeField] private Button reward2Button;
    [SerializeField] private Button reward3Button;
    [Header("Locks")]
    [SerializeField] private Image reward1Lock;
    [SerializeField] private Image reward2Lock;
    [SerializeField] private Image reward3Lock;
    private int playerLevel;
    // Start is called before the first frame update
    private void Awake()
    {
        playerLevel = PlayerPrefs.GetInt("PlayerLevel");
    }
    // Start is called before the first frame update
    void Start()
    {
        if(playerLevel == 1)
        {
            reward1Button.interactable = true;
            reward2Button.interactable = false;
            reward3Button.interactable = false;
            reward1Lock.enabled = false;
            reward2Lock.enabled = true;
            reward3Lock.enabled = true;
        }
        else if(playerLevel == 2)
        {
            reward1Button.interactable = true;
            reward2Button.interactable = true;
            reward3Button.interactable = false;
            reward1Lock.enabled = false;
            reward2Lock.enabled = false;
            reward3Lock.enabled = true;
        }
        else if(playerLevel == 3)
        {
            reward1Button.interactable = true;
            reward2Button.interactable = true;
            reward3Button.interactable = true;
            reward1Lock.enabled = false;
            reward2Lock.enabled = false;
            reward3Lock.enabled = false;
        }
        else
        {
            reward1Button.interactable = false;
            reward2Button.interactable = false;
            reward3Button.interactable = false;
            reward1Lock.enabled = true;
            reward2Lock.enabled = true;
            reward3Lock.enabled = true;
        }
    }
}
