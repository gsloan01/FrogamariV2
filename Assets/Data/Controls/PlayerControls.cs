// GENERATED AUTOMATICALLY FROM 'Assets/Data/Controls/PlayerControls.inputactions'

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
            ""name"": ""TouchScreen"",
            ""id"": ""80237ae2-fb34-455c-a35c-88db705626f6"",
            ""actions"": [
                {
                    ""name"": ""PressPosition"",
                    ""type"": ""Value"",
                    ""id"": ""53a1fbe8-2245-49f4-9b74-544f2ea35bcb"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PressDelta"",
                    ""type"": ""Value"",
                    ""id"": ""e8035c43-75e3-49b3-8bd6-f6dcf5d035c7"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1cee0045-684d-499a-839d-3a8e42015426"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PressPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8831f4a6-6177-4527-a8f2-4c70e355fbab"",
                    ""path"": ""<Touchscreen>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PressDelta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // TouchScreen
        m_TouchScreen = asset.FindActionMap("TouchScreen", throwIfNotFound: true);
        m_TouchScreen_PressPosition = m_TouchScreen.FindAction("PressPosition", throwIfNotFound: true);
        m_TouchScreen_PressDelta = m_TouchScreen.FindAction("PressDelta", throwIfNotFound: true);
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

    // TouchScreen
    private readonly InputActionMap m_TouchScreen;
    private ITouchScreenActions m_TouchScreenActionsCallbackInterface;
    private readonly InputAction m_TouchScreen_PressPosition;
    private readonly InputAction m_TouchScreen_PressDelta;
    public struct TouchScreenActions
    {
        private @PlayerControls m_Wrapper;
        public TouchScreenActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @PressPosition => m_Wrapper.m_TouchScreen_PressPosition;
        public InputAction @PressDelta => m_Wrapper.m_TouchScreen_PressDelta;
        public InputActionMap Get() { return m_Wrapper.m_TouchScreen; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TouchScreenActions set) { return set.Get(); }
        public void SetCallbacks(ITouchScreenActions instance)
        {
            if (m_Wrapper.m_TouchScreenActionsCallbackInterface != null)
            {
                @PressPosition.started -= m_Wrapper.m_TouchScreenActionsCallbackInterface.OnPressPosition;
                @PressPosition.performed -= m_Wrapper.m_TouchScreenActionsCallbackInterface.OnPressPosition;
                @PressPosition.canceled -= m_Wrapper.m_TouchScreenActionsCallbackInterface.OnPressPosition;
                @PressDelta.started -= m_Wrapper.m_TouchScreenActionsCallbackInterface.OnPressDelta;
                @PressDelta.performed -= m_Wrapper.m_TouchScreenActionsCallbackInterface.OnPressDelta;
                @PressDelta.canceled -= m_Wrapper.m_TouchScreenActionsCallbackInterface.OnPressDelta;
            }
            m_Wrapper.m_TouchScreenActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PressPosition.started += instance.OnPressPosition;
                @PressPosition.performed += instance.OnPressPosition;
                @PressPosition.canceled += instance.OnPressPosition;
                @PressDelta.started += instance.OnPressDelta;
                @PressDelta.performed += instance.OnPressDelta;
                @PressDelta.canceled += instance.OnPressDelta;
            }
        }
    }
    public TouchScreenActions @TouchScreen => new TouchScreenActions(this);
    public interface ITouchScreenActions
    {
        void OnPressPosition(InputAction.CallbackContext context);
        void OnPressDelta(InputAction.CallbackContext context);
    }
}
