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
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack1"",
                    ""type"": ""Button"",
                    ""id"": ""663e4ab0-279a-40a9-8847-f7ede315f2de"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack2"",
                    ""type"": ""Button"",
                    ""id"": ""3c9b685f-3b50-4a44-a85c-fc8b3a0801c7"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""bb0872e2-bb47-4d0a-8f27-9c13b164f8af"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": ""GamePads"",
                    ""action"": ""Movements"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
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
                    ""groups"": ""Keyboard"",
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
                    ""groups"": ""Keyboard"",
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
                    ""groups"": ""Keyboard"",
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
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movements"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""ArrowKeys"",
                    ""id"": ""ebffacfd-1f17-4e58-985e-0d2ab51f5016"",
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
                    ""id"": ""d82be9cd-822a-49a5-8df6-cd0d51efef66"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movements"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d03e0f7a-2e2b-430f-b9d7-a897b7a80922"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movements"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""5f134bb7-bfe4-4f58-ad26-7873263611a8"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movements"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""d57963e3-7001-46a3-b29a-8b645a526335"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movements"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""af27f550-20ac-4292-84e9-466b44043487"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePads"",
                    ""action"": ""Attack1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""35db9dc1-e813-45ec-b2dd-bdcfeab2b02e"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Attack1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5997a6ac-9f19-45ac-8a5f-bd51c756078d"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePads"",
                    ""action"": ""Attack2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6deb04a9-33e7-4b2b-9c0b-8c2ad0b0126e"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Attack2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""GamePads"",
            ""bindingGroup"": ""GamePads"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // PlayersControls
        m_PlayersControls = asset.FindActionMap("PlayersControls", throwIfNotFound: true);
        m_PlayersControls_Movements = m_PlayersControls.FindAction("Movements", throwIfNotFound: true);
        m_PlayersControls_Attack1 = m_PlayersControls.FindAction("Attack1", throwIfNotFound: true);
        m_PlayersControls_Attack2 = m_PlayersControls.FindAction("Attack2", throwIfNotFound: true);
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
    private readonly InputAction m_PlayersControls_Attack1;
    private readonly InputAction m_PlayersControls_Attack2;
    public struct PlayersControlsActions
    {
        private @PlayerControls m_Wrapper;
        public PlayersControlsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movements => m_Wrapper.m_PlayersControls_Movements;
        public InputAction @Attack1 => m_Wrapper.m_PlayersControls_Attack1;
        public InputAction @Attack2 => m_Wrapper.m_PlayersControls_Attack2;
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
                @Attack1.started -= m_Wrapper.m_PlayersControlsActionsCallbackInterface.OnAttack1;
                @Attack1.performed -= m_Wrapper.m_PlayersControlsActionsCallbackInterface.OnAttack1;
                @Attack1.canceled -= m_Wrapper.m_PlayersControlsActionsCallbackInterface.OnAttack1;
                @Attack2.started -= m_Wrapper.m_PlayersControlsActionsCallbackInterface.OnAttack2;
                @Attack2.performed -= m_Wrapper.m_PlayersControlsActionsCallbackInterface.OnAttack2;
                @Attack2.canceled -= m_Wrapper.m_PlayersControlsActionsCallbackInterface.OnAttack2;
            }
            m_Wrapper.m_PlayersControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movements.started += instance.OnMovements;
                @Movements.performed += instance.OnMovements;
                @Movements.canceled += instance.OnMovements;
                @Attack1.started += instance.OnAttack1;
                @Attack1.performed += instance.OnAttack1;
                @Attack1.canceled += instance.OnAttack1;
                @Attack2.started += instance.OnAttack2;
                @Attack2.performed += instance.OnAttack2;
                @Attack2.canceled += instance.OnAttack2;
            }
        }
    }
    public PlayersControlsActions @PlayersControls => new PlayersControlsActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_GamePadsSchemeIndex = -1;
    public InputControlScheme GamePadsScheme
    {
        get
        {
            if (m_GamePadsSchemeIndex == -1) m_GamePadsSchemeIndex = asset.FindControlSchemeIndex("GamePads");
            return asset.controlSchemes[m_GamePadsSchemeIndex];
        }
    }
    public interface IPlayersControlsActions
    {
        void OnMovements(InputAction.CallbackContext context);
        void OnAttack1(InputAction.CallbackContext context);
        void OnAttack2(InputAction.CallbackContext context);
    }
}
