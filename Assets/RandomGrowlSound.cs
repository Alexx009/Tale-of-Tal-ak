using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomGrowlSound : MonoBehaviour
{
    public List<AudioClip> growlSounds;
    public float minDistance = 10f; // Minimum distance for the sound to be heard clearly
    public float maxDistance = 20f; // Maximum distance at which the sound can be heard

    public AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.spatialBlend = 1f; // Set to 3D audio
        audioSource.minDistance = minDistance;
        audioSource.maxDistance = maxDistance;

        StartCoroutine(PlayGrowlWithDelay());
    }

    private IEnumerator PlayGrowlWithDelay()
    {
        while (true)
        {
            PlayRandomGrowl();
            yield return new WaitForSeconds(Random.Range(3f, 10f)); // Adjust the delay as desired
        }
    }

    public void PlayRandomGrowl()
    {
        if (growlSounds.Count == 0)
        {
            Debug.LogWarning("No growl sounds assigned!");
            return;
        }

        int randomIndex = Random.Range(0, growlSounds.Count);
        AudioClip randomClip = growlSounds[randomIndex];
        audioSource.PlayOneShot(randomClip);
    }
}
