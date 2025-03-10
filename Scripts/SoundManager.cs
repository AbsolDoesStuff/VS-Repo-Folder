using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    public AudioSource asteroidDestroyedSound;
    public AudioSource shipHitSound;
    public AudioSource projectileFiredSound;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayAsteroidDestroyedSound()
    {
        if (asteroidDestroyedSound != null)
        {
            asteroidDestroyedSound.Play();
        }
        else
        {
            Debug.LogError("Asteroid destroyed sound is missing!");
        }
    }
    
    public void PlayShipHitSound()
    {
        if (shipHitSound != null)
        {
            Debug.Log("Playing ship hit sound");
            if (!shipHitSound.isPlaying)
            {
                shipHitSound.Play();
            }
        }
        else
        {
            Debug.LogError("Ship hit sound is missing!");
        }
    }
    
    public void PlayProjectileFiredSound()
    {
        if (projectileFiredSound != null)
        {
            Debug.Log("Playing projectile fired sound");
            projectileFiredSound.Play();
        }
        else
        {
            Debug.LogError("Projectile fired sound is missing!");
        }
    }
}
