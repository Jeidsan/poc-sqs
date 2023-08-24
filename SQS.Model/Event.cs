namespace SQS.Model
{
    public enum Event
    {
        /// <summary>
        /// Quando o consentimento é criado
        /// </summary>
        CREATED = 0,

        /// <summary>
        /// Quando um consentimento é autorizado (AWAITING_AUTHORISATION -> AUTHORISED)
        /// </summary>
        AUTHORISATION_COMPLETED = 1,

        /// <summary>
        /// Quando o consentimento é consumido (AUTHORISED -> CONSUMED)
        /// </summary>
        AUTHORISATION_CONSUMED = 2,

        /// <summary>
        /// Quando o consentimento é rejeitado, seja pelo cooperado ou por expiração do prazo (AWAITING_AUTHORISATION -> REJECTED)
        /// </summary>
        AUTHORISATION_FAILED = 3,

        /// <summary>
        /// Quando vence o tempo para consumo do consentimento (AUTHORISED -> REJECTED)
        /// </summary>
        AUTHORISED_TIMEOUT_EXPIRED = 4,
    }
}