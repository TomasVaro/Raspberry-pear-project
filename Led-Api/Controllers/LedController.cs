using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Device.Gpio;
using System.Threading;
using System.Diagnostics;

namespace Led_Api.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class LedController : ControllerBase
    {
        // GET: /Led/blink
        [HttpGet("blink")]
        public async Task Blink()
        {

            int ledPin = 21;
            using (GpioController controller = new GpioController())
            {
                controller.OpenPin(ledPin, PinMode.Output);
                controller.Write(ledPin, PinValue.High);
                await Task.Delay(3000);
                controller.Write(ledPin, PinValue.Low);
                
            }



        }

        // GET: /Led/turboblinkblink
        [HttpGet("turboblink")]
        public async Task TurboBlink()
        {

            int ledPin = 21;
            using (GpioController controller = new GpioController())
            {
                controller.OpenPin(ledPin, PinMode.Output);
                controller.Write(ledPin, PinValue.High);
                await Task.Delay(1000);
                controller.Write(ledPin, PinValue.Low);
                await Task.Delay(1000);
                controller.Write(ledPin, PinValue.High);
                await Task.Delay(1000);
                controller.Write(ledPin, PinValue.Low);
                await Task.Delay(1000);
                controller.Write(ledPin, PinValue.High);
                await Task.Delay(1000);
                controller.Write(ledPin, PinValue.Low);
                await Task.Delay(1000);
                controller.Write(ledPin, PinValue.High);
                await Task.Delay(1000);
                controller.Write(ledPin, PinValue.Low);
                await Task.Delay(1000);
                controller.Write(ledPin, PinValue.High);
                await Task.Delay(1000);
                controller.Write(ledPin, PinValue.Low);

            }



        }

        // GET: /Led/on
        [HttpGet("on")]
        public void LedOn()
        {
            int ledPin = 21;
            GpioController controller = new GpioController();

            controller.OpenPin(ledPin, PinMode.Output);
            controller.Write(ledPin, PinValue.High);


        }

        // GET: api/off
        [HttpGet("off")]
        public void LedOff()
        {

            int ledPin = 21;
            GpioController controller = new GpioController();

            controller.OpenPin(ledPin, PinMode.Output);

            controller.Write(ledPin, PinValue.Low);




        }

        // GET: api/sensorOn
        [HttpGet("sensorOn")]
        public async Task<string> SensorOn()
        {
            const int triggerPin = 8;
            const int echoPin = 9;

            GpioController controller = new GpioController();

            controller.OpenPin(triggerPin, PinMode.Output);
            controller.OpenPin(echoPin, PinMode.Input);

            controller.Write(triggerPin, PinValue.High);
            await Task.Delay(new TimeSpan(100_000));
            controller.Write(triggerPin, PinValue.Low);

            PinValue pulseIn = PinValue.Low;
            Stopwatch sw = new Stopwatch();
            sw.Reset();
            sw.Start();
            while (pulseIn == PinValue.Low) { }
            sw.Stop();

            long distanceInCentimeter = (sw.ElapsedMilliseconds * 1000) / 58;

            return distanceInCentimeter.ToString();
        }

    }
}
