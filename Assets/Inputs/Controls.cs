// GENERATED AUTOMATICALLY FROM 'Assets/Inputs/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

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
                },
                {
                    ""name"": ""ChangeHeldItem"",
                    ""type"": ""Value"",
                    ""id"": ""eadac7ca-2b5f-4001-9abf-f519fa1345a8"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""History"",
                    ""type"": ""Button"",
                    ""id"": ""34903aa4-b8c2-4a7d-8290-78a3e1f9ca12"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""NormalizeVector2"",
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
                },
                {
                    ""name"": """",
                    ""id"": ""519759e6-fcd4-4d99-a167-68482c8e63d6"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": ""NormalizeVector2"",
                    ""groups"": """",
                    ""action"": ""ChangeHeldItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6214b056-ab95-4fa0-9bc3-dc8ad7a217b6"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""History"",
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
                    ""type"": ""Value"",
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
                }
            ]
        },
        {
            ""name"": ""TabletShortcuts"",
            ""id"": ""d24d287f-c1c8-44e3-8d1a-676254880f4e"",
            ""actions"": [
                {
                    ""name"": ""Journal"",
                    ""type"": ""Button"",
                    ""id"": ""4378acf4-e55a-44c4-b331-4558d02431f0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PhotoMode"",
                    ""type"": ""Button"",
                    ""id"": ""f26c9d51-c832-44ef-8c59-34c9d3ad2bae"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Email"",
                    ""type"": ""Button"",
                    ""id"": ""987c6622-cb85-401a-a851-31200a95f8be"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""46dec6c0-2bb4-4475-944f-00fd2d3bd2b1"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Journal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bac9d1c8-4176-43f6-b2d7-320de396cca4"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PhotoMode"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""207b5c92-7fe4-4ecb-a251-6243f71efc4d"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Email"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""StartGameText"",
            ""id"": ""517a8015-a351-4139-9315-f0c6e5960603"",
            ""actions"": [
                {
                    ""name"": ""Progress/Skip"",
                    ""type"": ""Button"",
                    ""id"": ""2a129f34-a3a2-44a9-8320-27498e920e48"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c094b685-ba07-4a2e-b753-9e9eb7851366"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Progress/Skip"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""GunConrols"",
            ""id"": ""f9c67952-f090-4533-bf11-e899169c2624"",
            ""actions"": [
                {
                    ""name"": ""CycleAmmo"",
                    ""type"": ""Button"",
                    ""id"": ""d1dd9766-15ee-4f0c-8d4c-f2f4477e5ef6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""170416cf-f669-4cd4-a6e2-e66acc23cab1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e7e89444-54a3-4c03-a1e8-2b6b5930a887"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CycleAmmo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0e9f29df-bd54-4136-bcaf-5ce327cc10cd"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""History"",
            ""id"": ""ca49f3be-ac3d-49b3-8a32-33af76b2f069"",
            ""actions"": [
                {
                    ""name"": ""History Activation"",
                    ""type"": ""Button"",
                    ""id"": ""2b95d9de-fd20-46b4-a622-b6074d41920e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""661a58f0-35e1-4c6f-9d03-cb1f496b20a1"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""History Activation"",
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
        m_PlayerMovement_ChangeHeldItem = m_PlayerMovement.FindAction("ChangeHeldItem", throwIfNotFound: true);
        m_PlayerMovement_History = m_PlayerMovement.FindAction("History", throwIfNotFound: true);
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
        // TabletShortcuts
        m_TabletShortcuts = asset.FindActionMap("TabletShortcuts", throwIfNotFound: true);
        m_TabletShortcuts_Journal = m_TabletShortcuts.FindAction("Journal", throwIfNotFound: true);
        m_TabletShortcuts_PhotoMode = m_TabletShortcuts.FindAction("PhotoMode", throwIfNotFound: true);
        m_TabletShortcuts_Email = m_TabletShortcuts.FindAction("Email", throwIfNotFound: true);
        // StartGameText
        m_StartGameText = asset.FindActionMap("StartGameText", throwIfNotFound: true);
        m_StartGameText_ProgressSkip = m_StartGameText.FindAction("Progress/Skip", throwIfNotFound: true);
        // GunConrols
        m_GunConrols = asset.FindActionMap("GunConrols", throwIfNotFound: true);
        m_GunConrols_CycleAmmo = m_GunConrols.FindAction("CycleAmmo", throwIfNotFound: true);
        m_GunConrols_Fire = m_GunConrols.FindAction("Fire", throwIfNotFound: true);
        // History
        m_History = asset.FindActionMap("History", throwIfNotFound: true);
        m_History_HistoryActivation = m_History.FindAction("History Activation", throwIfNotFound: true);
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
    private readonly InputAction m_PlayerMovement_ChangeHeldItem;
    private readonly InputAction m_PlayerMovement_History;
    public struct PlayerMovementActions
    {
        private @Controls m_Wrapper;
        public PlayerMovementActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerMovement_Movement;
        public InputAction @Jump => m_Wrapper.m_PlayerMovement_Jump;
        public InputAction @PickupMush => m_Wrapper.m_PlayerMovement_PickupMush;
        public InputAction @ChangeHeldItem => m_Wrapper.m_PlayerMovement_ChangeHeldItem;
        public InputAction @History => m_Wrapper.m_PlayerMovement_History;
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
                @ChangeHeldItem.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnChangeHeldItem;
                @ChangeHeldItem.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnChangeHeldItem;
                @ChangeHeldItem.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnChangeHeldItem;
                @History.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnHistory;
                @History.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnHistory;
                @History.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnHistory;
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
                @ChangeHeldItem.started += instance.OnChangeHeldItem;
                @ChangeHeldItem.performed += instance.OnChangeHeldItem;
                @ChangeHeldItem.canceled += instance.OnChangeHeldItem;
                @History.started += instance.OnHistory;
                @History.performed += instance.OnHistory;
                @History.canceled += instance.OnHistory;
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
    public struct ConstantControlsActions
    {
        private @Controls m_Wrapper;
        public ConstantControlsActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause => m_Wrapper.m_ConstantControls_Pause;
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
            }
            m_Wrapper.m_ConstantControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public ConstantControlsActions @ConstantControls => new ConstantControlsActions(this);

    // TabletShortcuts
    private readonly InputActionMap m_TabletShortcuts;
    private ITabletShortcutsActions m_TabletShortcutsActionsCallbackInterface;
    private readonly InputAction m_TabletShortcuts_Journal;
    private readonly InputAction m_TabletShortcuts_PhotoMode;
    private readonly InputAction m_TabletShortcuts_Email;
    public struct TabletShortcutsActions
    {
        private @Controls m_Wrapper;
        public TabletShortcutsActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Journal => m_Wrapper.m_TabletShortcuts_Journal;
        public InputAction @PhotoMode => m_Wrapper.m_TabletShortcuts_PhotoMode;
        public InputAction @Email => m_Wrapper.m_TabletShortcuts_Email;
        public InputActionMap Get() { return m_Wrapper.m_TabletShortcuts; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TabletShortcutsActions set) { return set.Get(); }
        public void SetCallbacks(ITabletShortcutsActions instance)
        {
            if (m_Wrapper.m_TabletShortcutsActionsCallbackInterface != null)
            {
                @Journal.started -= m_Wrapper.m_TabletShortcutsActionsCallbackInterface.OnJournal;
                @Journal.performed -= m_Wrapper.m_TabletShortcutsActionsCallbackInterface.OnJournal;
                @Journal.canceled -= m_Wrapper.m_TabletShortcutsActionsCallbackInterface.OnJournal;
                @PhotoMode.started -= m_Wrapper.m_TabletShortcutsActionsCallbackInterface.OnPhotoMode;
                @PhotoMode.performed -= m_Wrapper.m_TabletShortcutsActionsCallbackInterface.OnPhotoMode;
                @PhotoMode.canceled -= m_Wrapper.m_TabletShortcutsActionsCallbackInterface.OnPhotoMode;
                @Email.started -= m_Wrapper.m_TabletShortcutsActionsCallbackInterface.OnEmail;
                @Email.performed -= m_Wrapper.m_TabletShortcutsActionsCallbackInterface.OnEmail;
                @Email.canceled -= m_Wrapper.m_TabletShortcutsActionsCallbackInterface.OnEmail;
            }
            m_Wrapper.m_TabletShortcutsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Journal.started += instance.OnJournal;
                @Journal.performed += instance.OnJournal;
                @Journal.canceled += instance.OnJournal;
                @PhotoMode.started += instance.OnPhotoMode;
                @PhotoMode.performed += instance.OnPhotoMode;
                @PhotoMode.canceled += instance.OnPhotoMode;
                @Email.started += instance.OnEmail;
                @Email.performed += instance.OnEmail;
                @Email.canceled += instance.OnEmail;
            }
        }
    }
    public TabletShortcutsActions @TabletShortcuts => new TabletShortcutsActions(this);

    // StartGameText
    private readonly InputActionMap m_StartGameText;
    private IStartGameTextActions m_StartGameTextActionsCallbackInterface;
    private readonly InputAction m_StartGameText_ProgressSkip;
    public struct StartGameTextActions
    {
        private @Controls m_Wrapper;
        public StartGameTextActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @ProgressSkip => m_Wrapper.m_StartGameText_ProgressSkip;
        public InputActionMap Get() { return m_Wrapper.m_StartGameText; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(StartGameTextActions set) { return set.Get(); }
        public void SetCallbacks(IStartGameTextActions instance)
        {
            if (m_Wrapper.m_StartGameTextActionsCallbackInterface != null)
            {
                @ProgressSkip.started -= m_Wrapper.m_StartGameTextActionsCallbackInterface.OnProgressSkip;
                @ProgressSkip.performed -= m_Wrapper.m_StartGameTextActionsCallbackInterface.OnProgressSkip;
                @ProgressSkip.canceled -= m_Wrapper.m_StartGameTextActionsCallbackInterface.OnProgressSkip;
            }
            m_Wrapper.m_StartGameTextActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ProgressSkip.started += instance.OnProgressSkip;
                @ProgressSkip.performed += instance.OnProgressSkip;
                @ProgressSkip.canceled += instance.OnProgressSkip;
            }
        }
    }
    public StartGameTextActions @StartGameText => new StartGameTextActions(this);

    // GunConrols
    private readonly InputActionMap m_GunConrols;
    private IGunConrolsActions m_GunConrolsActionsCallbackInterface;
    private readonly InputAction m_GunConrols_CycleAmmo;
    private readonly InputAction m_GunConrols_Fire;
    public struct GunConrolsActions
    {
        private @Controls m_Wrapper;
        public GunConrolsActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @CycleAmmo => m_Wrapper.m_GunConrols_CycleAmmo;
        public InputAction @Fire => m_Wrapper.m_GunConrols_Fire;
        public InputActionMap Get() { return m_Wrapper.m_GunConrols; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GunConrolsActions set) { return set.Get(); }
        public void SetCallbacks(IGunConrolsActions instance)
        {
            if (m_Wrapper.m_GunConrolsActionsCallbackInterface != null)
            {
                @CycleAmmo.started -= m_Wrapper.m_GunConrolsActionsCallbackInterface.OnCycleAmmo;
                @CycleAmmo.performed -= m_Wrapper.m_GunConrolsActionsCallbackInterface.OnCycleAmmo;
                @CycleAmmo.canceled -= m_Wrapper.m_GunConrolsActionsCallbackInterface.OnCycleAmmo;
                @Fire.started -= m_Wrapper.m_GunConrolsActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_GunConrolsActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_GunConrolsActionsCallbackInterface.OnFire;
            }
            m_Wrapper.m_GunConrolsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @CycleAmmo.started += instance.OnCycleAmmo;
                @CycleAmmo.performed += instance.OnCycleAmmo;
                @CycleAmmo.canceled += instance.OnCycleAmmo;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
            }
        }
    }
    public GunConrolsActions @GunConrols => new GunConrolsActions(this);

    // History
    private readonly InputActionMap m_History;
    private IHistoryActions m_HistoryActionsCallbackInterface;
    private readonly InputAction m_History_HistoryActivation;
    public struct HistoryActions
    {
        private @Controls m_Wrapper;
        public HistoryActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @HistoryActivation => m_Wrapper.m_History_HistoryActivation;
        public InputActionMap Get() { return m_Wrapper.m_History; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(HistoryActions set) { return set.Get(); }
        public void SetCallbacks(IHistoryActions instance)
        {
            if (m_Wrapper.m_HistoryActionsCallbackInterface != null)
            {
                @HistoryActivation.started -= m_Wrapper.m_HistoryActionsCallbackInterface.OnHistoryActivation;
                @HistoryActivation.performed -= m_Wrapper.m_HistoryActionsCallbackInterface.OnHistoryActivation;
                @HistoryActivation.canceled -= m_Wrapper.m_HistoryActionsCallbackInterface.OnHistoryActivation;
            }
            m_Wrapper.m_HistoryActionsCallbackInterface = instance;
            if (instance != null)
            {
                @HistoryActivation.started += instance.OnHistoryActivation;
                @HistoryActivation.performed += instance.OnHistoryActivation;
                @HistoryActivation.canceled += instance.OnHistoryActivation;
            }
        }
    }
    public HistoryActions @History => new HistoryActions(this);
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
        void OnChangeHeldItem(InputAction.CallbackContext context);
        void OnHistory(InputAction.CallbackContext context);
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
    }
    public interface ITabletShortcutsActions
    {
        void OnJournal(InputAction.CallbackContext context);
        void OnPhotoMode(InputAction.CallbackContext context);
        void OnEmail(InputAction.CallbackContext context);
    }
    public interface IStartGameTextActions
    {
        void OnProgressSkip(InputAction.CallbackContext context);
    }
    public interface IGunConrolsActions
    {
        void OnCycleAmmo(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
    }
    public interface IHistoryActions
    {
        void OnHistoryActivation(InputAction.CallbackContext context);
    }
}
