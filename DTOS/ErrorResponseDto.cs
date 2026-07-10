namespace ELearning.Api.DTOs;

public class ErrorResponseDto
{
    public bool Success { get; set; } = false;
    public int StatusCode { get; set; }
    public string Message { get; set; } = string.Empty;
    public List<String> Error { get; set; } = [];
}