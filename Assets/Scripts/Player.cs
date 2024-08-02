using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public ProjectTile laserPrefab;
    public float speed = 5.0f;
    private bool _laserActive;

    private Camera mainCamera;
    private float screenLeftLimit;
    private float screenRightLimit;
    private float screenTopLimit;
    private float screenBottomLimit;
    private float playerWidth;
    private float playerHeight;


    public UnityEvent laser;

    private void Start()
    {
        mainCamera = Camera.main;
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        playerWidth = renderer.bounds.size.x / 2;
        playerHeight = renderer.bounds.size.y / 2;        
        screenLeftLimit = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, 0)).x + playerWidth;
        screenRightLimit = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x - playerWidth;
        screenBottomLimit = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, 0)).y + playerHeight;
        screenTopLimit = mainCamera.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y - playerHeight;
    }
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

        // ќбмеженн€ руху гравц€ в межах екрану
        float xClamp = Mathf.Clamp(transform.position.x, screenLeftLimit, screenRightLimit);
        float yClamp = Mathf.Clamp(transform.position.y, screenBottomLimit, screenTopLimit);
        transform.position = new Vector3(xClamp, yClamp, transform.position.z);
    }
    private void Shoot()
    {
        if (!_laserActive)
        {
            laser.Invoke();
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
            FindObjectOfType<GameManager>().GameOver();            
        }
    }
}
