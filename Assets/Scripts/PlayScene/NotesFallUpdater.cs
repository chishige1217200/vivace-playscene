using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesFallUpdater : MonoBehaviour
{
    static float speed = 0.06f;

    public float notesSpeed
    {
        get => speed;
    }

    void FixedUpdate()
    {
        this.transform.localPosition -= new Vector3(0, speed, 0);
    }
}