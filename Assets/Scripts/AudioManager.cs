using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header(" AUDIO Source ")]
    [SerializeField] AudioSource musicSource;

    [Header(" AUDIO Clip")]
    public AudioClip background;
    // bisa ditambah audio lainnya

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

}
