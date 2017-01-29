using System;
using System.Xml;

namespace QuickGraph.Serialization.Mawingu
{
    public abstract class SerializerBase<TVertex,TEdge>
        where TEdge :IEdge<TVertex>
    {
        public bool EmitDocumentDeclaration {get;set;}
    }
}
