// GENERATED AUTOMATICALLY FROM 'Assets/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace DayNight
{
    public class @Controls : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @Controls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""PlayerMovement"",
            ""id"": ""90054beb-abf3-4447-9893-96f476eec878"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""302f84f4-09bb-46d5-90e1-cfc3626635db"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""650b33c0-e5b7-40d9-ab9d-0e424bbf6f40"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PickupMush"",
                    ""type"": ""Button"",
                    ""id"": ""c9c7fed9-49bf-4809-8743-53456883b365"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""ba0b3d86-2111-4a10-85d9-b985a76d2e87"",
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
                    ""id"": ""b81ff148-fb71-44e3-beb7-16f04ca8170b"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b24919c2-5d30-490e-9d21-0908110e3e09"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""597f9227-ac0c-4815-a14b-5c43e38fc835"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""34171965-0cc4-4ce2-8584-1799b1980ace"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""45a5ca8b-c4cc-4193-99cd-6903a6869838"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4fac800f-0f7f-405a-8edd-c5f921d339db"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PickupMush"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PhotoModeControls"",
            ""id"": ""a18a28b1-3430-4f27-a3d8-dd0593f89c22"",
            ""actions"": [
                {
                    ""name"": ""TakePhoto"",
                    ""type"": ""Button"",
                    ""id"": ""34c603c1-6ba3-47f0-b5f6-fa730abb5cea"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""aabd219e-e80f-4779-a24b-57985bee13b0"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TakePhoto"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Look"",
            ""id"": ""adde448e-3dc0-4e14-8e03-8e72e3e9c3e2"",
            ""actions"": [
                {
                    ""name"": ""Look"",
                    ""type"": ""PassThrough"",
                    ""id"": ""146ad6b5-2abe-46a6-aa98-201c6dd20bff"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""fd7f6883-73d9-47cb-bbe5-7b600634358d"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""DevConsole"",
            ""id"": ""d03f4a45-f3f7-4603-948d-4739151c7051"",
            ""actions"": [
                {
                    ""name"": ""ConsoleToggle"",
                    ""type"": ""Button"",
                    ""id"": ""7366e852-806b-4855-887d-4ff907e0f591"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5dcf7679-5a5d-480d-869c-f6d8c12b7ab9"",
                    ""path"": ""<Keyboard>/rightBracket"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""ConsoleToggle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""InteractionSystem"",
            ""id"": ""14f49be6-eb73-4840-92c3-e00af4b0016c"",
            ""actions"": [
                {
                    ""name"": ""MousePos"",
                    ""type"": ""Value"",
                    ""id"": ""1cdea4cc-6181-423a-926f-243d1999208c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""2caa6613-8a44-4efb-873b-7c775d70261e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d67c8095-6bfe-460c-86a7-6916589d4258"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""345514ec-becd-4095-ae31-0528dbbd80ad"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""MousePos"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""ConstantControls"",
            ""id"": ""5f9792f5-55ff-4c25-abd6-aa00c868bd00"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""3cee83c7-7ec5-4473-98f8-b0948c16547a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""TogglePhotoMode"",
                    ""type"": ""Button"",
                    ""id"": ""8e2097cb-e8d2-42ae-8e14-d571b8fa1fbe"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Craft"",
                    ""type"": ""Button"",
                    ""id"": ""40ed9f19-af34-47eb-88ef-0a6a229ba525"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ff5bca5e-89ba-4ca4-ae53-e1fe6b6ca2e7"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1622c1ce-329a-4b2d-8119-4303037d1f72"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a163022c-51d0-4b9f-93ff-80523607d81b"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TogglePhotoMode"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""920a5870-1e23-4995-9886-5c5d394244eb"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Craft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard&Mouse"",
            ""bindingGroup"": ""Keyboard&Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
            // PlayerMovement
            m_PlayerMovement = asset.FindActionMap("PlayerMovement", throwIfNotFound: true);
            m_PlayerMovement_Movement = m_PlayerMovement.FindAction("Movement", throwIfNotFound: true);
            m_PlayerMovement_Jump = m_PlayerMovement.FindAction("Jump", throwIfNotFound: true);
            m_PlayerMovement_PickupMush = m_PlayerMovement.FindAction("PickupMush", throwIfNotFound: true);
            // PhotoModeControls
            m_PhotoModeControls = asset.FindActionMap("PhotoModeControls", throwIfNotFound: true);
            m_PhotoModeControls_TakePhoto = m_PhotoModeControls.FindAction("TakePhoto", throwIfNotFound: true);
            // Look
            m_Look = asset.FindActionMap("Look", throwIfNotFound: true);
            m_Look_Look = m_Look.FindAction("Look", throwIfNotFound: true);
            // DevConsole
            m_DevConsole = asset.FindActionMap("DevConsole", throwIfNotFound: true);
            m_DevConsole_ConsoleToggle = m_DevConsole.FindAction("ConsoleToggle", throwIfNotFound: true);
            // InteractionSystem
            m_InteractionSystem = asset.FindActionMap("InteractionSystem", throwIfNotFound: true);
            m_InteractionSystem_MousePos = m_InteractionSystem.FindAction("MousePos", throwIfNotFound: true);
            m_InteractionSystem_Interact = m_InteractionSystem.FindAction("Interact", throwIfNotFound: true);
            // ConstantControls
            m_ConstantControls = asset.FindActionMap("ConstantControls", throwIfNotFound: true);
            m_ConstantControls_Pause = m_ConstantControls.FindAction("Pause", throwIfNotFound: true);
            m_ConstantControls_TogglePhotoMode = m_ConstantControls.FindAction("TogglePhotoMode", throwIfNotFound: true);
            m_ConstantControls_Craft = m_ConstantControls.FindAction("Craft", throwIfNotFound: true);
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

        // PlayerMovement
        private readonly InputActionMap m_PlayerMovement;
        private IPlayerMovementActions m_PlayerMovementActionsCallbackInterface;
        private readonly InputAction m_PlayerMovement_Movement;
        private readonly InputAction m_PlayerMovement_Jump;
        private readonly InputAction m_PlayerMovement_PickupMush;
        public struct PlayerMovementActions
        {
            private @Controls m_Wrapper;
            public PlayerMovementActions(@Controls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Movement => m_Wrapper.m_PlayerMovement_Movement;
            public InputAction @Jump => m_Wrapper.m_PlayerMovement_Jump;
            public InputAction @PickupMush => m_Wrapper.m_PlayerMovement_PickupMush;
            public InputActionMap Get() { return m_Wrapper.m_PlayerMovement; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerMovementActions set) { return set.Get(); }
            public void SetCallbacks(IPlayerMovementActions instance)
            {
                if (m_Wrapper.m_PlayerMovementActionsCallbackInterface != null)
                {
                    @Movement.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMovement;
                    @Movement.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMovement;
                    @Movement.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMovement;
                    @Jump.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnJump;
                    @Jump.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnJump;
                    @Jump.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnJump;
                    @PickupMush.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnPickupMush;
                    @PickupMush.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnPickupMush;
                    @PickupMush.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnPickupMush;
                }
                m_Wrapper.m_PlayerMovementActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Movement.started += instance.OnMovement;
                    @Movement.performed += instance.OnMovement;
                    @Movement.canceled += instance.OnMovement;
                    @Jump.started += instance.OnJump;
                    @Jump.performed += instance.OnJump;
                    @Jump.canceled += instance.OnJump;
                    @PickupMush.started += instance.OnPickupMush;
                    @PickupMush.performed += instance.OnPickupMush;
                    @PickupMush.canceled += instance.OnPickupMush;
                }
            }
        }
        public PlayerMovementActions @PlayerMovement => new PlayerMovementActions(this);

        // PhotoModeControls
        private readonly InputActionMap m_PhotoModeControls;
        private IPhotoModeControlsActions m_PhotoModeControlsActionsCallbackInterface;
        private readonly InputAction m_PhotoModeControls_TakePhoto;
        public struct PhotoModeControlsActions
        {
            private @Controls m_Wrapper;
            public PhotoModeControlsActions(@Controls wrapper) { m_Wrapper = wrapper; }
            public InputAction @TakePhoto => m_Wrapper.m_PhotoModeControls_TakePhoto;
            public InputActionMap Get() { return m_Wrapper.m_PhotoModeControls; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PhotoModeControlsActions set) { return set.Get(); }
            public void SetCallbacks(IPhotoModeControlsActions instance)
            {
                if (m_Wrapper.m_PhotoModeControlsActionsCallbackInterface != null)
                {
                    @TakePhoto.started -= m_Wrapper.m_PhotoModeControlsActionsCallbackInterface.OnTakePhoto;
                    @TakePhoto.performed -= m_Wrapper.m_PhotoModeControlsActionsCallbackInterface.OnTakePhoto;
                    @TakePhoto.canceled -= m_Wrapper.m_PhotoModeControlsActionsCallbackInterface.OnTakePhoto;
                }
                m_Wrapper.m_PhotoModeControlsActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @TakePhoto.started += instance.OnTakePhoto;
                    @TakePhoto.performed += instance.OnTakePhoto;
                    @TakePhoto.canceled += instance.OnTakePhoto;
                }
            }
        }
        public PhotoModeControlsActions @PhotoModeControls => new PhotoModeControlsActions(this);

        // Look
        private readonly InputActionMap m_Look;
        private ILookActions m_LookActionsCallbackInterface;
        private readonly InputAction m_Look_Look;
        public struct LookActions
        {
            private @Controls m_Wrapper;
            public LookActions(@Controls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Look => m_Wrapper.m_Look_Look;
            public InputActionMap Get() { return m_Wrapper.m_Look; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(LookActions set) { return set.Get(); }
            public void SetCallbacks(ILookActions instance)
            {
                if (m_Wrapper.m_LookActionsCallbackInterface != null)
                {
                    @Look.started -= m_Wrapper.m_LookActionsCallbackInterface.OnLook;
                    @Look.performed -= m_Wrapper.m_LookActionsCallbackInterface.OnLook;
                    @Look.canceled -= m_Wrapper.m_LookActionsCallbackInterface.OnLook;
                }
                m_Wrapper.m_LookActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Look.started += instance.OnLook;
                    @Look.performed += instance.OnLook;
                    @Look.canceled += instance.OnLook;
                }
            }
        }
        public LookActions @Look => new LookActions(this);

        // DevConsole
        private readonly InputActionMap m_DevConsole;
        private IDevConsoleActions m_DevConsoleActionsCallbackInterface;
        private readonly InputAction m_DevConsole_ConsoleToggle;
        public struct DevConsoleActions
        {
            private @Controls m_Wrapper;
            public DevConsoleActions(@Controls wrapper) { m_Wrapper = wrapper; }
            public InputAction @ConsoleToggle => m_Wrapper.m_DevConsole_ConsoleToggle;
            public InputActionMap Get() { return m_Wrapper.m_DevConsole; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(DevConsoleActions set) { return set.Get(); }
            public void SetCallbacks(IDevConsoleActions instance)
            {
                if (m_Wrapper.m_DevConsoleActionsCallbackInterface != null)
                {
                    @ConsoleToggle.started -= m_Wrapper.m_DevConsoleActionsCallbackInterface.OnConsoleToggle;
                    @ConsoleToggle.performed -= m_Wrapper.m_DevConsoleActionsCallbackInterface.OnConsoleToggle;
                    @ConsoleToggle.canceled -= m_Wrapper.m_DevConsoleActionsCallbackInterface.OnConsoleToggle;
                }
                m_Wrapper.m_DevConsoleActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @ConsoleToggle.started += instance.OnConsoleToggle;
                    @ConsoleToggle.performed += instance.OnConsoleToggle;
                    @ConsoleToggle.canceled += instance.OnConsoleToggle;
                }
            }
        }
        public DevConsoleActions @DevConsole => new DevConsoleActions(this);

        // InteractionSystem
        private readonly InputActionMap m_InteractionSystem;
        private IInteractionSystemActions m_InteractionSystemActionsCallbackInterface;
        private readonly InputAction m_InteractionSystem_MousePos;
        private readonly InputAction m_InteractionSystem_Interact;
        public struct InteractionSystemActions
        {
            private @Controls m_Wrapper;
            public InteractionSystemActions(@Controls wrapper) { m_Wrapper = wrapper; }
            public InputAction @MousePos => m_Wrapper.m_InteractionSystem_MousePos;
            public InputAction @Interact => m_Wrapper.m_InteractionSystem_Interact;
            public InputActionMap Get() { return m_Wrapper.m_InteractionSystem; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(InteractionSystemActions set) { return set.Get(); }
            public void SetCallbacks(IInteractionSystemActions instance)
            {
                if (m_Wrapper.m_InteractionSystemActionsCallbackInterface != null)
                {
                    @MousePos.started -= m_Wrapper.m_InteractionSystemActionsCallbackInterface.OnMousePos;
                    @MousePos.performed -= m_Wrapper.m_InteractionSystemActionsCallbackInterface.OnMousePos;
                    @MousePos.canceled -= m_Wrapper.m_InteractionSystemActionsCallbackInterface.OnMousePos;
                    @Interact.started -= m_Wrapper.m_InteractionSystemActionsCallbackInterface.OnInteract;
                    @Interact.performed -= m_Wrapper.m_InteractionSystemActionsCallbackInterface.OnInteract;
                    @Interact.canceled -= m_Wrapper.m_InteractionSystemActionsCallbackInterface.OnInteract;
                }
                m_Wrapper.m_InteractionSystemActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @MousePos.started += instance.OnMousePos;
                    @MousePos.performed += instance.OnMousePos;
                    @MousePos.canceled += instance.OnMousePos;
                    @Interact.started += instance.OnInteract;
                    @Interact.performed += instance.OnInteract;
                    @Interact.canceled += instance.OnInteract;
                }
            }
        }
        public InteractionSystemActions @InteractionSystem => new InteractionSystemActions(this);

        // ConstantControls
        private readonly InputActionMap m_ConstantControls;
        private IConstantControlsActions m_ConstantControlsActionsCallbackInterface;
        private readonly InputAction m_ConstantControls_Pause;
        private readonly InputAction m_ConstantControls_TogglePhotoMode;
        private readonly InputAction m_ConstantControls_Craft;
        public struct ConstantControlsActions
        {
            private @Controls m_Wrapper;
            public ConstantControlsActions(@Controls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Pause => m_Wrapper.m_ConstantControls_Pause;
            public InputAction @TogglePhotoMode => m_Wrapper.m_ConstantControls_TogglePhotoMode;
            public InputAction @Craft => m_Wrapper.m_ConstantControls_Craft;
            public InputActionMap Get() { return m_Wrapper.m_ConstantControls; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(ConstantControlsActions set) { return set.Get(); }
            public void SetCallbacks(IConstantControlsActions instance)
            {
                if (m_Wrapper.m_ConstantControlsActionsCallbackInterface != null)
                {
                    @Pause.started -= m_Wrapper.m_ConstantControlsActionsCallbackInterface.OnPause;
                    @Pause.performed -= m_Wrapper.m_ConstantControlsActionsCallbackInterface.OnPause;
                    @Pause.canceled -= m_Wrapper.m_ConstantControlsActionsCallbackInterface.OnPause;
                    @TogglePhotoMode.started -= m_Wrapper.m_ConstantControlsActionsCallbackInterface.OnTogglePhotoMode;
                    @TogglePhotoMode.performed -= m_Wrapper.m_ConstantControlsActionsCallbackInterface.OnTogglePhotoMode;
                    @TogglePhotoMode.canceled -= m_Wrapper.m_ConstantControlsActionsCallbackInterface.OnTogglePhotoMode;
                    @Craft.started -= m_Wrapper.m_ConstantControlsActionsCallbackInterface.OnCraft;
                    @Craft.performed -= m_Wrapper.m_ConstantControlsActionsCallbackInterface.OnCraft;
                    @Craft.canceled -= m_Wrapper.m_ConstantControlsActionsCallbackInterface.OnCraft;
                }
                m_Wrapper.m_ConstantControlsActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Pause.started += instance.OnPause;
                    @Pause.performed += instance.OnPause;
                    @Pause.canceled += instance.OnPause;
                    @TogglePhotoMode.started += instance.OnTogglePhotoMode;
                    @TogglePhotoMode.performed += instance.OnTogglePhotoMode;
                    @TogglePhotoMode.canceled += instance.OnTogglePhotoMode;
                    @Craft.started += instance.OnCraft;
                    @Craft.performed += instance.OnCraft;
                    @Craft.canceled += instance.OnCraft;
                }
            }
        }
        public ConstantControlsActions @ConstantControls => new ConstantControlsActions(this);
        private int m_KeyboardMouseSchemeIndex = -1;
        public InputControlScheme KeyboardMouseScheme
        {
            get
            {
                if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard&Mouse");
                return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
            }
        }
        public interface IPlayerMovementActions
        {
            void OnMovement(InputAction.CallbackContext context);
            void OnJump(InputAction.CallbackContext context);
            void OnPickupMush(InputAction.CallbackContext context);
        }
        public interface IPhotoModeControlsActions
        {
            void OnTakePhoto(InputAction.CallbackContext context);
        }
        public interface ILookActions
        {
            void OnLook(InputAction.CallbackContext context);
        }
        public interface IDevConsoleActions
        {
            void OnConsoleToggle(InputAction.CallbackContext context);
        }
        public interface IInteractionSystemActions
        {
            void OnMousePos(InputAction.CallbackContext context);
            void OnInteract(InputAction.CallbackContext context);
        }
        public interface IConstantControlsActions
        {
            void OnPause(InputAction.CallbackContext context);
            void OnTogglePhotoMode(InputAction.CallbackContext context);
            void OnCraft(InputAction.CallbackContext context);
        }
    }
}
