using RPG.Combat;
using UnityEngine;
using UnityEngine.AI;
using RPG.Core;

namespace RPG.Movement
{
  public class Move : MonoBehaviour
  {
    // [SerializeField] GameObject target;

    Ray lastRay;
    NavMeshAgent agent;
    Animator animator;
    ActionSchedular actionSchedular;

    private void Start()
    {
      agent = GetComponent<NavMeshAgent>();
      animator = GetComponent<Animator>();
      actionSchedular = GetComponent<ActionSchedular>();
      // agent.destination = target.transform.position;
    }

    private void Update()
    {
      UpdateAnimator();
      // Debug.DrawRay(lastRay.origin, lastRay.direction * 100);
    }

    public void StartMoveAction(Vector3 destination)
    {
      actionSchedular.StartAction(this);
      GetComponent<Fighter>().Cancel();
      MoveTo(destination);
    }

    public void MoveTo(Vector3 destination)
    {
      agent.destination = destination;
      agent.isStopped = false;
    }

    public void Stop()
    {
      agent.isStopped = true;
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