namespace ECourse.Shared.Dtos
{
    public class ResponseDto<T>
    {
        public T Data { get; private set; }

        [JsonIgnore]
        public int StatusCode { get; private set; }

        public List<string> Errors { get; private set; }

        public static ResponseDto<T> Success(T data, int statusCode = 200)
        {
            return new ResponseDto<T> { Data = data, StatusCode = statusCode };
        }

        public static ResponseDto<T> Success(int statusCode = 200)
        {
            return new ResponseDto<T> { Data = default(T), StatusCode = statusCode };
        }

        public static ResponseDto<T> Fail(List<string> errors, int statusCode = 400)
        {
            return new ResponseDto<T>
            {
                Errors = errors,
                StatusCode = statusCode
            };
        }

        public static ResponseDto<T> Fail(string error, int statusCode = 400)
        {
            return new ResponseDto<T>
            {
                Errors = new List<string> { error },
                StatusCode = statusCode
            };
        }
    }
}