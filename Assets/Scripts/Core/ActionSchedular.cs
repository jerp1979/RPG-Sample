using UnityEngine;

namespace RPG.Core
{

  public class ActionSchedular : MonoBehaviour
  {
    MonoBehaviour currentAction;
    public void StartAction(MonoBehaviour action)
    {
      if (currentAction == action) return;

      if (currentAction != null)
      {
        print("Canceling action " + currentAction);
      }
      currentAction = action;

    }
  }
}