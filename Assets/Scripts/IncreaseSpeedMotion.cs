using TMPro;

using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
	[RequireComponent(typeof(Button))]
	public class IncreaseSpeedMotion : MonoBehaviour
	{
		private Button button;

		[SerializeField] private TextMeshProUGUI speedText;
		
		private float speed;
		
		private void Start()
		{
			button = gameObject.GetComponent<Button>();

			button.onClick.AddListener(() => Process());
			
			speed = PlayerPrefs.GetFloat("speed", 1f);
			
			speedText.text = "Speed = " + speed;
		}

		private void Process()
		{
			speed++;
			PlayerPrefs.SetFloat("speed", speed);
			speedText.text = "Speed = " + speed;
		}
	}
}