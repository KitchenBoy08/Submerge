using UnityEngine;

namespace Submerge.Player;

public static class LocalPlayer
{
    public static global::Player localPlayer;
    public static bool IsValid => localPlayer != null && localPlayer.gameObject != null && localPlayer.gameObject.activeInHierarchy;
    
    public static Vector3 Position => localPlayer.gameObject.transform.position;
    public static Quaternion Rotation => localPlayer.gameObject.transform.rotation;
}