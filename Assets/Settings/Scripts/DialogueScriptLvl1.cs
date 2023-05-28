using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueScriptLvl1 : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioSource ambianceSource;
    public AudioClip[] dialogueSfx;
    public AudioClip[] getKeyDialogue;
    public AudioClip[] ambianceSfx;
    public AudioClip[] catchPhrase;
    public AudioClip startDialogue;
    public AudioClip findPalawDialogue;
    public AudioClip missionDialogue;

    private int dialogueIndex;
    // Start is called before the first frame update
    void Start()
    {

        Invoke("StartDialogue", 7f);
        Invoke("MissionAudio", 15f);
        Invoke("DialoguePlay", 60f);
        Invoke("AmbianceSfx", 20f);


    }


    void StartDialogue()
    {
        audioSource.PlayOneShot(startDialogue);
    }
    void MissionAudio()
    {
        audioSource.PlayOneShot(missionDialogue);
    }
    void DialoguePlay()
    {
        dialogueIndex = Random.Range(0, dialogueSfx.Length);
        audioSource.PlayOneShot(dialogueSfx[dialogueIndex]);
        Invoke("DialoguePlay", Random.Range(10, 30));
    }
    void AmbianceSfx()
    {
        dialogueIndex = Random.Range(0, ambianceSfx.Length);
        ambianceSource.PlayOneShot(ambianceSfx[dialogueIndex]);
        Invoke("ambiance play", Random.Range(1, 3));
    }
    void CatchPhrase()
    {
        dialogueIndex = Random.Range(0, catchPhrase.Length);
        audioSource.PlayOneShot(catchPhrase[dialogueIndex]);
        Invoke("DialoguePlay", Random.Range(10, 20));
    }

    public void GetKeyAudio()
    {
        dialogueIndex = Random.Range(0, dialogueSfx.Length);
        audioSource.PlayOneShot(getKeyDialogue[dialogueIndex]);
    }
    public void FindPalawAudio()
    {
        audioSource.PlayOneShot(findPalawDialogue);
    }
}
