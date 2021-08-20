// GENERATED AUTOMATICALLY FROM 'Assets/InputMaster.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputMaster : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputMaster()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMaster"",
    ""maps"": [
        {
            ""name"": ""Inputs player"",
            ""id"": ""5246dd35-40c0-4653-941f-36168365ace0"",
            ""actions"": [
                {
                    ""name"": ""Directions"",
                    ""type"": ""PassThrough"",
                    ""id"": ""6ae0fe6f-7b5c-4175-9299-6b535ea26596"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""2a56788d-59de-4d0a-a27a-5ea500335b8b"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Directions"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""29a26fa8-25c2-4c8b-9b1b-73b424c7a2bb"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Directions"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""78be38e5-abc6-4d50-9120-b5158f4a5ff9"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Directions"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ba29a07e-6cb9-49b6-b75c-19f69836820d"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Directions"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""4aff56d8-5c05-44ed-bf1c-364825345ffc"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Directions"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Inputs player
        m_Inputsplayer = asset.FindActionMap("Inputs player", throwIfNotFound: true);
        m_Inputsplayer_Directions = m_Inputsplayer.FindAction("Directions", throwIfNotFound: true);
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

    // Inputs player
    private readonly InputActionMap m_Inputsplayer;
    private IInputsplayerActions m_InputsplayerActionsCallbackInterface;
    private readonly InputAction m_Inputsplayer_Directions;
    public struct InputsplayerActions
    {
        private @InputMaster m_Wrapper;
        public InputsplayerActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Directions => m_Wrapper.m_Inputsplayer_Directions;
        public InputActionMap Get() { return m_Wrapper.m_Inputsplayer; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InputsplayerActions set) { return set.Get(); }
        public void SetCallbacks(IInputsplayerActions instance)
        {
            if (m_Wrapper.m_InputsplayerActionsCallbackInterface != null)
            {
                @Directions.started -= m_Wrapper.m_InputsplayerActionsCallbackInterface.OnDirections;
                @Directions.performed -= m_Wrapper.m_InputsplayerActionsCallbackInterface.OnDirections;
                @Directions.canceled -= m_Wrapper.m_InputsplayerActionsCallbackInterface.OnDirections;
            }
            m_Wrapper.m_InputsplayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Directions.started += instance.OnDirections;
                @Directions.performed += instance.OnDirections;
                @Directions.canceled += instance.OnDirections;
            }
        }
    }
    public InputsplayerActions @Inputsplayer => new InputsplayerActions(this);
    public interface IInputsplayerActions
    {
        void OnDirections(InputAction.CallbackContext context);
    }
}
