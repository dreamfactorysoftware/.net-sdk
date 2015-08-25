namespace DreamFactory.Model.System.Config
{
    using global::System;

    /// <summary>
    /// StateInfo.
    /// </summary>
    public class StateInfo
    {
        /// <summary>
        /// The current enterprise/hosted platform state. Valid states are:
        /// -1	Unpublished, non-hosted, private or unknown
        /// 0	Ready but not activated
        /// 1	Ready and activated
        /// 2	Locked by provisioning manager
        /// 3	Maintenance Mode
        /// 4	Banned and not available
        /// </summary>
        public int? operation_state { get; set; }

        /// <summary>
        /// The current state of platform provisioning. Valid states are:
        /// 0	Request queued
        /// 1	Provisioning in progress
        /// 2	Provisioning complete
        /// 3	Deprovisioning in progress
        /// 4	Deprovisioning complete
        /// 10	Error queuing request
        /// 12	Provisioning Error
        /// 14	Deprovisioning Error
        /// </summary>
        public int? provision_state { get; set; }

        /// <summary>
        /// The current ready state of the DSP. Valid states are:
        /// 0	Platform Administrator Missing
        /// 1	Default Platform Data Missing
        /// 2	Install/Migrate Platform Database Schema
        /// 3	Platform Ready
        /// 4	Default Platform Schema Missing
        /// 5	Platform Upgrade Required
        /// 6	Welcome Page Required
        /// 7	Platform Database Ready
        /// </summary>
        public int? ready_state { get; set; }

        /// <summary>
        /// Get operation_state description.
        /// </summary>
        /// <param name="operation_state">operation_state value.</param>
        /// <returns>State description.</returns>
        public static string GetOperationStateDescription(int operation_state)
        {
            switch (operation_state)
            {
                case -1:
                    return "Unpublished, non-hosted, private or unknown";

                case 0:
                    return "Ready but not activated";

                case 1:
                    return "Ready and activated";

                case 2:
                    return "Locked by provisioning manager";

                case 3:
                    return "Maintenance Mode";

                case 4:
                    return "Banned and not available";

                default:
                    throw new ArgumentOutOfRangeException("operation_state");
            }
        }

        /// <summary>
        /// Get provision_state description.
        /// </summary>
        /// <param name="provision_state">provision_state value.</param>
        /// <returns>State description.</returns>
        public static string GetProvisionStateDescription(int provision_state)
        {
            switch (provision_state)
            {
                case 0:
                    return "Request queued";

                case 1:
                    return "Provisioning in progress";

                case 2:
                    return "Provisioning complete";

                case 3:
                    return "Deprovisioning in progress";

                case 4:
                    return "Deprovisioning complete";

                case 10:
                    return "Error queuing request";

                case 12:
                    return "Provisioning Error";

                case 14:
                    return "Deprovisioning Error";

                default:
                    throw new ArgumentOutOfRangeException("provision_state");
            }
        }

        /// <summary>
        /// Get ready_state description.
        /// </summary>
        /// <param name="ready_state">ready_state value.</param>
        /// <returns>State description.</returns>
        public static string GetReadyStateDescription(int ready_state)
        {
            switch (ready_state)
            {
                case 0:
                    return "Platform Administrator Missing";

                case 1:
                    return "Default Platform Data Missing";

                case 2:
                    return "Install/Migrate Platform Database Schema";

                case 3:
                    return "Platform Ready";

                case 4:
                    return "Default Platform Schema Missing";

                case 5:
                    return "Platform Upgrade Required";

                case 6:
                    return "Welcome Page Required";

                case 7:
                    return "Platform Database Ready";

                default:
                    throw new ArgumentOutOfRangeException("ready_state");
            }
        }
    }
}
