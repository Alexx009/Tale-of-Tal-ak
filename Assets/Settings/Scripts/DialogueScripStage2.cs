using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueScripStage2 : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioSource ambianceSource;
    public AudioClip[] playerHurtSfx;
    public AudioClip[] playerDeadSfx;
    public AudioClip[] playerFinishSfx;
    public AudioClip[] playerStartfx;
    public AudioClip[] catchPhrase;

    public AudioClip[] ambiance;
    public AudioClip trickySfx;
    private int dialogueIndex;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("StartSFX", 2f);
        Invoke("Ambiance", 5f);
        Invoke("CatchPhrase", 5f);
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

    void CatchPhrase()
    {
        dialogueIndex = Random.Range(0, catchPhrase.Length);
        audioSource.PlayOneShot(catchPhrase[dialogueIndex]);
        Invoke("DialoguePlay", Random.Range(10, 20));
    }
    void Ambiance()
    {
        dialogueIndex = Random.Range(0, ambiance.Length);
        ambianceSource.PlayOneShot(ambiance[dialogueIndex]);
        Invoke("DialoguePlay", Random.Range(5, 10));
    }
    public void Finish()
    {
        dialogueIndex = Random.Range(0, playerFinishSfx.Length);
        audioSource.PlayOneShot(playerFinishSfx[dialogueIndex]);
    }
    public void StartSFX()
    {
        dialogueIndex = Random.Range(0, playerStartfx.Length);
        audioSource.PlayOneShot(playerStartfx[dialogueIndex]);
    }
    public void Tricky()
    {
        audioSource.PlayOneShot(trickySfx);
    }
}
