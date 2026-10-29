using UnityEngine;

// Decides whether on-screen touch controls should be used.
public static class TouchControls
{
    // On a phone: yes. In the Editor: only while the build platform is Android/iOS
    // (or in Device Simulator), so switching the platform to Windows hides them there too.
    public static bool Enabled
    {
        get
        {
#if UNITY_ANDROID || UNITY_IOS
            return true;
#else
            return Application.isMobilePlatform;
#endif
        }
    }
}
