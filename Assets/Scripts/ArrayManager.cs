using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ArrayManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject custArray;
    public GameObject ArrBox;
    public GameObject inputField;
    public GameObject valueInputField;
    public GameObject AlgoTxt;
    public GameObject playAgain;
    public GameObject restart;
    public GameObject Prompts;
    public GameObject startAlgoButton;
    public GameObject nextStepButton;
    public GameObject quitButton;
    public GameObject startMenuButton;

    public Animator animator;

    public List<GameObject> allArrays = new List<GameObject>();

    public int left;
    public int right;
    public int mid;
    public int value;

    private bool whileCondition;
    private bool equalsCondition;

    private TextScript _algoText;
    private CustomArray _customArray;
    private Scene scene;
    //private Scene startScene;

    void Awake()
    {
        GameManager.OnGameStateChanged += GameManagerOnOnGameStateChanged;
    }

    void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManagerOnOnGameStateChanged;
    }
    private void GameManagerOnOnGameStateChanged(GameManager.GameState state)
    {

        if(state == GameManager.GameState.InitValues) // here's where i should probably delete all the arrays and stuff 
        {
            inputField.SetActive(true);
            valueInputField.SetActive(false);
            AlgoTxt.SetActive(true);
            Prompts.SetActive(true);
            startAlgoButton.SetActive(false);
            nextStepButton.SetActive(false);
            playAgain.SetActive(false);
            restart.SetActive(false);
            startMenuButton.SetActive(false);
            quitButton.SetActive(false);
        }
        else if(state == GameManager.GameState.WhileLR)
        {
            if (left <= right)
            {
                whileCondition = true;
            }
            else
            {
                whileCondition = false;
            }
            _algoText.updateAlgoStep("while(left <= right)\t" + left + " <= " + right + " == " + whileCondition);
        }
        else if(state == GameManager.GameState.CalculateMiddle)
        {
            int temp = left + (right - left) / 2;
            _customArray.updateArrow(mid, temp, temp, "middle");
            mid = temp;
            _algoText.updateMid(mid.ToString());
            _algoText.updateAlgoStep("middle = left + (r-1) / 2\t" + left + " + (" + right + " - " + left + ") / 2 = " + mid);
            
        }
        else if(state == GameManager.GameState.IfFoundValue)
        {
            int tempVal = allArrays[0].GetComponent<CustomArray>().intArr[mid];
            equalsCondition = tempVal == value;
            _algoText.updateAlgoStep("if arr[middle] == value\t" + "(" + tempVal + " == " + value + ") = " + equalsCondition);

        }
        else if(state == GameManager.GameState.IfLessThanValue) // arr[mid] < value 
        {
            int tempVal = allArrays[0].GetComponent<CustomArray>().intArr[mid];
            equalsCondition = tempVal < value;
            _algoText.updateAlgoStep("if arr[middle] < value\t" + "(" + tempVal + " < " + value + ") = " + equalsCondition);

        }
        else if(state == GameManager.GameState.DisplayIfResult)
        {
            
            if (equalsCondition)
            {
              
                int templeft = mid + 1;
                if(templeft >= allArrays[0].GetComponent<CustomArray>().intArr.Count)
                {
                    _customArray.updateNegArrow(left, templeft, "left");
                    _algoText.updateAlgoStep("left = middle + 1\t" + templeft + " = " + mid + " + 1 ");
                    _algoText.updateLeft(templeft.ToString());
                    left = templeft;
                }
                else
                {
                    _customArray.updateArrow(left, templeft, templeft, "left");
                    _algoText.updateAlgoStep("left = middle + 1\t" + templeft + " = " + mid + " + 1 ");
                    _algoText.updateLeft(templeft.ToString());
                    left = templeft;
                }
                
            }
            else
            {
                int tempright = mid - 1;
                if(tempright < 0)
                {
                    _customArray.updateNegArrow(right, tempright, "right");
                    _algoText.updateAlgoStep("right = middle - 1\t" + tempright + " = " + mid + " - 1 ");
                    _algoText.updateRight(tempright.ToString());
                    right = tempright;
                }
                else
                {
                    _customArray.updateArrow(right, tempright, tempright, "right");
                    _algoText.updateAlgoStep("right = middle - 1\t" + tempright + " = " + mid + " - 1 ");
                    _algoText.updateRight(tempright.ToString());
                    right = tempright;
                }
            }
        }
        else if(state == GameManager.GameState.FinishedFoundState)
        {
            playAgain.SetActive(true);
            restart.SetActive(true);
            startMenuButton.SetActive(true);
            quitButton.SetActive(true);
            nextStepButton.SetActive(false);
            _algoText.updateMid(_algoText.mid + "\n value found, return " + mid);
        }
        
        else if(state == GameManager.GameState.FinishedNotFoundState)
        {
            playAgain.SetActive(true);
            restart.SetActive(true);
            startMenuButton.SetActive(true);
            quitButton.SetActive(true);
            nextStepButton.SetActive(false);
            _algoText.updateMid(_algoText.mid + "\n value not found, return -1");
        }
        
        
    }
    void Start()
    {
        _algoText = AlgoTxt.GetComponent<TextScript>();
        scene = SceneManager.GetActiveScene();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakeArray(string value)
    {
        List<int> temp = new List<int>();
        foreach(string word in value.Split(" ")){
            temp.Add(int.Parse(word));   
        }
        Vector3 origin = new Vector3(-7.65f, -1.75f, 0f);
        Quaternion rotation = new Quaternion(0f, 0f, 0f, 0f);
        GameObject newCustArray = Instantiate(custArray, origin, rotation);
        CustomArray a = newCustArray.GetComponent<CustomArray>();
        a.setArrayValues(temp);
        a.drawArray();
        allArrays.Add(newCustArray);
        AlgoTxt.GetComponent<TextScript>().updateParameters(0.ToString(), (a.intArr.Count-1).ToString(), "", "", "");
        _customArray = a;
    }
    public void RemakeArray(List<int> a)
    {
        Vector3 origin = new Vector3(-7.65f, -1.75f, 0f);
        Quaternion rotation = new Quaternion(0f, 0f, 0f, 0f);
        GameObject newCustArray = Instantiate(custArray, origin, rotation);
        CustomArray newarray = newCustArray.GetComponent<CustomArray>();
        newarray.setArrayValues(a);
        newarray.drawArray();
        allArrays.Add(newCustArray);
        AlgoTxt.GetComponent<TextScript>().updateParameters(0.ToString(), (newarray.intArr.Count - 1).ToString(), "", "", "");
        _customArray = newarray;
    }
    
    public void advanceAlgorithm()
    {
        if (GameManager.Instance.State == GameManager.GameState.WhileLR)
        {
            if (whileCondition)
            {
                Debug.Log("while loop condition satisfied -> calculate mid");
                GameManager.Instance.updateGameState(GameManager.GameState.CalculateMiddle);
            }
            else
            {
                Debug.Log("while loop condition not satisfied -> finishednotfound");
                GameManager.Instance.updateGameState(GameManager.GameState.FinishedNotFoundState);
            }
            //whileCondition = false;
        }
        else if (GameManager.Instance.State == GameManager.GameState.CalculateMiddle)
        {
            Debug.Log("calculating middle -> ifFoundValue");
            GameManager.Instance.updateGameState(GameManager.GameState.IfFoundValue);
        }
        else if (GameManager.Instance.State == GameManager.GameState.IfFoundValue)
        {
            if (!equalsCondition)
            {
                Debug.Log("did not find the target value");
                GameManager.Instance.updateGameState(GameManager.GameState.IfLessThanValue);
            }
            else
            {
                Debug.Log("target value found");
                GameManager.Instance.updateGameState(GameManager.GameState.FinishedFoundState);
            }
            //equalsCondition = false;
        }
        else if(GameManager.Instance.State == GameManager.GameState.IfLessThanValue)
        {
            if (equalsCondition)
            {
                Debug.Log("update left");
                GameManager.Instance.updateGameState(GameManager.GameState.DisplayIfResult);
            }
            else
            {
                Debug.Log("update right");
                GameManager.Instance.updateGameState(GameManager.GameState.DisplayIfResult);
            }
        }
        else if(GameManager.Instance.State == GameManager.GameState.DisplayIfResult)
        {
            Debug.Log("loop back to while");
            GameManager.Instance.updateGameState(GameManager.GameState.WhileLR);
        }
    }

    public void StartAlgorithm()
    {
        startAlgoButton.SetActive(false);
        Prompts.SetActive(false);
        nextStepButton.SetActive(true);
        restart.SetActive(false);
        playAgain.SetActive(false);
        quitButton.SetActive(false);
        startMenuButton.SetActive(false);
        GameManager.Instance.updateGameState(GameManager.GameState.WhileLR);
    }

    public void promptForValue()
    {
        Prompts.GetComponent<TextMeshProUGUI>().text = "Please enter a value to search for";
        inputField.SetActive(false);
        valueInputField.SetActive(true);
    }
    public void valueEntered(string v)
    {
        AlgoTxt.GetComponent<TextScript>().displayTxt(v);
        Prompts.SetActive(false);
        startAlgoButton.SetActive(true);
        valueInputField.SetActive(false);
        left = 0;
        
        right = allArrays[0].GetComponent<CustomArray>().intArr.Count-1;
        mid = -1;
        value = int.Parse(v);
        _customArray.drawArrow("left", left);
        _customArray.drawArrow("right", right);
        _customArray.drawArrow("middle", mid);
    }
    public void makeArrow(string name, int value)
    {
        startAlgoButton.SetActive(false);
        Prompts.SetActive(false);
        AlgoTxt.SetActive(true);
    }

    public void reloadScene()
    {
        SceneManager.LoadScene(scene.name);
    }
        
    public void QuitScene()
    {
        Application.Quit();
    }

    public void StartMenu()
    {
        SceneManager.LoadScene(sceneName: "StartScreen");
    }

    public void replayBinarySearch()
    {
        left = 0;
        right = allArrays[0].GetComponent<CustomArray>().intArr.Count - 1;
        mid = -1;
        
        GameObject killSoon = allArrays[0];
        CustomArray temp = allArrays[0].GetComponent<CustomArray>();
        allArrays.Clear();
        RemakeArray(temp.intArr);
        Destroy(killSoon);
        Destroy(temp);
        //allArrays[0].GetComponent
        _customArray.drawArrow("left", left);
        _customArray.drawArrow("right", right);
        _customArray.drawArrow("middle", mid);
        StartAlgorithm();
        _algoText.displayTxt(value.ToString());
    }
}
