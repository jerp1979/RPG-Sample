
namespace RPG.Combat
{
  using UnityEngine;

  public class Fighter : MonoBehaviour
  {
    public void Attack(CombatTarget target)
    {
      if (!string.IsNullOrEmpty(target.TargetName()))
      {
        print($"Die, {target.TargetName()}");
      }
      else
      {
        print("Die, Rebel Scumm!!!");
      }
    }
  }
}