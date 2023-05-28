using UnityEngine;

public class slide : MonoBehaviour
{
    public float slideAngleThreshold = 25f;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        SlideObject();
    }

    private void SlideObject()
    {
        float slopeAngle = Vector3.Angle(Vector3.up, transform.up);
        if (slopeAngle > slideAngleThreshold)
        {
            Vector3 slideDirection = Vector3.Cross(transform.up, Vector3.up);
            rb.AddForce(slideDirection * rb.mass * Physics.gravity.magnitude);
            rb.AddForce(rb.velocity * -1f);
        }
    }
}
