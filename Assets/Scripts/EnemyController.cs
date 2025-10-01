using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float health = 0;
    private EnemyHealth enemyHealth;
    private Animator animator;
    private ParticleSystem hitParticles;
    private AudioSource audioSource;

    void Start()
    {
        animator = GetComponent<Animator>();
        hitParticles = GetComponent<ParticleSystem>();
        audioSource = GetComponent<AudioSource>();
        enemyHealth = GetComponent<EnemyHealth>();
    }

    public void GotHit(int dmg = 1)
    {
        health -= Mathf.Max(1, dmg);
        if (health <= 0) Die();
    }

    private void Die()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.IncrementScore(1);

        Destroy(gameObject);
    }

}