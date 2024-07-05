using UnityEngine;
using UnityEngine.SceneManagement;

public class Invader : MonoBehaviour
{
    public Invaders[] prefabs; 
    public int rows = 5;
    public int columns = 11;
    public AnimationCurve speed;
    public ProjectTile missilePrefab;
    public float missileAttackRate = 1.0f;
    public int invadersKilled {  get; private set; }
    public int amountAlive => totalInvaders - invadersKilled;
    public int totalInvaders => rows * columns;
    public float percentKilled => (float)invadersKilled / (float)totalInvaders;
    private Vector3 _direction = Vector2.right;
    private void Awake()
    {
        for (int row = 0; row < rows; row++)
        {
            float width = 2.0f * (columns - 1);
            float height = 2.0f * (rows - 1);
            Vector3 centering = new Vector3(-width / 2, -height / 2);
            Vector3 rowPosition = new Vector3(centering.x, centering.y + (row * 2.0f), 0.0f );
            for (int column = 0; column < columns; column++)
            {
                Invaders invader = Instantiate(prefabs[row], transform);
                invader.killed += InvaderKilled;
                Vector3 position = rowPosition;
                position.x += column * 2.0f;
                invader.transform.localPosition = position;
            }
        }
    }
    private void Start()
    {
        InvokeRepeating(nameof(MissileAttack), missileAttackRate, missileAttackRate);
    }
    private void Update()
    {
        transform.position += _direction * speed.Evaluate(percentKilled) * Time.deltaTime;
        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);
        foreach (Transform invader in transform)
        {
            if (!invader.gameObject.activeInHierarchy)
            {
                continue;
            }
            if (_direction == Vector3.right && invader.position.x >= rightEdge.x - 1.0f)
            {
                Advancerow();
            }
            else if (_direction == Vector3.left && invader.position.x <= leftEdge.x + 1.0f)
            {
                Advancerow();
            }
        }
    }
    private void Advancerow()
    {
        _direction.x *= -1.0f;
        Vector3 position = transform.position;
        position.y -= 1.0f;
        transform.position = position;
    }
    private void MissileAttack()
    {
        foreach (Transform invader in transform)
        {
            if (!invader.gameObject.activeInHierarchy)
            {
                continue;
            }
            if (Random.value < (1.0f / (float)amountAlive))
            {
                Instantiate(missilePrefab, invader.position, Quaternion.identity);
                break;
            }
        }
    }
    private void InvaderKilled()
    {
        invadersKilled++;

        if (invadersKilled >= totalInvaders)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}
