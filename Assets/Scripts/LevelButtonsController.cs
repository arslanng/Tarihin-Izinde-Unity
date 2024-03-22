using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtonsController : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button level2Button; 
    [SerializeField] private Button level3Button; 
    [SerializeField] private Button level4Button;
    [Header("Locks")]
    [SerializeField] private Image level2Lock;
    [SerializeField] private Image level3Lock;
    [SerializeField] private Image level4Lock;
    private int playerLevel;
    // Start is called before the first frame update
    private void Awake()
    {
        playerLevel = PlayerPrefs.GetInt("PlayerLevel");
    }
    void Start()
    {
        if(playerLevel == 1)
        {
            level2Button.interactable = true;
            level3Button.interactable = false;
            level4Button.interactable = false;
            level2Lock.enabled = false;
            level3Lock.enabled = true;
            level4Lock.enabled = true;
        } 
        else if(playerLevel == 2)
        {
            level2Button.interactable = true;
            level3Button.interactable = true;
            level4Button.interactable = false;
            level2Lock.enabled = false;
            level3Lock.enabled = false;
            level4Lock.enabled = true;
        } 
        else if(playerLevel == 3)
        {
            level2Button.interactable = true;
            level3Button.interactable = true;
            level4Button.interactable = true;
            level2Lock.enabled = false;
            level3Lock.enabled = false;
            level4Lock.enabled = false;
        } 
        else
        {
            level2Button.interactable = false;
            level3Button.interactable = false;
            level4Button.interactable = false;
            level2Lock.enabled = true;
            level3Lock.enabled = true;
            level4Lock.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
