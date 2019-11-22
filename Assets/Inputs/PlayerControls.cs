// GENERATED AUTOMATICALLY FROM 'Assets/Inputs/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    private InputActionAsset asset;
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""PlayersControls"",
            ""id"": ""61587923-c31b-4239-8cd5-680108b0327f"",
            ""actions"": [
                {
                    ""name"": ""Movements"",
                    ""type"": ""Value"",
                    ""id"": ""034facf0-a539-4fb5-8db5-9e6fc6a42063"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""cc8b1cd3-c168-4c45-9c34-b1a7a0404d5c"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movements"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""6b570ac9-dbbc-45d9-8ede-dc4ce116abb2"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movements"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""fa9fff97-9a05-4511-925f-bd5947b225b5"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movements"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""295bb040-89a0-4f24-a5e1-2af8c3e5e528"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movements"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""87cc952e-3f0e-430a-af78-2918ae6fda51"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movements"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayersControls
        m_PlayersControls = asset.FindActionMap("PlayersControls", throwIfNotFound: true);
        m_PlayersControls_Movements = m_PlayersControls.FindAction("Movements", throwIfNotFound: true);
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

    // PlayersControls
    private readonly InputActionMap m_PlayersControls;
    private IPlayersControlsActions m_PlayersControlsActionsCallbackInterface;
    private readonly InputAction m_PlayersControls_Movements;
    public struct PlayersControlsActions
    {
        private @PlayerControls m_Wrapper;
        public PlayersControlsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movements => m_Wrapper.m_PlayersControls_Movements;
        public InputActionMap Get() { return m_Wrapper.m_PlayersControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayersControlsActions set) { return set.Get(); }
        public void SetCallbacks(IPlayersControlsActions instance)
        {
            if (m_Wrapper.m_PlayersControlsActionsCallbackInterface != null)
            {
                @Movements.started -= m_Wrapper.m_PlayersControlsActionsCallbackInterface.OnMovements;
                @Movements.performed -= m_Wrapper.m_PlayersControlsActionsCallbackInterface.OnMovements;
                @Movements.canceled -= m_Wrapper.m_PlayersControlsActionsCallbackInterface.OnMovements;
            }
            m_Wrapper.m_PlayersControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movements.started += instance.OnMovements;
                @Movements.performed += instance.OnMovements;
                @Movements.canceled += instance.OnMovements;
            }
        }
    }
    public PlayersControlsActions @PlayersControls => new PlayersControlsActions(this);
    public interface IPlayersControlsActions
    {
        void OnMovements(InputAction.CallbackContext context);
    }
}
