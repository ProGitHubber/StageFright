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

    //// Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKey(KeyCode.Alpha1))
    //    {
    //        SwitchToCharacter(0);
    //    }
    //    if (Input.GetKey(KeyCode.Alpha2))
    //    {
    //        SwitchToCharacter(1);
    //    }
    //    if (Input.GetKey(KeyCode.Alpha3))
    //    {
    //        SwitchToCharacter(2);
    //    }
        
    //    if (character && !character.grabbedBy)
    //    {
    //        Vector3 pos = character.target.transform.position;
    //        if (Input.GetKey(KeyCode.W)) //|| Input.mousePosition.y >= Screen.height - (Screen.height * mouseDeadZone))
    //        {
    //            pos.z -= character.moveSpeed * Time.deltaTime;
    //        }
    //        if (Input.GetKey(KeyCode.S)) //|| Input.mousePosition.y <= (Screen.height * mouseDeadZone))
    //        {
    //            pos.z += character.moveSpeed * Time.deltaTime;
    //        }
    //        if (Input.GetKey(KeyCode.A)) //|| Input.mousePosition.x >= (Screen.width * mouseDeadZone))
    //        {
    //            pos.x += character.moveSpeed * Time.deltaTime;
    //        }
    //        if (Input.GetKey(KeyCode.D)) //|| Input.mousePosition.x <= Screen.width - (Screen.width * mouseDeadZone))
    //        {
    //            pos.x -= character.moveSpeed * Time.deltaTime;
    //        }
    //        character.target.transform.position = pos;
    //        //if (Input.GetButton("Fire1"))
    //        //{
    //        //    character.instrument.LightAttack();
    //        //}

    //        Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);
    //        RaycastHit hit2;
    //        if (Physics.Raycast(ray2, out hit2, floormask))
    //        {
    //            character.transform.rotation = Quaternion.Lerp(character.transform.rotation, Quaternion.LookRotation((hit2.point - character.transform.position).normalized), 10 * Time.deltaTime);
    //            character.transform.localEulerAngles = new Vector3(0, character.transform.localEulerAngles.y, 0);
    //            //if (Input.GetButton("Fire2"))
    //            //{
    //            //    character.target.position = hit2.point;
    //            //}
    //        }
    //    }

    //}

    void SwitchToCharacter(int CHAR)
    {
        if (character)
        {
            character.controlled = false;
            character.selectionCircle.SetActive(false);
        }
        character = playableCharacters[CHAR];
        character.controlled = true;
        currentCharacterPortrait.sprite = character.portrait;
        character.selectionCircle.SetActive(true);
    }
}
