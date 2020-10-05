using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Note
{
    public List<bool> currentlyPlaying = new List<bool>();

    public bool cleared = true;

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

    public UnityEvent onNewNote = new UnityEvent(), onNewLoop = new UnityEvent();

    public int maxNotes;
    public int currentNotes;

    public int startingActiveNotes = 2;
    public int maxActiveNotes;
    public int currentMaxActiveNotes;
    public int currentActiveNotes;

    public bool mistakeMade;

    public List<bool> signalsRecieved = new List<bool>();

    // Start is called before the first frame update
    void Start()
    {
        InitialiseNotes();

        currentMaxActiveNotes = startingActiveNotes;
        RandomiseNotes();
        signalsRecieved.Clear();
        for (int i = layers; i > 0; i--)
        {
            signalsRecieved.Add(new bool());
        }
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

    public GameObject GameOverScreen, startScreen;
    public void GameOver()
    {
        GameOverScreen.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (playing)
        {
            timeUntilNextBeat -= Time.deltaTime;
            if (timeUntilNextBeat <= 0)
            {
                if (output.Count == signalsRecieved.Count)
                    CheckCorrectPressed();
                currentNote++;
                if (currentNote >= notes.Count)
                {
                    onNewLoop.Invoke();
                    ToggleRandomNote();
                    currentNote = 0;
                }

                output = notes[currentNote].currentlyPlaying;
                onNewNote.Invoke();
                timeUntilNextBeat = 60 / bpm;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.R))
            {
                SceneManager.LoadScene(0);
            }
            if (Input.GetKey(KeyCode.Space) && !GameOverScreen.activeInHierarchy)
            {
                startScreen.SetActive(false);
                playing = true;
            }
        }
    }

    public void CheckCorrectPressed()
    {
        if (output[output.Count-1 ])
        {

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

        int note = Random.Range(1, notes.Count);
        int layer = Random.Range(0, layers);
        if (!notes[note].currentlyPlaying[layer])
        {
            ToggleNote(note.ToString("00") + layer.ToString("00"));
            currentActiveNotes++;
        }
        if (currentActiveNotes < currentMaxActiveNotes)
        {
            ToggleRandomNote();
            return;
        }
        else
        {
            currentMaxActiveNotes++;
            if (currentMaxActiveNotes > maxActiveNotes)
            {
                currentMaxActiveNotes = maxActiveNotes;
                //bpm += 3;
            }
        }

    }



    public void RandomiseNotes()
    {
        InitialiseNotes();
        currentActiveNotes = 0;
        ToggleRandomNote();
    }
}
