using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineJudger : MonoBehaviour
{
    [SerializeField] int lineNum;

    public int lineNumber
    {
        get => lineNum;
    }

    public void PointerEnterTest()
    {
        // Debug.Log("PointerEnterTest:" + lineNum);
    }

    public void PointerExitTest()
    {
        // Debug.Log("PointerExitTest:" + lineNum);
    }

    public void PointerDownTest()
    {
        Debug.Log("PointerDownTest:" + lineNum);
    }

    public void PointerUpTest()
    {
        // Debug.Log("PointerUpTest:" + lineNum);
    }

    public void PointerClickTest()
    {
        // Debug.Log("PointerClickTest:" + lineNum);
    }

    public void DragTest()
    {
        // Debug.Log("DragTest:" + lineNum);
    }

    public void DropTest()
    {
        Debug.Log("DropTest:" + lineNum);
    }

    public void BeginDragTest()
    {
        Debug.Log("BeginDragTest:" + lineNum);
    }

    public void EndDragTest()
    {
        // Debug.Log("EndDragTest:" + lineNum);
    }

}
