using UnityEngine;

public class CameraShakeTrigger : MonoBehaviour
{
    [SerializeField]
    private CameraShake cameraShake;

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            StartCoroutine(cameraShake.Shake(.15f, .4f));
        }
    }
}
