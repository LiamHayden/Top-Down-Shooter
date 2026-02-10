using UnityEngine;
using UnityEngine.Rendering;

public class EnemyController : MonoBehaviour
{
    public static EnemyController Instance;
    public ParticleSystem explosionParticle;
    public AudioClip explosionSound;
    private AudioSource playerAudio;

    public float forwardSpeed;

    void Start()
    {
        explosionParticle.Stop();

        playerAudio = GetComponent<AudioSource>();
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        MoveForward();
    }

    private void MoveForward()
    {
        transform.Translate(Vector3.back * forwardSpeed * Time.deltaTime);
    }

    // Activate explosion particle on collision with projectile and set isAlive to false
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);

            // Play explosion sound
            playerAudio.PlayOneShot(explosionSound, 1.0f);
        }
    }
}
