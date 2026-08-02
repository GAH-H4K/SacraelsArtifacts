using UnityEngine;
using Unity.Cinemachine;
public class PlayerSpawner : MonoBehaviour
{
    public GameObject[] playerPrefabs; 

    public Transform spawnPoint;
    public CinemachineCamera virtualCamera;

    private void Start()
    {
        int character = PlayerPrefs.GetInt("Character", 0);

        GameObject player = Instantiate(playerPrefabs[character], spawnPoint.position, Quaternion.identity);

        virtualCamera.Follow = player.transform;
    }
}
