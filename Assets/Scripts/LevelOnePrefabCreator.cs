using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.XR.ARFoundation;
using UnityEngine.SceneManagement;

public class LevelOnePrefabCreator : MonoBehaviour
{
    [SerializeField] private GameObject targetPrefab;
    [SerializeField] private Vector3 prefabOffset;
    [SerializeField] private Vector3 prefabRotation;
    [Header("UI")]
    [SerializeField] private GameObject fotoPanel;
    [SerializeField] private Button finishButton;
    [SerializeField] private Text lookBackText;
    [SerializeField] private String targetName;
    [SerializeField] private Button backButton;

    private ARTrackedImageManager arTrackedImageManager;
    private GameObject target;
    private String pageController;
    private bool isSetupComplete;

    private void Start()
    {
        Destroy(target);
        arTrackedImageManager = null;

        isSetupComplete = false;
        backButton.gameObject.SetActive(true);
        lookBackText.text = "";
        finishButton.gameObject.SetActive(false);
        fotoPanel.SetActive(true);

        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
    private void OnEnable()
    {
        if (arTrackedImageManager == null)
        {
            arTrackedImageManager = GetComponent<ARTrackedImageManager>();
            arTrackedImageManager.trackedImagesChanged += OnImageChanged;
        }
        isSetupComplete = false;
    }
    private void OnDisable()
    {
        if (arTrackedImageManager != null)
        {
            arTrackedImageManager.trackedImagesChanged -= OnImageChanged;
        }
        isSetupComplete = false;
    }

    private void OnImageChanged(ARTrackedImagesChangedEventArgs obj)
    {
        if (!isSetupComplete && target == null)
        {
            foreach (ARTrackedImage image in obj.added)
            {
                if (image.referenceImage.name == "Level1TargetImage")
                {
                    target = Instantiate(targetPrefab, image.transform.position + prefabOffset, Quaternion.Euler(prefabRotation));
                    fotoPanel.SetActive(false);
                    lookBackText.text = "Bir Sonraki Hedef Etrafında";
                    finishButton.gameObject.SetActive(true);
                    backButton.gameObject.SetActive(false);
                    isSetupComplete = true;
                    Invoke(nameof(TextChange), 5.0f);
                    break;
                }

            }
            foreach (ARTrackedImage image in obj.updated)
            {
                if (image.referenceImage.name == "Level1TargetImage")
                {
                    target = Instantiate(targetPrefab, image.transform.position + prefabOffset, Quaternion.Euler(prefabRotation));
                    fotoPanel.SetActive(false);
                    lookBackText.text = "Bir Sonraki Hedef Etrafında";
                    finishButton.gameObject.SetActive(true);
                    backButton.gameObject.SetActive(false);
                    isSetupComplete = true;
                    Invoke(nameof(TextChange), 5.0f);
                    break;
                }
            }
            obj.added.Clear();
            obj.updated.Clear();
            obj.removed.Clear();
        }
    }
    void TextChange()
    {
        lookBackText.text = targetName;
    }
    public void TargetDestroyer(string pageName)
    {
        PlayerPrefs.SetInt("PlayerLevel", 1);
        Destroy(target);
        pageController = pageName;
        isSetupComplete = false;
        if (arTrackedImageManager != null)
        {
            arTrackedImageManager.trackedImagesChanged -= OnImageChanged;
            arTrackedImageManager = null;
        }
        Destroy(arTrackedImageManager);
        Invoke(nameof(GoToPage), 1.0f);
    }
    void GoToPage()
    {
        SceneManager.LoadScene(pageController, LoadSceneMode.Single);
    }
}
