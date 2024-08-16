using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class JoinServer : MonoBehaviour
{
    [SerializeField] Button JoinButton;
    void Start()
    {
        JoinButton.onClick.AddListener( Join );
    }

    static void Join()
    {
        NetworkManager.Singleton.StartClient();
    }
}
