namespace DreamFactory.Api
{
    using DreamFactory.Model.Database;
    using DreamFactory.Model.System.Email;
    using global::System.Collections.Generic;
    using global::System.Threading.Tasks;

    /// <summary>
    /// Represents /system/emailtemplate API.
    /// </summary>
    public interface ISystemEmailTemplateApi
    {
        /// <summary>
        /// Retrieve one or more email templates.
        /// </summary>
        /// <param name="query">Query parameters.</param>
        /// <returns>List of email templates.</returns>
        Task<IEnumerable<EmailTemplateResponse>> GetEmailTemplatesAsync(SqlQuery query);

        /// <summary>
        /// Create one or more email templates.
        /// </summary>
        /// <param name="query">Query parameters.</param>
        /// <param name="templates">Email templates to create.</param>
        /// <returns>List of created email templates.</returns>
        Task<IEnumerable<EmailTemplateResponse>> CreateEmailTemplatesAsync(SqlQuery query, params EmailTemplateRequest[] templates);

        /// <summary>
        /// Update one or more email templates.
        /// </summary>
        /// <param name="query">Query parameters.</param>
        /// <param name="templates">Email templates to update.</param>
        /// <returns>List of updated email templates.</returns>
        Task<IEnumerable<EmailTemplateResponse>> UpdateEmailTemplatesAsync(SqlQuery query, params EmailTemplateRequest[] templates);

        /// <summary>
        /// Delete one or more email templates.
        /// </summary>
        /// <param name="query">Query parameters.</param>
        /// <param name="ids">Email template IDs to delete.</param>
        /// <returns>By default, only the id property of the record deleted is returned on success. Use 'fields' and 'related' to return more properties of the deleted records.</returns>
        Task<IEnumerable<EmailTemplateResponse>> DeleteEmailTemplatesAsync(SqlQuery query, params int[] ids);
    }
}
