using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator m_Animator;
    private void OnTriggerEnter(Collider cldr)
    {
        if(cldr.gameObject.tag == "Player")
        {
            m_Animator.SetBool("Open", true);
        }
    }

    private void OnTriggerExit(Collider cldr)
    {
        if (cldr.gameObject.tag == "Player")
        {
            m_Animator.SetBool("Open", false);
        }
    }
}
