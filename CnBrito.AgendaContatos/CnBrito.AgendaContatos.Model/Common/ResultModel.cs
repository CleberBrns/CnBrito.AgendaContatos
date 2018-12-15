namespace CnBrito.AgendaContatos.Model.Common
{
    public class ResultModel<T>
        where T : new()
    {
        public string Message { get; set; }
        public bool Status { get; set; } = true;
        public T Value { get; set; }
    }
}
