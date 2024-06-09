using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using KModkit;
using Newtonsoft.Json;
using System.Linq;
using System.Text.RegularExpressions;
using Rnd = UnityEngine.Random;

public class SimpleModuleScript : MonoBehaviour {

	public KMAudio audio;
	public KMBombInfo info;
	public KMBombModule module;
	public KMSelectable[] Buttons;
	static int ModuleIdCounter = 1;
	int ModuleId;

	public AudioSource correct;

	public int widgetChooser;

	bool _isSolved = false;
	bool incorrect = false;
	bool ERROR1 = false;
	bool ERROR2 = false;
	bool modified = false;

	public Material[] materials;
	public int modifiedNum;
	Renderer renderer;
	public GameObject display;


	void Awake() 
	{
		ModuleId = ModuleIdCounter++;

		foreach (KMSelectable button in Buttons)
		{
			KMSelectable pressedButton = button;
			button.OnInteract += delegate () { buttonPress(pressedButton); return false; };
		}
	}

	void Start ()
	{
		Invoke ("Creator", 0);
	}

	void Creator()
	{
		widgetChooser = Rnd.Range (1, 7);

		ERROR1 = false;
		ERROR2 = false;

		//widget starting num
		if (widgetChooser == 1) 
		{
			modifiedNum = info.GetPortCount ();
			Debug.LogFormat ("Starting modified number is {0} and widget chooser num is {1}", modifiedNum, widgetChooser); 
		}
		if (widgetChooser == 2) 
		{
			modifiedNum = info.GetPortPlateCount ();
			Debug.LogFormat ("Starting modified number is {0} and widget chooser num is {1}", modifiedNum, widgetChooser); 
		}
		if (widgetChooser == 3) 
		{
			modifiedNum = info.GetBatteryCount ();
			Debug.LogFormat ("Starting modified number is {0} and widget chooser num is {1}", modifiedNum, widgetChooser); 
		}
		if (widgetChooser == 4) 
		{
			modifiedNum = info.GetBatteryHolderCount ();
			Debug.LogFormat ("Starting modified number is {0} and widget chooser num is {1}", modifiedNum, widgetChooser); 
		}
		if (widgetChooser == 5) 
		{
			modifiedNum = info.GetOffIndicators ().ToList ().Count;
			Debug.LogFormat ("Starting modified number is {0} and widget chooser num is {1}", modifiedNum, widgetChooser); 
		}
		if (widgetChooser == 6) 
		{
			modifiedNum = info.GetOnIndicators ().ToList ().Count;
			Debug.LogFormat ("Starting modified number is {0} and widget chooser num is {1}", modifiedNum, widgetChooser); 
		}

		//modifying num
		if (modifiedNum > 2 && modifiedNum < 6 && modified == false) 
		{
			modifiedNum = modifiedNum * 2;
			modifiedNum = modifiedNum + 1;
			modified = true;
		}
		if (modifiedNum > 5 && modifiedNum < 9 && modified == false) 
		{
			modifiedNum = modifiedNum - 3;
			modified = true;
		}
		if (modifiedNum > 8 && modifiedNum < 12 && modified == false) 
		{
			modifiedNum = modifiedNum * 2;
			modifiedNum = modifiedNum - 12;
			modified = true;
		}
		if (modifiedNum > 11 && modifiedNum < 21 && modified == false) 
		{
			modifiedNum = modifiedNum * 2;
			modifiedNum = modifiedNum - 3;
			modified = true;
		}
		if (modifiedNum > 20 && modified == false) 
		{
			modifiedNum = modifiedNum * 3;
			modified = true;
		}

		//setting material
		if (modifiedNum < 12) 
		{
			renderer = display.GetComponent<Renderer> ();
			renderer.enabled = true;
			renderer.sharedMaterial = materials [modifiedNum];
		}
		if (modifiedNum > 11 && modifiedNum < 41)
		{
			renderer = display.GetComponent<Renderer> ();
			renderer.enabled = true;
			ERROR1 = true;
			renderer.sharedMaterial = materials [12];
		}
		if (modifiedNum > 40)
		{
			renderer = display.GetComponent<Renderer> ();
			renderer.enabled = true;
			ERROR2 = true;
			renderer.sharedMaterial = materials [13];
		}
	}

