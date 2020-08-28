using UnityEngine;

namespace RPG.Core
{

  public class ActionSchedular : MonoBehaviour
  {
    IAction currentAction;
    public void StartAction(IAction action)
    {
      if (currentAction == action) return;

      if (currentAction != null)
      {
        print("Canceling action " + currentAction);
        currentAction.Cancel();
      }
      currentAction = action;

    }
  }
}