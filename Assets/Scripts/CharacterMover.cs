using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMover : MonoBehaviour
{
    public Image currentCharacterPortrait;
    public GameObject moveEffect;
    public Character character;
    public Character[] playableCharacters;

    public LayerMask playermask, floormask;
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
            SwitchToCharacter(3);
        }
        
        if (character && !character.grabbed)
        {
            
            if (Input.GetButton("Fire1"))
            {
                character.instrument.LightAttack();
            }

            Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit2;
            if (Physics.Raycast(ray2, out hit2, floormask))
            {
                character.transform.rotation = Quaternion.Lerp(character.transform.rotation, Quaternion.LookRotation((hit2.point - character.transform.position).normalized), 10 * Time.deltaTime);
                character.transform.localEulerAngles = new Vector3(0, character.transform.localEulerAngles.y, 0);
                if (Input.GetButton("Fire2"))
                {
                    character.target.position = hit2.point;
                }
            }
        }

    }

    void SwitchToCharacter(int CHAR)
    {
        character = playableCharacters[CHAR];
        currentCharacterPortrait.sprite = character.portrait;
    }
}
