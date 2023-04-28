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

    private void Update() {
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
