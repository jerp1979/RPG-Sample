using UnityEngine;
using UnityEngine.AI;

namespace RPG.Movement
{
  public class Move : MonoBehaviour
  {
    // [SerializeField] GameObject target;

    Ray lastRay;
    NavMeshAgent agent;
    Animator animator;

    private void Start()
    {
      agent = GetComponent<NavMeshAgent>();
      animator = GetComponent<Animator>();
      // agent.destination = target.transform.position;
    }

    private void Update()
    {
      UpdateAnimator();
      // Debug.DrawRay(lastRay.origin, lastRay.direction * 100);
    }

    public void MoveTo(Vector3 destination)
    {
      agent.destination = destination;
    }

    private void UpdateAnimator()
    {
      Vector3 velocity = agent.velocity;
      Vector3 localVelocity = transform.InverseTransformDirection(velocity);

      float speed = localVelocity.z;

      animator.SetFloat("forwardSpeed", speed);
    }
  }
}