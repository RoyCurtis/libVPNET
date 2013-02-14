﻿using System;
using VP;
using VP.Native;

namespace VP
{
    public class Avatar
    {
        public string Name;
        public int Session;
        public int AvatarType;
        public float X, Y, Z;
        public float Yaw, Pitch;

        /// <summary>
        /// Checks if the avatar belongs to a bot instance, i.e. if the name is surrounded
        /// in square brackets
        /// </summary>
        public bool IsBot
        {
            get { return Name.StartsWith("[") && Name.EndsWith("]"); }
        }

        /// <summary>
        /// Gets or sets the coordinates of this avatar as a Vector3
        /// </summary>
        public Vector3 Coordinates
        {
            get { return new Vector3(X, Y, Z); }
            set { X = value.X; Y = value.Y; Z = value.Z; }
        }

        /// <summary>
        /// Gets or sets the position of this avatar as an AvatarPosition
        /// </summary>
        public AvatarPosition Position
        {
            get { return new AvatarPosition(Coordinates, Pitch, Yaw); }
            set { Coordinates = value.Coordinates; Pitch = value.Pitch; Yaw = value.Yaw; }
        }

        /// <summary>
        /// Creates an Avatar from a native instance's attributes
        /// </summary>
        internal Avatar (IntPtr pointer)
        {
            Name = Functions.vp_string(pointer, VPAttribute.AvatarName);
            Session = Functions.vp_int(pointer, VPAttribute.AvatarSession);
            AvatarType = Functions.vp_int(pointer, VPAttribute.AvatarType);
            X = Functions.vp_float(pointer, VPAttribute.AvatarX);
            Y = Functions.vp_float(pointer, VPAttribute.AvatarY);
            Z = Functions.vp_float(pointer, VPAttribute.AvatarZ);
            Yaw = Functions.vp_float(pointer, VPAttribute.AvatarYaw);
            Pitch = Functions.vp_float(pointer, VPAttribute.AvatarPitch);
        }
    }
}
