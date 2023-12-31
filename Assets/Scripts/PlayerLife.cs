using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator _animator;
    private static readonly int Death = Animator.StringToHash("death");
    private Rigidbody2D _rigidbody;
    [SerializeField] private AudioSource deathSoundEffect;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }   
    }

    private void Die()
    {
        deathSoundEffect.Play();
        _rigidbody.bodyType = RigidbodyType2D.Static;
        _animator.SetTrigger(Death);
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
