/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Booting;
using Dolittle.Clients;

namespace Dolittle.TimeSeries.DataPoints
{
    /// <summary>
    /// Represents the <see cref="ICanPerformBootProcedure">boot procedure</see> for dealing
    /// with data points
    /// </summary>
    public class BootProcedure : ICanPerformBootProcedure
    {
        readonly IDataPointsProcessors _processors;

        /// <summary>
        /// Initializes a new instance of <see cref="BootProcedure"/>
        /// </summary>
        /// <param name="processors"><see cref="IDataPointsProcessors"/> in the system</param>
        public BootProcedure(IDataPointsProcessors processors)
        {
            _processors = processors;
        }
        
        /// <inheritdoc/>
        public bool CanPerform() => Client.Connected;

        /// <inheritdoc/>
        public void Perform()
        {
            _processors.Register();
        }
    }
}