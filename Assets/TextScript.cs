using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextScript : MonoBehaviour
{
    // Start is called before the first frame update
    public string mid;
    public string left;
    public string  right;
    public string value;
    public string algoStep;
    void Start()
    {
        mid = "";
        left = "";
        right = "";
        value = "";
        algoStep = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void displayTxt(string v)
    {
        value = v;
        updateParameters(left, right, mid, v, algoStep);
    }
    
    public void updateParameters(string l, string r, string m, string v, string algoS)
    {
        left = l;
        right = r;
        mid = m;
        value = v;
        algoStep = algoS;
        gameObject.GetComponent<TextMeshProUGUI>().text = "value = " + value + "\nleft = " + left + "\nright = " + right + "\t Algo Step: " + algoStep + "\nmiddle = " + mid;
    }

    public void updateAlgoStep(string s)
    {
        algoStep = s;
        updateParameters(left, right, mid, value, algoStep);
    }

    public void updateMid(string s)
    {
        mid = s;
        updateParameters(left, right, mid, value, algoStep);
    }
    public void updateLeft(string s)
    {
        left = s;
        updateParameters(left, right, mid, value, algoStep);
    }
    public void updateRight(string s)
    {
        right = s;
        updateParameters(left, right, mid, value, algoStep);
    }
}
