using BeatThat.Properties;
using UnityEngine;
using UnityEngine.Serialization;

namespace BeatThat
{
    public class RendererMaterial : HasMaterial, IDrive<Renderer>
	{
		[FormerlySerializedAs("m_renderer")]public Renderer m_driven;

		public override Material value
		{
			get {
                if(Application.isPlaying) {
                    return this.renderer.sharedMaterial;
                }
                return this.renderer.material;
			}
			set {
                if (Application.isPlaying)
                {
                    this.renderer.sharedMaterial = value;
                }
                else {
                    this.renderer.material = value;
                }
			}
		}

        new public Renderer renderer { get { return this.driven; } }

        public Renderer driven
        {
            get
            {
                return m_driven ?? (m_driven = GetComponent<Renderer>());
            }
        }

        public bool ClearDriven()
        {
            m_driven = null;
            return true;
        }

        public object GetDrivenObject()
        {
            return this.driven;
        }
    }
}
