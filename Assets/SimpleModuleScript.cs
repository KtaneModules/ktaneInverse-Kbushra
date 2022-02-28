using System.Collections.Generic;
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

		//modifying num
		if (modifiedNum > 2 && modifiedNum < 6) 
		{
			modifiedNum = modifiedNum * 2;
			modifiedNum = modifiedNum + 1;
		}
		if (modifiedNum > 5 && modifiedNum < 9) 
		{
			modifiedNum = modifiedNum - 3;
		}
		if (modifiedNum > 8 && modifiedNum < 12) 
		{
			modifiedNum = modifiedNum * 2;
			modifiedNum = modifiedNum - 12;
		}
		if (modifiedNum > 11 && modifiedNum < 21) 
		{
			modifiedNum = modifiedNum * 2;
			modifiedNum = modifiedNum - 3;
		}
		if (modifiedNum > 20) 
		{
			modifiedNum = modifiedNum * 3;
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
			renderer.sharedMaterial = materials [11];
		}
		if (modifiedNum > 40)
		{
			renderer = display.GetComponent<Renderer> ();
			renderer.enabled = true;
			ERROR2 = true;
			renderer.sharedMaterial = materials [12];
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
}


