using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueScripStage2 : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] playerHurtSfx;
    public AudioClip[] playerDeadSfx;
    public AudioClip[] playerFinishSfx;
    public AudioClip trickySfx;
    private int dialogueIndex;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Dead", 2f);
    }

    public void Hurt()
    {
        dialogueIndex = Random.Range(0, playerHurtSfx.Length);
        audioSource.PlayOneShot(playerHurtSfx[dialogueIndex]);
    }

    public void Dead()
    {
        dialogueIndex = Random.Range(0, playerDeadSfx.Length);
        audioSource.PlayOneShot(playerDeadSfx[dialogueIndex]);
    }
    public void Finish()
    {
        dialogueIndex = Random.Range(0, playerFinishSfx.Length);
        audioSource.PlayOneShot(playerFinishSfx[dialogueIndex]);
    }
    public void Tricky()
    {
        audioSource.PlayOneShot(trickySfx);
    }
}
