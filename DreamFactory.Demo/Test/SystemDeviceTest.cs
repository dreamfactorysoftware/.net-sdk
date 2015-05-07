namespace DreamFactory.Demo.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Remoting.Messaging;
    using System.Threading.Tasks;
    using DreamFactory.Api;
    using DreamFactory.Model.Database;
    using DreamFactory.Model.User;
    using DreamFactory.Rest;
    using DeviceResponse = DreamFactory.Model.System.Device.DeviceResponse;

    public static class SystemDeviceTest
    {
// ReSharper disable PossibleMultipleEnumeration
        public static async Task Run(IRestContext context)
        {
            ISystemApi systemApi = context.Factory.CreateSystemApi();
            
            IEnumerable<DeviceResponse> devices = await systemApi.GetDevicesAsync(new SqlQuery());
            await DeleteAnyDevices(devices, systemApi);

            IUserApi userApi = context.Factory.CreateUserApi();
            DeviceRequest device = new DeviceRequest
            {
                uuid = "1",
                model = "model",
                platform = "windows",
                version = "1.0"
            };

            bool ok = await userApi.SetDeviceAsync(device);
            Console.WriteLine("SetDeviceAsync(): success={0}", ok);

            SqlQuery query = new SqlQuery { filter = "platform=\"windows\"", fields = "*" };
            devices = await systemApi.GetDevicesAsync(new SqlQuery());
            Console.WriteLine("GetDevicesAsync(): {0}", context.ContentSerializer.Serialize(devices.Single()));

            await DeleteAnyDevices(devices, systemApi);
        }

        private static async Task DeleteAnyDevices(IEnumerable<DeviceResponse> devices, ISystemApi systemApi)
        {
            if (devices.Any())
            {
                int[] ids = devices.Select(x => x.id ?? 0).ToArray();
                await systemApi.DeleteDevicesAsync(ids);
                Console.WriteLine("DeleteDevicesAsync()");
            }
        }
    }
}
