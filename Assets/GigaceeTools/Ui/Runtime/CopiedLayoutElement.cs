﻿// Original code from https://github.com/StompyRobot/SRF/blob/master/Scripts/UI/CopyLayoutElement.cs
// Licensed under https://github.com/StompyRobot/SRF/blob/master/LICENSE

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GigaceeTools
{
    [ExecuteAlways]
    [RequireComponent(typeof(RectTransform))]
    public class CopiedLayoutElement : UIBehaviour, ILayoutElement
    {
        [SerializeField] private bool _shouldCopyMinWidth;
        [SerializeField] private RectTransform _copySourceOfMinWidth;
        [SerializeField] private bool _shouldCopyMinHeight;
        [SerializeField] private RectTransform _copySourceOfMinHeight;
        [SerializeField] private bool _shouldCopyPreferredWidth;
        [SerializeField] private RectTransform _copySourceOfPreferredWidth;
        [SerializeField] private bool _shouldCopyPreferredHeight;
        [SerializeField] private RectTransform _copySourceOfPreferredHeight;

        public float minWidth
        {
            get
            {
                if (!_shouldCopyMinWidth || (_copySourceOfMinWidth == null) || !IsActive())
                {
                    return -1f;
                }

                // ReSharper disable once InvertIf
                if (_copySourceOfMinWidth == transform as RectTransform)
                {
                    Debug.LogWarning("コピー元に自身が設定されています。", gameObject);
                    return -1f;
                }

                return LayoutUtility.GetMinWidth(_copySourceOfMinWidth);
            }
        }

        public float minHeight
        {
            get
            {
                if (!_shouldCopyMinHeight || (_copySourceOfMinHeight == null) || !IsActive())
                {
                    return -1f;
                }

                // ReSharper disable once InvertIf
                if (_copySourceOfMinHeight == transform as RectTransform)
                {
                    Debug.LogWarning("コピー元に自身が設定されています。", gameObject);
                    return -1f;
                }

                return LayoutUtility.GetMinHeight(_copySourceOfMinHeight);
            }
        }

        public float preferredWidth
        {
            get
            {
                if (!_shouldCopyPreferredWidth || (_copySourceOfPreferredWidth == null) || !IsActive())
                {
                    return -1f;
                }

                // ReSharper disable once InvertIf
                if (_copySourceOfPreferredWidth == transform as RectTransform)
                {
                    Debug.LogWarning("コピー元に自身が設定されています。", gameObject);
                    return -1f;
                }

                return LayoutUtility.GetPreferredWidth(_copySourceOfPreferredWidth);
            }
        }

        public float preferredHeight
        {
            get
            {
                if (!_shouldCopyPreferredHeight || (_copySourceOfPreferredHeight == null) || !IsActive())
                {
                    return -1f;
                }

                // ReSharper disable once InvertIf
                if (_copySourceOfPreferredHeight == transform as RectTransform)
                {
                    Debug.LogWarning("コピー元に自身が設定されています。", gameObject);
                    return -1f;
                }

                return LayoutUtility.GetPreferredHeight(_copySourceOfPreferredHeight);
            }
        }

        public int layoutPriority => 2;
        public float flexibleHeight => -1f;
        public float flexibleWidth => -1f;

        public void CalculateLayoutInputHorizontal()
        {
        }

        public void CalculateLayoutInputVertical()
        {
        }
    }
}