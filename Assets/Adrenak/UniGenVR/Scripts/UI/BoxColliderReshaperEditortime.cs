﻿using UnityEngine;

namespace Adrenak.UniGenVR {
    [ExecuteInEditMode]
    public class BoxColliderReshaperEditortime : MonoBehaviour {
        BoxCollider m_BoxCollider;
        RectTransform m_RectTransform;

        private void Start() {
            m_RectTransform = GetComponent<RectTransform>();
            m_BoxCollider = GetComponent<BoxCollider>();
        }

        void Update () {
            m_BoxCollider.size = new Vector3(
                m_RectTransform.sizeDelta.x,
                m_RectTransform.sizeDelta.y,
                .01F
            );
        }
    }
}
