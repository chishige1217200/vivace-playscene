using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class MusicJson
{
    public string name;
    public int maxBlock;
    public int BPM;
    public int offset;
    public NotesJson[] notes;
}

[System.Serializable]
public class NotesJson
{
    public int LPB;
    public int num;
    public int block;
    public int type;
    public NotesJson[] notes;
}

public class PlaySceneProcessManager : MonoBehaviour
{
    List<List<NoteData>> _notes = new List<List<NoteData>>(); // 2次元リスト
    static float laneWidth = 0.3f; //レーンの太さ( = ノーツの太さ )
    float _offset = 10.8f;
    [SerializeField] LongNotesGenerator lng;
    void Start()
    {
        TextAsset jsonFile = Resources.Load("sample2") as TextAsset;
        string inputString = jsonFile.ToString();
        MusicJson music = JsonUtility.FromJson<MusicJson>(inputString);

        Debug.Log(music);
        LoadNotes(music);
        Invoke("UnPause", 3);
    }

    void LoadNotes(MusicJson music)
    {
        MusicData.BPM = music.BPM;
        MusicData.musicName = music.name;

        Object noteObject = Resources.Load("Notes");

        for (int i = 0; i < 7; i++)
        {
            _notes.Add(new List<NoteData>());
        }

        NoteData firstNote = new NoteData();
        NoteData nextNote = new NoteData();
        for (int i = 0; i < music.notes.Length; i++)
        {
            firstNote.LPB = music.notes[i].LPB;
            firstNote.num = music.notes[i].num;
            firstNote.block = music.notes[i].block;
            firstNote.type = music.notes[i].type;
            firstNote.timing = (60f * firstNote.num) / (MusicData.BPM * firstNote.LPB); // ms
            _notes[firstNote.block].Add(firstNote);
            if (music.notes[i].notes.Length == 1)
            {
                nextNote.LPB = music.notes[i].notes[0].LPB;
                nextNote.num = music.notes[i].notes[0].num;
                nextNote.block = music.notes[i].notes[0].block;
                nextNote.type = music.notes[i].notes[0].type;
                nextNote.timing = (60f * nextNote.num) / (MusicData.BPM * nextNote.LPB); // ms
                _notes[nextNote.block].Add(nextNote);
            }

            if (firstNote.type == 1)
            {
                Instantiate(noteObject, new Vector3(-0.9f + laneWidth * firstNote.block, 3.6f * firstNote.timing + _offset, -0.005f), new Quaternion(0, 0, 0, 0));
            }
            else if (firstNote.type == 2)
            {
                lng.Create(firstNote.block, nextNote.block, firstNote.timing, nextNote.timing);
            }
            else if (firstNote.type == 5)
            {

            }
        }
    }

    void UnPause()
    {
        NotesFallUpdater.isPose = false;
    }
}
