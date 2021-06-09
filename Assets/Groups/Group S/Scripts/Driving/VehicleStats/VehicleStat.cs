using System;
using UnityEngine;

namespace Groups.Group_S.Driving.VehicleStats
{
    /// <summary>
    /// Base Class from which all known vehicle stats inherit.
    /// </summary>
    [Serializable]
    public abstract class VehicleStat
    {
        /// <summary>
        /// Calculate resulting forces which should be applied to the vehicle.
        /// </summary>
        /// <param name="playerInput">Player input in which each axis can reach from -1 to 1.</param>
        /// <param name="lastSpeed">Movement which was performed by this vehicle during the last movement tick.</param>
        /// <returns>Resulting forces which this component applies to the vehicle</returns>
        internal virtual Vector3 CalcLinearForces(Vector2 playerInput, Vector3 lastSpeed)
        {
            return Vector3.zero;
        }

        /// <summary>
        /// Calculate resulting rotation which should be applied to the vehicle.
        /// </summary>
        /// <param name="playerInput">Player input in which each axis can reach from -1 to 1.</param>
        /// <returns>Rotation in degrees which should be applied to this vehicle</returns>
        internal virtual Vector3 CalcRotation(Vector2 playerInput)
        {
            return Vector3.zero;
        }

        /// <summary>
        /// Perform additional modifications on the final speed which will be applied to the vehicle.
        /// It is better to use one of the <i>CalcForces</i> methods since they provide better separation of concerns
        /// and their combinations can be reasoned about easier.
        /// </summary>
        /// <param name="speed">
        /// Speed value which will be applied to the vehicle as seen from the vehicles local coordinate system.
        /// </param>
        internal virtual void ModifySpeed(ref Vector3 speed)
        {
        }
    }
}