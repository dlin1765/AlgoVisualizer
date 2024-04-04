using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ArrBoxScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int value;
    public int index;
    public GameObject txt;
    public GameObject indexTxt;
    public GameObject arrow;

    public List<GameObject> arrowList = new List<GameObject>();

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetValue(int v)
    {
        value = v;
        txt.GetComponent<TextMeshPro>().text = value.ToString();
    }       
    public void SetIndex(int v)
    {
        index = v;
        indexTxt.GetComponent<TextMeshPro>().text = v.ToString();
    }
}
