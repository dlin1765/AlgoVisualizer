using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject txt;
    public GameObject mText;
    public GameObject StartButton;
    public GameObject MenuOption;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButtonPressed()
    {
        StartButton.SetActive(false);
        MenuOption.SetActive(true);
        mText.SetActive(true);
        txt.SetActive(false);
        //Debug.Log(txt.GetComponent<TextMeshPro>().text);
        //txt.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text = a;
    }

    public void loadBinarySearchScene()
    {
        SceneManager.LoadScene(sceneName: "AlgorithmScene");
    }
}
