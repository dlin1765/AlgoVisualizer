using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ArrowScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int value;
    public GameObject txt;
    public string arrowName;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetValue(int v, string n)
    {
        value = v;
        arrowName = n;
        txt.GetComponent<TextMeshPro>().text = n + " = " + value.ToString();
    }
    public void changeValue(int v)
    {
        value = v;
        txt.GetComponent<TextMeshPro>().text = name + " = " + value.ToString();
    }
}
