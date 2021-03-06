using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace GigaceeTools
{
    [RequireComponent(typeof(RectTransform))]
    public class DebugLabelManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _labelPrefab;
        [SerializeField] private AutoLayoutSupporter _autoLayoutSupporter;

        private readonly Dictionary<int, TextMeshProUGUI> _children = new Dictionary<int, TextMeshProUGUI>();

        private void Reset()
        {
            _autoLayoutSupporter = GetComponent<AutoLayoutSupporter>();
        }

        public TextMeshProUGUI Add(string typeName, int priority)
        {
            if (_children.ContainsKey(priority))
            {
                Debug.LogError($"すでに同じ優先度のデバッグラベルが登録されています: {typeName}");
                return null;
            }

            TextMeshProUGUI newLabel;

            if (_labelPrefab == null)
            {
                var obj = new GameObject(typeName)
                {
                    transform =
                    {
                        parent = transform,
                        localScale = Vector3.one
                    }
                };

                newLabel = obj.AddComponent<TextMeshProUGUI>();
                newLabel.verticalAlignment = VerticalAlignmentOptions.Middle;
            }
            else
            {
                newLabel = Instantiate(_labelPrefab, transform);
                newLabel.name = typeName;
            }

            _children.Add(priority, newLabel);

            TextMeshProUGUI[] sortedLabels = _children
                .OrderBy(pair => pair.Key)
                .Select(pair => pair.Value)
                .ToArray();

            for (var i = 0; i < _children.Count; i++)
            {
                sortedLabels[i].transform.SetSiblingIndex(i);
            }

            _autoLayoutSupporter.ExecuteRebuilding();

            return newLabel;
        }

        public void Remove(string className)
        {
            KeyValuePair<int, TextMeshProUGUI> childPair
                = _children.SingleOrDefault(pair => (pair.Value != null) && (pair.Value.name == className));

            if (!childPair.Value)
            {
                Debug.LogWarning($"要求されたラベルが存在しません: {className}");
                return;
            }

            _children.Remove(childPair.Key);
            Destroy(childPair.Value.gameObject);

            _autoLayoutSupporter.ExecuteRebuilding();
        }
    }
}
