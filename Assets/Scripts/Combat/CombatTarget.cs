namespace RPG.Combat
{
  using UnityEngine;

  public class CombatTarget : MonoBehaviour
  {
    [SerializeField] string targetName;

    public string TargetName()
    {
      return targetName;
    }

  }
}