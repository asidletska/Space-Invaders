using System;
using UnityEngine;

public class Invaders : MonoBehaviour
{
    public Sprite[] animationSprites;
    public float animationTime = 1.0f;
    public Action killed;
    private SpriteRenderer _spriteRenderer;
    public int points = 10;

    private int _animationFrame;
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
            killed?.Invoke();
            gameObject.SetActive(false);           
        }
        if (ScoreManager.instance != null)
        {
            ScoreManager.instance.AddScore(points);
        }
    }
    private void OnDestroy()
    {
        if (ScoreManager.instance != null)
        {
            //ScoreManager.instance.AddScore(points);
        }
    }
}
