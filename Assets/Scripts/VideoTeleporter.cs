using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
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

    [SerializeField]
	private TransitionScript transition;

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
            StartCoroutine(ReturnPlayer());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (!other.CompareTag("Player"))
            return;

        player = other.gameObject;
        // transition
        StartCoroutine(TeleportPlayer());
    }

    private IEnumerator TeleportPlayer()
    {
        yield return transition.FadeOut();

        player.transform.SetPositionAndRotation(videoTransform.position, videoTransform.rotation);

        yield return transition.FadeIn();

        playing = true;
        videoPlayer.Play();
    }

    private IEnumerator ReturnPlayer()
    {
        yield return transition.FadeOut();

        player.transform.SetPositionAndRotation(returnTransform.position, returnTransform.rotation);

        yield return transition.FadeIn();
    }
}
