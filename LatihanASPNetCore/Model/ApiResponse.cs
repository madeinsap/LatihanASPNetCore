namespace LatihanASPNetCore.Model
{
    public class ApiResponse<T>
    {
        public string? Message { get; set; }

        public int? StatusCode { get; set; }

        public T? Data { get; set; }
    }
}
