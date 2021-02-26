// GENERATED AUTOMATICALLY FROM 'Assets/Inputs/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""PayerMap"",
            ""id"": ""2d1ce72e-e1f8-4975-921d-0892fe1ce619"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""64bf05c3-d88a-4a67-9b2f-b6db6d3e2ef5"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""102b3bf7-8e78-4f72-aa4d-faa22539f418"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""8451a4e0-2681-4e27-9e92-3a37fc265382"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""51ed175a-5463-4942-8a6c-570eac236aeb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""57273a88-c393-4108-9e25-57111a49e7bd"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Direction"",
                    ""id"": ""f88e6248-41aa-4219-8f8c-34028b0655ae"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""3e69ba39-e6e2-468e-b594-4ad894be026a"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""c2276b3e-3c6d-4d9f-b7fd-4ba370c0c41d"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""22e6c275-3ac2-430c-ad2c-206df382dba9"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b043badd-dbc2-406a-8724-885b93082aca"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""0aa558e5-9c35-4d5b-8333-4302450971c2"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""009a55b5-4264-4c85-9212-4df82c27632a"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""94d4ac13-d38f-44eb-a10a-7e3823a375a1"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""48b946ee-168c-44fd-93ba-c8315f6b6ca7"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PayerMap
        m_PayerMap = asset.FindActionMap("PayerMap", throwIfNotFound: true);
        m_PayerMap_Movement = m_PayerMap.FindAction("Movement", throwIfNotFound: true);
        m_PayerMap_Run = m_PayerMap.FindAction("Run", throwIfNotFound: true);
        m_PayerMap_Jump = m_PayerMap.FindAction("Jump", throwIfNotFound: true);
        m_PayerMap_Attack = m_PayerMap.FindAction("Attack", throwIfNotFound: true);
        m_PayerMap_Look = m_PayerMap.FindAction("Look", throwIfNotFound: true);
    }

    public void Dispose()
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

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

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

    // PayerMap
    private readonly InputActionMap m_PayerMap;
    private IPayerMapActions m_PayerMapActionsCallbackInterface;
    private readonly InputAction m_PayerMap_Movement;
    private readonly InputAction m_PayerMap_Run;
    private readonly InputAction m_PayerMap_Jump;
    private readonly InputAction m_PayerMap_Attack;
    private readonly InputAction m_PayerMap_Look;
    public struct PayerMapActions
    {
        private @PlayerControls m_Wrapper;
        public PayerMapActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PayerMap_Movement;
        public InputAction @Run => m_Wrapper.m_PayerMap_Run;
        public InputAction @Jump => m_Wrapper.m_PayerMap_Jump;
        public InputAction @Attack => m_Wrapper.m_PayerMap_Attack;
        public InputAction @Look => m_Wrapper.m_PayerMap_Look;
        public InputActionMap Get() { return m_Wrapper.m_PayerMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PayerMapActions set) { return set.Get(); }
        public void SetCallbacks(IPayerMapActions instance)
        {
            if (m_Wrapper.m_PayerMapActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PayerMapActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PayerMapActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PayerMapActionsCallbackInterface.OnMovement;
                @Run.started -= m_Wrapper.m_PayerMapActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_PayerMapActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_PayerMapActionsCallbackInterface.OnRun;
                @Jump.started -= m_Wrapper.m_PayerMapActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PayerMapActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PayerMapActionsCallbackInterface.OnJump;
                @Attack.started -= m_Wrapper.m_PayerMapActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_PayerMapActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_PayerMapActionsCallbackInterface.OnAttack;
                @Look.started -= m_Wrapper.m_PayerMapActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_PayerMapActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_PayerMapActionsCallbackInterface.OnLook;
            }
            m_Wrapper.m_PayerMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
            }
        }
    }
    public PayerMapActions @PayerMap => new PayerMapActions(this);
    public interface IPayerMapActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
    }
}
