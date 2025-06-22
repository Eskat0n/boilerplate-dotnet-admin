namespace Boilerplate.Web.DTOs
{
    public class PositionForm<T>
    {
        public T Id { get; set; } = default!;
        public int OrderIndex { get; set; }
    }
}