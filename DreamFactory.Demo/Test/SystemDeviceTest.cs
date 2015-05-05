namespace DreamFactory.Demo.IntegrationTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using DreamFactory.Api;
    using DreamFactory.Model.Database;
    using DreamFactory.Model.User;
    using DreamFactory.Rest;
    using SystemDeviceResponse = DreamFactory.Model.System.Device.DeviceResponse;

    public static class SystemDeviceTest
    {
// ReSharper disable PossibleMultipleEnumeration
        public static async Task Run(IRestContext context)
        {
            ISystemApi systemApi = context.Factory.CreateSystemApi();
            
            IEnumerable<SystemDeviceResponse> devices = await systemApi.GetDevicesAsync();
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

            devices = await systemApi.GetDevicesAsync(new SqlQuery("platform=\"windows\""));
            Console.WriteLine("GetDevicesAsync(): {0}", context.ContentSerializer.Serialize(devices.Single()));

            await DeleteAnyDevices(devices, systemApi);
        }

        private static async Task DeleteAnyDevices(IEnumerable<SystemDeviceResponse> devices, ISystemApi systemApi)
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
