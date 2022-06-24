using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LineJudger : MonoBehaviour
{
    [SerializeField] int lineNum = 0;

    void Start() // 自オブジェクトのEvent Triggerに関数のコール情報を自動追加します
    {
        //Fetch the Event Trigger component from your GameObject
        EventTrigger trigger = GetComponent<EventTrigger>();
        //Create a new entry for the Event Trigger
        EventTrigger.Entry entry = new EventTrigger.Entry();
        //Add a BeginDrag type event to the Event Trigger
        entry.eventID = EventTriggerType.BeginDrag;
        //call the BeginDrag function when the Event System detects dragging
        entry.callback.AddListener((data) => { BeginDrag((PointerEventData)data); });
        //Add the trigger entry
        trigger.triggers.Add(entry);

        //Create a new entry for the Event Trigger
        entry = new EventTrigger.Entry();
        //Add a Drop type event to the Event Trigger
        entry.eventID = EventTriggerType.Drop;
        //call the Drop function when the Event System detects dragging
        entry.callback.AddListener((data) => { Drop((PointerEventData)data); });
        //Add the trigger entry
        trigger.triggers.Add(entry);

        //Create a new entry for the Event Trigger
        entry = new EventTrigger.Entry();
        //Add a PointerDown type event to the Event Trigger
        entry.eventID = EventTriggerType.PointerDown;
        //call the PointerDown function when the Event System detects dragging
        entry.callback.AddListener((data) => { PointerDown(); });
        //Add the trigger entry
        trigger.triggers.Add(entry);

        //Create a new entry for the Event Trigger
        entry = new EventTrigger.Entry();
        //Add a PointerEnter type event to the Event Trigger
        entry.eventID = EventTriggerType.PointerEnter;
        //call the PointerEnter function when the Event System detects dragging
        entry.callback.AddListener((data) => { PointerEnter((PointerEventData)data); });
        //Add the trigger entry
        trigger.triggers.Add(entry);

    }
    public void BeginDrag(PointerEventData data)
    {
        Debug.Log("BeginDrag: " + lineNum + "," + data.position.y + "," + data.pointerId);
        CoordYPresever.AddCoordY(data.position.y, lineNum);
    }

    public void Drop(PointerEventData data)
    {
        Debug.Log("Drop: " + lineNum + "," + data.position.y + "," + data.pointerId);
        int result = CoordYPresever.isFlick(data.position.y, lineNum);
        if (result == 1) Debug.Log("Flick Up!");
    }

    public void PointerDown()
    {
        Debug.Log("PointerDown: " + lineNum);
    }

    public void PointerEnter(PointerEventData data)
    {
        Debug.Log("PointerEnter: " + lineNum + "," + data.position.y + "," + data.pointerId);
        CoordYPresever.AddCoordY(data.position.y, lineNum);
    }
}
