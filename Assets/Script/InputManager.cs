// GENERATED AUTOMATICALLY FROM 'Assets/Script/InputManager.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputManager : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputManager()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputManager"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""948d42f1-3f46-499a-b7ec-7bdc3900cacf"",
            ""actions"": [
                {
                    ""name"": ""Click"",
                    ""type"": ""PassThrough"",
                    ""id"": ""f9383223-723a-4590-a110-3fc4698058ab"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""InputPosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""fc167124-4e9d-498d-b308-8dd93e8a2eb2"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e4f1ef82-986b-429c-b9ec-72c3d96a1ddc"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""81edd955-cf2e-46ea-91b3-d74d9c5c859e"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""InputPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Click = m_Player.FindAction("Click", throwIfNotFound: true);
        m_Player_InputPosition = m_Player.FindAction("InputPosition", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Click;
    private readonly InputAction m_Player_InputPosition;
    public struct PlayerActions
    {
        private @InputManager m_Wrapper;
        public PlayerActions(@InputManager wrapper) { m_Wrapper = wrapper; }
        public InputAction @Click => m_Wrapper.m_Player_Click;
        public InputAction @InputPosition => m_Wrapper.m_Player_InputPosition;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Click.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnClick;
                @Click.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnClick;
                @Click.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnClick;
                @InputPosition.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInputPosition;
                @InputPosition.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInputPosition;
                @InputPosition.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInputPosition;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Click.started += instance.OnClick;
                @Click.performed += instance.OnClick;
                @Click.canceled += instance.OnClick;
                @InputPosition.started += instance.OnInputPosition;
                @InputPosition.performed += instance.OnInputPosition;
                @InputPosition.canceled += instance.OnInputPosition;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnClick(InputAction.CallbackContext context);
        void OnInputPosition(InputAction.CallbackContext context);
    }
}