	void buttonPress(KMSelectable pressedButton)
	{
		GetComponent<KMAudio>().PlayGameSoundAtTransformWithRef(KMSoundOverride.SoundEffect.ButtonPress, transform);
		int buttonPosition = new int();
		for(int i = 0; i < Buttons.Length; i++)
		{
			if (pressedButton == Buttons[i])
			{
				buttonPosition = i;
				break;
			}
		}

		if (_isSolved == false) 
		{
			switch (buttonPosition) 
			{
			case 0:
				if (widgetChooser == 1) {
					modifiedNum = info.GetPortCount ();
				}
				if (widgetChooser == 2) {
					modifiedNum = info.GetPortPlateCount ();
				}
				if (widgetChooser == 3) {
					modifiedNum = info.GetBatteryCount ();
				}
				if (widgetChooser == 4) {
					modifiedNum = info.GetBatteryHolderCount ();
				}
				if (widgetChooser == 5) {
					modifiedNum = info.GetOffIndicators ().ToList ().Count;
				}
				if (widgetChooser == 6) {
					modifiedNum = info.GetOnIndicators ().ToList ().Count;
				}

				if (modifiedNum == info.GetPortCount ()) 
				{
					module.HandlePass ();
					_isSolved = true;
				}
				else 
				{
					incorrect = true;
				}

				break;
			case 1:
				if (widgetChooser == 1) 
				{
					modifiedNum = info.GetPortCount ();
				}
				if (widgetChooser == 2) 
				{
					modifiedNum = info.GetPortPlateCount ();
				}
				if (widgetChooser == 3) 
				{
					modifiedNum = info.GetBatteryCount ();
				}
				if (widgetChooser == 4) 
				{
					modifiedNum = info.GetBatteryHolderCount ();
				}
				if (widgetChooser == 5) 
				{
					modifiedNum = info.GetOffIndicators ().ToList ().Count;
				}
				if (widgetChooser == 6) 
				{
					modifiedNum = info.GetOnIndicators ().ToList ().Count;
				}

				if (modifiedNum == info.GetPortPlateCount ()) 
				{
					module.HandlePass ();
					_isSolved = true;
				}
				else 
				{
					incorrect = true;
				}

				break;
			case 2:
				if (widgetChooser == 1) 
				{
					modifiedNum = info.GetPortCount ();
				}
				if (widgetChooser == 2) 
				{
					modifiedNum = info.GetPortPlateCount ();
				}
				if (widgetChooser == 3) 
				{
					modifiedNum = info.GetBatteryCount ();
				}
				if (widgetChooser == 4) 
				{
					modifiedNum = info.GetBatteryHolderCount ();
				}
				if (widgetChooser == 5) 
				{
					modifiedNum = info.GetOffIndicators ().ToList ().Count;
				}
				if (widgetChooser == 6) 
				{
					modifiedNum = info.GetOnIndicators ().ToList ().Count;
				}

				if (modifiedNum == info.GetBatteryCount ()) 
				{
					module.HandlePass ();
					_isSolved = true;
				}
				else 
				{
					incorrect = true;
				}

				break;
			case 3:
				if (widgetChooser == 1) 
				{
					modifiedNum = info.GetPortCount ();
				}
				if (widgetChooser == 2) 
				{
					modifiedNum = info.GetPortPlateCount ();
				}
				if (widgetChooser == 3) 
				{
					modifiedNum = info.GetBatteryCount ();
				}
				if (widgetChooser == 4) 
				{
					modifiedNum = info.GetBatteryHolderCount ();
				}
				if (widgetChooser == 5) 
				{
					modifiedNum = info.GetOffIndicators ().ToList ().Count;
				}
				if (widgetChooser == 6) 
				{
					modifiedNum = info.GetOnIndicators ().ToList ().Count;
				}

				if (modifiedNum == info.GetBatteryHolderCount ()) 
				{
					module.HandlePass ();
					_isSolved = true;
				}
				else 
				{
					incorrect = true;
				}

				break;
			case 4:
				if (widgetChooser == 1) 
				{
					modifiedNum = info.GetPortCount ();
				}
				if (widgetChooser == 2) 
				{
					modifiedNum = info.GetPortPlateCount ();
				}
				if (widgetChooser == 3) 
				{
					modifiedNum = info.GetBatteryCount ();
				}
				if (widgetChooser == 4) 
				{
					modifiedNum = info.GetBatteryHolderCount ();
				}
				if (widgetChooser == 5) 
				{
					modifiedNum = info.GetOffIndicators ().ToList ().Count;
				}
				if (widgetChooser == 6) 
				{
					modifiedNum = info.GetOnIndicators ().ToList ().Count;
				}

				if (modifiedNum == info.GetOffIndicators ().ToList().Count) 
				{
					module.HandlePass ();
					_isSolved = true;
				}
				else 
				{
					incorrect = true;
				}

				break;
			case 5:
				if (widgetChooser == 1) 
				{
					modifiedNum = info.GetPortCount ();
				}
				if (widgetChooser == 2) 
				{
					modifiedNum = info.GetPortPlateCount ();
				}
				if (widgetChooser == 3) 
				{
					modifiedNum = info.GetBatteryCount ();
				}
				if (widgetChooser == 4) 
				{
					modifiedNum = info.GetBatteryHolderCount ();
				}
				if (widgetChooser == 5) 
				{
					modifiedNum = info.GetOffIndicators ().ToList ().Count;
				}
				if (widgetChooser == 6) 
				{
					modifiedNum = info.GetOnIndicators ().ToList ().Count;
				}

				if (modifiedNum == info.GetOnIndicators ().ToList().Count) 
				{
					module.HandlePass ();
					_isSolved = true;
				}
				else 
				{
					incorrect = true;
				}


				break;
			case 6:
				if (ERROR1 == true) 
				{
					if ((int)info.GetTime () % 10 == info.GetBatteryCount () % 10)
					{
						module.HandlePass ();
						_isSolved = true;
					}
					else
					{
						incorrect = true;
						Log ("Error 101 not online.");
					}
				}
				if (ERROR2 == true) 
				{
					if ((int)info.GetTime () % 10 == info.GetStrikes() % 10)
					{
						module.HandlePass ();
						_isSolved = true;
					}
					else
					{
						incorrect = true;
						Log ("Error 202 not online.");
					}
				}
				if (ERROR1 == false && ERROR2 == false) 
				{
					incorrect = true;
					Log ("Errors not found.");
				}
				break;
			}
			if (incorrect) 
			{
				module.HandleStrike ();
				Debug.LogFormat ("Number => {0}", modifiedNum);
				Invoke ("Creator", 0);
				incorrect = false;
			}
			else 
			{
				module.HandlePass ();
				_isSolved = true;
			}
		}
	}

