using Practic.Domain.Enum;

namespace Practic.Domain.Responce
{
    public class BaseResponce<T> : IBaseResponce<T>
    {
        public string Description { get; set; }

        public StatusCode StatusCode { get; set; }

        public T Data { get; set; }
    }

    public interface IBaseResponce<T>
    {
        T Data { get; set; }
    }
}
