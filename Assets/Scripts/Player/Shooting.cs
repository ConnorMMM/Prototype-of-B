using UnityEngine;
using UnityEngine.InputSystem;

namespace DefaultNamespace
{
	public class Shooting : MonoBehaviour
	{
		private InputAction ShootAction => shootActionReference.action;

		[SerializeField] private InputActionReference shootActionReference;
		[SerializeField] private Transform bulletExitLocation;
		
		public GameObject bulletPrefab;
		
		private void Awake()
		{
			ShootAction.Enable();
			ShootAction.performed += OnShootPerformed;
		}
		
		private void OnShootPerformed(InputAction.CallbackContext _context)
		{
			if(bulletExitLocation != null)
			{
				GameObject bullet;
				bullet = Instantiate(bulletPrefab, bulletExitLocation.position, bulletExitLocation.rotation) as GameObject;
				Destroy(bullet, 2.0f);
				bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * 50, ForceMode.Impulse);
			}
		}
	}
}