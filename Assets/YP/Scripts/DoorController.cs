using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public AudioClip doorBell;
    private AudioSource audioSource;
    private Animator animator;

    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        animator = this.GetComponent<Animator>();
    }

    public void DoorOpen()
    {
        animator.SetTrigger("isOpen");
        audioSource.PlayOneShot(doorBell);
    }
}
