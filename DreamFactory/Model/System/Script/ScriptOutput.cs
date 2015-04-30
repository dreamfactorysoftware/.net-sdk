// ReSharper disable InconsistentNaming
namespace DreamFactory.Model.System.Script
{
    /// <summary>
    /// ScriptOutput.
    /// </summary>
    public class ScriptOutput
    {
        /// <summary>
        /// The output of the script, if any.
        /// </summary>
        public string script_output { get; set; }

        /// <summary>
        /// The value of the last variable created within the script.
        /// </summary>
        public string script_last_variable { get; set; }
    }
}
