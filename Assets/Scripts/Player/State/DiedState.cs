using UnityEngine;
using UnityEngine.Events;

public class DiedState : EnemyState
{
    [SerializeField] private float _fallDistance;

    public event UnityAction Died;

    public void ApplyDamage(Rigidbody attachedBody, float force)
    {
        Debug.Log("falling");

        Vector3 direction = (transform.position - attachedBody.position);
        direction.y = 0;
        Ridgibody.AddForce(direction.normalized * force, ForceMode.Impulse);
    }

    private void FixedUpdate()
    {
        Ray ray = new Ray(transform.position + Vector3.up, Vector3.down);

        if(Physics.Raycast(ray, _fallDistance) == false)
        {
            Ridgibody.constraints = RigidbodyConstraints.None;
            Died?.Invoke();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (enabled == false)
            return;

        if (other.TryGetComponent(out IDamageable damageable))
            damageable.ApplyDamage(Ridgibody, Ridgibody.velocity.magnitude);
    }
}
