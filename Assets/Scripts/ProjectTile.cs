using System;
using UnityEngine;

public class ProjectTile : MonoBehaviour
{
    public Vector3 direction;
    public float speed;
    public Action destroyed;


    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (destroyed != null)
        {
            destroyed.Invoke();
            
        }
        Destroy(gameObject);
    }
}
