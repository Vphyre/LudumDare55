using UnityEngine;
using UnityEngine.Events;

public class CollisionDetector : MonoBehaviour
{
    [SerializeField] private string targetTag;
    public UnityEvent onCollisionEnter;
    public UnityEvent onCollisionStay;
    public UnityEvent onCollisionExit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(targetTag))
        {
            onCollisionEnter.Invoke();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag(targetTag))
        {
            onCollisionStay.Invoke();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(targetTag))
        {
            onCollisionExit.Invoke();
        }
    }
    public void SetTargetTag(string newTag)
    {
        targetTag = newTag;
    }
}
