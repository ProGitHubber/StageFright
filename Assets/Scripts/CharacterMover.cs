using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMover : MonoBehaviour
{
    public Image currentCharacterPortrait;
    public GameObject moveEffect;
    public Character character;

    public LayerMask playermask, floormask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, playermask))
            {
                Character c = hit.collider.gameObject.GetComponentInParent<Character>();
                if (c)
                {
                    //effects go here
                    currentCharacterPortrait.sprite = c.portrait;
                    //all your characters are now mine
                    character = c;
                }
            }
        }

        if (character)
        {
            if (Input.GetButton("Fire2"))
            {
                Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit2;
                if (Physics.Raycast(ray2, out hit2, floormask))
                {
                    character.target.position = hit2.point;
                }
            }
        }

    }
}
