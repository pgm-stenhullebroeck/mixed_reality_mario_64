using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TransitionScript : MonoBehaviour
{
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	[SerializeField]
	UnityEngine.UI.Image image;

	private void Awake()
	{
		if (image == null)
            image = GetComponent<UnityEngine.UI.Image>();

        // Make the image black and fully transparent
        image.color = Color.black;

        // Force CanvasRenderer alpha to 0 so CrossFadeAlpha works
        image.canvasRenderer.SetAlpha(0f);
	}

	void Start()
	{
		//StartCoroutine(FadeOut());
	}

	public IEnumerator FadeIn()
	{
		image.CrossFadeAlpha(0f, 0.5f, false);
		Debug.Log("faded in");
		yield return new WaitForSeconds(1);
	}

	public IEnumerator FadeOut()
	{
		image.CrossFadeAlpha(1f, 0.5f, false);
		Debug.Log("faded out");
		yield return new WaitForSeconds(1);
	}
}
