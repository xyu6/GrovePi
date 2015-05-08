﻿using System;

namespace GrovePi.Sensors
{
    public interface IRtcSensor
    {
        byte[] Read();
    }

    internal class RtcSensor : IRtcSensor
    {
        private const byte CommandAddress = 30;
        private readonly GrovePi _device;
        private readonly Pin _pin;

        internal RtcSensor(GrovePi device, Pin pin)
        {
            if (device == null) throw new ArgumentNullException(nameof(device));
            _device = device;
            _pin = pin;
        }

        public byte[] Read()
        {
            var buffer = new byte[] { CommandAddress, (byte)_pin, Constants.Unused, Constants.Unused };
            _device.DirectAccess.Write(buffer);
            _device.DirectAccess.Read(buffer);
            return buffer;
        }
    }
}