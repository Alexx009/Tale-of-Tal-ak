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
    


    public float kbforce = 10f;
    public float kbduration = 0.5f;
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
        isLeftPunchRunning = true;
        punchAnimator.SetBool("isHit", true);
        yield return new WaitForSeconds(1.0f);
        punchAnimator.SetBool("isHit", false);
        isLeftPunchRunning = false;
    }

    IEnumerator PerformRightPunch() {
        isRightPunchRunning = true;
        punchAnimator.SetBool("isHit1", true);
        yield return new WaitForSeconds(1.0f);
        punchAnimator.SetBool("isHit1", false);
        isRightPunchRunning = false;
    }
}
