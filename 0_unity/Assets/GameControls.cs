// GENERATED AUTOMATICALLY FROM 'Assets/GameControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Generated
{
    public class @GameControls : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @GameControls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameControls"",
    ""maps"": [
        {
            ""name"": ""Pawn"",
            ""id"": ""25d0724d-ef42-4acc-ba5a-13f125dd6400"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""8c339a85-1b41-4ca6-a8ce-118830940aa0"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""3ee85897-81e9-493e-9588-d74904a7d078"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""a35eed52-62e5-461b-bf11-f9c5e432e528"",
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
                    ""id"": ""02f4a58c-6e87-4495-a58f-838d8a65c92a"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard+Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""6743e3f4-9cd6-40ef-92ed-93cfdb4baee9"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard+Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""38893c4c-2ebb-4a16-b5b2-dea2f6542b0d"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard+Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""00fd4c00-afe0-4680-96ec-7f2ddd193f99"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard+Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""5b25758c-5047-4093-a4d7-621879474708"",
                    ""path"": ""<DualShockGamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PS4"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9a2efd7c-0bbd-4a40-94b6-09b561eced7d"",
                    ""path"": ""<DualShockGamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PS4"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""53f6f1ad-6c68-4d20-a068-afc80a7a64aa"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard+Mouse"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Camera"",
            ""id"": ""c0795d01-dc3d-4e83-87f3-f782e9b587b6"",
            ""actions"": [
                {
                    ""name"": ""SetMovementCameraMode"",
                    ""type"": ""Button"",
                    ""id"": ""35cd4e3d-36a3-436d-b0a2-3a0f7bba0423"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SetScenicCameraMode"",
                    ""type"": ""Button"",
                    ""id"": ""eeb2e503-d3cb-4d1d-9db1-8f67a921c3a0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Zoom"",
                    ""type"": ""Value"",
                    ""id"": ""7227e23f-f125-4a6a-a4c0-155889ef21e5"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Spin"",
                    ""type"": ""Value"",
                    ""id"": ""a5444b79-4c2a-4f72-90b9-cb9846a3a700"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""93f0e612-7f57-4255-99d4-628fb6fa8890"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard+Mouse"",
                    ""action"": ""Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""L1+Right Stick Y"",
                    ""id"": ""413bdfba-3a88-4a3d-a977-63adc94f7641"",
                    ""path"": ""AxisWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Zoom"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""b1f51577-61b6-4548-b5d6-25cc4ed9e2a4"",
                    ""path"": ""<DualShockGamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PS4"",
                    ""action"": ""Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""axis"",
                    ""id"": ""568b1ef5-380c-4956-bc45-9ce5950fee3f"",
                    ""path"": ""<DualShockGamepad>/rightStick/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PS4"",
                    ""action"": ""Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""de5537f6-ba1e-4714-b2e3-22acadb9e0b5"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard+Mouse"",
                    ""action"": ""Spin"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""089d7423-e9fd-436d-ae71-b89ac81d3d99"",
                    ""path"": ""<DualShockGamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PS4"",
                    ""action"": ""Spin"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""424fa419-aea4-4f7c-bf02-ff4e3fc29a4f"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard+Mouse"",
                    ""action"": ""SetMovementCameraMode"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""22fd6ea4-5c17-42d8-9b6f-74fec0f2d342"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SetMovementCameraMode"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""f07ec6ab-4e38-4c26-8da6-0cdf221a6876"",
                    ""path"": ""<DualShockGamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": ""PS4"",
                    ""action"": ""SetMovementCameraMode"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""d2b73765-53a0-4f06-a166-17de78edda26"",
                    ""path"": ""<DualShockGamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone,Invert"",
                    ""groups"": ""PS4"",
                    ""action"": ""SetMovementCameraMode"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""1a15e4a0-6d1d-4dcf-9765-623727cc2099"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard+Mouse"",
                    ""action"": ""SetScenicCameraMode"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Targeting"",
            ""id"": ""7d88328a-0676-4278-9368-22948ac8a15e"",
            ""actions"": [
                {
                    ""name"": ""TargetRay"",
                    ""type"": ""Value"",
                    ""id"": ""b009ea97-ce89-413d-b694-5fe728b6124f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Change"",
                    ""type"": ""Button"",
                    ""id"": ""1a48b4e8-0671-4a3a-97fa-b008e28f585c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Target Cycle"",
                    ""type"": ""Value"",
                    ""id"": ""c9c8272c-5a95-4a80-9627-08ec2c4fe703"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""aa0b5ba0-668e-4b8d-9680-29e6d5a6e971"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard+Mouse"",
                    ""action"": ""TargetRay"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""acab0f2a-1da0-4a8c-a900-25d1fe0b8148"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard+Mouse"",
                    ""action"": ""Change"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d3690259-31f7-4503-8ef7-b4a13e094e8d"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Target Cycle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Shift+Tab [Keyboard]"",
                    ""id"": ""4df41b1a-9164-4b5f-a02f-9df7faee04f2"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": ""Invert"",
                    ""groups"": """",
                    ""action"": ""Target Cycle"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""80473a33-1447-4e54-a1bd-b2aa5818d8ec"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Target Cycle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""16bda612-441b-4eda-82d5-f6605f59695b"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Target Cycle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""D-Pad"",
                    ""id"": ""844f5c06-9577-4cd9-9abb-65bd26465aa4"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Target Cycle"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""30af5ae2-d6b1-4fc9-8695-9dd100c9e49b"",
                    ""path"": ""<DualShockGamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Target Cycle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""42e01e06-646f-4c94-bf05-ff13274684fc"",
                    ""path"": ""<DualShockGamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Target Cycle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard+Mouse"",
            ""bindingGroup"": ""Keyboard+Mouse"",
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
            ""name"": ""PS4"",
            ""bindingGroup"": ""PS4"",
            ""devices"": [
                {
                    ""devicePath"": ""<DualShockGamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
            // Pawn
            m_Pawn = asset.FindActionMap("Pawn", throwIfNotFound: true);
            m_Pawn_Move = m_Pawn.FindAction("Move", throwIfNotFound: true);
            m_Pawn_Jump = m_Pawn.FindAction("Jump", throwIfNotFound: true);
            // Camera
            m_Camera = asset.FindActionMap("Camera", throwIfNotFound: true);
            m_Camera_SetMovementCameraMode = m_Camera.FindAction("SetMovementCameraMode", throwIfNotFound: true);
            m_Camera_SetScenicCameraMode = m_Camera.FindAction("SetScenicCameraMode", throwIfNotFound: true);
            m_Camera_Zoom = m_Camera.FindAction("Zoom", throwIfNotFound: true);
            m_Camera_Spin = m_Camera.FindAction("Spin", throwIfNotFound: true);
            // Targeting
            m_Targeting = asset.FindActionMap("Targeting", throwIfNotFound: true);
            m_Targeting_TargetRay = m_Targeting.FindAction("TargetRay", throwIfNotFound: true);
            m_Targeting_Change = m_Targeting.FindAction("Change", throwIfNotFound: true);
            m_Targeting_TargetCycle = m_Targeting.FindAction("Target Cycle", throwIfNotFound: true);
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

        // Pawn
        private readonly InputActionMap m_Pawn;
        private IPawnActions m_PawnActionsCallbackInterface;
        private readonly InputAction m_Pawn_Move;
        private readonly InputAction m_Pawn_Jump;
        public struct PawnActions
        {
            private @GameControls m_Wrapper;
            public PawnActions(@GameControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Move => m_Wrapper.m_Pawn_Move;
            public InputAction @Jump => m_Wrapper.m_Pawn_Jump;
            public InputActionMap Get() { return m_Wrapper.m_Pawn; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PawnActions set) { return set.Get(); }
            public void SetCallbacks(IPawnActions instance)
            {
                if (m_Wrapper.m_PawnActionsCallbackInterface != null)
                {
                    @Move.started -= m_Wrapper.m_PawnActionsCallbackInterface.OnMove;
                    @Move.performed -= m_Wrapper.m_PawnActionsCallbackInterface.OnMove;
                    @Move.canceled -= m_Wrapper.m_PawnActionsCallbackInterface.OnMove;
                    @Jump.started -= m_Wrapper.m_PawnActionsCallbackInterface.OnJump;
                    @Jump.performed -= m_Wrapper.m_PawnActionsCallbackInterface.OnJump;
                    @Jump.canceled -= m_Wrapper.m_PawnActionsCallbackInterface.OnJump;
                }
                m_Wrapper.m_PawnActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Move.started += instance.OnMove;
                    @Move.performed += instance.OnMove;
                    @Move.canceled += instance.OnMove;
                    @Jump.started += instance.OnJump;
                    @Jump.performed += instance.OnJump;
                    @Jump.canceled += instance.OnJump;
                }
            }
        }
        public PawnActions @Pawn => new PawnActions(this);

        // Camera
        private readonly InputActionMap m_Camera;
        private ICameraActions m_CameraActionsCallbackInterface;
        private readonly InputAction m_Camera_SetMovementCameraMode;
        private readonly InputAction m_Camera_SetScenicCameraMode;
        private readonly InputAction m_Camera_Zoom;
        private readonly InputAction m_Camera_Spin;
        public struct CameraActions
        {
            private @GameControls m_Wrapper;
            public CameraActions(@GameControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @SetMovementCameraMode => m_Wrapper.m_Camera_SetMovementCameraMode;
            public InputAction @SetScenicCameraMode => m_Wrapper.m_Camera_SetScenicCameraMode;
            public InputAction @Zoom => m_Wrapper.m_Camera_Zoom;
            public InputAction @Spin => m_Wrapper.m_Camera_Spin;
            public InputActionMap Get() { return m_Wrapper.m_Camera; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(CameraActions set) { return set.Get(); }
            public void SetCallbacks(ICameraActions instance)
            {
                if (m_Wrapper.m_CameraActionsCallbackInterface != null)
                {
                    @SetMovementCameraMode.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnSetMovementCameraMode;
                    @SetMovementCameraMode.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnSetMovementCameraMode;
                    @SetMovementCameraMode.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnSetMovementCameraMode;
                    @SetScenicCameraMode.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnSetScenicCameraMode;
                    @SetScenicCameraMode.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnSetScenicCameraMode;
                    @SetScenicCameraMode.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnSetScenicCameraMode;
                    @Zoom.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnZoom;
                    @Zoom.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnZoom;
                    @Zoom.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnZoom;
                    @Spin.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnSpin;
                    @Spin.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnSpin;
                    @Spin.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnSpin;
                }
                m_Wrapper.m_CameraActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @SetMovementCameraMode.started += instance.OnSetMovementCameraMode;
                    @SetMovementCameraMode.performed += instance.OnSetMovementCameraMode;
                    @SetMovementCameraMode.canceled += instance.OnSetMovementCameraMode;
                    @SetScenicCameraMode.started += instance.OnSetScenicCameraMode;
                    @SetScenicCameraMode.performed += instance.OnSetScenicCameraMode;
                    @SetScenicCameraMode.canceled += instance.OnSetScenicCameraMode;
                    @Zoom.started += instance.OnZoom;
                    @Zoom.performed += instance.OnZoom;
                    @Zoom.canceled += instance.OnZoom;
                    @Spin.started += instance.OnSpin;
                    @Spin.performed += instance.OnSpin;
                    @Spin.canceled += instance.OnSpin;
                }
            }
        }
        public CameraActions @Camera => new CameraActions(this);

        // Targeting
        private readonly InputActionMap m_Targeting;
        private ITargetingActions m_TargetingActionsCallbackInterface;
        private readonly InputAction m_Targeting_TargetRay;
        private readonly InputAction m_Targeting_Change;
        private readonly InputAction m_Targeting_TargetCycle;
        public struct TargetingActions
        {
            private @GameControls m_Wrapper;
            public TargetingActions(@GameControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @TargetRay => m_Wrapper.m_Targeting_TargetRay;
            public InputAction @Change => m_Wrapper.m_Targeting_Change;
            public InputAction @TargetCycle => m_Wrapper.m_Targeting_TargetCycle;
            public InputActionMap Get() { return m_Wrapper.m_Targeting; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(TargetingActions set) { return set.Get(); }
            public void SetCallbacks(ITargetingActions instance)
            {
                if (m_Wrapper.m_TargetingActionsCallbackInterface != null)
                {
                    @TargetRay.started -= m_Wrapper.m_TargetingActionsCallbackInterface.OnTargetRay;
                    @TargetRay.performed -= m_Wrapper.m_TargetingActionsCallbackInterface.OnTargetRay;
                    @TargetRay.canceled -= m_Wrapper.m_TargetingActionsCallbackInterface.OnTargetRay;
                    @Change.started -= m_Wrapper.m_TargetingActionsCallbackInterface.OnChange;
                    @Change.performed -= m_Wrapper.m_TargetingActionsCallbackInterface.OnChange;
                    @Change.canceled -= m_Wrapper.m_TargetingActionsCallbackInterface.OnChange;
                    @TargetCycle.started -= m_Wrapper.m_TargetingActionsCallbackInterface.OnTargetCycle;
                    @TargetCycle.performed -= m_Wrapper.m_TargetingActionsCallbackInterface.OnTargetCycle;
                    @TargetCycle.canceled -= m_Wrapper.m_TargetingActionsCallbackInterface.OnTargetCycle;
                }
                m_Wrapper.m_TargetingActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @TargetRay.started += instance.OnTargetRay;
                    @TargetRay.performed += instance.OnTargetRay;
                    @TargetRay.canceled += instance.OnTargetRay;
                    @Change.started += instance.OnChange;
                    @Change.performed += instance.OnChange;
                    @Change.canceled += instance.OnChange;
                    @TargetCycle.started += instance.OnTargetCycle;
                    @TargetCycle.performed += instance.OnTargetCycle;
                    @TargetCycle.canceled += instance.OnTargetCycle;
                }
            }
        }
        public TargetingActions @Targeting => new TargetingActions(this);
        private int m_KeyboardMouseSchemeIndex = -1;
        public InputControlScheme KeyboardMouseScheme
        {
            get
            {
                if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard+Mouse");
                return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
            }
        }
        private int m_PS4SchemeIndex = -1;
        public InputControlScheme PS4Scheme
        {
            get
            {
                if (m_PS4SchemeIndex == -1) m_PS4SchemeIndex = asset.FindControlSchemeIndex("PS4");
                return asset.controlSchemes[m_PS4SchemeIndex];
            }
        }
        public interface IPawnActions
        {
            void OnMove(InputAction.CallbackContext context);
            void OnJump(InputAction.CallbackContext context);
        }
        public interface ICameraActions
        {
            void OnSetMovementCameraMode(InputAction.CallbackContext context);
            void OnSetScenicCameraMode(InputAction.CallbackContext context);
            void OnZoom(InputAction.CallbackContext context);
            void OnSpin(InputAction.CallbackContext context);
        }
        public interface ITargetingActions
        {
            void OnTargetRay(InputAction.CallbackContext context);
            void OnChange(InputAction.CallbackContext context);
            void OnTargetCycle(InputAction.CallbackContext context);
        }
    }
}
