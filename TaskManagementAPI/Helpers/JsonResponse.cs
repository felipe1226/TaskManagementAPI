using TaskManagementAPI.DTO;

namespace TaskManagementAPI.Helpers
{
    public class JsonResponse
    {
        private static JsonResponse instance;
        private static readonly object lockObject = new object();

        private JsonResponse(){}

        public static JsonResponse Instance
        {
            get
            {
                // Verificar si ya existe una instancia, y si no, crear una.
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new JsonResponse();
                        }
                    }
                }
                return instance;
            }
        }

        public JsonResponseDTO CreateSuccessResponse(object data, string message = null)
        {
            return new JsonResponseDTO
            {
                Success = true,
                Error = (string)null,
                Message = message ?? "Se realizó la petición correctamente",
                Data = data
            };
        }

        public JsonResponseDTO CreateErrorResponse(string errorMessage)
        {
            return new JsonResponseDTO
            {
                Success = false,
                Error = errorMessage,
                Message = "Se produjo un error en la petición"
            };
        }
    }
}
