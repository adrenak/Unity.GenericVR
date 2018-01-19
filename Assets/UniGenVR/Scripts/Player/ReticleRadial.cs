using UnityEngine;
using UnityEngine.UI;
using System;

namespace UniGenVR.Utils {
    // This class is used to control a radial bar that fills
    // up as the user holds down the Fire1 button.  When it has
    // finished filling it triggers an event.  It also has a
    // coroutine which returns once the bar is filled.
    public class ReticleRadial : VRBehaviour {
        public event Action OnSelectionComplete;                                                // This event is triggered when the bar has filled.


        [SerializeField] private bool m_HideOnStart = true;                                     // Whether or not the bar should be visible at the start.
        [SerializeField] private Image m_Selection;                                             // Reference to the image who's fill amount is adjusted to display the bar.


        private Coroutine m_SelectionFillRoutine;                                               // Used to start and stop the filling coroutine based on input.
        private bool m_IsSelectionRadialActive;                                                    // Whether or not the bar is currently useable.
        private bool m_RadialFilled;                                                               // Used to allow the coroutine to wait for the bar to fill.


        private void OnEnable() {
            VRInput.OnHold += HandleHold;
            VRInput.OnUp += HandleUp;
            VRInput.OnMaxHold += HandleMaxHold;
        }


        private void OnDisable() {
            VRInput.OnHold -= HandleHold;
            VRInput.OnUp -= HandleUp;
            VRInput.OnMaxHold -= HandleMaxHold;
        }


        private void Start() {
            // Setup the radial to have no fill at the start and hide if necessary.
            m_Selection.fillAmount = 0f;

            if (m_HideOnStart)
                Hide();
        }


        public void Show() {
            m_Selection.gameObject.SetActive(true);
            m_IsSelectionRadialActive = true;
        }


        public void Hide() {
            m_Selection.gameObject.SetActive(false);
            m_IsSelectionRadialActive = false;

            // This effectively resets the radial for when it's shown again.
            m_Selection.fillAmount = 0f;
        }

        private void HandleMaxHold() {
            m_Selection.fillAmount = 1;
        }

        private void HandleHold(float obj) {
            m_Selection.fillAmount = 1;
        }

        private void HandleUp() {
            m_Selection.fillAmount = 0f;
        }
    }
}