using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIPrintingDialouge : MonoBehaviour
{

	public static UIPrintingDialouge Instance;

	public Text DialougeTextField;
	public Image DialougeBackgroud;

	void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		} 
	}

	public void StartPrint(Transform target, string dialouge)
	{
		StopAllCoroutines();
		StartCoroutine(PrintDialouge(target, dialouge));
	}

	private IEnumerator PrintDialouge(Transform target, string dialouge, float hideDelay = 2f)
	{
		ResetDialogue(true);

		transform.position = Camera.main.WorldToScreenPoint(target.position);
		for (int i = 0; i < dialouge.Length; i++)
		{
			yield return new WaitForSeconds(0.1f);
			DialougeTextField.text = dialouge.Substring(0, i+1);
			DialougeBackgroud.rectTransform.sizeDelta = new Vector2(16+DialougeTextField.text.Length*8, DialougeBackgroud.rectTransform.rect.height);
		}
		yield return new WaitForSeconds(hideDelay);

		ResetDialogue(false);
	}

	private void ResetDialogue(bool enable)
	{
		DialougeTextField.text = "";
		DialougeBackgroud.rectTransform.sizeDelta = new Vector2(0, DialougeBackgroud.rectTransform.rect.height);
		DialougeBackgroud.gameObject.SetActive(enabled); // not working!?!?!
	}

}
