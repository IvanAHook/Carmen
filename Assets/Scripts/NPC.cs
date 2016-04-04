using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;

public class NPC : MonoBehaviour
{

	private Dictionary<int, string> _dialogue = new Dictionary<int, string>();

	private void Start()
	{
		_dialogue.Add(0, "Hallå eller!");
		_dialogue.Add(1, "Hen måste ha grundat!!!");
	}

	public void Talk(int responeIndex)
	{
		UIPrintingDialouge.Instance.StartPrint(transform, _dialogue[responeIndex]);
	}

}