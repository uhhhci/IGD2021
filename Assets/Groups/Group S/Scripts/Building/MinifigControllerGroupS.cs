using UnityEngine;
using UnityEngine.InputSystem;

namespace Groups.Group_S.Building
{
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent(typeof(AudioSource))]
    [DisallowMultipleComponent]
    public class MinifigControllerGroupS : MinifigController
    {
        // redefine start so that player input is not automatically bound to this minifig
        protected new void Start() {}
    }
}