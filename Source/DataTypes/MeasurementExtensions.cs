/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

namespace Dolittle.TimeSeries.DataTypes
{
    /// <summary>
    /// Extension methods for conversion between <see cref="Measurement"/> and <see cref="Measurement"/>
    /// </summary>
    public static class MeasurementExtensions
    {
        /// <summary>
        /// Convert supported primitive types of <see cref="Measurement"/> to <see cref="Measurement"/>
        /// </summary>
        /// <param name="measurement"><see cref="Measurement"/> to convert from</param>
        /// <returns>Converted <see cref="Runtime.Measurement"/></returns>
        public static Runtime.Measurement ToProtobuf(this Measurement measurement)
        {
            return new Runtime.Measurement
            {
                Value = measurement.Value
            };
        }

        /// <summary>
        /// Convert a protobuf <see cref="Runtime.Measurement"/> to a <see cref="Measurement"/> of supported primitive types
        /// </summary>
        /// <param name="measurement"><see cref="Runtime.Measurement"/> to convert from</param>
        /// <returns>Converted <see cref="Measurement"/></returns>
        public static Measurement ToMeasurement(this Runtime.Measurement measurement)
        {
            return new Measurement
            {
                Value = measurement.Value
            };
        }
    }
}