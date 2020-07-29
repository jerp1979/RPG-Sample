using UnityEngine;
using RPG.Movement;

namespace RPG.Control
{
  public class PlayerController : MonoBehaviour
  {
    [SerializeField] Camera camera;

    Move move;

    private void Start()
    {
      move = GetComponent<Move>();
    }

    private void LateUpdate()
    {
      if (Input.GetMouseButton(0))
      {
        MoveToCursor();
      }
    }

    private void MoveToCursor()
    {
      Ray ray = camera.ScreenPointToRay(Input.mousePosition);
      // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
      RaycastHit hit;

      bool hasHit = Physics.Raycast(ray, out hit);

      if (hasHit)
      {
        move.MoveTo(hit.point);
      }
    }
  }
}