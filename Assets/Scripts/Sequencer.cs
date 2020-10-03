using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Note
{
    public List<bool> currentlyPlaying = new List<bool>();

    public void populateNote(int layers)
    {
        for (int i = 0; i < layers; i++)
        {
            currentlyPlaying.Add(false);
        }
    }

    public void Clear()
    {
        for (int i = 0; i < currentlyPlaying.Count; i++)
        {
            currentlyPlaying[i] = false;
        }
    }

    public void toggleLine(int line)
    {
        currentlyPlaying[line] = !currentlyPlaying[line];
    }
}

public class Sequencer : MonoBehaviour
{
    public float bpm;
    float timeUntilNextBeat;
    public int layers;
    public int bars;
    public int notesPerBar;
    public List<Note> notes = new List<Note>();
    public int currentNote;
    public List<bool> output = new List<bool>();

    public bool playing;

    public UnityEvent onNewNote = new UnityEvent();

    public int maxNotes;
    public int currentNotes;

    public int startingActiveNotes = 2;
    public int maxActiveNotes;
    public int currentMaxActiveNotes;
    public int currentActiveNotes;

    // Start is called before the first frame update
    void Start()
    {
        InitialiseNotes();
        currentMaxActiveNotes = startingActiveNotes;
    }

    [ContextMenu("Initialise Notes")]
    public void InitialiseNotes()
    {
        currentNote = -1;
        notes.Clear();
        for (int i = notes.Count; i < (bars * notesPerBar); i++)
        {
            Note noteToAdd = new Note();

            noteToAdd.populateNote(layers);

            notes.Add(noteToAdd);
        }

        for (int i = 0; i < notes.Count; i++)
        {
            notes[i].Clear();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playing)
        {
            timeUntilNextBeat -= Time.deltaTime;
            if (timeUntilNextBeat <= 0)
            {
                currentNote++;
                if (currentNote >= notes.Count)
                {
                    currentNote = 0;
                }

                output = notes[currentNote].currentlyPlaying;
                onNewNote.Invoke();
                timeUntilNextBeat = 60 / bpm;
            }
        }
    }

    public void ToggleNote(string noteToSet)
    {
        int note = int.Parse(noteToSet.Substring(0, 2));
        int layer = int.Parse(noteToSet.Substring(2, 2));

        notes[note].toggleLine(layer);
    }

    public void ToggleRandomNote()
    {

        int note = Random.Range(0, notes.Count);
        int layer = Random.Range(0, layers);
        if (!notes[note].currentlyPlaying[layer])
        {
            ToggleNote(note.ToString("00") + layer.ToString("00"));
            currentActiveNotes++;
        }
        if (currentActiveNotes < currentMaxActiveNotes)
        {
            ToggleRandomNote();
        }
    }



    public void RandomiseNotes()
    {
        InitialiseNotes();
        currentActiveNotes = 0;
        ToggleRandomNote();
    }
}
