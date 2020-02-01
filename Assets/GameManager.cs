using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform player;
    public Camera cam;
    public int materialAmount;
    public int neededAmount;
    public Text materialText;
    public string materialName;

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        materialAmount = 0;
        neededAmount = 3;
        materialText.text = string.Concat(materialName, ": ", materialAmount.ToString());
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void AddMaterial()
    {
        materialAmount++;
        UpdateProgress();
    }


    public void UpdateProgress()
    {
        materialText.text = string.Concat(materialName, ": ", materialAmount.ToString());
    }
}