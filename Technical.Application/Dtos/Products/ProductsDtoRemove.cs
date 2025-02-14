

using Technical.Application.Dtos.Base;

namespace Technical.Application.Dtos.Products
{
    public class ProductsDtoRemove : DtoBase
    {
        public int ProductID { get; set; }
        public bool Eliminado { get; set; }

    }
}
