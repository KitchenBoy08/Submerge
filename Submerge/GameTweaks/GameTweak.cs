namespace Submerge.GameTweaks;

public abstract class GameTweak
{
    /// <summary>
    /// Called when the Tweak is first created. Should be used for patching/hooking, setup, ect.
    /// </summary>
    public virtual void Initialize() { }
}