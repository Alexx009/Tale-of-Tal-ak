using UnityEngine;

public class savePoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UpdateRespawnPoint();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            UpdateRespawnPoint();
        }
    }

    private void UpdateRespawnPoint()
    {
        // Update the respawn point to the location of this save point
        PlayerPrefs.SetFloat("RespawnX", transform.position.x);
        PlayerPrefs.SetFloat("RespawnY", transform.position.y);
        PlayerPrefs.SetFloat("RespawnZ", transform.position.z);

        Debug.Log("Respawn point updated to: " + transform.position);
    }
}
