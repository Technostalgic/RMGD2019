using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace RMGD {

	[CustomEditor(typeof(TerrainController))]
	public class TerrainControllerInspector : Editor {

		public TerrainController terrainController => target as TerrainController;

		public override void OnInspectorGUI() {
			base.OnInspectorGUI();

			GUIContent buttonContent = new GUIContent("Rebuild Mesh", "Rebuilds the mesh to match the attached 2d polygon collider");
			if(GUILayout.Button(buttonContent)) {
				terrainController.BuildMesh();
			}
		}

	}
}