using BeatThat.Properties;
using UnityEngine;
using UnityEngine.Serialization;

namespace BeatThat
{
    public class RendererMaterial : HasMaterial, IDrive<Renderer>
	{
        public enum MaterialOptions 
        {
            USE_INSTANCE = 0,
            USE_SHARED = 1
        }

		[FormerlySerializedAs("m_renderer")]public Renderer m_driven;
        public MaterialOptions m_materialOptions;

		public override Material value
		{
			get {
                if(!Application.isPlaying) {
                    return this.renderer.sharedMaterial;
                }
                switch(m_materialOptions) {
                    case MaterialOptions.USE_SHARED:
                        return this.renderer.sharedMaterial;
                    case MaterialOptions.USE_INSTANCE:
                        return this.renderer.material;
                    default:
                        return this.renderer.sharedMaterial;
                }
			}
			set {
                if (!Application.isPlaying)
                {
                    this.renderer.sharedMaterial = value;
                }
                else {
                    switch (m_materialOptions)
                    {
                        case MaterialOptions.USE_SHARED:
                            this.renderer.sharedMaterial = value;
                            break;
                        case MaterialOptions.USE_INSTANCE:
                            this.renderer.material = value;
                            break;
                    }
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
