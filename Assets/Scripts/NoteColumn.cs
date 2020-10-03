using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteColumn : MonoBehaviour
{
    Sequencer s;
    public string columnID;
    public NoteButton buttonPrefab;

    public List<NoteButton> noteButtons = new List<NoteButton>();

    Image columnBackground;
    public Color highlightCol = Color.grey;

    private void Start()
    {
        s = FindObjectOfType<Sequencer>();
        columnBackground = GetComponent<Image>();
        GenerateNoteButtons();
    }

    private void Update()
    {
        if (int.Parse(columnID) == s.currentNote && s.playing)
        {
            columnBackground.color = highlightCol;
        }
        else
        {
            columnBackground.color = Color.clear;
        }
    }

    public void GenerateNoteButtons()
    {
        for (int i = 0; i < s.layers; i++)
        {
            NoteButton nb = Instantiate(buttonPrefab, transform);
            nb.buttonID = columnID + i.ToString("00");
            noteButtons.Add(nb);
        }
    }

}
