using UnityEngine;
using RPG.Movement;
using RPG.Core;

namespace RPG.Combat
{



  public class Fighter : MonoBehaviour, IAction
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
        GetComponent<Move>().Cancel();
        AttackBehaviour();
      }
    }

    private void AttackBehaviour()
    {
      GetComponent<Animator>().SetTrigger("attack");
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

    // Animation Event
    void Hit()
    {

    }
  }
}