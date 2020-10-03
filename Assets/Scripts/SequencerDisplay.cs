using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SequencerDisplay : MonoBehaviour
{
    Sequencer s;

    public NoteColumn noteColumnPrefab;

    public List<NoteColumn> noteColumns = new List<NoteColumn>();
    private void Start()
    {
        s = FindObjectOfType<Sequencer>();

        Invoke("GenerateNoteColumns", 0.05f);
        //s.onNewNote.AddListener();
    }

    void GenerateNoteColumns()
    {
        for (int i = 0; i < s.notes.Count; i++)
        {
            NoteColumn nc = Instantiate(noteColumnPrefab, transform);
            nc.columnID = i.ToString("00");
            noteColumns.Add(nc);
        }
    }
}
