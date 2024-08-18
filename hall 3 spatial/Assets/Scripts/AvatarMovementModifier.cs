using UnityEngine;
using SpatialSys.UnitySDK;

public class AvatarMovementModifier : MonoBehaviour
{
    public bool isRunComplete = false;

    private IAvatar avatar;

    void Start()
    {
        avatar = SpatialBridge.actorService.localActor.avatar;
        avatar.onAvatarLoadComplete += OnAvatarLoadComplete;
    }

    private void OnAvatarLoadComplete()
    {
        if(isRunComplete)
            ModifyAvatarValues();
    }

    public void ModifyAvatarValues()
    {
        avatar.jumpHeight = 50f;
        avatar.walkSpeed = 20f;
        avatar.runSpeed = 100f;
        avatar.airControl = 0.7f;
        avatar.gravityMultiplier = 0.7f;
        avatar.maxJumpCount = 50;
    }

    
    
}