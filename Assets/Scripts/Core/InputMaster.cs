// GENERATED AUTOMATICALLY FROM 'Assets/InputMaster.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Input;
using UnityEngine.Experimental.Input.Utilities;

public class InputMaster : IInputActionCollection
{
    private InputActionAsset asset;
    public InputMaster()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMaster"",
    ""maps"": [
        {
            ""name"": ""PlayerControls"",
            ""id"": ""98017cba-176d-4e0f-9214-dd18ddb35238"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""id"": ""419063e8-3d05-4d5e-bbaa-71e50eb95d6b"",
                    ""expectedControlLayout"": ""Vector2"",
                    ""continuous"": true,
                    ""passThrough"": false,
                    ""initialStateCheck"": true,
                    ""processors"": """",
                    ""interactions"": """",
                    ""bindings"": []
                },
                {
                    ""name"": ""Face"",
                    ""id"": ""5fd3c43d-039c-4430-9879-0a92a91fad23"",
                    ""expectedControlLayout"": ""Vector2"",
                    ""continuous"": true,
                    ""passThrough"": false,
                    ""initialStateCheck"": true,
                    ""processors"": """",
                    ""interactions"": """",
                    ""bindings"": []
                },
                {
                    ""name"": ""ActionA"",
                    ""id"": ""ea78aac4-8f25-4e74-a02f-4c9dcb854f40"",
                    ""expectedControlLayout"": """",
                    ""continuous"": false,
                    ""passThrough"": false,
                    ""initialStateCheck"": false,
                    ""processors"": """",
                    ""interactions"": """",
                    ""bindings"": []
                },
                {
                    ""name"": ""ActionB"",
                    ""id"": ""38e7c51c-32be-494e-8aad-d5fba4fdacc8"",
                    ""expectedControlLayout"": """",
                    ""continuous"": false,
                    ""passThrough"": false,
                    ""initialStateCheck"": false,
                    ""processors"": """",
                    ""interactions"": """",
                    ""bindings"": []
                },
                {
                    ""name"": ""ActionC"",
                    ""id"": ""d0f8a812-0722-4605-b7b3-1ad33029db2c"",
                    ""expectedControlLayout"": """",
                    ""continuous"": false,
                    ""passThrough"": false,
                    ""initialStateCheck"": false,
                    ""processors"": """",
                    ""interactions"": """",
                    ""bindings"": []
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c7797b81-2c7d-4e90-a02e-e91378116b93"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": "";Xbox-2;Xbox-1"",
                    ""action"": ""ActionA"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                },
                {
                    ""name"": """",
                    ""id"": ""8f0bb41c-f317-4f22-88a3-24b4962ccbc7"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ActionB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                },
                {
                    ""name"": """",
                    ""id"": ""b06eef70-e42d-4bdb-a336-ba5ae6fc073d"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ActionC"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                },
                {
                    ""name"": """",
                    ""id"": ""d63f138d-60ff-444b-846e-1d20e21ac4f1"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Face"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                },
                {
                    ""name"": """",
                    ""id"": ""1b1a57ec-f3fd-46de-9b2f-72f1d1123c9c"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Xbox-1;Xbox-2"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerControls
        m_PlayerControls = asset.GetActionMap("PlayerControls");
        m_PlayerControls_Movement = m_PlayerControls.GetAction("Movement");
        m_PlayerControls_Face = m_PlayerControls.GetAction("Face");
        m_PlayerControls_ActionA = m_PlayerControls.GetAction("ActionA");
        m_PlayerControls_ActionB = m_PlayerControls.GetAction("ActionB");
        m_PlayerControls_ActionC = m_PlayerControls.GetAction("ActionC");
    }
    ~InputMaster()
    {
        UnityEngine.Object.Destroy(asset);
    }
    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }
    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }
    public ReadOnlyArray<InputControlScheme> controlSchemes
    {
        get => asset.controlSchemes;
    }
    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }
    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    public void Enable()
    {
        asset.Enable();
    }
    public void Disable()
    {
        asset.Disable();
    }
    // PlayerControls
    private InputActionMap m_PlayerControls;
    private IPlayerControlsActions m_PlayerControlsActionsCallbackInterface;
    private InputAction m_PlayerControls_Movement;
    private InputAction m_PlayerControls_Face;
    private InputAction m_PlayerControls_ActionA;
    private InputAction m_PlayerControls_ActionB;
    private InputAction m_PlayerControls_ActionC;
    public struct PlayerControlsActions
    {
        private InputMaster m_Wrapper;
        public PlayerControlsActions(InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement { get { return m_Wrapper.m_PlayerControls_Movement; } }
        public InputAction @Face { get { return m_Wrapper.m_PlayerControls_Face; } }
        public InputAction @ActionA { get { return m_Wrapper.m_PlayerControls_ActionA; } }
        public InputAction @ActionB { get { return m_Wrapper.m_PlayerControls_ActionB; } }
        public InputAction @ActionC { get { return m_Wrapper.m_PlayerControls_ActionC; } }
        public InputActionMap Get() { return m_Wrapper.m_PlayerControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled { get { return Get().enabled; } }
        public InputActionMap Clone() { return Get().Clone(); }
        public static implicit operator InputActionMap(PlayerControlsActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerControlsActions instance)
        {
            if (m_Wrapper.m_PlayerControlsActionsCallbackInterface != null)
            {
                Movement.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMovement;
                Movement.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMovement;
                Movement.cancelled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMovement;
                Face.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnFace;
                Face.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnFace;
                Face.cancelled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnFace;
                ActionA.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnActionA;
                ActionA.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnActionA;
                ActionA.cancelled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnActionA;
                ActionB.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnActionB;
                ActionB.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnActionB;
                ActionB.cancelled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnActionB;
                ActionC.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnActionC;
                ActionC.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnActionC;
                ActionC.cancelled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnActionC;
            }
            m_Wrapper.m_PlayerControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                Movement.started += instance.OnMovement;
                Movement.performed += instance.OnMovement;
                Movement.cancelled += instance.OnMovement;
                Face.started += instance.OnFace;
                Face.performed += instance.OnFace;
                Face.cancelled += instance.OnFace;
                ActionA.started += instance.OnActionA;
                ActionA.performed += instance.OnActionA;
                ActionA.cancelled += instance.OnActionA;
                ActionB.started += instance.OnActionB;
                ActionB.performed += instance.OnActionB;
                ActionB.cancelled += instance.OnActionB;
                ActionC.started += instance.OnActionC;
                ActionC.performed += instance.OnActionC;
                ActionC.cancelled += instance.OnActionC;
            }
        }
    }
    public PlayerControlsActions @PlayerControls
    {
        get
        {
            return new PlayerControlsActions(this);
        }
    }
    public interface IPlayerControlsActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnFace(InputAction.CallbackContext context);
        void OnActionA(InputAction.CallbackContext context);
        void OnActionB(InputAction.CallbackContext context);
        void OnActionC(InputAction.CallbackContext context);
    }
}
