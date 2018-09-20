using BeatThat.Properties;
using UnityEngine;

namespace BeatThat
{
	public class RendererAlpha : HasFloat
	{
		public string m_colorProperty = "_Color";
		public Renderer m_renderer;

		public override float value
		{
			get {
				return this.material.GetColor(m_colorProperty).a;
			}
			set {
				var m = this.material;
				var c = m.GetColor(m_colorProperty);
				c.a = value;
				m.color = c;
			}
		}

		public override bool sendsValueObjChanged { get { return false; } }

		private Material material { get { return m_material?? (m_material = this._renderer.material); } }
		private Material m_material;

		private Renderer _renderer { get { return m_renderer?? (m_renderer = GetComponent<Renderer>()); } }

		#if UNITY_EDITOR
		void Reset()
		{
			m_renderer = GetComponent<Renderer>();
		}
		#endif
	}
}
