using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using TMPro;
using Levels;
using Controllers;
using Storage;


public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [Header("Panels")]
    [Space(5)]
    [SerializeField] private GameObject WinPanel;
    [SerializeField] private GameObject LosePanel;
    [SerializeField] private GameObject GamePlayPanel;
    [SerializeField] private GameObject StartPanel;
    [SerializeField] private Button startBtn;





    #region Unity Methodes

    private void OnEnable()
    {
        LevelManager.OnLevelStart += OnLevelStart;
        LevelManager.OnLevelComplete += OnLevelComplete;

    }
    private void OnDisable()
    {
        LevelManager.OnLevelStart -= OnLevelStart;
        LevelManager.OnLevelComplete -= OnLevelComplete;

    }

    private void Awake()
    {
        Instance = this;
        Initialized();
    }

    #endregion

        


    

    private void Initialized()
    {

        startBtn.onClick.AddListener(() =>
        {
            LevelManager.Instance.LevelStart();
        });

        WinPanel.GetComponentInChildren<Button>().onClick.AddListener(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        });

        LosePanel.GetComponentInChildren<Button>().onClick.AddListener(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        });



    }


    #region DelegateMethode

    private void OnLevelStart(Level level)
    {
        StartPanel.gameObject.SetActive(false);
        GamePlayPanel.gameObject.SetActive(true);
    }
    private void OnLevelComplete(Level level)
    {
        WinPanel.gameObject.SetActive(true);

    }
    private void OnLevelFaild()
    {
        LosePanel.gameObject.SetActive(true);

    }

    #endregion

}
