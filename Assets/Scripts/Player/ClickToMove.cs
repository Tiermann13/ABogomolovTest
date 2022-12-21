using UnityEngine;

public class ClickToMove : MonoBehaviour
{
    [SerializeField] 
    private float speed = 4.0f;

    private bool isMoving = false;
    private Vector3 targetPosition;
    private Quaternion rotationToTarget;
    
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            SetTargetPosition();
            RotateToTarget();
            isMoving = true;
        }
        if (isMoving)
        {
            MoveToTarget();
        }
    }

    private void SetTargetPosition()
    {
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPosition.z = transform.position.z;
    }

    private void RotateToTarget()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.forward, targetPosition - transform.position); 
    }
    
    private void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (transform.position == targetPosition)
        {
            isMoving = false;
        }
    }
}
