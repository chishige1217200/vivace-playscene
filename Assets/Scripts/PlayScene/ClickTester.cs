using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickTester : MonoBehaviour
{
    [SerializeField] int lineNumber = 0;
    public void BeginDrag()
    {
        Debug.Log("BeginDrag: " + lineNumber);
    }

    public void Drop()
    {
        Debug.Log("Drop" + lineNumber);
    }

    public void PointerDown()
    {
        Debug.Log("PointerDown" + lineNumber);
    }
}