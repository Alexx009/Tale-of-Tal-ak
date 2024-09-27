using System.Collections;
using UnityEngine;

public class playerPunch : MonoBehaviour {
    public Animator punchAnimator;
    public KeyCode leftPunchKey = KeyCode.Mouse0;
    public KeyCode rightPunchKey = KeyCode.Mouse1;

    private bool isLeftPunchRunning = false;
    private bool isRightPunchRunning = false;

    public Camera mainCamera;
    public float rayLength;
    public LayerMask layerMask;

    public cameraShake cameraShake;

    public enemyFollow enemyFollow;

void Start()
{
    // Get a reference to the CameraShake script attached to the main camera
    cameraShake = Camera.main.GetComponent<cameraShake>();
}

    


    public float kbforce = 10f;
    private float kbtimer = 0f;

    public float knockbackDistanceThreshold = 5f;

    private Vector3 kbdirection;


    private void Update() {


        if (kbtimer > 0)
        {
            // Move the object in the knockback direction
            transform.position += kbdirection * kbforce * Time.deltaTime;

            // Reduce the knockback timer
            kbtimer -= Time.deltaTime;
        }

        if (Input.GetKeyDown(leftPunchKey) && !isLeftPunchRunning) {
            StartCoroutine(PerformLeftPunch());

            RaycastHit hit;
            Vector3 centerScreen = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);
            Ray ray = mainCamera.ScreenPointToRay(centerScreen);

            if (Physics.Raycast(ray, out hit, rayLength, layerMask)) {
                if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Enemy")) {
                    enemyHealth enemy = hit.transform.gameObject.GetComponent<enemyHealth>();
                    if (enemy != null) {
                        enemy.TakeDamage(10);

                        cameraShake.TriggerShake();
                        // Calculate the knockback direction
                        Vector3 knockbackDirection = (enemy.transform.position - transform.position).normalized;
                        
                        // Apply the knockback force to the enemy's Rigidbody
                        Rigidbody enemyRigidbody = hit.transform.gameObject.GetComponent<Rigidbody>();
                        if (enemyRigidbody != null) {
                            float distance = Vector3.Distance(transform.position, enemy.transform.position);
                            float knockbackForceScaled = kbforce * Mathf.Clamp01(1f - distance / knockbackDistanceThreshold);
                            enemyRigidbody.AddForce(knockbackDirection * knockbackForceScaled, ForceMode.Impulse);
                            
                        }
                    }
                }
            }
        }

        if (Input.GetKeyDown(rightPunchKey) && !isRightPunchRunning) {
            StartCoroutine(PerformRightPunch());

            RaycastHit hit;
            Vector3 centerScreen = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);
            Ray ray = mainCamera.ScreenPointToRay(centerScreen);

            if (Physics.Raycast(ray, out hit, rayLength, layerMask)) {
                if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Enemy")) {
                    enemyHealth enemy = hit.transform.gameObject.GetComponent<enemyHealth>();
                    if (enemy != null) {
                        enemy.TakeDamage(10);

                        cameraShake.TriggerShake();

                        // Calculate the knockback direction
                        Vector3 knockbackDirection = (enemy.transform.position - transform.position).normalized;

                        // Apply the knockback force to the enemy's Rigidbody
                        Rigidbody enemyRigidbody = hit.transform.gameObject.GetComponent<Rigidbody>();
                        if (enemyRigidbody != null) {
                            float distance = Vector3.Distance(transform.position, enemy.transform.position);
                            float knockbackForceScaled = kbforce * Mathf.Clamp01(1f - distance / knockbackDistanceThreshold);
                            enemyRigidbody.AddForce(knockbackDirection * knockbackForceScaled, ForceMode.Impulse);
                        }
                    }
                }
            }
        }

    }

    IEnumerator PerformLeftPunch() {
        punchAnimator.SetBool("isHit1", false);
        isLeftPunchRunning = true;
        punchAnimator.SetBool("isHit", true);
       // enemyFollow.followPlayer = false;
        yield return new WaitForSeconds(0.5f);
        punchAnimator.SetBool("isHit", false);
        isLeftPunchRunning = false;
        
        yield return new WaitForSeconds(1f);
       // enemyFollow.followPlayer = true;

    }

    IEnumerator PerformRightPunch() {
        punchAnimator.SetBool("isHit", false);
        isRightPunchRunning = true;
        punchAnimator.SetBool("isHit1", true);
        //enemyFollow.followPlayer = false;
        yield return new WaitForSeconds(0.5f);
        punchAnimator.SetBool("isHit1", false);
        isRightPunchRunning = false;
        yield return new WaitForSeconds(1f);
        //enemyFollow.followPlayer = true;
    }
}
