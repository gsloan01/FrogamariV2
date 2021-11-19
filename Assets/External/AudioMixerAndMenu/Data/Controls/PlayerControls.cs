// GENERATED AUTOMATICALLY FROM 'Assets/External/AudioMixerAndMenu/Data/Controls/PlayerControls.inputactions'

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
            ""id"": ""0deafec1-9d6e-43e8-a3d9-3c9488cf2623"",
            ""actions"": [
                {
                    ""name"": ""PrimaryTouch"",
                    ""type"": ""Value"",
                    ""id"": ""ee1d7748-0d92-46ff-adb6-bf3de514e922"",
                    ""expectedControlType"": ""Touch"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""00f3e987-fc0f-4b18-bbd6-d48308d315c2"",
                    ""path"": ""<Touchscreen>/primaryTouch"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryTouch"",
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
        m_TouchScreen_PrimaryTouch = m_TouchScreen.FindAction("PrimaryTouch", throwIfNotFound: true);
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
    private readonly InputAction m_TouchScreen_PrimaryTouch;
    public struct TouchScreenActions
    {
        private @PlayerControls m_Wrapper;
        public TouchScreenActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @PrimaryTouch => m_Wrapper.m_TouchScreen_PrimaryTouch;
        public InputActionMap Get() { return m_Wrapper.m_TouchScreen; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TouchScreenActions set) { return set.Get(); }
        public void SetCallbacks(ITouchScreenActions instance)
        {
            if (m_Wrapper.m_TouchScreenActionsCallbackInterface != null)
            {
                @PrimaryTouch.started -= m_Wrapper.m_TouchScreenActionsCallbackInterface.OnPrimaryTouch;
                @PrimaryTouch.performed -= m_Wrapper.m_TouchScreenActionsCallbackInterface.OnPrimaryTouch;
                @PrimaryTouch.canceled -= m_Wrapper.m_TouchScreenActionsCallbackInterface.OnPrimaryTouch;
            }
            m_Wrapper.m_TouchScreenActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PrimaryTouch.started += instance.OnPrimaryTouch;
                @PrimaryTouch.performed += instance.OnPrimaryTouch;
                @PrimaryTouch.canceled += instance.OnPrimaryTouch;
            }
        }
    }
    public TouchScreenActions @TouchScreen => new TouchScreenActions(this);
    public interface ITouchScreenActions
    {
        void OnPrimaryTouch(InputAction.CallbackContext context);
    }
}
