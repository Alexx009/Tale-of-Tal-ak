using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueScriptLvl1 : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip[] dialogueSfx;
    public AudioClip[] getKeyDialogue;
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


    }

    // Update is called once per frame
    void Update()
    {

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

    public void GetKeyAudio()
    {
        dialogueIndex = Random.Range(0, dialogueSfx.Length);
        audioSource.PlayOneShot(getKeyDialogue[dialogueIndex]);
    }
    public void FindPalawAudio()
    {
        dialogueIndex = Random.Range(0, dialogueSfx.Length);
        audioSource.PlayOneShot(getKeyDialogue[dialogueIndex]);
    }
}
