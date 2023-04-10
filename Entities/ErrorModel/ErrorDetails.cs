using System.Text.Json;

namespace Entities.ErrorModel
{
    public class ErrorDetails
    {
        #region Properties

        public int StatusCode { get; set; }
        public string? Message { get; set; }

        #endregion Properties

        #region Methods

        public override string ToString() => JsonSerializer.Serialize(this);

        #endregion Methods
    }
}