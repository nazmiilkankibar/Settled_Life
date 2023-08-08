using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    private Animator anim;
    private int randomInt;
    private void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(RandomNumber());
    }
    private void Update()
    {
        anim.SetInteger("Idle", randomInt);
    }
    IEnumerator RandomNumber()
    {
        while (true)
        {
            randomInt = Random.Range(0, 2);
            yield return new WaitForSeconds(1);
        }
    }
}
