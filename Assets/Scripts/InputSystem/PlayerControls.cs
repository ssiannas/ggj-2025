//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.12.0
//     from Assets/Scripts/InputSystem/PlayerControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace ggj_2025
{
    /// <summary>
    /// Provides programmatic access to <see cref="InputActionAsset" />, <see cref="InputActionMap" />, <see cref="InputAction" /> and <see cref="InputControlScheme" /> instances defined in asset "Assets/Scripts/InputSystem/PlayerControls.inputactions".
    /// </summary>
    /// <remarks>
    /// This class is source generated and any manual edits will be discarded if the associated asset is reimported or modified.
    /// </remarks>
    /// <example>
    /// <code>
    /// using namespace UnityEngine;
    /// using UnityEngine.InputSystem;
    ///
    /// // Example of using an InputActionMap named "Player" from a UnityEngine.MonoBehaviour implementing callback interface.
    /// public class Example : MonoBehaviour, MyActions.IPlayerActions
    /// {
    ///     private MyActions_Actions m_Actions;                  // Source code representation of asset.
    ///     private MyActions_Actions.PlayerActions m_Player;     // Source code representation of action map.
    ///
    ///     void Awake()
    ///     {
    ///         m_Actions = new MyActions_Actions();              // Create asset object.
    ///         m_Player = m_Actions.Player;                      // Extract action map object.
    ///         m_Player.AddCallbacks(this);                      // Register callback interface IPlayerActions.
    ///     }
    ///
    ///     void OnDestroy()
    ///     {
    ///         m_Actions.Dispose();                              // Destroy asset object.
    ///     }
    ///
    ///     void OnEnable()
    ///     {
    ///         m_Player.Enable();                                // Enable all actions within map.
    ///     }
    ///
    ///     void OnDisable()
    ///     {
    ///         m_Player.Disable();                               // Disable all actions within map.
    ///     }
    ///
    ///     #region Interface implementation of MyActions.IPlayerActions
    ///
    ///     // Invoked when "Move" action is either started, performed or canceled.
    ///     public void OnMove(InputAction.CallbackContext context)
    ///     {
    ///         Debug.Log($"OnMove: {context.ReadValue&lt;Vector2&gt;()}");
    ///     }
    ///
    ///     // Invoked when "Attack" action is either started, performed or canceled.
    ///     public void OnAttack(InputAction.CallbackContext context)
    ///     {
    ///         Debug.Log($"OnAttack: {context.ReadValue&lt;float&gt;()}");
    ///     }
    ///
    ///     #endregion
    /// }
    /// </code>
    /// </example>
    public partial class @PlayerControls: IInputActionCollection2, IDisposable
    {
        /// <summary>
        /// Provides access to the underlying asset instance.
        /// </summary>
        public InputActionAsset asset { get; }

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public @PlayerControls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""BaseMoveset"",
            ""id"": ""7f4b233b-760e-4828-8eeb-61da4359c195"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""054cf136-4826-418b-95c8-02e1138a9926"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""7c46b04d-156c-487d-8bf1-635d7279e131"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Value"",
                    ""id"": ""a5189dcb-6d10-41c6-9f73-d511e679bbd9"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Special"",
                    ""type"": ""Button"",
                    ""id"": ""30b43ca7-457d-43f5-80ea-652ae551fb0c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""AimMouse"",
                    ""type"": ""Value"",
                    ""id"": ""c8d9e260-002f-4d86-8048-91e35a7d55ed"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a9327c32-add1-4c37-846a-a081b90d9930"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1c468b07-6336-47a0-944b-6ed441505275"",
                    ""path"": ""<DualShockGamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""77422b90-8a59-4351-a259-a344f7303a01"",
                    ""path"": ""<DualSenseGamepadHID>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""c7e35c14-4ff1-4ed7-a6df-b8e609e8c81a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""ca05558f-fc59-4154-9453-1a2987047c70"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""453350c3-ab7b-4391-99e1-246f8dd40519"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""e44afbfd-24b3-4931-86f6-91ae44c07e35"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""6d9f26a1-a5f8-420e-a6cd-20b6c9651fa9"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""cfc16c5a-433a-48a9-891a-1e0312884df1"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""50ea4a85-979b-4232-a5db-c4ea590c7e41"",
                    ""path"": ""<DualShockGamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ebb47051-b18d-4b31-8da1-c98f35bf28c2"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c8556e2b-9748-40e4-91d6-514b40787ea4"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""caf6740a-b928-444d-bdbb-f3a59fcd9bbb"",
                    ""path"": ""<DualSenseGamepadHID>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ccf9e2c2-5d04-43f8-8c06-84e62661d506"",
                    ""path"": ""<DualShockGamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""abd7d6a8-fe6f-4732-b482-ad4ef3e30c18"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Special"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6d607ed7-7721-4060-95fa-cc76d21b2f20"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Special"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9149079d-dfd4-49c6-9dc3-ed9b3346c388"",
                    ""path"": ""<DualShockGamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Special"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""62e13a02-e9d1-4de8-aeeb-eefb41dc601e"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""AimMouse"",
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
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
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
            // BaseMoveset
            m_BaseMoveset = asset.FindActionMap("BaseMoveset", throwIfNotFound: true);
            m_BaseMoveset_Move = m_BaseMoveset.FindAction("Move", throwIfNotFound: true);
            m_BaseMoveset_Fire = m_BaseMoveset.FindAction("Fire", throwIfNotFound: true);
            m_BaseMoveset_Aim = m_BaseMoveset.FindAction("Aim", throwIfNotFound: true);
            m_BaseMoveset_Special = m_BaseMoveset.FindAction("Special", throwIfNotFound: true);
            m_BaseMoveset_AimMouse = m_BaseMoveset.FindAction("AimMouse", throwIfNotFound: true);
        }

        ~@PlayerControls()
        {
            UnityEngine.Debug.Assert(!m_BaseMoveset.enabled, "This will cause a leak and performance issues, PlayerControls.BaseMoveset.Disable() has not been called.");
        }

        /// <summary>
        /// Destroys this asset and all associated <see cref="InputAction"/> instances.
        /// </summary>
        public void Dispose()
        {
            UnityEngine.Object.Destroy(asset);
        }

        /// <inheritdoc cref="UnityEngine.InputSystem.InputActionAsset.bindingMask" />
        public InputBinding? bindingMask
        {
            get => asset.bindingMask;
            set => asset.bindingMask = value;
        }

        /// <inheritdoc cref="UnityEngine.InputSystem.InputActionAsset.devices" />
        public ReadOnlyArray<InputDevice>? devices
        {
            get => asset.devices;
            set => asset.devices = value;
        }

        /// <inheritdoc cref="UnityEngine.InputSystem.InputActionAsset.controlSchemes" />
        public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

        /// <inheritdoc cref="UnityEngine.InputSystem.InputActionAsset.Contains(InputAction)" />
        public bool Contains(InputAction action)
        {
            return asset.Contains(action);
        }

        /// <inheritdoc cref="UnityEngine.InputSystem.InputActionAsset.GetEnumerator()" />
        public IEnumerator<InputAction> GetEnumerator()
        {
            return asset.GetEnumerator();
        }

        /// <inheritdoc cref="IEnumerable.GetEnumerator()" />
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <inheritdoc cref="UnityEngine.InputSystem.InputActionAsset.Enable()" />
        public void Enable()
        {
            asset.Enable();
        }

        /// <inheritdoc cref="UnityEngine.InputSystem.InputActionAsset.Disable()" />
        public void Disable()
        {
            asset.Disable();
        }

        /// <inheritdoc cref="UnityEngine.InputSystem.InputActionAsset.bindings" />
        public IEnumerable<InputBinding> bindings => asset.bindings;

        /// <inheritdoc cref="UnityEngine.InputSystem.InputActionAsset.FindAction(string, bool)" />
        public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
        {
            return asset.FindAction(actionNameOrId, throwIfNotFound);
        }

        /// <inheritdoc cref="UnityEngine.InputSystem.InputActionAsset.FindBinding(InputBinding, out InputAction)" />
        public int FindBinding(InputBinding bindingMask, out InputAction action)
        {
            return asset.FindBinding(bindingMask, out action);
        }

        // BaseMoveset
        private readonly InputActionMap m_BaseMoveset;
        private List<IBaseMovesetActions> m_BaseMovesetActionsCallbackInterfaces = new List<IBaseMovesetActions>();
        private readonly InputAction m_BaseMoveset_Move;
        private readonly InputAction m_BaseMoveset_Fire;
        private readonly InputAction m_BaseMoveset_Aim;
        private readonly InputAction m_BaseMoveset_Special;
        private readonly InputAction m_BaseMoveset_AimMouse;
        /// <summary>
        /// Provides access to input actions defined in input action map "BaseMoveset".
        /// </summary>
        public struct BaseMovesetActions
        {
            private @PlayerControls m_Wrapper;

            /// <summary>
            /// Construct a new instance of the input action map wrapper class.
            /// </summary>
            public BaseMovesetActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
            /// <summary>
            /// Provides access to the underlying input action "BaseMoveset/Move".
            /// </summary>
            public InputAction @Move => m_Wrapper.m_BaseMoveset_Move;
            /// <summary>
            /// Provides access to the underlying input action "BaseMoveset/Fire".
            /// </summary>
            public InputAction @Fire => m_Wrapper.m_BaseMoveset_Fire;
            /// <summary>
            /// Provides access to the underlying input action "BaseMoveset/Aim".
            /// </summary>
            public InputAction @Aim => m_Wrapper.m_BaseMoveset_Aim;
            /// <summary>
            /// Provides access to the underlying input action "BaseMoveset/Special".
            /// </summary>
            public InputAction @Special => m_Wrapper.m_BaseMoveset_Special;
            /// <summary>
            /// Provides access to the underlying input action "BaseMoveset/AimMouse".
            /// </summary>
            public InputAction @AimMouse => m_Wrapper.m_BaseMoveset_AimMouse;
            /// <summary>
            /// Provides access to the underlying input action map instance.
            /// </summary>
            public InputActionMap Get() { return m_Wrapper.m_BaseMoveset; }
            /// <inheritdoc cref="UnityEngine.InputSystem.InputActionMap.Enable()" />
            public void Enable() { Get().Enable(); }
            /// <inheritdoc cref="UnityEngine.InputSystem.InputActionMap.Disable()" />
            public void Disable() { Get().Disable(); }
            /// <inheritdoc cref="UnityEngine.InputSystem.InputActionMap.enabled" />
            public bool enabled => Get().enabled;
            /// <summary>
            /// Implicitly converts an <see ref="BaseMovesetActions" /> to an <see ref="InputActionMap" /> instance.
            /// </summary>
            public static implicit operator InputActionMap(BaseMovesetActions set) { return set.Get(); }
            /// <summary>
            /// Adds <see cref="InputAction.started"/>, <see cref="InputAction.performed"/> and <see cref="InputAction.canceled"/> callbacks provided via <param cref="instance" /> on all input actions contained in this map.
            /// </summary>
            /// <param name="instance">Callback instance.</param>
            /// <remarks>
            /// If <paramref name="instance" /> is <c>null</c> or <paramref name="instance"/> have already been added this method does nothing.
            /// </remarks>
            /// <seealso cref="BaseMovesetActions" />
            public void AddCallbacks(IBaseMovesetActions instance)
            {
                if (instance == null || m_Wrapper.m_BaseMovesetActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_BaseMovesetActionsCallbackInterfaces.Add(instance);
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @Special.started += instance.OnSpecial;
                @Special.performed += instance.OnSpecial;
                @Special.canceled += instance.OnSpecial;
                @AimMouse.started += instance.OnAimMouse;
                @AimMouse.performed += instance.OnAimMouse;
                @AimMouse.canceled += instance.OnAimMouse;
            }

            /// <summary>
            /// Removes <see cref="InputAction.started"/>, <see cref="InputAction.performed"/> and <see cref="InputAction.canceled"/> callbacks provided via <param cref="instance" /> on all input actions contained in this map.
            /// </summary>
            /// <remarks>
            /// Calling this method when <paramref name="instance" /> have not previously been registered has no side-effects.
            /// </remarks>
            /// <seealso cref="BaseMovesetActions" />
            private void UnregisterCallbacks(IBaseMovesetActions instance)
            {
                @Move.started -= instance.OnMove;
                @Move.performed -= instance.OnMove;
                @Move.canceled -= instance.OnMove;
                @Fire.started -= instance.OnFire;
                @Fire.performed -= instance.OnFire;
                @Fire.canceled -= instance.OnFire;
                @Aim.started -= instance.OnAim;
                @Aim.performed -= instance.OnAim;
                @Aim.canceled -= instance.OnAim;
                @Special.started -= instance.OnSpecial;
                @Special.performed -= instance.OnSpecial;
                @Special.canceled -= instance.OnSpecial;
                @AimMouse.started -= instance.OnAimMouse;
                @AimMouse.performed -= instance.OnAimMouse;
                @AimMouse.canceled -= instance.OnAimMouse;
            }

            /// <summary>
            /// Unregisters <param cref="instance" /> and unregisters all input action callbacks via <see cref="BaseMovesetActions.UnregisterCallbacks(IBaseMovesetActions)" />.
            /// </summary>
            /// <seealso cref="BaseMovesetActions.UnregisterCallbacks(IBaseMovesetActions)" />
            public void RemoveCallbacks(IBaseMovesetActions instance)
            {
                if (m_Wrapper.m_BaseMovesetActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            /// <summary>
            /// Replaces all existing callback instances and previously registered input action callbacks associated with them with callbacks provided via <param cref="instance" />.
            /// </summary>
            /// <remarks>
            /// If <paramref name="instance" /> is <c>null</c>, calling this method will only unregister all existing callbacks but not register any new callbacks.
            /// </remarks>
            /// <seealso cref="BaseMovesetActions.AddCallbacks(IBaseMovesetActions)" />
            /// <seealso cref="BaseMovesetActions.RemoveCallbacks(IBaseMovesetActions)" />
            /// <seealso cref="BaseMovesetActions.UnregisterCallbacks(IBaseMovesetActions)" />
            public void SetCallbacks(IBaseMovesetActions instance)
            {
                foreach (var item in m_Wrapper.m_BaseMovesetActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_BaseMovesetActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        /// <summary>
        /// Provides a new <see cref="BaseMovesetActions" /> instance referencing this action map.
        /// </summary>
        public BaseMovesetActions @BaseMoveset => new BaseMovesetActions(this);
        private int m_KeyboardMouseSchemeIndex = -1;
        /// <summary>
        /// Provides access to the input control scheme.
        /// </summary>
        /// <seealso cref="UnityEngine.InputSystem.InputControlScheme" />
        public InputControlScheme KeyboardMouseScheme
        {
            get
            {
                if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard&Mouse");
                return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
            }
        }
        private int m_GamepadSchemeIndex = -1;
        /// <summary>
        /// Provides access to the input control scheme.
        /// </summary>
        /// <seealso cref="UnityEngine.InputSystem.InputControlScheme" />
        public InputControlScheme GamepadScheme
        {
            get
            {
                if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
                return asset.controlSchemes[m_GamepadSchemeIndex];
            }
        }
        /// <summary>
        /// Interface to implement callback methods for all input action callbacks associated with input actions defined by "BaseMoveset" which allows adding and removing callbacks.
        /// </summary>
        /// <seealso cref="BaseMovesetActions.AddCallbacks(IBaseMovesetActions)" />
        /// <seealso cref="BaseMovesetActions.RemoveCallbacks(IBaseMovesetActions)" />
        public interface IBaseMovesetActions
        {
            /// <summary>
            /// Method invoked when associated input action "Move" is either <see cref="UnityEngine.InputSystem.InputAction.started" />, <see cref="UnityEngine.InputSystem.InputAction.performed" /> or <see cref="UnityEngine.InputSystem.InputAction.canceled" />.
            /// </summary>
            /// <seealso cref="UnityEngine.InputSystem.InputAction.started" />
            /// <seealso cref="UnityEngine.InputSystem.InputAction.performed" />
            /// <seealso cref="UnityEngine.InputSystem.InputAction.canceled" />
            void OnMove(InputAction.CallbackContext context);
            /// <summary>
            /// Method invoked when associated input action "Fire" is either <see cref="UnityEngine.InputSystem.InputAction.started" />, <see cref="UnityEngine.InputSystem.InputAction.performed" /> or <see cref="UnityEngine.InputSystem.InputAction.canceled" />.
            /// </summary>
            /// <seealso cref="UnityEngine.InputSystem.InputAction.started" />
            /// <seealso cref="UnityEngine.InputSystem.InputAction.performed" />
            /// <seealso cref="UnityEngine.InputSystem.InputAction.canceled" />
            void OnFire(InputAction.CallbackContext context);
            /// <summary>
            /// Method invoked when associated input action "Aim" is either <see cref="UnityEngine.InputSystem.InputAction.started" />, <see cref="UnityEngine.InputSystem.InputAction.performed" /> or <see cref="UnityEngine.InputSystem.InputAction.canceled" />.
            /// </summary>
            /// <seealso cref="UnityEngine.InputSystem.InputAction.started" />
            /// <seealso cref="UnityEngine.InputSystem.InputAction.performed" />
            /// <seealso cref="UnityEngine.InputSystem.InputAction.canceled" />
            void OnAim(InputAction.CallbackContext context);
            /// <summary>
            /// Method invoked when associated input action "Special" is either <see cref="UnityEngine.InputSystem.InputAction.started" />, <see cref="UnityEngine.InputSystem.InputAction.performed" /> or <see cref="UnityEngine.InputSystem.InputAction.canceled" />.
            /// </summary>
            /// <seealso cref="UnityEngine.InputSystem.InputAction.started" />
            /// <seealso cref="UnityEngine.InputSystem.InputAction.performed" />
            /// <seealso cref="UnityEngine.InputSystem.InputAction.canceled" />
            void OnSpecial(InputAction.CallbackContext context);
            /// <summary>
            /// Method invoked when associated input action "AimMouse" is either <see cref="UnityEngine.InputSystem.InputAction.started" />, <see cref="UnityEngine.InputSystem.InputAction.performed" /> or <see cref="UnityEngine.InputSystem.InputAction.canceled" />.
            /// </summary>
            /// <seealso cref="UnityEngine.InputSystem.InputAction.started" />
            /// <seealso cref="UnityEngine.InputSystem.InputAction.performed" />
            /// <seealso cref="UnityEngine.InputSystem.InputAction.canceled" />
            void OnAimMouse(InputAction.CallbackContext context);
        }
    }
}
