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
      if (InteractWithCombat()) return;

      if (InteractWithMovement()) return;

    }

    private bool InteractWithCombat()
    {
      RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());

      foreach (RaycastHit hit in hits)
      {
        var combatTarget = hit.transform.gameObject.GetComponent<CombatTarget>();
        if (combatTarget == null) continue;

        if (Input.GetMouseButtonDown(0))
        {
          fighter.Attack(combatTarget);
        }

        return true;
      }

      return false;
    }

    private bool InteractWithMovement()
    {
      RaycastHit hit;

      bool hasHit = Physics.Raycast(GetMouseRay(), out hit);

      if (hasHit)
      {
        if (Input.GetMouseButton(0))
        {
          move.MoveTo(hit.point);
        }
      }
      return hasHit;
    }

    private Ray GetMouseRay()
    {
      return camera.ScreenPointToRay(Input.mousePosition);
    }
  }
}