#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

namespace Groups.Group_S.Driving
{
    [CustomEditor(typeof(Drivable))]
    public class DrivableEditor : Editor
    {
        private Drivable TargetObject => (Drivable) serializedObject.targetObject;
        
        public override void OnInspectorGUI()
        {
            EditorGUILayout.LabelField("Collected Stat Components", TargetObject.CollectStats().Length.ToString());

            if (!Application.isPlaying)
            {
                EditorGUILayout.HelpBox("More information is available during play", MessageType.Info);
            }
            else
            {
                EditorGUILayout.LabelField("Current input", TargetObject.Input.ToString());
                EditorGUILayout.LabelField("Current Speed", TargetObject.LastSpeed.ToString());
            }
        }
    }
}

#endif