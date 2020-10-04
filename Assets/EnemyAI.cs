using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAI : MonoBehaviour
{
    Character me;
    List<Character> targets = new List<Character>();
    public bool hit;

    public Transform home;
    bool goingHome;
    // Start is called before the first frame update
    void Start()
    {
        home = new GameObject().transform;
        home.position = transform.position;
        me = GetComponent<Character>();
        Invoke("CompileList", 0.1f);
        me.onTargetReached.AddListener(ReturnHome);
    }


    void CompileList()
    {
        targets.Clear();
        Character[] cs = FindObjectsOfType<Character>();
        foreach (Character c in cs)
        {
            if (c.mainCharacter)
            {
                targets.Add(c);
            }
        }
        PickRandomTarget();
    }

    void PickRandomTarget()
    {
        me.target = targets[Random.Range(0, targets.Count)].transform;
    }

    void ReturnHome()
    {
        if (!goingHome)
        {
            me.target.GetComponent<Character>().grabbedBy = me;
            me.target = home;
            goingHome = true;
        }
        else
        { 
            gameObject.SetActive(false);
        }
    }


    private void OnParticleTrigger()
    {
        
    }
}
