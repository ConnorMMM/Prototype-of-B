using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DefaultNamespace
{
	[RequireComponent(typeof(Button))]
	public class StartButton : MonoBehaviour
	{
		private Button button;
		
		private void Start()
		{
			button = gameObject.GetComponent<Button>();

			button.onClick.AddListener(() => Process());
		}

		private void Process() => SceneManager.LoadScene("Play", LoadSceneMode.Single);
	}
}