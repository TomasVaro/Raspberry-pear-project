﻿using System;
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
        public string LedOn()
        {
            int ledPin = 21;
            GpioController controller = new GpioController();

            controller.OpenPin(ledPin, PinMode.Output);
            controller.Write(ledPin, PinValue.High);

	        return "The LED is on!";
        }

        // GET: Led/off
        [HttpGet("off")]
        public string LedOff()
        {

            int ledPin = 21;
            GpioController controller = new GpioController();

            controller.OpenPin(ledPin, PinMode.Output);

            controller.Write(ledPin, PinValue.Low);

            return "The LED is off!";


        }

        // GET: Buzzer/on
        [HttpGet("buzzerOn")]
        public void BuzzerOn()
        {
            int buzzPin = 12;
            GpioController controller = new GpioController();

            controller.OpenPin(buzzPin, PinMode.Output);
            controller.Write(buzzPin, PinValue.High);


        }

        // GET: Buzzer/off
        [HttpGet("buzzerOff")]
        public void BuzzerOff()
        {

            int buzzPin = 12;
            GpioController controller = new GpioController();

            controller.OpenPin(buzzPin, PinMode.Output);

            controller.Write(buzzPin, PinValue.Low);




        }


        // GET: api/sensorOn
        [HttpGet("sensorOn")]
        public async Task<string> SensorOn()
        {
            const int triggerPin = 23;
            const int echoPin = 24;

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
            while (pulseIn == PinValue.Low)
                pulseIn = controller.Read(echoPin);
            sw.Stop();

            long distanceInMeter = sw.ElapsedMilliseconds / 5800;

            return distanceInMeter.ToString();
        }

    }
}
