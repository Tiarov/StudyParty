using UnityEngine;

public class VideoPlayerBehaivor : MonoBehaviour
{
    public Material VideoMaterial;
    public MovieTexture Clip;

    public VuforiaExtensionEventHandler Events;

    [SerializeField, Range(0, 1)]
    private float Volume = 0.2f;

    private AudioSource _audioSource;
    private MovieTexture _video;

    private void Start()
    {
        var renderer = GetComponent<Renderer>();
        renderer.material = new Material(VideoMaterial);
        VideoMaterial = renderer.material;

        VideoMaterial.mainTexture = Clip;
        _video = (MovieTexture)VideoMaterial.mainTexture;

        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _video.audioClip;

        Events.TrackingFoundEvent += OnTrackingFound;
        Events.TrackingLostEvent += OnTrackingLost;
        OnTrackingFound();
    }

    private void OnDestroy()
    {
        Events.TrackingFoundEvent -= OnTrackingFound;
        Events.TrackingLostEvent -= OnTrackingLost;
    }

    public void OnTrackingLost()
    {
        _video.Stop();
        _audioSource.Stop();
    }

    public void OnTrackingFound()
    {
        _video.Play();
        _audioSource.Play();
        _audioSource.volume = Volume;
    }
}
