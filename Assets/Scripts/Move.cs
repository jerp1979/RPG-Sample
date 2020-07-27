using UnityEngine;
using UnityEngine.AI;

public class Move : MonoBehaviour
{
  [SerializeField] GameObject target;

  NavMeshAgent agent;
  private void Start()
  {
    agent = GetComponent<NavMeshAgent>();
    agent.destination = target.transform.position;
  }
}