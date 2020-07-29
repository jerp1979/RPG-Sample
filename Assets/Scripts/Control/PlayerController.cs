using UnityEngine;
using RPG.Movement;
using RPG.Combat;

namespace RPG.Control
{
  public class PlayerController : MonoBehaviour
  {
    [SerializeField] Camera camera;

    Move move;
    Fighter fighter;

    private void Start()
    {
      move = GetComponent<Move>();
      fighter = GetComponent<Fighter>();
    }

    private void LateUpdate()
    {
      InteractWithCombat();
      InteractWithMovement();
    }

    private void InteractWithCombat()
    {
      if (Input.GetMouseButtonDown(0))
      {

        RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());

        foreach (RaycastHit hit in hits)
        {
          var combatTarget = hit.transform.gameObject.GetComponent<CombatTarget>();
          if (combatTarget != null)
          {
            fighter.Attack(combatTarget);
          }
        }
      }
    }

    private void InteractWithMovement()
    {
      if (Input.GetMouseButton(0))
      {
        MoveToCursor();
      }
    }

    private void MoveToCursor()
    {
      RaycastHit hit;

      bool hasHit = Physics.Raycast(GetMouseRay(), out hit);

      if (hasHit)
      {
        move.MoveTo(hit.point);
      }
    }

    private Ray GetMouseRay()
    {
      return camera.ScreenPointToRay(Input.mousePosition);
    }
  }
}