	void Log(string message)
	{
		Debug.LogFormat("[Inverse #{0}] {1}", ModuleId, message);
	}

	//twitch plays
	#pragma warning disable 414
	private readonly string TwitchHelpMessage = @"!{0} tl(pos)/ports(name) [Presses the specified button] | !{0} otherwise 2 [Presses the otherwise button when the last timer digit is 2]";
	#pragma warning restore 414

	IEnumerator ProcessTwitchCommand(string command)
	{
		switch (command.ToLowerInvariant())
		{
		case "tl":
		case "ports":
			yield return null;
			Buttons[0].OnInteract();
			break;
		case "tm":
		case "port plates":
			yield return null;
			Buttons[1].OnInteract();
			break;
		case "tr":
		case "batteries":
			yield return null;
			Buttons[2].OnInteract();
			break;
		case "bl":
		case "battery holders":
			yield return null;
			Buttons[3].OnInteract();
			break;
		case "bm":
		case "unlit indicators":
			yield return null;
			Buttons[4].OnInteract();
			break;
		case "br":
		case "lit indicators":
			yield return null;
			Buttons[5].OnInteract();
			break;
		case "otherwise 0":
		case "otherwise 1":
		case "otherwise 2":
		case "otherwise 3":
		case "otherwise 4":
		case "otherwise 5":
		case "otherwise 6":
		case "otherwise 7":
		case "otherwise 8":
		case "otherwise 9":
			yield return null;
			while ((int)info.GetTime() % 10 != int.Parse(command.Substring(10))) yield return "trycancel";
			Buttons[6].OnInteract();
			break;
		}
	}

	IEnumerator TwitchHandleForcedSolve()
	{
		if (ERROR1)
		{
			while ((int)info.GetTime() % 10 != info.GetBatteryCount() % 10) yield return true;
			Buttons[6].OnInteract();
		}
		else if (ERROR2)
		{
			while ((int)info.GetTime() % 10 != info.GetStrikes() % 10) yield return true;
			Buttons[6].OnInteract();
		}
		else
		{
			Buttons[widgetChooser - 1].OnInteract();
			yield return new WaitForSeconds(.1f);
		}
	}
}


