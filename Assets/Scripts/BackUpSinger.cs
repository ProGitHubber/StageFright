using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackUpSinger : MonoBehaviour
{
    public float lifeTime;
    // Start is called before the first frame update
    private void OnEnable()
    {
        Invoke("DisableSelf", lifeTime);
    }
    void DisableSelf()
    {
        gameObject.SetActive(false);
    }
}
