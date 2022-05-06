using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shoot")]
    [SerializeField] AudioClip shootOGG;
    [SerializeField] [Range(0f, 1f)] float shootVol = 1f;

    [Header("Damage")]
    [SerializeField] AudioClip damageOGG;
    [SerializeField] [Range(0f, 1f)] float damageVol = 1f;

    static AudioPlayer instance;

    void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        if(instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayShootOGG()
    {
        PlayClip(shootOGG, shootVol);
    }
    
    public void PlayDamageOGG()
    {
        PlayClip(damageOGG, damageVol);
    }

    void PlayClip(AudioClip ogg, float flVol)
    {
        if(ogg != null)
        {
            Vector3 camPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(ogg, camPos, flVol);
        }
    }
}
