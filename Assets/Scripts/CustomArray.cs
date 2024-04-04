using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomArray : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ArrBox;
    public GameObject Arrow;


    public List<int> intArr = new List<int>();
    public List<GameObject> boxArr = new List<GameObject>();
    public List<GameObject> arrowArr = new List<GameObject>();
    void Start()
    {

    }

    public void setArrayValues(List<int> a)
    {
        intArr = a;
    }
    public void drawArray()
    {
        for (int i = 0; i < intArr.Count; i++)
        {
            Vector3 origin = new Vector3(this.transform.position.x + 1.5f * i, transform.position.y, 0f);
            Quaternion rotation = new Quaternion(0f, 0f, 0f, 0f);
            GameObject temp = Instantiate(ArrBox, origin, rotation, this.transform);
            temp.GetComponent<ArrBoxScript>().SetValue(intArr[i]);
            temp.GetComponent<ArrBoxScript>().SetIndex(i);
            boxArr.Add(temp);
        }
    }

    public void moveArrows(ArrBoxScript _ref)
    {
        for (int i = 0; i < _ref.arrowList.Count; i++)
        {
            GameObject arrowRef = _ref.arrowList[i];
            Vector3 originalPos = arrowRef.transform.position;
            float offset = originalPos.x - 0.55f;
            originalPos.Set(offset, originalPos.y, originalPos.z);
            Debug.Log("the x value of the arrbox " + originalPos.x);
            _ref.arrowList[i].transform.position = originalPos;
        }
    }

    public void InstantiateArrow(string name, int index, ArrBoxScript _ref)
    {
        Quaternion rotation = new Quaternion(0f, 0f, 0f, 0f);
        Vector3 posTemp = boxArr[index].transform.position;
        float offset = (0.55f * _ref.arrowList.Count);
        float yoffset = 0.20f * _ref.arrowList.Count;
        posTemp.Set(posTemp.x-0.55f+ offset, posTemp.y + 1.5f+yoffset, posTemp.z);
        GameObject temp = Instantiate(Arrow, posTemp, rotation, boxArr[index].transform);
        temp.GetComponent<ArrowScript>().SetValue(index, name);
        boxArr[index].GetComponent<ArrBoxScript>().arrowList.Add(temp);
        arrowArr.Add(temp);
    }

    public void drawArrow(string name, int index)
    {
        if (index == -1)
        {

        }
        else
        {
            ArrBoxScript arrBoxRef = boxArr[index].GetComponent<ArrBoxScript>();
            InstantiateArrow(name, index, arrBoxRef);
        }
        
    }
    public void updateNegArrow(int index, int value, string name)
    {
        ArrBoxScript reference = boxArr[index].GetComponent<ArrBoxScript>();
        for (int i = 0; i < reference.arrowList.Count; i++)
        {
            if (reference.arrowList[i].GetComponent<ArrowScript>().arrowName == name)
            {
                GameObject temp = reference.arrowList[i];
                reference.arrowList[i].GetComponent<ArrowScript>().SetValue(value, name);
            }
        }
    }
    
    public void updateArrow(int index, int newIndex, int value, string name)
    {
        if(index == -1)
        {
            drawArrow("middle", newIndex);//this is the good stuff
        }
        else
        {
            ArrBoxScript reference = boxArr[newIndex].GetComponent<ArrBoxScript>();
            ArrBoxScript reference2 = boxArr[index].GetComponent<ArrBoxScript>();
            for (int i = 0; i < reference2.arrowList.Count; i++)
            {
                if (reference2.arrowList[i].GetComponent<ArrowScript>().arrowName == name)
                {
                    GameObject temp = reference2.arrowList[i];
                    reference2.arrowList.RemoveAt(i);
                    Destroy(temp);
                }
            }
            drawArrow(name, newIndex);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
