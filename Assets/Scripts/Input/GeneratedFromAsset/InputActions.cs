// GENERATED AUTOMATICALLY FROM 'Assets/InputAssets/InputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace GameInput
{
    public class @InputActions : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @InputActions()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""2e12ff72-c1c7-4f56-9a1a-cba780890eff"",
            ""actions"": [
                {
                    ""name"": ""PointerMove"",
                    ""type"": ""Value"",
                    ""id"": ""ba7dbf10-e377-43a0-a3ed-397dcf5f1272"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Tap"",
                    ""type"": ""Button"",
                    ""id"": ""919fd662-3c5a-401f-b7b2-99156725d0b2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Hold"",
                    ""type"": ""Button"",
                    ""id"": ""3d060d7c-af82-4d0c-a12b-4953fba627ac"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d1de54f3-141c-451e-9c34-3799e46f07c9"",
                    ""path"": ""<Pointer>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touchscreen;Keyboard&mouse"",
                    ""action"": ""PointerMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2372e023-3e9d-4207-b448-61f9031070b9"",
                    ""path"": ""<Touchscreen>/press"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": ""Touchscreen"",
                    ""action"": ""Tap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3c2d900b-200f-4fbc-a2c0-bf64d5c0a94f"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard&mouse"",
                    ""action"": ""Tap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""27cb1168-378d-4588-8a8f-86dc78279cba"",
                    ""path"": ""<Pointer>/press"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Touchscreen;Keyboard&mouse"",
                    ""action"": ""Hold"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Touchscreen"",
            ""bindingGroup"": ""Touchscreen"",
            ""devices"": [
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Keyboard&mouse"",
            ""bindingGroup"": ""Keyboard&mouse"",
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
            // Gameplay
            m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
            m_Gameplay_PointerMove = m_Gameplay.FindAction("PointerMove", throwIfNotFound: true);
            m_Gameplay_Tap = m_Gameplay.FindAction("Tap", throwIfNotFound: true);
            m_Gameplay_Hold = m_Gameplay.FindAction("Hold", throwIfNotFound: true);
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

        // Gameplay
        private readonly InputActionMap m_Gameplay;
        private IGameplayActions m_GameplayActionsCallbackInterface;
        private readonly InputAction m_Gameplay_PointerMove;
        private readonly InputAction m_Gameplay_Tap;
        private readonly InputAction m_Gameplay_Hold;
        public struct GameplayActions
        {
            private @InputActions m_Wrapper;
            public GameplayActions(@InputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @PointerMove => m_Wrapper.m_Gameplay_PointerMove;
            public InputAction @Tap => m_Wrapper.m_Gameplay_Tap;
            public InputAction @Hold => m_Wrapper.m_Gameplay_Hold;
            public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
            public void SetCallbacks(IGameplayActions instance)
            {
                if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
                {
                    @PointerMove.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPointerMove;
                    @PointerMove.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPointerMove;
                    @PointerMove.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPointerMove;
                    @Tap.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTap;
                    @Tap.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTap;
                    @Tap.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTap;
                    @Hold.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnHold;
                    @Hold.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnHold;
                    @Hold.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnHold;
                }
                m_Wrapper.m_GameplayActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @PointerMove.started += instance.OnPointerMove;
                    @PointerMove.performed += instance.OnPointerMove;
                    @PointerMove.canceled += instance.OnPointerMove;
                    @Tap.started += instance.OnTap;
                    @Tap.performed += instance.OnTap;
                    @Tap.canceled += instance.OnTap;
                    @Hold.started += instance.OnHold;
                    @Hold.performed += instance.OnHold;
                    @Hold.canceled += instance.OnHold;
                }
            }
        }
        public GameplayActions @Gameplay => new GameplayActions(this);
        private int m_TouchscreenSchemeIndex = -1;
        public InputControlScheme TouchscreenScheme
        {
            get
            {
                if (m_TouchscreenSchemeIndex == -1) m_TouchscreenSchemeIndex = asset.FindControlSchemeIndex("Touchscreen");
                return asset.controlSchemes[m_TouchscreenSchemeIndex];
            }
        }
        private int m_KeyboardmouseSchemeIndex = -1;
        public InputControlScheme KeyboardmouseScheme
        {
            get
            {
                if (m_KeyboardmouseSchemeIndex == -1) m_KeyboardmouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard&mouse");
                return asset.controlSchemes[m_KeyboardmouseSchemeIndex];
            }
        }
        public interface IGameplayActions
        {
            void OnPointerMove(InputAction.CallbackContext context);
            void OnTap(InputAction.CallbackContext context);
            void OnHold(InputAction.CallbackContext context);
        }
    }
}
