using UnityEngine;
using UnityEngine.AI;

public class Move : MonoBehaviour
{
  // [SerializeField] GameObject target;
  [SerializeField] Camera camera;

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
    if (Input.GetMouseButton(0))
    {
      MoveToCursor();
    }

    UpdateAnimator();
    // Debug.DrawRay(lastRay.origin, lastRay.direction * 100);
  }

  private void MoveToCursor()
  {
    Ray ray = camera.ScreenPointToRay(Input.mousePosition);
    // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    RaycastHit hit;

    bool hasHit = Physics.Raycast(ray, out hit);

    if (hasHit)
    {
      agent.destination = hit.point;
    }
  }

  private void UpdateAnimator()
  {
    Vector3 velocity = agent.velocity;
    Vector3 localVelocity = transform.InverseTransformDirection(velocity);

    float speed = localVelocity.z;

    animator.SetFloat("forwardSpeed", speed);
  }
}