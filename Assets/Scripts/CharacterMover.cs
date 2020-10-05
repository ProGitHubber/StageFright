using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMover : MonoBehaviour
{
    public Image currentCharacterPortrait;
    public GameObject moveEffect;
    public BandMember character;
    public BandMember[] playableCharacters;

    public LayerMask playermask, floormask;

    public Transform controlCircle;

    int currentCharacter;

    Sequencer s;
    // Start is called before the first frame update
    void Start()
    {
        s = FindObjectOfType<Sequencer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!character && s.playing)
        {
            SwitchToCharacter(0);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.Alpha1))
        {
            SwitchToCharacter(0);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.Alpha2))
        {
            SwitchToCharacter(1);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.Alpha3))
        {
            SwitchToCharacter(2);
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Alpha4))
        {
            SwitchToCharacter(3);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            int newChar = currentCharacter - 1;
            if (newChar < 0)
            {
                newChar = playableCharacters.Length-1;
            }
            SwitchToCharacter(newChar);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            int newChar = currentCharacter + 1;
            if (newChar >= playableCharacters.Length)
            {
                newChar = 0 ;
            }
            SwitchToCharacter(newChar);
        }

        if (character)
        {
            controlCircle.position = character.transform.position + Vector3.up * 0.1f;
            if (Input.GetButton("Fire1"))
            {
                Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit2;
                if (Physics.Raycast(ray2, out hit2, floormask))
                {
                    character.directionIndicator.position = hit2.point + Vector3.up * 0.01f;
                }
            }
        }

    }

    void SwitchToCharacter(int CHAR)
    {
        currentCharacter = CHAR;
        if (character)
        {
            character.controlled = false;

        }
        character = playableCharacters[CHAR];
        character.controlled = true;
        currentCharacterPortrait.sprite = character.portrait;
        character.selectionCircle.SetActive(true);
    }
}
