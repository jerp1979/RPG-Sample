using UnityEngine;
using RPG.Movement;
using RPG.Core;

namespace RPG.Combat
{



  public class Fighter : MonoBehaviour
  {
    [SerializeField] private float weaponRange = 2f;
    Transform target = null;

    ActionSchedular actionSchedular;

    private void Start()
    {
      actionSchedular = GetComponent<ActionSchedular>();
    }

    private void Update()
    {

      if (target == null) return;

      if (!IsInRange())
      {
        GetComponent<Move>().MoveTo(target.position);
      }
      else
      {
        GetComponent<Move>().Stop();
      }
    }

    private bool IsInRange()
    {
      return Vector3.Distance(transform.position, target.position) < weaponRange;
    }

    public void Attack(CombatTarget target)
    {
      actionSchedular.StartAction(this);
      this.target = target.transform;
    }

    public void Cancel()
    {
      target = null;
    }
  }
}