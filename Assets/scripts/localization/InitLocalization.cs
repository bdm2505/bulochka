﻿
using UnityEngine;

namespace localization
{
	/// <summary>
	/// Asset usage example.
	/// </summary>
	public class InitLocalization : MonoBehaviour
	{
		public void Standart()
		{
			LocalizationManager.Read();

			switch (Application.systemLanguage)
			{
				case SystemLanguage.Russian:
					LocalizationManager.Language = "Russian";
					break;
				default:
					LocalizationManager.Language = "English";
					break;
			}
		}

		public void SetLanguage(string language)
		{
			LocalizationManager.Language = language;
		}
	}
	
}