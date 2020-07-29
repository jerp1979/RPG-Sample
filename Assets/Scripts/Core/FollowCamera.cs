using UnityEngine;

namespace RPG.Core
{
  public class FollowCamera : MonoBehaviour
  {
    [SerializeField] Transform target;
    // [SerializeField] Camera camera;
    private void Update()
    {
      // camera.transform.position = target.position;
      transform.position = target.position;
    }
  }

}