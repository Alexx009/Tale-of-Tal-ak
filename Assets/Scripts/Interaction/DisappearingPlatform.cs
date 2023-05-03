using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingPlatform : MonoBehaviour
{
    public float disappearTime; // time platform is invisible
    public float appearTime; // time platform is visible

    public List<GameObject> platforms;
    private List<float> originalYPos;

    void Start()
    {
        originalYPos = new List<float>();

        foreach (GameObject platform in platforms)
        {
            originalYPos.Add(platform.transform.position.y);
        }

        StartCoroutine(DisappearAndAppear());
    }

    IEnumerator DisappearAndAppear()
    {  
        while (true)
        {
            yield return new WaitForSeconds(5); // wait for platform to appear
            for (int i = 0; i < platforms.Count; i++)
            {
                yield return new WaitForSeconds(appearTime); // wait for platform to appear
                LeanTween.moveY(platforms[i], originalYPos[i] - 10f, 0.5f * (i + .5f)); // animate platform down
                yield return new WaitForSeconds(.5f); // wait for platform to finish animating
                platforms[i].SetActive(false); // make platform invisible
            }

            yield return new WaitForSeconds(2f); 

            for (int i = platforms.Count - 1; i >= 0; i--)
            {
                yield return new WaitForSeconds(disappearTime); // wait for platforms to disappear
                platforms[i].SetActive(true); // make platform visible again
                LeanTween.moveY(platforms[i], originalYPos[i], 1.5f); // animate platform up
                yield return new WaitForSeconds(.5f); // wait for platform to finish animating
            }
        }
    }
}
