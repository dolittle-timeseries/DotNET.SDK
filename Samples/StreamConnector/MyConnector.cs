/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Linq;
using System.Threading.Tasks;
using Dolittle.Logging;
using Dolittle.TimeSeries;
using Dolittle.TimeSeries.Connectors;
using Dolittle.TimeSeries.DataPoints;
using Dolittle.TimeSeries.DataTypes;

namespace StreamConnector
{
    public class MyConnector : IAmAStreamingConnector
    {
        readonly ILogger _logger;
        readonly Random _random;

        public MyConnector(ILogger logger)
        {
            _logger = logger;
            _random = new Random();
        }

        public Source Name => "MyStreamConnector";

        public async Task Connect(IStreamWriter writer)
        {
            var tags = new [] {"first", "second", "third"};

            await Task.Run(async () =>
            {
                for (; ; )
                {
                    _logger.Information($"Streaming tags '{string.Join(", ", tags.Select(_ => _))}'");
                    var dataPoints = tags.Select(_ => new TagDataPoint(
                        (Tag)_,
                        //Value = (Measurement<float>)_random.NextDouble()
                        //Value = (Measurement<double>)_random.NextDouble()
                        //Value = new Vector2 { X = (float)_random.NextDouble(), Y = (float)_random.NextDouble() }
                        new Vector3 { X = (float)_random.NextDouble(), Y = (float)_random.NextDouble(), Z = (float)_random.NextDouble() }
                    ));
                    await writer.Write(dataPoints);

                    await Task.Delay(1000);
                }
            });
        }
    }
}