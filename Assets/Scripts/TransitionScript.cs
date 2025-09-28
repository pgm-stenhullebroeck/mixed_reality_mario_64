using System.Collections;
using UnityEngine;

public enum FadeState
{
	IN,
	OUT,
	IDLE
}

public class TransitionScript : MonoBehaviour
{

	[SerializeField]
	MeshRenderer sphere;
	private FadeState fadeState = FadeState.IDLE;
	private float t = 0f;


	private void Awake()
	{
        // Make the image black and fully transparent
        sphere.material.color = Color.black;
		Color c = sphere.material.color;
		c.a = 0f;
		sphere.material.color = c;
	}


    private void Update()
    {
        switch (fadeState)
		{
			case FadeState.OUT:
				t += Time.deltaTime;
				Color c = sphere.material.color;
				c.a = Mathf.Lerp(0, 1, t * 2);
				sphere.material.color = c;
				break;
			case FadeState.IN:
				t += Time.deltaTime;
				Color d = sphere.material.color;
				d.a = Mathf.Lerp(1, 0, t * 2);
				sphere.material.color = d;
				break;
			default:
				break;
		}
		if (t >= .5f) fadeState = FadeState.IDLE;
    }

	public IEnumerator FadeIn()
	{
		fadeState = FadeState.IN;
		t = 0f;
		yield return new WaitForSeconds(.5f);
	}

	public IEnumerator FadeOut()
	{
		fadeState = FadeState.OUT;
		t = 0f;
		yield return new WaitForSeconds(.5f);
	}
}
