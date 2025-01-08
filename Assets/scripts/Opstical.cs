using UnityEngine;

public class Opstical : MonoBehaviour
{
    private float zone;
    private void Start()
    {
        zone = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 2f;
    }
    private void Update()
    {
        transform.position += Vector3.left * GameManager.Instance.gameSpeed * Time.deltaTime;
        if(transform.position.x < zone)
        {
            Destroy(gameObject);
        }
    }
}
