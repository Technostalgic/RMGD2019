using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RMGD {

	[RequireComponent(typeof(Grid))]
	public sealed class BuildGridController : MonoBehaviour {

		private Grid _grid;
		public Grid grid {
			get {
				if(_grid == null)
					_grid = GetComponent<Grid>();
				return _grid;
			}
		}

		[SerializeField]
		private Sprite _highlightGraphic = default;

		private SpriteRenderer _tileHighlight;
		public SpriteRenderer tileHighlight {
			get {
				if(_tileHighlight == null)
					constructGridHighlight();
				return _tileHighlight;
			}
		}

		[SerializeField]
		private Camera _mainCamera;
		public Camera mainCamera {
			get {
				if(_mainCamera == null)
					_mainCamera = FindObjectOfType<Camera>();
				return _mainCamera;
			}
		}

		[SerializeField]
		private BaseBuildingController _baseBuiler;
		public BaseBuildingController baseBuilder {
			get {
				if(_baseBuiler == null)
					_baseBuiler = GetComponentInChildren<BaseBuildingController>();
				return _baseBuiler;
			}
		}

		public Vector2 mousePos {
			get {
				// calculate the mouse position by applying the camera's projection mattrix to the mouse's screen position
				return mainCamera.ScreenToWorldPoint(Input.mousePosition);
			}
		}
		
		public Vector3Int mouseTile {
			get {
				return grid.WorldToCell(mousePos);
			}
		}

        public static BuildGridController instance;

		// ----------------------------------------------------------------------------------------

		private void constructGridHighlight() {
			_tileHighlight = new GameObject("TileHighlight").AddComponent<SpriteRenderer>();
			_tileHighlight.drawMode = SpriteDrawMode.Sliced;
			_tileHighlight.sprite = _highlightGraphic;
		}

		private void highlightMouseTile() {

			Vector3 tpos = grid.CellToWorld(mouseTile);
			tpos += grid.cellSize / 2;
			tpos.z = -1;

			tileHighlight.transform.position = tpos;
			tileHighlight.size = grid.cellSize;
		}


		// ----------------------------------------------------------------------------------------

		private void Update() {
			highlightMouseTile();
		}

		private void Awake() {
            instance = this;
			constructGridHighlight();
		}
	}
}