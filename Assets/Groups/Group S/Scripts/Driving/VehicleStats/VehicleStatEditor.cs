#if UNITY_EDITOR

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace Groups.Group_S.Driving.VehicleStats
{
    [CustomEditor(typeof(VehicleStatProvider))]
    public class VehicleStatEditor : Editor
    {
        private IEnumerable<Type> VehicleStatTypes => Assembly
            .GetAssembly(typeof(VehicleStat))
            .GetTypes()
            .Where(iType => iType.IsClass && !iType.IsAbstract && iType.IsSubclassOf(typeof(VehicleStat)));

        private VehicleStatProvider TargetObject => (VehicleStatProvider) serializedObject.targetObject;

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            // iterate over all possible vehicle stats and draw GUI for each one of them so that the user can decide
            // whether they want the TargetObject to provide this stat
            foreach (var iStatType in VehicleStatTypes)
            {
                var iStat = TargetObject.vehicleStats.FirstOrDefault(i => i.GetType() == iStatType);
                var index = TargetObject.vehicleStats.IndexOf(iStat);

                // a stat of that type is not yet activated
                if (iStat == null)
                {
                    // offer a toggle button to activate it
                    if (EditorGUILayout.ToggleLeft($"Provide {iStatType.Name}", false))
                    {
                        TargetObject.vehicleStats.Add((VehicleStat) Activator.CreateInstance(iStatType));
                    }
                }

                // a stat of that type is activated
                else
                {
                    // offer a toggle button to deactivate it
                    if (!EditorGUILayout.BeginToggleGroup($"Provide {iStatType.Name}", true))
                    {
                        TargetObject.vehicleStats.Remove(iStat);
                    }

                    // draw all properties of that stat neatly
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.Space(16f, false);
                    EditorGUILayout.BeginVertical();
                    var serializedStat = serializedObject.FindProperty("vehicleStats").GetArrayElementAtIndex(index);
                    foreach (SerializedProperty statProp in serializedStat)
                    {
                        EditorGUILayout.PropertyField(statProp);
                    }
                    EditorGUILayout.EndVertical();
                    EditorGUILayout.EndHorizontal();

                    EditorGUILayout.EndToggleGroup();
                }

                // draw separator except for last item
                if (index < TargetObject.vehicleStats.Count)
                {
                    EditorGUILayout.Space();
                }
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}

#endif