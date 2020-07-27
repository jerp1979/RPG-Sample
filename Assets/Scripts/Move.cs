using UnityEngine;
using UnityEngine.AI;

public class Move : MonoBehaviour
{
  // [SerializeField] GameObject target;
  [SerializeField] Camera camera;

  Ray lastRay;

  NavMeshAgent agent;
  private void Start()
  {
    agent = GetComponent<NavMeshAgent>();
    // agent.destination = target.transform.position;
  }

  private void Update()
  {
    if (Input.GetMouseButtonDown(0))
    {
      MoveToCursor();
    }
    Debug.DrawRay(lastRay.origin, lastRay.direction * 100);
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
}