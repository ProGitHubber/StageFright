using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class NoteButton : MonoBehaviour
{
    public string buttonID;
    Sequencer s;
    Button b;
    public Color[] colors;
    public Color successColor;
    public Color failColor;
    // Start is called before the first frame update
    void Start()
    {
        s = FindObjectOfType<Sequencer>();
        b = GetComponent<Button>();
        //b.onClick.AddListener(Click);
    }

    private void Update()
    {
        
        int note = int.Parse(buttonID.Substring(0, 2));
        int layer = int.Parse(buttonID.Substring(2, 2));

        if (s.notes[note].currentlyPlaying[layer])
        {
            if (s.currentNote == note)
            {
                b.image.color = colors[layer];
            }
            else
            {
                b.image.color = colors[layer];
            }
        }
        else
        {
            if (s.currentNote == note)
            {
                b.image.color = Color.grey;
            }
            else
            {
                b.image.color = Color.white;
            }
        }
    }

    //void Click()
    //{
    //    s.ToggleNote(buttonID);
    //}
}
