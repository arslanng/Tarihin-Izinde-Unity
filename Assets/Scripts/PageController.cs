using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PageController : MonoBehaviour
{
    public void GoToPage(string pageName)
    {
        SceneManager.LoadScene(pageName, LoadSceneMode.Single);
    }
}
