using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform camPos;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = camPos.position;

    }
}
