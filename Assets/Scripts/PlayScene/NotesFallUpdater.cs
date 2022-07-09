using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesFallUpdater : MonoBehaviour
{
    static float speed = 0.06f;
    public static bool isPose = true;

    public float notesSpeed
    {
        set => speed = value;
    }

    void FixedUpdate()
    {
        if (!isPose) transform.localPosition -= new Vector3(0, speed, 0);
    }

    public void Push()
    {

    }
}