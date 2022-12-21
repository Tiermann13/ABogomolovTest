using UnityEngine;

public class RotateCanvasByPatent : MonoBehaviour
{
    private Canvas canvas;

    void Start()
    {
        canvas = GetComponent<Canvas>();
    }

    void Update()
    {
        canvas.transform.rotation = Quaternion.AngleAxis(-transform.parent.rotation.z, Vector3.forward);
    }
}
