using UnityEngine;
using System.Collections;

public class OctofoodAttack : MonoBehaviour
{
    public Animator tentacle1;
    public Animator tentacle2;
    public Animator tentacle3;
    public Animator tentacle4;
    public Animator tentacle5;
    public Animator tentacle6;

    public string parameterName = "isAttack";

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T)){
            StartCoroutine(AnimateTentacles());
        } 
    }

    IEnumerator AnimateTentacles()
    {
        while (true)
        {
            // Wait for 3 seconds
            yield return new WaitForSeconds(3f);

            // Create a random boolean parameter for each tentacle Animator
            tentacle1.SetBool(parameterName, Random.Range(0, 10) == 1);
            tentacle2.SetBool(parameterName, Random.Range(0, 10) == 1);
            tentacle3.SetBool(parameterName, Random.Range(0, 10) == 1);
            tentacle4.SetBool(parameterName, Random.Range(0, 10) == 1);
            tentacle5.SetBool(parameterName, Random.Range(0, 10) == 1);
            tentacle6.SetBool(parameterName, Random.Range(0, 10) == 1);
        }
    }

}
