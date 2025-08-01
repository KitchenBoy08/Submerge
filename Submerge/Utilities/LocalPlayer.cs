using UnityEngine;

namespace Submerge.Utilities;

public static class LocalPlayer
{
    public static Player localPlayer;
    public static bool IsValid => localPlayer && localPlayer.gameObject && localPlayer.gameObject.activeInHierarchy;
    
    public static Vector3 Position => localPlayer.gameObject.transform.position;
    public static Quaternion Rotation => localPlayer.gameObject.transform.rotation;

    public static void OnPlayerAwake()
    {
        
    }
}