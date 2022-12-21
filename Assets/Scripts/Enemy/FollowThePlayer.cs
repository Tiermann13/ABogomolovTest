using UnityEngine;

public class FollowThePlayer : MonoBehaviour
{
    [SerializeField] 
    private float speed = 2.0f;
    
    private GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if(!player) return;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, player.transform.position - transform.position);
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
}
