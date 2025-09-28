using UnityEngine;
using UnityEngine.Video;

public class VideoTeleporter : MonoBehaviour
{
    [SerializeField]
    private Transform videoTransform;
    [SerializeField]
    private Transform returnTransform;

    [SerializeField]
    private VideoPlayer videoPlayer;
    private bool playing = false;

    private GameObject player;


    private void Start()
    {

    }


    private void Update()
    {
        if (playing)
        {
            player.transform.SetPositionAndRotation(videoTransform.position, player.transform.rotation);
        }

        if (playing && !videoPlayer.isPlaying)
        {
            playing = false;
            // transition

            player.transform.SetPositionAndRotation(returnTransform.position, returnTransform.rotation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (!other.CompareTag("Player"))
            return;

        player = other.gameObject;
        // transition

        player.transform.SetPositionAndRotation(videoTransform.position, videoTransform.rotation);

        playing = true;
        videoPlayer.Play();

    }
}
