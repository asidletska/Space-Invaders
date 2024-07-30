using System;
using UnityEngine;

public class Invaders : MonoBehaviour
{
    public Sprite[] animationSprites;
    public float animationTime = 1.0f;
    public Action killed;
    private SpriteRenderer _spriteRenderer;

    private int _animationFrame;
    public int points = 1;
    private void Awake()
    {
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
    }
    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), animationTime, animationTime);

    }
    private void AnimateSprite()
    {
        _animationFrame++;

        if (_animationFrame >= animationSprites.Length)
        {
            _animationFrame = 0;
        }
        _spriteRenderer.sprite = animationSprites[_animationFrame];
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Laser"))
        {
            FindObjectOfType<GameManager>().IncreaseScore(points);
            killed.Invoke();
            gameObject.SetActive(false);
        }
    }
}
