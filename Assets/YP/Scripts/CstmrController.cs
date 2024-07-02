//using Autohand.Demo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using UnityEngine;
using UnityEngine.AI;

public class CstmrController : MonoBehaviour
{
    [NonSerialized] public string cstmrStat;
    //private GameObject door;
    private GameObject chair;

    public GameObject gameover;

    private AudioSource talkSource;
    public AudioClip[] talkClips = new AudioClip[3];

    private bool[] playOnce = new bool[10];

    void Start()
    {
        cstmrStat = "walking";
        //door = ObjectManager.Instance.door;
        chair = ObjectManager.Instance.chair;

        gameover = ObjectManager.Instance.gameover;

        talkSource = this.GetComponent<AudioSource>();
    }

    void Update()
    {
        cstmrStatChecker();
    }

    private void cstmrStatChecker()
    {
        switch (cstmrStat)
        {
            case "walking":
                //this.GetComponent<NavMeshAgent>().SetDestination(door.transform.position);
                this.GetComponent<NavMeshAgent>().SetDestination(chair.transform.position);
                //if (this.GetComponent<NavMeshAgent>().remainingDistance < .2f)
                if (this.GetComponent<NavMeshAgent>().remainingDistance < 1f)
                {
                    //StartCoroutine(OpenDoor());
                    cstmrStat = "sittingDown";
                }
                break;

            case "sittingDown":
                this.GetComponent<NavMeshAgent>().SetDestination(chair.transform.position);
                if (this.GetComponent<NavMeshAgent>().remainingDistance < .1f)
                {
                    StartCoroutine(SitDown());
                }
                break;

            case "sittingIdle":
                this.GetComponent<Animator>().SetTrigger("sittingIdle");
                break;

            case "readingMenu":
                StartCoroutine(ReadMenu());
                break;

            case "sittingTalk":
                BaristaManager.Instance.CheckOrder();
                BaristaManager.Instance.ShowRecipe();
                SitTalk();
                break;

            case "matched":
                Debug.Log("matched");
                StartCoroutine(Matched());
                break;

            case "mismatched":
                Debug.Log("mismatched");
                StartCoroutine(MisMatched());
                break;
        }

    }

    //IEnumerator OpenDoor()
    //{
    //    if (!playOnce[0])
    //    {
    //        playOnce[0] = true;
    //        //doorController.DoorOpen();
    //    }
    //    yield return new WaitForSeconds(3);
    //    cstmrStat = "sittingDown";
    //}

    IEnumerator SitDown()
    {
        yield return new WaitForSeconds(1);
        this.GetComponent<Animator>().SetTrigger("sittingDown");
        yield return new WaitForSeconds(2);
        cstmrStat = "sittingIdle";
    }

    IEnumerator ReadMenu()
    {
        this.GetComponent<Animator>().SetTrigger("readMenu");
        yield return new WaitForSeconds(4);
        cstmrStat = "sittingTalk";
    }

    private void SitTalk()
    {
        if (!playOnce[2])
        {
            playOnce[2] = true;
            this.GetComponent<Animator>().SetTrigger("sittingTalk");
            talkSource.PlayOneShot(talkClips[0]);
        }
        if (!talkSource.isPlaying)
        {
            this.GetComponent<Animator>().SetTrigger("sittingIdle");
            cstmrStat = "sittingIdle";
        }
    }

    IEnumerator Matched()
    {
        this.GetComponent<Animator>().SetBool("sitDrink", true);
        yield return new WaitForSeconds(4);
        this.GetComponent<Animator>().SetTrigger("thumbsUp");
        if (!playOnce[3])
        {
            playOnce[3] = true;
            talkSource.PlayOneShot(talkClips[1]);
        }
        yield return new WaitForSeconds(4);
        this.GetComponent<Animator>().SetTrigger("sittingIdle");
        cstmrStat = "sittingIdle";
        yield return new WaitForSeconds(5);
        gameover.SetActive(true);

    }

    IEnumerator MisMatched()
    {
        this.GetComponent<Animator>().SetBool("sitDrink", true);
        yield return new WaitForSeconds(4);
        this.GetComponent<Animator>().SetTrigger("sittingTalk");
        if (!playOnce[4])
        {
            playOnce[4] = true;
            talkSource.PlayOneShot(talkClips[2]);
        }
        yield return new WaitForSeconds(4);
        this.GetComponent<Animator>().SetTrigger("sittingIdle");
        cstmrStat = "sittingIdle";
        yield return new WaitForSeconds(5);
        gameover.SetActive(true);
    }
}
