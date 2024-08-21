using Unity.Netcode.Components;

public class ClientNetworkTransform : NetworkTransform
{
    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        // We assign here the ownership 
        CanCommitToTransform = IsOwner;
    }

    protected override void Update()
    {
        base.Update();
        // Just a safety check to every frame check if we are still the owner
        CanCommitToTransform = IsOwner;
        // Safety check if the network manager exists
        if ( NetworkManager != null )
        {
            // Are we connected to the server as a client? or we are listening (this one is probably an unnecessary safety check, just in case)
            if ( NetworkManager.IsConnectedClient ||  NetworkManager.IsListening)
            {
                if ( CanCommitToTransform )
                {
                    TryCommitTransformToServer( transform, NetworkManager.LocalTime.Time );
                }
            }
        }
    }

    // The owner of this object now has the authority to whatever the object says
    protected override bool OnIsServerAuthoritative()
    {
        return false;
    }
}
