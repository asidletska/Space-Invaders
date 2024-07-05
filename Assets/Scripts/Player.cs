using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public ProjectTile laserPrefab;
    public float speed = 5.0f;
    private bool _laserActive;

    private void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) ) 
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        if (!_laserActive)
        {
            ProjectTile projecttile = Instantiate(laserPrefab, transform.position, Quaternion.identity);
            projecttile.destroyed += LaserDestroyed;
            _laserActive = true;
        }
    }
    private void LaserDestroyed()
    {
        _laserActive = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Invader")|| other.gameObject.layer == LayerMask.NameToLayer("Missile")) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
