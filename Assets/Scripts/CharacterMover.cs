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

    int currentCharacter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            SwitchToCharacter(0);
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            SwitchToCharacter(1);
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            SwitchToCharacter(2);
        }
        if (Input.GetKey(KeyCode.Alpha4))
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
            if (Input.GetButton("Fire1"))
            {
                Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit2;
                if (Physics.Raycast(ray2, out hit2, floormask))
                {
                    character.transform.rotation = Quaternion.Lerp(character.transform.rotation, Quaternion.LookRotation((hit2.point - character.transform.position).normalized), 10 * Time.deltaTime);
                    character.transform.localEulerAngles = new Vector3(0, character.transform.localEulerAngles.y, 0);
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
